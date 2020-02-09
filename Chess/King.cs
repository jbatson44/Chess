using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    /*********************************************************************
    * King Class
    * Inherits from piece. Contains the logic specific to a king.
    *********************************************************************/
    class King : Piece
    {
        /*********************************************************************
        * NON-DEFAULT CONSTRUCTOR
        * Parameters
        *   team - this king's team
        * Set the values for the king
        *********************************************************************/
        public King(String team)
        {
            this.team = team;
            possMoves = new List<Pair>();
            pieceType = "King";
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
        * A king can move one space in any direction
        *********************************************************************/
        override public void CalcPossMoves(Space[,] board)
        {
            StraightPaths(board, 1);
            DiagonalPaths(board, 1);
        }
    }
}
