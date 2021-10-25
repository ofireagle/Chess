using Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class King : Piece, ISpecialFirstMovePiece  // יורש מחייל
    {
        
        public bool HasMoved { get; set; } // האם זז
        /// <summary>
        /// בנאי של מלך עפ"י צבעו
        /// </summary>
        /// <param name="pieceColor"></param>
        public King(PieceColor pieceColor)
            : base(pieceColor)
        {
            this.CanMoveOnlyOneStep = true;
            // אתחול הכיוונים האפשריים לו
            this.AvailableDirections = new List<Direction>(Directions.DirectionsArray);
        }

        /// <summary>
        /// בונה מעתיקה מלך אחר.
        /// </summary>
        /// <param name="piece"></param>
        public King(King piece)
            : base(piece)
        {
            this.HasMoved = piece.HasMoved;
        }
    }
}
