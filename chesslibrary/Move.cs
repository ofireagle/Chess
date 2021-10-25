using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Move // מייצג מהלך במשחק
    {
        public Cell cell { get; set; } // תא שאליו ניתן להגיע במהלך הנ"ל
        public MoveType type { get; set; } // סוג המהלך

        public Move(Cell cell , MoveType type)
        {
            this.cell = cell;
            this.type = type;
        }
    }
}
