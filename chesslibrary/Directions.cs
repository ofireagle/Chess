using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Direction
    {
        public int I { get; set; } // אינדקס שורה
        public int J { get; set; } // אינדקס עמודה
        public DirectionType DirectionType { get; set; } // סוג הכיוון

        // אתחול כיוון ע"י אינדקס
        public Direction(int i, int j)
        {
            this.I = i;
            this.J = j;
        }

        // נותן חעשות פעולת + על שני כיוונים ומחזירה את הכיוון המחובר של שניהם
        public static Direction operator+(Direction dir1, Direction dir2)
        {
            return new Direction(dir1.I + dir2.I, dir1.J + dir2.J);
        }

        // בונה כיוון ע"י סוגו
        public Direction(DirectionType directionType)
        {
            var direction = Directions.GetDirectionByName(directionType); // מסיג את הכיוון ע"פי שמו

            this.I = direction.I; // אתחול אינדקס וסוג כיוון
            this.J = direction.J;
            DirectionType = directionType;
        }
    }
    
    public enum DirectionType // סוג כיוון
    {
        Up = 0,
        Down = 1,
        Right = 2,
        Left = 3,
        UpRight = 4,
        UpLeft=5,
        DownRight=6,
        DownLeft=7
    }

    public static class Directions // מחלקת כיוונים מחלקה סטאטית
    {
        public static Direction[] DirectionsArray { get; private set; } // מערך סטאטי של כיוונים

        static Directions() // שימת הכיוונים במערך הסטאטי
        {
            DirectionsArray = new Direction[]{new Direction(-1,0),
                                              new Direction(1,0),
                                              new Direction(0,1),
                                              new Direction(0,-1),
                                              new Direction(-1,1),
                                              new Direction(-1,-1),
                                              new Direction(1,1),
                                              new Direction(1,-1)};
        }

        // הפונקציה מחזירה כיוון מתוך מערך הכיוונים לפי סוג הכיוון
        public static Direction GetDirectionByName(DirectionType directionType) 
        {
            return (DirectionsArray[((int)Enum.Parse(typeof(DirectionType), directionType.ToString()))]);
        }
    }
}
