using Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class Knight : Piece // יורש מחייל
    {
        public Knight(PieceColor pieceColor)
            : base(pieceColor)
        {
            this.CanMoveOnlyOneStep = true;
            // אתחול הכיוונים האפשריים לו
            this.AvailableDirections = new List<Direction>() { Directions.GetDirectionByName(DirectionType.Up) + Directions.GetDirectionByName(DirectionType.UpRight) ,
                                                               Directions.GetDirectionByName(DirectionType.Up) + Directions.GetDirectionByName(DirectionType.UpLeft),
                                                               Directions.GetDirectionByName(DirectionType.Down) + Directions.GetDirectionByName(DirectionType.DownRight),
                                                               Directions.GetDirectionByName(DirectionType.Down) + Directions.GetDirectionByName(DirectionType.DownLeft),
                                                               Directions.GetDirectionByName(DirectionType.Right) + Directions.GetDirectionByName(DirectionType.UpRight) ,
                                                               Directions.GetDirectionByName(DirectionType.Right) + Directions.GetDirectionByName(DirectionType.DownRight),
                                                               Directions.GetDirectionByName(DirectionType.Left) + Directions.GetDirectionByName(DirectionType.UpLeft),
                                                               Directions.GetDirectionByName(DirectionType.Left) + Directions.GetDirectionByName(DirectionType.DownLeft)};
        }

        public Knight(Knight piece)
            : base(piece)
        {
        }
    }
}
