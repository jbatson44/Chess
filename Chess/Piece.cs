using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    abstract class Piece
    {
        public Piece()
        {

        }
        protected List<Pair> possMoves;
        protected String team;
        protected int row;
        protected int col;
        protected Image image;
        protected String pieceType;
        public abstract void CalcPossMoves(Space [,] board);

        public void SetSpaceValid(int row, int col)
        {
            if (row < 8 && row >= 0 && col < 8 && col >= 0)
            {
                possMoves.Add(new Pair(row, col));
            }
        }

        public void MovePiece(int newRow, int newCol, Space[,] board)
        {
            
        }

        public Image GetImage() { return image; }
        public String GetPieceType() { return pieceType; }
        public int GetRow() { return row; }
        public void SetRow(int row) { this.row = row; }
        public int GetColumn() { return col; }
        public void SetCol(int col) { this.col = col; }
        public String GetTeam() { return team; }
        public List<Pair> GetPossMoves() { return possMoves; }
    }
}
