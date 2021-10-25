using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    

    public class Cell // משבצת
    {
        
        public Piece Piece { get; set; } // חייל שנמצא על התא
        
        public int I { get; private set; } // אינקס של שורה
        
        public int J { get; private set; } // אינדקס של עמודה
        
        public bool IsOutOfBounds { get { return I > 7 || I < 0 || J > 7 || J < 0; } } // האם התא מחוץ לגבולות הלוח
        
        public bool IsEmpty { get { return this.Piece == null; } } // האם התא ריק

        // בונה תא מחייל ואינדקס
        public Cell(Piece piece, int i, int j)
        {
            Piece newPiece = null;
            if (piece != null)
            {
                Type pieceType = piece.GetType(); // מציאת סוג החייל
                var constructor = pieceType.GetConstructor(new Type[] { pieceType }); // שימה בפעולה הבונה לפי סוג החייל
                newPiece = constructor.Invoke(new object[] {piece}) as Piece; // הפעלת הפעולה הבונה בעבור סוגו והחזרת החייל
            }

            this.Piece = newPiece;
            this.I = i;
            this.J = j;
        }

        // בניית תא מתא קיים
        public Cell(Cell cell):this(cell.Piece, cell.I, cell.J){}
    }
}
