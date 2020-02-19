using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Chess
{
    /*********************************************************************
    * Pawn Class
    * Inherits from piece. Contains the logic specific to a pawn.
    *********************************************************************/
    public class Pawn : Piece
    {
        /*********************************************************************
        * NON-DEFAULT CONSTRUCTOR
        * Parameters
        *   team - this pawn's team
        * Set the values for the pawn
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
        * CalcPossMoves
        * Parameters
        *   board - the board of spaces
        * A pawn can move one space towards the enemy, but if it is the pawn's
        * first move it could move two spaces instead. If there is an enemy 
        * one space diagonally in front of it then it can move and take it.
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
            possMoves.Clear();
            if (ValidSpot(row, col + direction) && board[row, col + direction].GetIsEmpty() == true)
            {
                CheckIfPossible(row, col + direction, board);
            }

            if ((team == "white" && col == 1) || (team == "black" && col == 6))
            {
                CheckIfPossible(row, col + direction * 2, board);
            }

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
