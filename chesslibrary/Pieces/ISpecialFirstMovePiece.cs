using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public interface ISpecialFirstMovePiece // interface of special first move pieces => saves 3 checks , more efficient 
    {
        bool HasMoved { get; set; } // האם זז
    }
}
