using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chess.Pieces;
using System.Runtime.Serialization;

namespace Chess
{
    public class Board // מייצג לוח משחק
    {
        private const int BOARD_SIZE = 8; //   גודל הלוח האמיתי
        private const int SPARE_FRAME = 2; // גודל מסגרת לכל כיוון
        private const int TOTAL_SIZE = BOARD_SIZE + (SPARE_FRAME * 2); // גודל הלוח בסה"כ

        private Cell[,] board; // מטריצת הלוח

        public Cell this[int i, int j] // indexer
        {
            get
            {
                return board[i+2, j+2]; // נועד לפיתרון הגבולות
            }
            set
            {
                board[i+2, j+2] = value;
            }
        }

        public Cell this[Cell cell] // indexer
        {
            get
            {
                return this[cell.I, cell.J];
            }
            set
            {
                this[cell.I, cell.J] = value;
            }
        }

        // פעולה בונה של לוח חדש
        public Board()
        {
            this.board = new Cell[TOTAL_SIZE, TOTAL_SIZE]; // איתחול
            for (int i = 0; i < TOTAL_SIZE; i++)
            {
                for (int j = 0; j < TOTAL_SIZE; j++)
                {
                    this.board[i, j] = new Cell(null, i - 2, j - 2); // בניית התא ע"פי האינדקסר
                }
            }
            // Pawns
            for (int j = 0; j < 8; j++)
            {
                this[1, j].Piece = new Pawn(PieceColor.Black);
                this[6, j].Piece = new Pawn(PieceColor.White);
            }
            // Rooks
            this[0, 0].Piece =(new Rook(PieceColor.Black));
            this[0, 7].Piece =(new Rook(PieceColor.Black));
            this[7, 0].Piece =(new Rook(PieceColor.White));
            this[7, 7].Piece =(new Rook(PieceColor.White));
            // Knights
            this[0, 1].Piece =(new Knight(PieceColor.Black));
            this[0, 6].Piece =(new Knight(PieceColor.Black));
            this[7, 1].Piece =(new Knight(PieceColor.White));
            this[7, 6].Piece =(new Knight(PieceColor.White));
            // Bishops                             );
            this[0, 2].Piece =(new Bishop(PieceColor.Black));
            this[0, 5].Piece =(new Bishop(PieceColor.Black));
            this[7, 2].Piece =(new Bishop(PieceColor.White));
            this[7, 5].Piece =(new Bishop(PieceColor.White));
            // Kings
            this[0, 4].Piece =(new King(PieceColor.Black)); 
            this[7, 4].Piece =(new King(PieceColor.White)); 
            // Queens
            this[0, 3].Piece =(new Queen(PieceColor.Black));
            this[7, 3].Piece =(new Queen(PieceColor.White));
        }

        // בניית לוח עפ"י לוח קיים
        public Board(Board board)
        {
            this.board = new Cell[TOTAL_SIZE, TOTAL_SIZE];
            for (int i = 0; i < TOTAL_SIZE; i++)
            {
                for (int j = 0; j < TOTAL_SIZE; j++)
                {
                    this.board[i, j] = new Cell(board.board[i, j]);
                }
            }
        }

        // החזרת התאים של הלוח אבל אחד אחד
        public IEnumerable<Cell> EnumerateCells()
        {
            var cellsList = new List<Cell>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    yield return (this[i, j]); 
                }
            }
        }
    }
}
