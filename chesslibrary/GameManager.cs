using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public delegate void WrongMove(string errorMessage);
    public delegate void GameEnded(Player winner);
    public delegate void PieceWasEaten(Piece piece);
    public delegate Piece Promotion(Cell cell);

    public class GameManager
    {
        public event WrongMove WrongMove; // מאורע של עניין לא חוקי כגון לא תורך וכדומה
        public event GameEnded GameEnded; // מאורע של סיום משחק
        public event PieceWasEaten PieceWasEaten; // מאורע של חייל שנאכל בשביל תמונות כלים שנאכלו
        public event Promotion Promotion; // מאורע של הכתרה
        public Dictionary<PieceColor, Player> Players { get; set; }      // בנ"ל נמצאים שני שחקני המשחק שניתן לגשת אליהם דרך הצבע של חייליהם
        public Board Board { get; private set; } // לוח המשחק

        public Player CurrentPlayer { get; private set; } // השחקן הנוכחי
        public Cell Source { get; private set; } // תא המקור כלומר התא שנלחץ ורוצים לזוז עם הכלי שעליו
        public List<Move> AvailableMoves { get; private set; } // רשימת מהלכים אפשריים לתא המקור
        private bool? _IsCurrentPlayerUnderCheck;  // האם השחקן הנוכחי תחת שח או אמת או שקר או null 
        // וזה כדי שאם נבדק פעם אחת לא ייבדק שוב כמבואר לעיל :
        public bool IsCurrentPlayerUnderCheck
        {
            get
            {
                if (!_IsCurrentPlayerUnderCheck.HasValue) // אם אין ערך כלומר פעם ראשונה שזה נבדק
                {
                    this._IsCurrentPlayerUnderCheck = this.IsPlayerUnderCheck(CurrentPlayer); // שמים את תוצאת הבדיקה
                }

                return this._IsCurrentPlayerUnderCheck.Value; // מחזירים את תוצאת הבדיקה
            }
        }

        // פעולה בונה של מנהל משחק חדש
        public GameManager()
        {
            Board = new Board(); // יצירת לוח חדש
            this._IsCurrentPlayerUnderCheck = null; // לא נבדק
            this.Source = null;
            this.Players = new Dictionary<PieceColor, Player>(); 
            this.Players.Add(PieceColor.White, new Player(PieceColor.White, this)); // הוספת השחקנים
            this.Players.Add(PieceColor.Black, new Player(PieceColor.Black, this));
            this.CurrentPlayer = Players[PieceColor.White]; // השחקן המתחיל הוא הלבן
            this.AvailableMoves = new List<Move>(); // אתחול רשימת המהלכים
        }

        // פעולה בונה של מנהל משחק חדש שמעתיקה ממנהל משחק קיים
        public GameManager(GameManager gameManager)
        {
            this.Board = new Board(gameManager.Board); // העתקת הלוח
            this.AvailableMoves = new List<Move>(); // אתחול רשימת מהלכים
            this.Source = null; // המקור נהיה null

            this._IsCurrentPlayerUnderCheck = null; 

            this.Players = new Dictionary<PieceColor, Player>();
            this.Players.Add(PieceColor.White, new Player(gameManager.Players[PieceColor.White],this)); // הוספת השחקנים
            this.Players.Add(PieceColor.Black, new Player(gameManager.Players[PieceColor.Black],this));
            this.CurrentPlayer = this.Players[gameManager.CurrentPlayer.PiecesColor]; // השחקן הנוכחי בהתאם למשחק האחר
        }

        // פונציה של בחירת תא ומחזירה האם התור הסתיים או שזה רק בחירת הכלי
        public bool SelectCell(Cell selectedCell)
        {
            bool turnEnded = false;
            string errorMessage = null;

            // כלי כבר נבחר , ועכשיו השחקן בוחר תא אליו רוצה ללכת , אבל התא צריך להיות ללא כלי עם אותו צבע של כלי השחקן ,כי אז נרצה שיסמן כבר את בחירתו החדשה.
            if (this.Source != null && (this.Source.Piece == selectedCell.Piece || selectedCell.IsEmpty || selectedCell.Piece.Color != this.CurrentPlayer.PiecesColor))
            {
                var move = AvailableMoves.FirstOrDefault(x => x.cell == selectedCell); // אם המהלך נמצא ברשימת המהלכים האפשריים אז ישים במשתנה את המהלך , אם לא יושם null

                // בודקת אם התא שנבחר אפשרי בשביל המהלך
                if (move != null)
                {
                    this.Move(this, move, Source); // עשיית המהלך כמבואר בפונקציה
                    this.SwitchPlayer(); // החלפת התורות (השחקנים)
                    turnEnded = true; // התור אכן הסתיים
                    this.NewTurn(); // אתחול של תור חדש
                }
                // בודקת האם הבעייה היא בגלל שחמט שיקרה אם יוזז לכיוון הנ"ל
                else if (this.CurrentPlayer.GetAvailableMoves(Source, true).Exists(x => x.cell == selectedCell))
                {
                    errorMessage = "Mooving that piece in that direction will get your king eaten...";
                }
                
                this.Source = null; // אתחול המקור
                this.AvailableMoves = new List<Move>(); // אתחול רשימת המהלכים
            }
            // לא נבחר עדיין כלי - זוהי הבחירה , או שהשחקן בחר כעת כלי אחר מכליו
            else if (!selectedCell.IsEmpty)
            {
                if (selectedCell.Piece.Color != this.CurrentPlayer.PiecesColor) // האם הוא בחר כלי שלא בצבע שלו
                {
                    errorMessage = string.Format("Hey, {0} player! it's your turn!", Enum.GetName(this.CurrentPlayer.PiecesColor.GetType(), this.CurrentPlayer.PiecesColor)); // הודעת שגיאה בעבורו שלא בחר כלי בצבע שלו
                }
                else // בחר כראוי
                {
                    var pieceMoves = this.CurrentPlayer.GetAvailableMoves(selectedCell, true); // רשימת מהלכים אפשריים של הכלי שנבחר כולל מהלכים מיוחדים
                    this.AvailableMoves = pieceMoves.Where(x => this.TryMove(x, selectedCell)).ToList(); // סינון מהלכים שייצרו אם יקרו שחמט

                    // אם יש לו מהלך ללכת עם הכלי
                    if (this.AvailableMoves.Count != 0)
                    {
                        Source = selectedCell; // המקור נהיה התא שנבחר
                    }
                    // אם אין לו מהלכים אבל זה בגלל התחשבויות בשח
                    else if (pieceMoves.Count > 0)
                    {
                        errorMessage = "Mooving that piece will get your king eaten..."; // הודעת שגיאה של הזזת הכלי תגרום לשחמט
                    } 
                }
            }

            if (errorMessage != null && this.WrongMove != null) // אם הייתה הודעת שגיאה ונרשמו לאירוע
            {
                this.WrongMove(errorMessage); // הפעלת האירוע והפונקציות שנרשמו אליו של הודעת שגיאה
            }

            return turnEnded; // החזרת האם התור הסתיים
        }

        // פונקציה שמתחילה תור חדש מכל הבחינות
        private void NewTurn()
        {
            this._IsCurrentPlayerUnderCheck = null; // לא נבדק בעבור תור זה האם יש שח
            this.CurrentPlayer.ResetEnPassant(); // איפוס המהלך הכאה דרך הילוכו כלומר מי שניתן היה לעשות עליו את המהלך כבר לא ניתן כי התחיל תור חדש

            // בודקת האם המשחק הסתיים.
            if (!this.CanPlayerMove(this.CurrentPlayer)) // האם השחקן הנוכחי לא יכול לזוז
            {
                if (this.GameEnded != null) // האם נרשמו לאירוע של סיום משחק
                {
                    Player winner = this.IsCurrentPlayerUnderCheck ? this.GetOtherPlayer(this.CurrentPlayer) : null; // אם הוא גם תחת שח יש מנצח , אם לא יש תיקו
                    this.GameEnded(winner); // הקפצת האירוע
                }
            }
        }

        // פונקצייה של החלפת השחקנים
        private void SwitchPlayer()
        {
            this.CurrentPlayer = this.GetOtherPlayer(this.CurrentPlayer); // השחקן הנוכחי הופך להיות השחקן האחר מבין השניים
        }

        // מחזירה האם תא מאויים על ידי השחקן השני
        public bool IsCellThreaten(Cell cell, Player player)
        {
            return this.GetOtherPlayer(player).IsThreatning(cell); // מחזירה האם השחקן השני מאיים על התא הנ"ל
        }

        // מחזירה האם שחקן תחת שח
        private bool IsPlayerUnderCheck(Player player)
        {
            Cell KingLocation = player.GetKingLocation(); // מציאת מיקום המלך של השחקן
            return this.IsCellThreaten(KingLocation, player); // בדיקה האם התא שעליו המלך יושב מאויים כלומר שח
        }

        // האם שחקן יכול לזוז
        public bool CanPlayerMove(Player player)
        {
            var cells = new List<Cell>(player.PieceContainers); // רשימת תאים של כל הכלים של השחקן
            foreach (var cell in cells) // בעבור כל כלי
            {
                if (this.GetMovesWithChessConsideration(cell).Count != 0) // אם אחד מהכלים יכול לזוז 
                {
                    return true; // יוחזר אמת
                }
            }
            return false; // אף אחד לא יכול לזוז יוחזר שקר כלומר השחקן לא יכול לזוז
        }

        // מחזירה את התא הבא בכיוון שנתקבל מהתא שנתקבל
        public Cell GetNextCell(Cell cell, Direction direction)
        {
            return this.Board[cell.I + direction.I, cell.J + direction.J]; // החזרת התא המתבקש על פי הכיוון
        }

        // החזרת השחקן האחר מהשחקן שמתקבל
        private Player GetOtherPlayer(Player Player)
        {
            return Player.PiecesColor == PieceColor.White ? this.Players[PieceColor.Black] : Players[PieceColor.White]; // עפ"י צבע השחקן מוחזר השחקן האחר מהמילון
        }

        // החזרת המהלכים של השחקן של הכלי שנתקבל בתא שנתקבל עם התחשבויות במהלכים בלתי חוקיים בגלל שחמט
        private List<Move> GetMovesWithChessConsideration(Cell source)
        {
            var player = this.Players[source.Piece.Color]; // השחקן של הכלי שנתקבל
            return player.GetAvailableMoves(source, true).Where(x => this.TryMove(x, source)).ToList(); // מחזיר את המהלכים האפשריים מבחינת שחמט
        }

        // פונקציה של הזזת כלי ממקור לתא נבחר תוך אכילת התא בהתאם למהלך
        private void Move(GameManager gameManager, Move move, Cell source)
        {
            Cell eatenCell; // התא שייאכל
            var currPlayer = gameManager.Players[source.Piece.Color]; // השחקן הנוכחי בפונקציה הנ"ל

            switch (move.type) // בהתאם לסוג המהלך
            {
                case MoveType.RegularMove: // במהלך רגיל התא שהולך אליו החייל הוא זה שנאכל
                    eatenCell = move.cell;
                    break;
                case MoveType.EnPassant: // במהלך הכאה דרך הילוכו התא שנאכל הוא בשורה החמישית בהתאם לשחקן אבל באותה עמודה של היכן שהוא הולך
                    eatenCell = gameManager.Board[currPlayer.GetRowRealIndex(4), move.cell.J];
                    break;
                case MoveType.Castling: // בהצרחה התא שנאכל הוא רגיל אבל יש צורך להזזת הצריח אחד לידש המלך בהתאם להשוואה
                    eatenCell = move.cell;                    
                    var comparsion = eatenCell.J.CompareTo(4); // אם אינדקס העמודה גדול מ4 ההשוואה נותנת 1 אחרת נותנת -1
                    var firstRow = currPlayer.GetRowRealIndex(0); // שורה הראשונה של השחקן
                    var rookCell = gameManager.Board[firstRow, comparsion < 0 ? 0 : 7]; // מציאת התא של הצריח
                    currPlayer.MovePiece(rookCell, gameManager.Board[firstRow, comparsion + 4]); // בהתאם להשוואה
                    break;
                case MoveType.Promotion: // במהלך ההכתרה התא שנאכל רגיל
                    eatenCell = move.cell;
                    if (gameManager.Promotion != null) // אם נרשמו לאירוע ההכתרה
                    {
                        source.Piece = gameManager.Promotion.Invoke(source); // הקפצת האירוע אבל הפעם עד שלא תיגמר הפונקציה של ההכתרה הפונקצייה הנ"ל לא תמשיך
                    }
                    break;
                case MoveType.TwoStepsForPawn: // כשזה מהלך 2 צעדים לחייל המהלך הוא נורמלי
                    eatenCell = move.cell;
                    ((Pawn)source.Piece).IsEnPasant = true; // כעת ניתן לעשות על החייל שמוזז את המהלך הכאה דרך הילוכו עד התור שאחרי
                    break;
                default:
                    eatenCell = null;
                    break;
            }
            // הסרת החייל שנאכל.
            if (eatenCell.Piece != null) // אם קיים
            {
                gameManager.GetOtherPlayer(currPlayer).EatPiece(eatenCell); // לשחקן האחר נאכל החייל ובהתאם מעדכן את רשימותיו 

                
                if (gameManager.PieceWasEaten != null) // אם נרשמו לאירוע של חייל שנאכל
                {
                    gameManager.PieceWasEaten(eatenCell.Piece); // יוקפץ האירוע
                }

                eatenCell.Piece = null; // הסרת החייל בעצם מהתא שנאכל
            }

            var ispecialfirstmove = source.Piece as ISpecialFirstMovePiece; // סימת החייל כחייל שאפשר לעשות מהלך ראשון מיוחד
            if (ispecialfirstmove != null) // אם זה באמת כזה חייל כלומר או רגלי או צריח או מלך
            {
                ispecialfirstmove.HasMoved = true; // כלומר כעת החייל הנ"ל זז ולא יוכל לעשות יותר את המהלכים המיוחדים של צעד ראשון
            }

            currPlayer.MovePiece(source, move.cell); // הזזת החייל עצמו.
        }

        // פונקציה שמנסה מהלך ומחזירה האם הוא חוקי מבחינת התיחסות לשחמט
        public bool TryMove(Move move, Cell source)
        {
            var testManager = new GameManager(this); // יצירת עותק של מנהל משחק
            var newMove = new Move(testManager.Board[move.cell], move.type); // עותק של המהלך
            var newSource = testManager.Board[source]; // עותק של המקור
            this.Move(testManager, newMove, newSource); // הזזה בעותק של המהלך שנתבקש

            // בודקת אם , אחרי שהמהלך נעשה , השחקן ייאבד את המלך שלו - שזה לא חוקי
            return !testManager.IsPlayerUnderCheck(testManager.Players[newMove.cell.Piece.Color]);
        }

    }
}
