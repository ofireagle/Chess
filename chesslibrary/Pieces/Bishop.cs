using Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class Bishop : Piece  // יורש מחייל
    {
        public Bishop(PieceColor pieceColor)
            : base(pieceColor)
        {
            this.CanMoveOnlyOneStep = false;
            // אתחול הכיוונים האפשריים לו
            this.AvailableDirections = new List<Direction>() { new Direction(DirectionType.DownLeft), new Direction(DirectionType.DownRight), new Direction(DirectionType.UpLeft), new Direction(DirectionType.UpRight) };
        }

        public Bishop(Bishop piece)
            : base(piece)
        {
        }
    }
}
