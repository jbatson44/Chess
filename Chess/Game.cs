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
        private int spaceWidth;
        private int spaceHeight;
        private bool gameOver;
        private List<Piece> whiteTeam;
        private List<Piece> blackTeam;

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
            whiteTeam = new List<Piece>();
            blackTeam = new List<Piece>();
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
                    board[r, c].FlatStyle = FlatStyle.Flat;
                    board[r, c].FlatAppearance.BorderColor = Color.Black;
                    board[r, c].FlatAppearance.BorderSize = 1;
                    board[r, c].Text = "";
                    

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
            Pawn w;
            Pawn b;
            for (int i = 0; i < 8; i++)
            {
                w = new Pawn("white");
                board[i, 1].SetPiece(w);
                whiteTeam.Add(w);
                b = new Pawn("black");
                board[i, 6].SetPiece(b);
                blackTeam.Add(b);
            }

            Rook rook = new Rook("white");
            board[0, 0].SetPiece(rook);
            whiteTeam.Add(rook);
            rook = new Rook("white");
            board[7, 0].SetPiece(rook);
            whiteTeam.Add(rook);

            Rook rookB = new Rook("black");
            board[0, 7].SetPiece(rookB);
            blackTeam.Add(rookB);
            rookB = new Rook("black");
            board[7, 7].SetPiece(rookB);
            blackTeam.Add(rookB);

            Knight knight = new Knight("white");
            board[1, 0].SetPiece(knight);
            whiteTeam.Add(knight);
            knight = new Knight("white");
            board[6, 0].SetPiece(knight);
            whiteTeam.Add(knight);

            Knight knightB = new Knight("black");
            board[1, 7].SetPiece(knightB);
            blackTeam.Add(knightB);
            knightB = new Knight("black");
            board[6, 7].SetPiece(knightB);
            blackTeam.Add(knightB);

            Bishop bishop = new Bishop("white");
            board[2, 0].SetPiece(bishop);
            whiteTeam.Add(bishop);
            bishop = new Bishop("white");
            board[5, 0].SetPiece(bishop);
            whiteTeam.Add(bishop);

            Bishop bishopB = new Bishop("black");
            board[2, 7].SetPiece(bishopB);
            blackTeam.Add(bishopB);
            bishopB = new Bishop("black");
            board[5, 7].SetPiece(bishopB);
            blackTeam.Add(bishopB);

            Queen queen = new Queen("white");
            board[3, 0].SetPiece(queen);
            whiteTeam.Add(queen);
            queen = new Queen("black");
            board[3, 7].SetPiece(queen);
            blackTeam.Add(queen);

            King king = new King("white");
            board[4, 0].SetPiece(king);
            whiteTeam.Add(king);
            king = new King("black");
            board[4, 7].SetPiece(king);
            blackTeam.Add(king);
        }

        /*********************************************************************
        * ButtonClick
        * Handles the button click for each space of the board
        *********************************************************************/
        public void ButtonClick(object sender, MouseEventArgs e)
        {
            Space thisButton = ((Space)sender);
            //MessageBox.Show(whiteTeam[0].GetRow().ToString() + " " + whiteTeam[0].GetColumn().ToString());
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
                        ClearPossible();
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
                                        ShowPossibleMoves();
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
                board[row, col].FlatAppearance.BorderColor = Color.Yellow;
                board[row, col].FlatAppearance.BorderSize = 2;
            }
        }

        /*********************************************************************
        * ClearPossible
        * Reset the border of every space
        *********************************************************************/
        public void ClearPossible()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    board[row, col].FlatAppearance.BorderColor = Color.Black;
                    board[row, col].FlatAppearance.BorderSize = 1;
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
            Kill(toR, toC);
            board[toR, toC].SetPiece(selected);
            selected.GetPossMoves().Clear();
            selected = null;
            board[fromR, fromC].ClearSpace();
        }

        public void Kill(int r, int c)
        {
            for (int i = 0; i < whiteTeam.Count; i++)
            {
                if (r == whiteTeam[i].GetRow() && c == whiteTeam[i].GetColumn())
                {
                    whiteTeam.RemoveAt(i);
                }
            }
            for (int i = 0; i < blackTeam.Count; i++)
            {
                if (r == blackTeam[i].GetRow() && c == blackTeam[i].GetColumn())
                {
                    blackTeam.RemoveAt(i);
                }
            }
        }

        /*********************************************************************
        * IsCheck
        * Loop through the board and for each piece we check if they can kill
        * the king if they can we end and return true.
        *********************************************************************/
        public bool IsCheck(int row, int col, ref Piece killer)
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    killer = board[r, c].GetPiece();
                    if (killer != null && killer.GetTeam() == turn)
                    {
                        killer.CalcPossMoves(board);
                        if (killer.IsPossible(row, col))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /*********************************************************************
        * IsCheckMate
        * Loop through the board and for each piece we check if they can kill
        * the king if they can we end and return true.
        *********************************************************************/
        public bool IsCheckMate()
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Piece piece = board[r, c].GetPiece();
                    if (piece != null && piece.GetTeam() != turn && piece.GetPieceType() == "King")
                    {
                        Piece king = board[r, c].GetPiece();
                        Piece killer = null;
                        king.CalcPossMoves(board);
                        bool Check = false; 
                        int checkCount = 0;
                        int vulnerableChecks = 0;
                        if (IsCheck(r, c, ref killer))
                        {
                            Check = true;
                            checkCount++;
                            if (IsKillable(killer.GetRow(), killer.GetColumn(), turn))
                            {
                                vulnerableChecks++;
                            }
                        }
                        if (Check)
                        {
                            for (int i = 0; i < king.GetPossMoves().Count; i++)
                            {
                                if (IsCheck(king.GetPossMoves()[i].row, king.GetPossMoves()[i].col, ref killer))
                                {
                                    checkCount++;
                                    if (IsKillable(killer.GetRow(), killer.GetColumn(), turn))
                                    {
                                        vulnerableChecks++;
                                    }
                                }
                            }
                        }
                        if (checkCount > 0 && checkCount == king.GetPossMoves().Count)
                        {
                            checkText.Text = "CHECKMATE";
                            return true;
                        }
                        else if (checkCount == 0 || checkCount == vulnerableChecks)
                        {
                            checkText.Text = "";
                        }
                        else if (Check)
                        {
                            MessageBox.Show("king is checked");
                            checkText.Text = "CHECK";
                        }
                    }
                }
            }
            
            return false;
        }

        /*********************************************************************
        * IsKillable
        * Parameters
        *   r - the row of the piece being checked
        *   c - the column of the piece being checked
        *   enemy - the opposite team of the piece being checked
        * Check if the coordinates can be taken by any of the pieces on the 
        * opposite team.
        *********************************************************************/
        public bool IsKillable(int r, int c, string enemy)
        {
            List<Piece> enemies;
            if (enemy == "white")
            {
                enemies = whiteTeam;
            }
            else
            {
                enemies = blackTeam;
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].CalcPossMoves(board);
                if (enemies[i].IsPossible(r, c))
                {
                    return true;
                }

            }
            return false;
        }
    }
}
