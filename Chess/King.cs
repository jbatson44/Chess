using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class King : Piece
    {
        /*********************************************************************
        * 
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
        * 
        *********************************************************************/
        override public void CalcPossMoves(Space[,] board)
        {
            StraightPaths(board, 1);
            DiagonalPaths(board, 1);
        }
    }
}
