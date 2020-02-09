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
        protected Color textColor;

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


        /*********************************************************************
         * 
         *********************************************************************/
        public bool ValidSpot(int row, int col)
        {
            if (row >= 0 && row < 8 && col >= 0 && col < 8)
            {
                return true;
            }
            return false;
        }

        public void CheckIfPossible(int newRow, int newCol, Space[,] board)
        {
            if (ValidSpot(newRow, newCol))
            {
                if ((board[newRow, newCol].GetPiece() != null
                    && board[newRow, newCol].GetPiece().GetTeam() != team)
                    || board[newRow, newCol].GetPiece() == null)
                {
                    SetSpaceValid(newRow, newCol);
                }
            }
        }

        public bool IsOtherTeam(Piece p)
        {
            if (p != null)
            {
                if (p.GetTeam() != this.team)
                {
                    return true;
                }
            }
            return false;
        }

        public void StraightPaths(Space[,] board, int distance)
        {
            int newRow = row;
            int newCol = col - 1;
            int count = 0;
            while ((ValidSpot(newRow, newCol) && (board[newRow, newCol].GetPiece() == null
                || IsOtherTeam(board[newRow, newCol].GetPiece())) && count < distance))
            {
                CheckIfPossible(newRow, newCol, board);
                if (IsOtherTeam(board[newRow, newCol].GetPiece()))
                    break;
                newCol--;
                count++;

            }

            newCol = col + 1;
            count = 0;
            while ((ValidSpot(newRow, newCol) && (board[newRow, newCol].GetPiece() == null
                || IsOtherTeam(board[newRow, newCol].GetPiece())) && count < distance))
            {
                CheckIfPossible(newRow, newCol, board);
                if (IsOtherTeam(board[newRow, newCol].GetPiece()))
                    break;
                newCol++;
                count++;

            }

            newRow = row + 1;
            newCol = col;
            count = 0;
            while ((ValidSpot(newRow, newCol) && (board[newRow, newCol].GetPiece() == null
                || IsOtherTeam(board[newRow, newCol].GetPiece())) && count < distance))
            {
                CheckIfPossible(newRow, newCol, board);
                if (IsOtherTeam(board[newRow, newCol].GetPiece()))
                    break;
                newRow++;
                count++;
            }


            newRow = row - 1;
            newCol = col;
            count = 0;
            while ((ValidSpot(newRow, newCol) && (board[newRow, newCol].GetPiece() == null
                || IsOtherTeam(board[newRow, newCol].GetPiece())) && count < distance))
            {
                CheckIfPossible(newRow, newCol, board);
                if (IsOtherTeam(board[newRow, newCol].GetPiece()))
                    break;
                newRow--;
                count++;
            }
        }

        public void DiagonalPaths(Space[,] board, int distance)
        {
            int newRow = row + 1;
            int newCol = col + 1;
            int count = 0;

            while ((ValidSpot(newRow, newCol) && (board[newRow, newCol].GetPiece() == null
                || IsOtherTeam(board[newRow, newCol].GetPiece())) && count < distance))
            {
                CheckIfPossible(newRow, newCol, board);
                if (IsOtherTeam(board[newRow, newCol].GetPiece()))
                    break;
                newRow++;
                newCol++;
                count++;
            }

            newRow = row - 1;
            newCol = col + 1;
            count = 0;
            while ((ValidSpot(newRow, newCol) && (board[newRow, newCol].GetPiece() == null
                || IsOtherTeam(board[newRow, newCol].GetPiece())) && count < distance))
            {
                CheckIfPossible(newRow, newCol, board);
                if (IsOtherTeam(board[newRow, newCol].GetPiece()))
                    break;
                newRow--;
                newCol++;
                count++;
            }

            newRow = row - 1;
            newCol = col - 1;
            count = 0;
            while ((ValidSpot(newRow, newCol) && (board[newRow, newCol].GetPiece() == null
                || IsOtherTeam(board[newRow, newCol].GetPiece())) && count < distance))
            {
                CheckIfPossible(newRow, newCol, board);
                if (IsOtherTeam(board[newRow, newCol].GetPiece()))
                    break;
                newRow--;
                newCol--;
                count++;
            }

            newRow = row + 1;
            newCol = col - 1;
            count = 0;
            while ((ValidSpot(newRow, newCol) && (board[newRow, newCol].GetPiece() == null
                || IsOtherTeam(board[newRow, newCol].GetPiece())) && count < distance))
            {
                CheckIfPossible(newRow, newCol, board);
                if (IsOtherTeam(board[newRow, newCol].GetPiece()))
                    break;
                newRow++;
                newCol--;
                count++;
            }

        }

        public Color GetTextColor() { return textColor; }
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
