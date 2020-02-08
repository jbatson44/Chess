using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Knight : Piece
    {
        /*********************************************************************
         * 
         *********************************************************************/
        public Knight(String team)
        {
            this.team = team;
            possMoves = new List<Pair>();
            pieceType = "Knight";
            image = null;

            if (team == "white")
            {
                textColor = Color.White;
            }
            else
            {
                textColor = Color.Black;
            }
        }

        /*********************************************************************
         * 
         *********************************************************************/
        override public void CalcPossMoves(Space[,] board)
        {
            int newRow = row + 1;
            int newCol = col + 2;
            CheckIfPossible(newRow, newCol, board);
            newRow = row - 1;
            CheckIfPossible(newRow, newCol, board);
            newCol = col - 2;
            CheckIfPossible(newRow, newCol, board);
            newRow = row + 1;
            CheckIfPossible(newRow, newCol, board);
            newRow = row + 2;
            newCol = col + 1;
            CheckIfPossible(newRow, newCol, board);
            newCol = col - 1;
            CheckIfPossible(newRow, newCol, board);
            newRow = row - 2;
            CheckIfPossible(newRow, newCol, board);
            newCol = col + 1;
            CheckIfPossible(newRow, newCol, board);

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
    }
}
