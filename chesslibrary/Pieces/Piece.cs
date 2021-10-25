using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public abstract class Piece // מחלקה אבסטרקטית של חייל
    {        
        public PieceColor Color { get; protected set; } // צבע החייל
        
        public List<Direction> AvailableDirections { get; protected set; } // כיוונים אפשריים
        public bool CanMoveOnlyOneStep { get; protected set; } // האם יכול לזוז רק צעד אחד

        // בנאי בעבור חייל (לא ניתן למימוש על המחלקה עצמה)
        public Piece(PieceColor pieceColor)
        {
            this.Color = pieceColor;
        }

        public Piece(Piece piece)
        {
            this.Color = piece.Color;
            this.AvailableDirections = piece.AvailableDirections;
            this.CanMoveOnlyOneStep = piece.CanMoveOnlyOneStep;
        }
 
    }

    public enum PieceColor // צבע חייל
    {
        White,
        Black
    }
}
