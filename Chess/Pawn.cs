using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    /*********************************************************************
    * 
    *********************************************************************/
    class Pawn : Piece
    {
        /*********************************************************************
        * 
        *********************************************************************/
        public Pawn(String team)
        {
            this.team = team;
            possMoves = new List<Pair>();
            pieceType = "Pawn";
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
            int direction = 0;
            if (team == "white")
            {
                direction = 1;
                textColor = Color.White;
            }
            else
            {
                direction = -1;
                textColor = Color.Black;
            }

            if (ValidSpot(row, col + direction) && board[row, col + direction].GetPiece() == null)
                SetSpaceValid(row, col + direction);
            if ((team == "white" && col == 1) || (team == "black" && col == 6))
                SetSpaceValid(row, col + (direction * 2));
            
            if ((ValidSpot(row + 1, col + direction)) 
                && (board[row + 1, col + direction].GetPiece() != null 
                && board[row + 1, col + direction].GetPiece().GetTeam() != team))
            {
                SetSpaceValid(row + 1, col + direction);
            }
            else if ((ValidSpot(row - 1, col + direction)) && board[row - 1, col + direction].GetPiece() != null)
            {
                SetSpaceValid(row - 1, col + direction);
            }
        }


    }

   
}
