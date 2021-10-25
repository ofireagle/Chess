using Chess;
using Chess.Pieces;
using Pictures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public class GraphicBoard : Panel
    {
        public Game Game { get; private set; }
        private GraphicCell[,] GBoard = new GraphicCell[8, 8];
        
        public GraphicBoard(Game game) : this(game, new Size(400, 400), new Point(100, 100)) { }

        // בונה לוח גרפי ממשחק קיים
        public GraphicBoard(Game game, Size size, Point point)
        {
            this.Game = game; // המשחק נקבע

            this.Size = size; // הגודל נקבע

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var gCell = new GraphicCell(new Cell(null,i, j)); // יצירת תא גרפי
                    gCell.GraphicCellWasPressed += gCell_GraphicCellWasPressed; // הרשמה של הפונקציה הנ"ל למאורע
                    this[i, j] = gCell; //  הוספת התא ללוח
                    this.Controls.Add(gCell); // הוספת התא לתצוגה
                }
            }

            this.Game.Controls.Add(this); // הוספת הלוח כולו לטופס המשחק
            this.Location = point; // המיקום של הלוח נקבע עפ"י נקודה מתקבלת

        }

        //פונקציה המסמנת תאים לפי הפרמטר(מקבלת רשימת תאים אמיתיים => מסמנת את התאים הגרפיים)
        public void MarkSelectedCells(List<Cell> cells)
        {
            cells.ForEach(cell => this[cell].SetColorAsMarked()); // מסמנת את כל התאים שקיבלה
        }

        //פונקציה המבטלת את סימון התאים.
        public void UnmarkMarkedCells()
        {
            foreach (var item in this.GBoard) // עבור כל תא גרפי בלוח הגרפי
            {
                item.UnmarkIfMarked(); // מבטל סימון אם מסומן
            }
        }

        public void RefreshBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    this[i, j].SetColorAsStandard(); // מעדכנת את כל התאים לצבע סטנדרטי
                    var piece = this.Game.Board[i, j].Piece; // שמה את החייל שתא הנ"ל בתוך משתנה
                    this[i, j].Image = piece == null ? null : Pieces_Pictures.GetPicture(Enum.GetName(piece.Color.GetType(), piece.Color) + piece.GetType().Name); // מעדכנת את תמונת התא הגרפי להיות עם חייל כאשר ישנו
                }
            }
        }

        // פונקציה שמופעלת מאירוע הלחיצה תא גרפי , מופעלת הפונקציה במחלקת המשחק – מחלקת Game .
        void gCell_GraphicCellWasPressed(Cell cell)
        {
            Game.GraphicCellWasPressed(cell); // מפעילה את הפונקציה במחלקת המשחק
        }

        public GraphicCell this[int i, int j] // אינדקסר 
        {
            get
            {
                return (this.GBoard[i, j]); 
            }
            set
            {
                this.GBoard[i, j] = value;
            }
        }

        public GraphicCell this[Cell cell] // indexer
        {
            get
            {
                return this[cell.I, cell.J];
            }
            set
            {
                this[cell.I, cell.J] = value;
            }
        }

        // הפונקציה מעדכנת את צבע התא הגרפי המתקבל להיות צבע של "תחת איום" / "שח".
        public void MarkCellAsThreaten(Cell cell)
        {
            this[cell].SetColorAsUnderCheck(); // סימון כשח
        }
    }
}
