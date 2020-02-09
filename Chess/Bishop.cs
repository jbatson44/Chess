using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    /*********************************************************************
    * Bishop Class
    * Inherits from piece. Contains the logic specific to a bishop.
    *********************************************************************/
    class Bishop : Piece
    {
        /*********************************************************************
        * NON-DEFAULT CONSTRUCTOR
        * Parameters
        *   team - this bishops's team
        * Set the values for the bishop
        *********************************************************************/
        public Bishop(String team)
        {
            this.team = team;
            possMoves = new List<Pair>();
            pieceType = "Bishop";
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
        * A bishop can move diagonally a max of 8 spaces
        *********************************************************************/
        override public void CalcPossMoves(Space[,] board)
        {
            DiagonalPaths(board, 8);
        }
    }
}
