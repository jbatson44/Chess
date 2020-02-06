using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Pawn : Piece
    {
        public Pawn(String team)
        {
            this.team = team;
            possMoves = new List<Pair>();
            pieceType = "Pawn";
            image = null;
        }

        override public void CalcPossMoves(Space[,] board)
        {
            int direction = 0;
            if (team == "white")
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }

            SetSpaceValid(row, col + direction);
            if ((team == "white" && col == 1) || (team == "black" && col == 6))
                SetSpaceValid(row, col + (direction * 2));
            
            if ((ValidSpot(row + 1, col + direction)) && (board[row + 1, col + direction].GetPiece() != null))
            {
                SetSpaceValid(row + 1, col + direction);
            }
            else if ((ValidSpot(row - 1, col + direction)) && board[row - 1, col + direction].GetPiece() != null)
            {
                SetSpaceValid(row - 1, col + direction);
            }
        }

        public bool ValidSpot(int row, int col)
        {
            if (row >= 0 && row < 8 && col >= 0 && col < 8)
            {
                return true;
            }
            return false;
        }

    }

   
}
