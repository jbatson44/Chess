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
     * StartMenu
     * This will be our main menu for the 
     *********************************************************************/
    public partial class StartMenu : Form
    {
        private String team;
        private Game game;

        /*********************************************************************
         * DEFAULT CONSTRUCTOR
         *********************************************************************/
        public StartMenu()
        {
            InitializeComponent();
        }

        /*********************************************************************
         * WhiteTeam CheckedChanged
         * If they check the white radio button then we set the team to "white"
         * and enable the start game button.
         *********************************************************************/
        private void WhiteTeam_CheckedChanged(object sender, EventArgs e)
        {
            if (WhiteTeam.Checked)
            {
                team = "white";
                LocalMultiplayer.Enabled = true;
            }
        }

        /*********************************************************************
         * BlackTeam CheckedChanged
         * If they check the black radio button then we set the team to "black"
         * and enable the start game button.
         *********************************************************************/
        private void BlackTeam_CheckedChanged(object sender, EventArgs e)
        {
            if (BlackTeam.Checked)
            {
                team = "black";
                LocalMultiplayer.Enabled = true;
            }
        }

        /*********************************************************************
         * startButton Click
         * When we click the start game button we make a new game form and send
         * the team value. The menu is then hidden.
         *********************************************************************/
        private void startButton_Click(object sender, EventArgs e)
        {
            game = new Game(team);
            game.Show();
            this.Hide();
            game.FormClosed += new FormClosedEventHandler(GameClosed);
        }

        /*********************************************************************
         * GameClosed
         * If the game form is closed the menu reappears.
         *********************************************************************/
        private void GameClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
