using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Player
    {
        public List<Cell> PieceContainers { get; private set; } // רשימת התאים בלוח ששם נמצאים כל כליו
        public PieceColor PiecesColor { get; private set; } // צבע חיילי השחקן
        private GameManager GameManager { get; set; } // מנהל המשחק שלו
        private int FirstLine { get; set; } // השורה הראשונה של השחקן
        public TimeSpan PlayingTime { get; set; } // טיימר של כמה זמן שיחק
        public List<Piece> EatenPieces { get; private set; } // רשימת כלים שנאכלו

        // פעולה בונה של שחקן עפ"י צבע ומנהל המשחק שלו
        public Player(PieceColor color, GameManager gameManager)
        {
            this.PieceContainers = new List<Cell>(gameManager.Board.EnumerateCells().Where(x => !x.IsEmpty && x.Piece.Color == color)); // אתחול רשימת תאי כליו עפ"י הלוח
            this.PiecesColor = color; // אתחול צבע
            this.GameManager = gameManager; // אתחול מנהל משחקו
            this.EatenPieces = new List<Piece>(); // רשימת כלים נאכלים ריקה
            this.FirstLine = PiecesColor == PieceColor.White ? 7 : 0; // שימת השורה ראשונה בהתאם לצבעו
            this.PlayingTime = new TimeSpan(); // יצירת הטיימר
        }

        // יצירת שחקן עפ"י שחקן ומנהל משחק
        public Player(Player player, GameManager gameManager)
            : this(player.PiecesColor, gameManager)
        {
            this.PlayingTime = new TimeSpan(player.PlayingTime.Hours, player.PlayingTime.Minutes, player.PlayingTime.Seconds);
            this.EatenPieces = new List<Piece>(player.EatenPieces);
        }

        // פונקציה המסירה תא שיש בו כלי של השחקן
        private void RemovePieceContainer(Cell cell)
        {
            this.PieceContainers.Remove(cell);
        }

        // פונקציה הוסיפה תא שיש בו כלי של השחקן
        public void AddPieceContainer(Cell cell)
        {
            this.PieceContainers.Add(cell);
        }

        // פונקציה ש"אוכלת" לשחקן חייל מתא מסויים
        public void EatPiece(Cell cell)
        {
            this.EatenPieces.Add(cell.Piece); // הוספה לרשימת הכלים שנאכלו
            this.RemovePieceContainer(cell); // הסרהת התא של הכלי מרשימת תאי כלי השחקן
        }

        // פונקציה המחזירה את המהלכים האפשריים לכלי בתא מסויים , אם הפרדה כאשר זה כולל מהלכים מיוחדים וכאשר זה לא
        public List<Move> GetAvailableMoves(Cell cell, bool includeSpecialMoves)
        {
            var moves = new List<Move>(); // אתחול רשימת מהלכים
            var piece = cell.Piece; // הכלי שנבדק
            var pawn = piece as Pawn; // הפיכתו לסוג רגלי

            // בדיקת כל הכיוונים האפשריים לכלי זה
            foreach (var direction in piece.AvailableDirections)
            {
                var currCell = GameManager.GetNextCell(cell, direction); // התא הנוכחי בריצה על הכיוון הזה הוא התא הבא בכיוון
                MoveType moveType = MoveType.RegularMove; // בינתיים סוג המהלך הוא מהלך רגיל

                // בדיקת כל המהלכים האפריים בכיוון הנוכחי
                while (!(currCell.IsOutOfBounds || !currCell.IsEmpty && currCell.Piece.Color == this.PiecesColor)) // כל עוד התא נמצא בגבולות והוא ריק ולא בצבע של הכלי הראשון
                {
                    if (pawn == null) // אם הכלי הוא לא חייל
                    {
                        moves.Add(new Move(currCell, moveType)); // הוספת מהלך רגיל
                    }
                    else if (pawn.CanMove(direction, currCell.IsEmpty)) // אם חייל ויכול לזוז לכיוון הנ"ל
                    {
                        // בודקת אם החייל הגיע לסוף הלוח.
                        if (currCell.I == GetRowRealIndex(7))
                        {
                            moveType = MoveType.Promotion; // סוג המהלך הוא הכתרה
                        }

                        moves.Add(new Move(currCell, moveType)); // הוספת המהלך

                        // בודקת אם זה מהלך של 2 צעדים ראשונים לחייל.
                        if (includeSpecialMoves && !pawn.HasMoved && direction == pawn.AvailableDirections[1])
                        {
                            currCell = GameManager.GetNextCell(currCell, direction); // התא שיוסף למהלך הוא הבא בכיוון כלומר 2 צעדים
                            if (currCell.IsEmpty) // אם התא הנ"ל ריק
                            {
                                moveType = MoveType.TwoStepsForPawn;
                                moves.Add(new Move(currCell, moveType)); // הוספת המהלך של 2 צעדים ראשונים לחייל
                            }
                        }
                    }

                    if (!currCell.IsEmpty || piece.CanMoveOnlyOneStep) // אם התא לא ריק או שהכלי הנבחר יכול לזוז רק צעד אחד הסריקה בכיוון הנ"ל תיגמר
                    {
                        break;
                    }

                    // שימת התא הבא באותו כיוון
                    currCell = GameManager.GetNextCell(currCell, direction);
                }
            }

              if (includeSpecialMoves) // אם הפונקציה צריכה להוסיף גם מהלכים מיוחדים
            {
                if (pawn != null) // אם הכלי שנבחר הוא חייל
                {
                    moves.AddRange(EnPassant(cell)); // הוספת רשימת מהלכי הכאה דרך הילוכו
                }
                else if (piece is King) // אם מלך
                {
                    moves.AddRange(CastlingMoves((King)piece)); // הוספת רשימת מהלכי הצרחה
                }
            }

            return moves; // החזרת רשימת המהלכים
        }

        // מחזירה רשימה של מהלכי הכאה דרך הילוכו שאפשריים
        private List<Move> EnPassant(Cell cell)
        {
            List<Move> moves = new List<Move>(); // אתחול
            if(checkEnPassantOneDirection(cell,new Direction(DirectionType.Right))) // בדיקה בעבור צד ימין והוספה אם יש
                moves.Add(new Move(GameManager.GetNextCell(cell,cell.Piece.AvailableDirections[2]), MoveType.EnPassant));
            else if (checkEnPassantOneDirection(cell, new Direction(DirectionType.Left)))  // בדיקה בעבור צד שמאל והוספה אם יש
                moves.Add(new Move(GameManager.GetNextCell(cell,cell.Piece.AvailableDirections[0]), MoveType.EnPassant));
            return moves;
        }

        // בדיקת המהלך הכאה דרך הילוכו בעבור צד שמתקבל
        private bool checkEnPassantOneDirection(Cell cell,Direction direction)
        {
            Cell nextCell = GameManager.GetNextCell(cell, direction); // מי החייל שייאכל בצד שנתקבל
            if (!cell.IsOutOfBounds && !nextCell.IsEmpty) // האם התא שנתקבל לא מחוץ לגבול , והתא ליד מכיל חייל
            {
                var threatenPawn = nextCell.Piece as Pawn; // הרגלי המאוים
                if (threatenPawn != null && threatenPawn.IsEnPasant) // אם הוא באמת רגלי ואפשר לעשות עליו את המהלך הכאה דרך הילוכו
                {
                    return true; // תחזרי אמת
                }
            }
            return false; // אחרת תחזיר שקר
        }

        // מחזירה רשימה של מהלכי הצרחה שאפשריים
        private List<Move> CastlingMoves(King king)
        {
            List<Move> moves = new List<Move>(); // אתחול
            if (!king.HasMoved && !GameManager.IsCurrentPlayerUnderCheck) // אם המלך לא זז , והשחקן לא תחת שח
            {
                if (CheckCastlingWithOneRook(0)) // אם הצריח בעמודה הראשונה ואפשר הצרחה
                    moves.Add(new Move(GameManager.Board[this.FirstLine, 2], MoveType.Castling)); 
                if (CheckCastlingWithOneRook(7)) // אם הצריח בעמודה האחרונה ואפשר הצרחה
                    moves.Add(new Move(GameManager.Board[this.FirstLine, 6], MoveType.Castling));
            }

            return moves; // החזרת הרשימה

        }

        // בדיקת הצרחה אם צריח אחד בקבלת אינדקס עמודה של הצריח
        public bool CheckCastlingWithOneRook(int rookJ)
        {
            const int kingJ = 4; // אינקס העמודה של המלך במצב הצרחה הוא 4
            var KingCell = GameManager.Board[this.FirstLine, kingJ]; // מציאת המלך
            var Rook = GameManager.Board[this.FirstLine, rookJ].Piece as Rook; // מציאת הצריח

            if (Rook == null || Rook.HasMoved) // אם החייל לא צריח או שהוא כן אבל הצריח זז
            {
                return false; // אין הצרחה
            }

            var compartion = rookJ.CompareTo(kingJ); // מחזירה 1 או -1 , וזה עוזר לחשב את היחסיות שבין המלך והצריח
            for (int j = kingJ + compartion; j != rookJ; j += compartion) // בדיקת כל התאים מהתא שליד המלך עד הצריח האם הם ריקים
            {
                if (!GameManager.Board[this.FirstLine, j].IsEmpty)
                {
                    return false;
                }
            }

            // בודקת תא אחד לימין או לשמאל , לפי העמודה של הצריח , אם הוא מאויים
            if (GameManager.IsCellThreaten(GameManager.Board[this.FirstLine, kingJ + compartion], this))
            {
                return false;
            }

            return true; // ישנה ההצרחה
        }

        // פונקציה המחזירה את האינדקס האמיתי עפ"י שורה שניתנת וזה באופן יחסי לשחקן
        public int GetRowRealIndex(int index)
        {
            return Math.Abs(this.FirstLine - index);
        }

        // פונקציה המחזירה האם השחקן מאיים על תא מסויים
        public bool IsThreatning(Cell target)
        {
            foreach (var cell in this.PieceContainers) // בעבור כל תאי הכלים של השחקן
            {
                if (this.GetAvailableMoves(cell, false).Select(x => x.cell).Contains(target)) // אם בתוך אחד מן המהלכים האפשריים נמצא התא משמע שהוא מאויים על ידי השחקן
                {
                    return true; // לכן יוחזר אמת
                }
            }

            return false; // אחרת שקר
        }

        // איפוס המהלך הכאה דרך הילוכו כלומר שכל החיילים מסוג רגלי לא ניתן יהיה לבצע עליהם את המהלך
        public void ResetEnPassant()
        {
            foreach (var cell in PieceContainers) // בעבור כל תאי הכלים של השחקן
            {
                var Pawn = cell.Piece as Pawn;
                if (Pawn != null) // האם הוא חייל
                {
                    Pawn.IsEnPasant = false; // איפוס
                }
            }
        }

        // ההזזה הממשית של חייל מתא אחד לשני
        public void MovePiece(Cell cellFrom, Cell cellTo)
        {
            cellTo.Piece = cellFrom.Piece; // החייל הועבר
            cellFrom.Piece = null; // הסרתו מהקודם
            this.RemovePieceContainer(cellFrom); // הסרה מהרשימה
            this.AddPieceContainer(cellTo); // הוספה לרשימה
            
        }

        // מציאת התא שמכיל את המלך
        public Cell GetKingLocation()
        {
            return this.PieceContainers.First(x => x.Piece is King);
        }
    }

    public enum MoveType // סוג מהלך
    {
        RegularMove,
        EnPassant,
        Castling,
        Promotion,
        TwoStepsForPawn
    }
}
