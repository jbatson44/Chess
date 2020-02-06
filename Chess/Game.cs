using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    /*********************************************************************
     * 
     *********************************************************************/
    public partial class Game : Form
    {
        private String team;
        private Space[,] board;
        private Piece selected;

        /*********************************************************************
         * 
         *********************************************************************/
        public Game(String team)
        {
            InitializeComponent();

            this.team = team;
            CreateBoard();
        }

        /*********************************************************************
         * 
         *********************************************************************/
        public void CreateBoard()
        {
            board = new Space[8, 8];
            int count = 0;
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Color color;
                    if (count % 2 == 0)
                    {
                        color = Color.White;
                    }
                    else
                    {
                        color = Color.Gray;
                    }
                    
                    board[r, c] = new Space(color, null);
                    board[r, c].MouseUp += ButtonClick;
                    board[r, c].Width = 50;
                    board[r, c].Height = 50;
                    board[r, c].SetCol(c);
                    board[r, c].SetRow(r);


                    board[r, c].Location = new Point(board[r, c].Width * c + 100, board[r, c].Height * r + 50);
                    Controls.Add(board[r, c]);
                    count++;
                    if (c == 7)
                    {
                        count++;
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                Pawn w = new Pawn("white");
                board[i, 1].SetPiece(w);
                Pawn b = new Pawn("Black");
                board[i, 6].SetPiece(b);
            }
            
        }

        /*********************************************************************
         * 
         *********************************************************************/
        public void ButtonClick(object sender, MouseEventArgs e)
        {
            Space thisButton = ((Space)sender);
            

            if (selected == null)
            {
                
                if (thisButton.GetPiece() != null)
                {
                    selected = thisButton.GetPiece();
                    if (e.Button == MouseButtons.Right)
                    {

                    }
                    else
                    {
                        selected.CalcPossMoves(board);
                        ShowPossibleMoves();
                    }
                }
            }
            else
            {
                int row = thisButton.GetRow();
                int col = thisButton.GetCol();
                
                if (IsPossible(row, col))
                {
                    int fromRow = selected.GetRow();
                    int fromCol = selected.GetColumn();
                    MoveTo(fromRow, fromCol, row, col);
                }
            }
        }

        /*********************************************************************
         * 
         *********************************************************************/
        public void ShowPossibleMoves()
        {
            for (int i = 0; i < selected.GetPossMoves().Count; i++)
            {
                int row = selected.GetPossMoves()[i].row;
                int col = selected.GetPossMoves()[i].col;
                board[row, col].Text += "Poss";
            }
        }

        /*********************************************************************
         * 
         *********************************************************************/
        public bool IsPossible(int row, int col)
        {
            for (int i = 0; i < selected.GetPossMoves().Count; i++)
            {
                if (row == selected.GetPossMoves()[i].row &&
                    col == selected.GetPossMoves()[i].col)
                {
                    return true;
                }
            }
            return false;

        }

        /*********************************************************************
         * 
         *********************************************************************/
        public void MoveTo(int fromR, int fromC, int toR, int toC)
        {
            board[fromR, fromC].SetPiece(null);
            board[toR, toC].SetPiece(selected);
            selected.GetPossMoves().Clear();
            selected = null;
            board[fromR, fromC].ClearSpace();
        }
    }
}
