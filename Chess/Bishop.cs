using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Bishop : Piece
    {
        /*********************************************************************
         * 
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
         * 
         *********************************************************************/
        override public void CalcPossMoves(Space[,] board)
        {
            DiagonalPaths(board, 8);
        }
    }
}
