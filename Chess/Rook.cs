using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    /*********************************************************************
    * Rook Class
    * Inherits from piece. Contains the logic specific to a rook.
    *********************************************************************/
    public class Rook : Piece
    {
        /*********************************************************************
        * NON-DEFAULT CONSTRUCTOR
        * Parameters
        *   team - this rook's team
        * Set the values for the rook
        *********************************************************************/
        public Rook(String team)
        {
            this.team = team;
            possMoves = new List<Pair>();
            pieceType = "Rook";
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
        * A rook can up to 8 spaces up, down, left, or right
        *********************************************************************/
        override public void CalcPossMoves(Space[,] board)
        {
            StraightPaths(board, 8);
        }
    }
}
