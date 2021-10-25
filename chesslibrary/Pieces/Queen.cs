using Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class Queen : Piece // יורשת מחייל
    {
        public Queen(PieceColor pieceColor)
            : base(pieceColor)
        {
            this.CanMoveOnlyOneStep = false;
            // אתחול הכיוונים האפשריים לה
            this.AvailableDirections = new List<Direction>(Directions.DirectionsArray);
        }

        public Queen(Queen piece)
            : base(piece)
        {
        }
    }
}
