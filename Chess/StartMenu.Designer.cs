namespace Chess
{
    partial class StartMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WhiteTeam = new System.Windows.Forms.RadioButton();
            this.BlackTeam = new System.Windows.Forms.RadioButton();
            this.LocalMultiplayer = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WhiteTeam
            // 
            this.WhiteTeam.AutoSize = true;
            this.WhiteTeam.Enabled = false;
            this.WhiteTeam.Location = new System.Drawing.Point(211, 196);
            this.WhiteTeam.Name = "WhiteTeam";
            this.WhiteTeam.Size = new System.Drawing.Size(105, 21);
            this.WhiteTeam.TabIndex = 0;
            this.WhiteTeam.TabStop = true;
            this.WhiteTeam.Text = "White Team";
            this.WhiteTeam.UseVisualStyleBackColor = true;
            this.WhiteTeam.CheckedChanged += new System.EventHandler(this.WhiteTeam_CheckedChanged);
            // 
            // BlackTeam
            // 
            this.BlackTeam.AutoSize = true;
            this.BlackTeam.Enabled = false;
            this.BlackTeam.Location = new System.Drawing.Point(348, 196);
            this.BlackTeam.Name = "BlackTeam";
            this.BlackTeam.Size = new System.Drawing.Size(103, 21);
            this.BlackTeam.TabIndex = 1;
            this.BlackTeam.TabStop = true;
            this.BlackTeam.Text = "Black Team";
            this.BlackTeam.UseVisualStyleBackColor = true;
            this.BlackTeam.CheckedChanged += new System.EventHandler(this.BlackTeam_CheckedChanged);
            // 
            // LocalMultiplayer
            // 
            this.LocalMultiplayer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LocalMultiplayer.Location = new System.Drawing.Point(333, 97);
            this.LocalMultiplayer.Name = "LocalMultiplayer";
            this.LocalMultiplayer.Size = new System.Drawing.Size(144, 23);
            this.LocalMultiplayer.TabIndex = 2;
            this.LocalMultiplayer.Text = "Start Local Game";
            this.LocalMultiplayer.UseVisualStyleBackColor = true;
            this.LocalMultiplayer.Click += new System.EventHandler(this.startButton_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(489, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "StartGame";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LocalMultiplayer);
            this.Controls.Add(this.BlackTeam);
            this.Controls.Add(this.WhiteTeam);
            this.Name = "StartMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chess";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton WhiteTeam;
        private System.Windows.Forms.RadioButton BlackTeam;
        private System.Windows.Forms.Button LocalMultiplayer;
        private System.Windows.Forms.Button button1;
    }
}

