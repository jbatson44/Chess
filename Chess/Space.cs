using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    /*********************************************************************
    * Space Class
    * Contains the logic for a space on a chess board
    *********************************************************************/
    public class Space : Button
    {
        private Color color;
        private Image image;
        private Piece piece;
        private int row;
        private int col;
        private bool isEmpty;

        /*********************************************************************
        * NON-DEFAULT CONSTRUCTOR
        *********************************************************************/
        public Space(Color color, Piece piece)
        {
            this.BackColor = color;
            image = null;
            this.piece = piece;
            this.color = color;
            isEmpty = true;
            if (piece != null)
                isEmpty = false;
        }

        /*********************************************************************
        * SetPiece
        * Parameters
        *   piece - the piece that will now be on this space
        * Set the new piece for this space
        *********************************************************************/
        public void SetPiece(Piece piece)
        {
            this.piece = piece;
            if (piece != null)
            {
                BackColor = BackColor;
                ForeColor = piece.GetTextColor();
                image = piece.GetImage();
                this.Text = piece.GetPieceType();
                piece.SetCol(col);
                piece.SetRow(row);
                ForeColor = piece.GetTextColor();
                isEmpty = false;
            }
                
        }

        /*********************************************************************
        * ClearSpace
        * Clear the values of this space once a piece moves to a new space
        *********************************************************************/
        public void ClearSpace()
        {
            image = null;
            piece = null;
            this.Text = "";
            isEmpty = true;
        }

        public bool GetIsEmpty() { return isEmpty; }

        public Piece GetPiece() { return piece; }

        public int GetRow() { return row; }
        public void SetRow(int row) { this.row = row; }
        public int GetCol() { return col; }
        public void SetCol(int col) { this.col = col; }

        public Color GetColor() { return color; }
        public void SetColor(Color color) { this.color = color; }

        public Image GetImage() { return image; }
        public void SetImage(Image image) { this.image = image; }
    }
}
