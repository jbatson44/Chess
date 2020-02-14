using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    /*********************************************************************
    * Knight Class
    * Inherits from piece. Contains the logic specific to a knight.
    *********************************************************************/
    public class Knight : Piece
    {
        /*********************************************************************
        * NON-DEFAULT CONSTRUCTOR
        * Parameters
        *   team - this knight's team
        * Set the values for the knight
        *********************************************************************/
        public Knight(String team)
        {
            this.team = team;
            possMoves = new List<Pair>();
            pieceType = "Knight";
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
        * A knight can move to spaces that are an L shaped distane away
        *********************************************************************/
        override public void CalcPossMoves(Space[,] board)
        {
            int newRow = row + 1;
            int newCol = col + 2;
            CheckIfPossible(newRow, newCol, board);
            newRow = row - 1;
            CheckIfPossible(newRow, newCol, board);
            newCol = col - 2;
            CheckIfPossible(newRow, newCol, board);
            newRow = row + 1;
            CheckIfPossible(newRow, newCol, board);
            newRow = row + 2;
            newCol = col + 1;
            CheckIfPossible(newRow, newCol, board);
            newCol = col - 1;
            CheckIfPossible(newRow, newCol, board);
            newRow = row - 2;
            CheckIfPossible(newRow, newCol, board);
            newCol = col + 1;
            CheckIfPossible(newRow, newCol, board);

        }

        
    }
}
