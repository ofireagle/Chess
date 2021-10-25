using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Game : Form
    {
        private GraphicBoard _graphicBoard;
        public GraphicBoard GraphicBoard // מי שפנה ראשון מאתחלו (האופציה השנייה הייתה לאתחלו באתחול משחק חדש
        {
            get
            {
                if (this._graphicBoard == null)
                {
                    this._graphicBoard = new GraphicBoard(this); // הלוח הגראפי משתמש בלוח האמיתי , לכן רק מתי שמתחיל משחק אמיתי אפשר לאתחל את הלוח ולתת לו את המשחק כאשר יש כבר משחק פועל 
                    // לכן בפעם הראשונה יהיה האתחול
                }

                return this._graphicBoard;
            }
        }
        public List<GameManager> History { get; set; }
        private GameManager GameManager { get; set; }
        public Board Board { get { return this.GameManager.Board; } }
        private ToolStripStatusLabel lblCurrentTimeElapsed;
        private ToolStripStatusLabel lblCurrentError;
        public int CurrentMove { get; private set; }

        /* בנאי ברירת מחדל- מאתחל את תכונות המחלקה המייצגת את המשחק – מסך המשחק , המשחק ותכונותיו .ביניהם :
         History – רשימה של GameManager בשביל הundo/redo .
        GameManager – מנהל המשחק.
         המשחק פתוח על 
         panelOpenning */
        public Game()
        {
            InitializeComponent();
            this.pnlPausePanel.BringToFront(); 
            this.panelOpeningGame.BringToFront();
            this.ShowOpenningScreen(); // מסך פתיחת משחק

        }

        /* פונקציה שכאשר תא גרפי נלחץ בלוח , מסמנת את הבחירה ע"י ה GameManager .
          כאשר התור לא נגמר (כלומר רק סימון ) => מסמנת את התאים שאליו יכול להגיע   .
כאשר התור נגמר => מתאימה את הלוח הגרפי ללוח המשחק , מעדכנת את הסטטוס ליבלים , מוסיפה את המשחק להיסטוריית המשחקים , ומוסיפה אפשרות של  undo. */

        public void GraphicCellWasPressed(Cell cell)
        {
            bool turnEnded = this.GameManager.SelectCell(this.Board[cell]); // האם תור הסתיים => שליחה ללוגיקה ע"פי בחירת התא
            if (!turnEnded) // האם התור לא הסתיים כלומר לחיצה ראשונה
            {
                this.GraphicBoard.UnmarkMarkedCells(); // ביטול הסימון של מה שהיה
                this.GraphicBoard.MarkSelectedCells(this.GameManager.AvailableMoves.Select(x => x.cell).ToList()); // סימון התאים שחוקיים בעבור המהלך הנוכחי
            }
            else // התור הסתיים כלומר לחיצה שנייה
            {
                this.MatchGraphicBoardToGameBoard(); // התאמה בין הלוח הגרפי ללוח האמיתי
                this.UpdateStatusLabels(); // עדכון הסטטוס ברים           
                this.AddGameToHistory(); // הוספת המשחק להיסטוריה
                this.undoToolStripMenuItem.Enabled = true;
            }
        }

        // מעדכנת את הסטאטוס ברים מבחינת זמן והודעת שגיאה בהתאם לשחקן הנוכחי
        private void UpdateStatusLabels() 
        {
            if (this.GameManager.CurrentPlayer.PiecesColor == PieceColor.White) // אם השחקן הנוכחי הוא הלבן
            {
                this.lblCurrentTimeElapsed = this.lblTimeWhite; // הזמן ש"ירוץ" הוא של הלבן
                this.lblCurrentError = this.lblErrorWhite; 
            }
            else // אם השחקן הנוכחי הוא השחור
            {
                this.lblCurrentTimeElapsed = this.lblTimeBlack; // הזמן ש"ירוץ" הוא של השחור
                this.lblCurrentError = this.lblErrorBlack;
            }
        }

        // יציאה מהמשחק
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // להראות מסך החוקים
        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Pause(); // השהיית המשחק
            var Rules = new Rules();
            Rules.ShowDialog();
            this.Start();
        }

        // להראות את מסך פתיחת משחק על מנת להתחיל משחק חדש
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowOpenningScreen(); 
        }

        /* הפונקציה בעצם מעדכנת ליצירת משחק חדש:
מאתחלת למנהל משחק חדש, רושמת לאירועים , מאפסת את הסטטוס ברים , מתאימה בין הלוח הגראפי ללוח האמיתי , ומתחילה משחק .
         */
        private void SetNewGame()
        {
            this.GameManager = new GameManager(); // אתחול מנהל משחק חדש

            this.AssignGameToManagerEvents(); // הרשמה של המשחק לאירועי מנהל המשחק
            
            this.CurrentMove = -1; // המהלך הנוכחי -1
            History = new List<GameManager>(); // אתחול רשימת ההיסטוריה
            this.AddGameToHistory(); // הוספת המשחק להיסטוריה
            this.undoToolStripMenuItem.Enabled = false; // ביטול אפשרות undo

            this.ResetStatusBars(); // איפוס הסטטוס ברים

            this.MatchGraphicBoardToGameBoard(); // התאמת הלוח הגרפי ללוח האמיתי
            this.Start(); // התחלת המשחק
            
        }

        // הפונקציה קופצת ע"י אירוע כאשר הגיע מצב של "הכתרה" והיא בעצם מציגה את מסך ההכתרה במיקום המתאים לה , ואחרי כן מחזירה את הכלי הרצוי .
        Piece GameManager_Promotion(Cell cell)
        {
            var menu = new PromotionMenu(cell.Piece.Color) { StartPosition = FormStartPosition.Manual}; // יצירת טופס ההכתרה
            var cellLocation = this.GraphicBoard[cell].Location; // מציאת מיקום התא הגרפי
            menu.Location = new Point(cellLocation.X + this.GraphicBoard.Location.X, cellLocation.Y + this.GraphicBoard.Location.Y); // בהתאם המיקום של מסך ההכתרה
            menu.ShowDialog(); // מסך ההכתרה מוראה

            return menu.ChosenPiece; // הכלי שנבחר מוחזר
        }


        private void AddGameToHistory()
        {
            var newManager = new GameManager(this.GameManager); // יצירת עותק של מנהל המשחק כדי לשמור על מצב המשחק
            this.CurrentMove++;

            // במקרה שהמהלך נעשה אחרי undo
            //אז הפעולה מוחקת את שאר המהלכים מההיסטוריה 
            History.RemoveRange(this.CurrentMove, this.History.Count - this.CurrentMove);
            // הוספת עותק המשחק לרשימת ההיסטוריה
            this.History.Add(newManager);
            this.redoToolStripMenuItem.Enabled = false; // ביטול אפשרות undo
        }

        // הפונקציה קופצת מאירוע סיום משחק
        // הפונקציה מציגה מסך של ניצחון (/ תיקו ) ונותנת אפשרות או להמשיך לראות את המשחק שהיה , או להתחיל משחק חדש .
        private void gameManager_GameEnded(Player winner)
        {
            this.tmrTime.Stop(); // הפסקת השעון
            string winnerName = winner == null ? "Nobody. It's a tie." : Enum.GetName(winner.PiecesColor.GetType(), winner.PiecesColor) + " player!"; // שם המנצח או שיש תיקו
            this.BeginInvoke(new Action(() => MatchGraphicBoardToGameBoard())); // נועד כדי שזה יקרה לפני שקופצץ ההודעה לעיל

            if (MessageBox.Show("The winner is:\n" + winnerName + "\n\nWould you like to play another game?", "Game ended", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes) // האם רוצה להתחיל משחק חדש או לצפות במשחק הישן עם אפשרות לחזור למהלכים קודמים
            {
                this.SetNewGame(); // אם רוצה חדש - איפוס למשחק חדש
            }
        }

        // הפונקציה קופצת ע"י אירוע כאשר ישנו מהלך לא תקין / שגוי – ולכן הפונקציה מציגה הודעת שגיאה באחד הסטטוס ברים בהתאם לשחקן בתור הנוכחי.
        private void gameManager_WrongCheckConsideratinMove(string errorMessage)
        {
            this.WriteAnError(errorMessage); // כותבת את הודעת השגיאה
        }
        //  המאורע גורם למשחק "לחזור" (/"לבטל") תור אחד אחורה .
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadGameAtMove(this.CurrentMove - 1); // טעינת המשחק של התור הקודם
            this.redoToolStripMenuItem.Enabled = true; // אפשור ה redo
            if (this.CurrentMove == 0) // אם זה התור הראשון
            {
                this.undoToolStripMenuItem.Enabled = false; // אין אפשרות לעשות undo לאחר מכן
            }
        }

        // טוענת משחק לפי האינדקס שלו ברשימת היסטורית המשחקים . (ומאפסת ומאתחלת סטטוס ברים , מתאימה את הלוח הגרפי'
        private void LoadGameAtMove(int i)
        {
            this.GameManager = new GameManager(History[i]); // יצירת עותק של משחק באינדקס שנתקבל ברשימת היסטוריית המשחקים - נועד לשמירה על מצב המשחק אם ירצה לחזור על התהליך
            this.AssignGameToManagerEvents(); // הרשמה של המשחק לאירועים של מנהל המשחק החדש
            this.CurrentMove = i; // המהלך הנוכחי הופך להיות האינדקס שמתקבל
            this.ResetStatusBars(); // איפוס הסטטוס ברים
            this.MatchGraphicBoardToGameBoard(); // התאמת הלוח הגרפי ללוח האמיתי
        }

        // המאורע גורם למשחק "להתקדם" (/"לחזור") תור אחד קדימה .
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadGameAtMove(CurrentMove + 1); // טעינת המשחק בתור הבא
            this.undoToolStripMenuItem.Enabled = true; // אפשור undo
            if (this.CurrentMove == History.Count - 1) // אם לאחר ה redo זהו התור האחרון שעשה
            {
                this.redoToolStripMenuItem.Enabled = false; // ביטול אפשרות redo
            }
        }
        // "טיק" כלומר מספר שניות במקרה הנ"ל , בטיימר של הודעת שגיאה. – מעיף את הודעת השגיאה ועוצר את ה .
        private void tmrError_Tick(object sender, EventArgs e)
        {
            this.lblErrorBlack.Text = "";
            this.lblErrorWhite.Text = "";
            this.tmrError.Stop();
        }
        // הפונקציה כותבת על הסטטוס הבר שנצרך את הודעת השגיאה בהתאם.
        private void WriteAnError(string error)
        {
            this.lblCurrentError.Text = error; // הודעת השגיאה מוצגת
            this.tmrError.Stop();
            this.tmrError.Start();
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            var currPlayerTime = this.GameManager.CurrentPlayer.PlayingTime; // הזמן שהחקן הנוכחי שיחק

            this.GameManager.CurrentPlayer.PlayingTime = new TimeSpan(currPlayerTime.Hours, currPlayerTime.Minutes, currPlayerTime.Seconds + 1); // הוספה של שנייה בכל טיק
            this.lblCurrentTimeElapsed.Text = this.GameManager.CurrentPlayer.PlayingTime.ToString(); // הצגה של הזמן בלייבל המתאים
        }
        // פונקציה המתאימה את תווית התור לשחקן המתאים , ומעדכנת את הלוח הגראפי בהתאם ללוח האמיתי , וגם מסמנת מצב של שח אם דרוש.
        private void MatchGraphicBoardToGameBoard()
        {
            this.GraphicBoard.RefreshBoard(); // עדכון הלוח הגראפי
            turn_label.Text = "Turn of " + (GameManager.CurrentPlayer.PiecesColor == PieceColor.White ? "WHITE" : "BLACK"); // עדכון תווית התור

                
            if (this.GameManager.IsCurrentPlayerUnderCheck) // אם השחקן הנוכחי תחת שח
            {
                this.GraphicBoard.MarkCellAsThreaten(this.GameManager.CurrentPlayer.GetKingLocation()); // סימון מלכו כמאויים שח
            }
        }

        // פונקציה המאפסת את כל המאפיינים של שני הסטטוס ברים ( טיימרים , תמונות של כלים שנאכלו.
        private void ResetStatusBars()
        {
            this.WhiteStatus.Items.Clear(); 
            this.BlackStatus.Items.Clear(); // ניקוי שני הסטטוס ברים
            this.lblErrorBlack.Text = "";
            this.lblErrorWhite.Text = ""; // איפוס הודעות השגיאה
            this.WhiteStatus.Items.AddRange(new ToolStripItem[] { new ToolStripLabel("White:"), this.lblTimeWhite, this.lblErrorWhite }); 
            this.BlackStatus.Items.AddRange(new ToolStripItem[] { new ToolStripLabel("Black:"), this.lblTimeBlack, this.lblErrorBlack }); // הוספת כל הלייבלים
            this.GameManager.Players[PieceColor.White].EatenPieces.ForEach(piece => this.WhiteStatus.Items.Add(null, Pictures.Pieces_Pictures.GetPicture(Enum.GetName(piece.Color.GetType(), piece.Color) + piece.GetType().Name)));
            this.GameManager.Players[PieceColor.Black].EatenPieces.ForEach(piece => this.BlackStatus.Items.Add(null, Pictures.Pieces_Pictures.GetPicture(Enum.GetName(piece.Color.GetType(), piece.Color) + piece.GetType().Name))); // הוספת התמונות של כל הכלים שנאכלו בהתאם לרשימת הכלים שנאכלו
            this.lblTimeWhite.Text = this.GameManager.Players[PieceColor.White].PlayingTime.ToString();
            this.lblTimeBlack.Text = this.GameManager.Players[PieceColor.Black].PlayingTime.ToString(); // הדפסת תוויות הזמן בהתאם לזמן השחקנים
            this.UpdateStatusLabels(); // עדכון הסטטוס לייבלים
        }

        // הירשמות לכלל האירועים
        public void AssignGameToManagerEvents() 
        {
            this.GameManager.WrongMove += gameManager_WrongCheckConsideratinMove; // הירשמות לאירוע של מהלך לא חוקי
            this.GameManager.GameEnded += gameManager_GameEnded; // הירשמות לאירוע של סיום משחק
            this.GameManager.Promotion += GameManager_Promotion; // הירשמות לאירוע  של הכתרה
            this.GameManager.PieceWasEaten += GameManager_PieceWasEaten; // הירשמות לאירוע של חייל נאכל
        }

        // הפונקציה קופצת ע"י אירוע כאשר כלי נאכל– ולכן הפונקציה מוסיפה תמונה של הכלי שנאכל לסטטוס בר המתאים.
        void GameManager_PieceWasEaten(Piece piece) 
        {
            var currentStatusBar = piece.Color == PieceColor.White ? this.WhiteStatus : this.BlackStatus; // מציאת הסטטוס בר הנוכחי
            currentStatusBar.Items.Add(null, Pictures.Pieces_Pictures.GetPicture(Enum.GetName(piece.Color.GetType(), piece.Color) + piece.GetType().Name));  // הוספת התמונה של חייל שנאכל          
        }

        // הפונקציה עוצרת את הזמן , ומציגה את הפאנל של ההשהיה : הפאנל מסתיר את המשחק בכדי למנוע מחשבה.
        private void Pause()
        {
            if (!panelOpeningGame.Visible)
            {
                this.tmrTime.Stop();
                this.pnlPausePanel.Visible = true;
            }
        }
        // הפונקציה ממשיכה את הזמן (כשיש משחק) , ומסתירה את פאנל ההשהיה .
        private void Start()
        {
            this.pnlPausePanel.Visible = false;

            if (this.GameManager != null)
            {
                this.tmrTime.Start(); 
            }
        }

        // לחיצה על הודעת ההשהייה בתוך מסך ההשהייה
        private void label2_Click(object sender, EventArgs e)
        {
            this.Start();
        }
        // מאורע לחיצה על אפשרות ההשהייה מפעיל את ההשהייה כמבואר לעיל
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Pause();
        }
        // מאורע לחיצה שכאשר לוחצים על הכפתור הנ"ל מתחיל משחק . (הכפתור נמצא בפאנל התחלת משחק).
        private void buttonOpening_Click(object sender, EventArgs e)
        {
            this.panelOpeningGame.Visible = false; // מראה את פאנל התחלת משחק
            this.SetNewGame(); // מתחיל משחק חדש
            this.newGameToolStripMenuItem.Enabled = true; // אפשור הופעת מסך תחילת משחק שנית 
        }
        // פונקציה המציגה את מסך פתיחת משחק.
        private void ShowOpenningScreen()
        {
            this.panelOpeningGame.Visible = true; // מראה את מסך תחילת משחק
            this.newGameToolStripMenuItem.Enabled = false; // אי אפשר ללחוץ על להראות את מסך תחילת משחק
        }
        // מאורע לחיצה שכאשר לוחצים על הכפתור הנ"ל מוצג מסך החוקים . (הכפתור נמצא בפאנל התחלת משחק).
        private void buttonRules_Click(object sender, EventArgs e)
        {
            var Rules = new Rules(); 
            Rules.ShowDialog(); // מראה את מסך החוקים עד שיוצאים ממנו
        }
        // המאורע גורם להקפצת הודעה על היסטוריית השחמט.
        private void developmentAndHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Pause();
            MessageBox.Show(@"כנראה מוצאו של משחק השחמט בהודו. שם הוא ידוע יותר מאלפיים שנה. ממשחק שחמט הודי הסתעפו משחקים רבים ושונים לרחבי אסיה.  פירוש שמו של המשחק בפרסית הינו שח=מלך, מט=מת, כלומר מלך מת.
דרך פרס משחק השחמט ההודי חדר לאירופה והתפשט שם בתוך המדינות והיה חביב ביותר על אנשי האצולה ועל כן כונה: משחק המלכים. עד המאה ה-19 שיחקו בו רק בני האצולה והעשירים, וכלי השחמט היו יקרים ומפוארים. חוקי וכללי המשחק כל הזמן השתנו ונעשו יותר רלוונטיים. השינוי האחרון המהותי התרחש בערך לפני ארבע מאות שנה באיטליה. נדרש זמן יחסית ממושך עד שחוקים חדשים של המשחק התקבלו באופן קבוע. נכון להיום משחק השחמט האירופאי התפשט באופן רחב בכל העולם.","היסטוריית השחמט",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1,MessageBoxOptions.RtlReading|MessageBoxOptions.RightAlign);
        }
        // המאורע גורם להקפצת מסך אודות המשחק.
        private void aboutTheGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Pause(); // השהיית המשחק
            this.pnlPausePanel.BringToFront(); 
            var AboutTheGame = new AboutTheGame();
            AboutTheGame.ShowDialog(); // מראה את מסך אודות המשחק עד לסגירתו
        }

    }
}
