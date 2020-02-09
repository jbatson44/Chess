﻿using System;
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
        private int spaceWidth;
        private int spaceHeight;
        private bool gameOver;

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
            selected = null;

            spaceWidth = 60;
            spaceHeight = 60;
            CreateBoard();
            turnSign.Text = "WHITE TURN";

            gameOver = false;
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
                    board[r, c].Width = spaceWidth;
                    board[r, c].Height = spaceHeight;
                    board[r, c].SetCol(c);
                    board[r, c].SetRow(r);


                    board[r, c].Location = new Point(board[r, c].Width * c + 100, board[r, c].Height * r + 80);
                    Controls.Add(board[r, c]);
                    count++;
                    if (c == 7)
                    {
                        count++;
                    }
                }
            }
            SetPieces();

            //Bishop rook = new Bishop("white");
            //board[4, 4].SetPiece(rook);
            //Pawn p = new Pawn("black");
            //board[0, 7].SetPiece(p);
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
            bishopB = new Bishop("black");
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
        * Handles the button click for each space of the board
        *********************************************************************/
        public void ButtonClick(object sender, MouseEventArgs e)
        {
            Space thisButton = ((Space)sender);

            if (!gameOver)
            {
                // Check if it was a right mouse click
                if (e.Button == MouseButtons.Right)
                {
                    // if this was the selected space then we unselect it
                    if (selected != null && thisButton.GetPiece() == selected)
                    {
                        selected = null;
                        thisButton.ForeColor = thisButton.GetPiece().GetTextColor();
                        return;
                    }
                }
                // left mouse click
                else
                {
                    // if there isn't a piece selected
                    if (selected == null)
                    {
                        // if the place we just clicked on has a piece there
                        if (thisButton.GetPiece() != null)
                        {
                            // if the piece is on our team
                            if (turn == thisButton.GetPiece().GetTeam())
                            {
                                // set this piece as the selected one
                                selected = thisButton.GetPiece();
                                if (e.Button == MouseButtons.Right)
                                {

                                }
                                else
                                {
                                    // calculate all the spots this piece could move to
                                    selected.CalcPossMoves(board);
                                    // if it can't move then we unselect it
                                    if (selected.GetPossMoves().Count == 0)
                                    {
                                        selected = null;
                                    }
                                    // we set the text color to yellow to show which piece is selected
                                    else
                                    {
                                        thisButton.ForeColor = Color.Yellow;
                                        //ShowPossibleMoves();
                                    }
                                }
                            }
                        }
                    }
                    // if we already had a selected piece
                    else
                    {
                        int row = thisButton.GetRow();
                        int col = thisButton.GetCol();

                        // if the selected piece can be moved here then we move it
                        if (IsPossible(row, col))
                        {
                            int fromRow = selected.GetRow();
                            int fromCol = selected.GetColumn();
                            MoveTo(fromRow, fromCol, row, col);
                            ClearPossible();
                            gameOver = IsCheckMate();
                            SwitchTurn();
                        }
                    }
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
                turnSign.Text = "BLACK TURN";
            }
            else
            {
                turn = "white";
                turnSign.Text = "WHITE TURN";
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
        * Reset the text of every space
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
        * IsPossible
        * Parameters
        *  row - the row of the spot being checked
        *  col - the column of the spot being checked
        * Check if this location is a spot our piece can move to
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
        * MoveTo
        * Parameters
        *  fromR - the row of the piece's original space
        *  fromC - the column of the piece's original space
        *  toR - the row of the piece's new space
        *  toC - the column of the piece's new space
        * Move the piece to its new space
        *********************************************************************/
        public void MoveTo(int fromR, int fromC, int toR, int toC)
        {
            board[fromR, fromC].SetPiece(null);
            board[toR, toC].SetPiece(selected);
            selected.GetPossMoves().Clear();
            selected = null;
            board[fromR, fromC].ClearSpace();
        }

        /*********************************************************************
        * IsCheck
        * Loop through the board and for each piece we check if they can kill
        * the king if they can we end and return true.
        *********************************************************************/
        public bool IsCheck(int row, int col)
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Piece piece = board[r, c].GetPiece();
                    if (piece != null && piece.GetTeam() == turn)
                    {
                        piece.CalcPossMoves(board);
                        if (piece.IsPossible(row, col))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /*********************************************************************
        * IsCheck
        * Loop through the board and for each piece we check if they can kill
        * the king if they can we end and return true.
        *********************************************************************/
        public bool IsCheckMate()
        {
            //MessageBox.Show("here");
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Piece piece = board[r, c].GetPiece();
                    if (piece != null && piece.GetTeam() != turn && piece.GetPieceType() == "King")
                    {
                        MessageBox.Show("here king found");
                        Piece king = board[r, c].GetPiece();
                        if (IsCheck(r, c))
                        {
                            MessageBox.Show("king is checked");
                            checkText.Text = "CHECK";


                            king.CalcPossMoves(board);
                            int checkCount = 0;
                            for (int i = 0; i < king.GetPossMoves().Count; i++)
                            {
                                if (IsCheck(king.GetPossMoves()[i].row, king.GetPossMoves()[i].col))
                                {
                                    checkCount++;
                                }
                            }
                            if (checkCount == king.GetPossMoves().Count)
                            {
                                checkText.Text = "CHECKMATE";
                                return true;
                            }
                        }
                        
                    }
                }
            }
            
            return false;
        }
    }
}
