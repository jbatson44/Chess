using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Rook : Piece
    {
        /*********************************************************************
         * 
         *********************************************************************/
        public Rook(String team)
        {
            this.team = team;
            possMoves = new List<Pair>();
            pieceType = "Pawn";
            image = null;
        }

        /*********************************************************************
         * 
         *********************************************************************/
        override public void CalcPossMoves(Space[,] board)
        {
            
        }
    }
}
