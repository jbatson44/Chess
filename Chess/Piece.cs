using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    /*********************************************************************
    * Piece Class
    * Contains the basic logic that all chess pieces need
    *********************************************************************/
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

        public bool CanKillKing(Space[,] board)
        {
            for (int i = 0; i < GetPossMoves().Count; i++)
            {
                int row = GetPossMoves()[i].row;
                int col = GetPossMoves()[i].col;
                if (ValidSpot(row, col) && board[row, col].GetPiece().GetPieceType() == "King")
                {
                    return true;
                }
            }
            return false;
        }

        /*********************************************************************
        * IsPossible
        * Parameters
        *  row - the row of the spot being checked
        *  col - the column of the spot being checked
        * Check if this location is a spot our piece can move to
        *********************************************************************/
        public bool IsPossible(int row, int col)
        {
            for (int i = 0; i < GetPossMoves().Count; i++)
            {
                if (row == GetPossMoves()[i].row &&
                    col == GetPossMoves()[i].col)
                {
                    return true;
                }
            }
            return false;

        }

        /*********************************************************************
        * SetSpaceValid
        * Parameters
        *   row - the row of the space being checked
        *   col - the column of the space being checked
        * Check to see if the space is on the board and if it is add it to
        * the list of possible moves (possMoves)
        *********************************************************************/
        public void SetSpaceValid(int row, int col)
        {
            if (row < 8 && row >= 0 && col < 8 && col >= 0)
            {
                possMoves.Add(new Pair(row, col));
            }
        }

        /*********************************************************************
        * 
        *********************************************************************/
        public void MovePiece(int newRow, int newCol, Space[,] board)
        {
            
        }


        /*********************************************************************
        * ValidSpot
        * Parameters
        *   row - the row of the space being checked
        *   col - the column of the space being checked
        * Check to see if the space is on the board
        *********************************************************************/
        public bool ValidSpot(int row, int col)
        {
            if (row >= 0 && row < 8 && col >= 0 && col < 8)
            {
                return true;
            }
            return false;
        }

        /*********************************************************************
        * CheckIfPossible
        * Parameters
        *   newRow - the row the piece could be moved to
        *   newCol - the column the piece could be moved to
        *   board - the board of spaces
        * Checks to see if the space is on the board. Then checks to see if
        * the space is empty or if its occupied by an enemy piece. If either
        * is true then we add it to the possible values
        *********************************************************************/
        public void CheckIfPossible(int newRow, int newCol, Space[,] board)
        {
            if (ValidSpot(newRow, newCol))
            {
                if (IsOtherTeam(board[newRow, newCol].GetPiece())
                    || board[newRow, newCol].GetPiece() == null)
                {
                    SetSpaceValid(newRow, newCol);
                }
            }
        }

        /*********************************************************************
        * IsOtherTeam
        * Parameters
        *   piece - the piece we are checking
        * Check to see if the piece is an enemy piece or not
        *********************************************************************/
        public bool IsOtherTeam(Piece piece)
        {
            if (piece != null)
            {
                if (piece.GetTeam() != this.team)
                {
                    return true;
                }
            }
            return false;
        }

        /*********************************************************************
        * StraightPaths
        * Parameters
        *   board - the board of spaces
        *   distance - the max distance the piece can move
        * Calculate the possible spaces the piece could move on the x and y
        * axes.
        *********************************************************************/
        public void StraightPaths(Space[,] board, int distance)
        {
            // first we check the possible spaces to the left
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

            // check the possible spaces to the right
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

            // check the possible spaces up
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

            // check the possible spaces down
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

        /*********************************************************************
        * DiagonalPaths
        * Parameters
        *   board - the board of spaces
        *   distance - the max distance the piece can move
        * We check the possible spaces the piece could move to on the spaces
        * diagonal to its current location up to the max distance it can move.
        *********************************************************************/
        public void DiagonalPaths(Space[,] board, int distance)
        {
            // check the possible spaces on the up-right diagonal
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

            // check the possible spaces on the down-right diagonal
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

            // check the possible spaces on the down-left diagonal
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

            // check the possible spaces on the up-left diagonal
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
