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
     * Game
     * This is our game form
     *********************************************************************/
    public partial class Game : Form
    {
        private String team;
        private Space[,] board;
        private Piece selected;
        private String turn;

        /*********************************************************************
         * NON-DEFAULT CONSTRUCTOR
         * Parameters
         *  team - the team the user chose
         * Set the users team and call CreateBoard() to initialize the board
         *********************************************************************/
        public Game(String team)
        {
            InitializeComponent();

            this.team = team;
            turn = "white";
            CreateBoard();
        }

        /*********************************************************************
        * CreateBoard
        * Here we set up the board and place the pieces in their original places
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
                        color = Color.Gray;
                    }
                    else
                    {
                        color = Color.Red;
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
            SetPieces();
        }

        /*********************************************************************
        * SetPieces
        * Set up all of the pieces on the board
        *********************************************************************/
        void SetPieces()
        {
            for (int i = 0; i < 8; i++)
            {
                Pawn w = new Pawn("white");
                board[i, 1].SetPiece(w);
                Pawn b = new Pawn("black");
                board[i, 6].SetPiece(b);
            }

            Rook rook = new Rook("white");
            board[0, 0].SetPiece(rook);
            rook = new Rook("white");
            board[7, 0].SetPiece(rook);

            Rook rookB = new Rook("black");
            board[0, 7].SetPiece(rookB);
            rookB = new Rook("black");
            board[7, 7].SetPiece(rookB);

            Knight knight = new Knight("white");
            board[1, 0].SetPiece(knight);
            knight = new Knight("white");
            board[6, 0].SetPiece(knight);

            Knight knightB = new Knight("black");
            board[1, 7].SetPiece(knightB);
            knightB = new Knight("black");
            board[6, 7].SetPiece(knightB);

            Bishop bishop = new Bishop("white");
            board[2, 0].SetPiece(bishop);
            bishop = new Bishop("white");
            board[5, 0].SetPiece(bishop);

            Bishop bishopB = new Bishop("black");
            board[2, 7].SetPiece(bishopB);
            bishop = new Bishop("black");
            board[5, 7].SetPiece(bishopB);

            Queen queen = new Queen("white");
            board[3, 0].SetPiece(queen);
            queen = new Queen("black");
            board[3, 7].SetPiece(queen);

            King king = new King("white");
            board[4, 0].SetPiece(king);
            king = new King("black");
            board[4, 7].SetPiece(king);
        }

        /*********************************************************************
        * ButtonClick
        * 
        *********************************************************************/
        public void ButtonClick(object sender, MouseEventArgs e)
        {
            Space thisButton = ((Space)sender);
            

            if (selected == null)
            {
                
                if (thisButton.GetPiece() != null)
                {
                    if (turn == thisButton.GetPiece().GetTeam())
                    {
                        selected = thisButton.GetPiece();
                        if (e.Button == MouseButtons.Right)
                        {

                        }
                        else
                        {
                            selected.CalcPossMoves(board);

                            ShowPossibleMoves();

                            if (selected.GetPossMoves().Count == 0)
                                selected = null;
                        }
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
                    ClearPossible();
                    SwitchTurn();
                }
            }
        }

        /*********************************************************************
        * SwitchTurn
        * Simply switches whose turn it is
        *********************************************************************/
        public void SwitchTurn()
        {
            if (turn == "white")
            {
                turn = "black";
            }
            else
            {
                turn = "white";
            }
        }

        /*********************************************************************
        * ShowPossibleMoves
        * This will check the selected pieces possible moves and then make
        * them evident on the board
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
         * ClearPossible
         * 
         *********************************************************************/
        public void ClearPossible()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board[row, col].GetPiece() != null)
                        board[row, col].Text = board[row, col].GetPiece().GetPieceType();
                    else
                        board[row, col].Text = "";
                }
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
