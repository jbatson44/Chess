using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    /*********************************************************************
    * Queen Class
    * Inherits from piece. Contains the logic specific to a queen.
    *********************************************************************/
    public class Queen : Piece
    {
        /*********************************************************************
        * NON-DEFAULT CONSTRUCTOR
        * Parameters
        *   team - this queen's team
        * Set the values for the queen
        *********************************************************************/
        public Queen(String team)
        {
            this.team = team;
            possMoves = new List<Pair>();
            pieceType = "Queen";
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
        * A queen can move 8 spaces in any direction
        *********************************************************************/
        override public void CalcPossMoves(Space[,] board)
        {
            StraightPaths(board, 8);
            DiagonalPaths(board, 8);
        }
    }
}
