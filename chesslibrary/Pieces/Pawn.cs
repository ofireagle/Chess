using Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{ 
    public class Pawn : Piece ,ISpecialFirstMovePiece // יורש מחייל
    {
        
        public bool IsEnPasant { get; set; } // בדיקה האם ניתן לעשות עליו את המהלך הכאה דרך הילוכו
        
        public Func<Direction, bool, bool> CanMove { get; private set; } // מטרת השימוש בנ"ל , היא מבחינה לוגית שזהו ממש מאפיין בסיסי של החייל ולא כבדיקה
        
        public bool HasMoved { get; set; }

        public Pawn(PieceColor pieceColor)
            : base(pieceColor)
        {
            this.CanMoveOnlyOneStep = true;

            // אתחול הכיוונים האפשריים לו ע"פי צבעו
            if (pieceColor == PieceColor.White)
            {
                this.AvailableDirections = new List<Direction>() { new Direction(DirectionType.UpLeft), new Direction(DirectionType.Up), new Direction(DirectionType.UpRight)};
            }
            else
            {
                this.AvailableDirections = new List<Direction>() { new Direction(DirectionType.DownLeft), new Direction(DirectionType.Down), new Direction(DirectionType.DownRight) };
            }

            this.CanMove = new Func<Direction, bool, bool>((x, isEmpty) => { return (isEmpty && (x.DirectionType == this.AvailableDirections[1].DirectionType)) || (!isEmpty && x.DirectionType != this.AvailableDirections[1].DirectionType); }); // אתחול מאפיין הפונקציה של האם יכול לזוז
        }

        public Pawn(Pawn piece):base(piece)
        {
            this.IsEnPasant = piece.IsEnPasant;
            this.HasMoved = piece.HasMoved;
            this.CanMove = piece.CanMove;
        }
    }
}
