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
    public partial class StartMenu : Form
    {
        private int team;
        private Game game;
        public StartMenu()
        {
            InitializeComponent();
        }

        private void WhiteTeam_CheckedChanged(object sender, EventArgs e)
        {
            if (WhiteTeam.Checked)
            {
                team = 1;
                startButton.Enabled = true;
            }
        }

        private void BlackTeam_CheckedChanged(object sender, EventArgs e)
        {
            if (BlackTeam.Checked)
            {
                team = 2;
                startButton.Enabled = true;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            game = new Game(team);
            game.Show();
            this.Hide();
            game.FormClosed += new FormClosedEventHandler(GameClosed);
            //MessageBox.Show("You chose team ", team.ToString());
        }

        private void GameClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
