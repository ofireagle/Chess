using Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    

    public class Rook : Piece, ISpecialFirstMovePiece  // יורש מחייל 
    {
        
        public bool HasMoved { get; set; } // האם זז

        public Rook(PieceColor pieceColor) 
            : base(pieceColor)
        {
            this.CanMoveOnlyOneStep = false;
            this.AvailableDirections = new List<Direction>() { new Direction(DirectionType.Down), new Direction(DirectionType.Right), new Direction(DirectionType.Up), new Direction(DirectionType.Left) };
        }

        public Rook(Rook piece)
            : base(piece)
        {
            this.HasMoved = piece.HasMoved;
        }
    }
}
