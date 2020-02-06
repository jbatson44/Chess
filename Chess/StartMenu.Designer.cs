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
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WhiteTeam
            // 
            this.WhiteTeam.AutoSize = true;
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
            this.BlackTeam.Location = new System.Drawing.Point(348, 196);
            this.BlackTeam.Name = "BlackTeam";
            this.BlackTeam.Size = new System.Drawing.Size(103, 21);
            this.BlackTeam.TabIndex = 1;
            this.BlackTeam.TabStop = true;
            this.BlackTeam.Text = "Black Team";
            this.BlackTeam.UseVisualStyleBackColor = true;
            this.BlackTeam.CheckedChanged += new System.EventHandler(this.BlackTeam_CheckedChanged);
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(487, 196);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(144, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "StartGame";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.BlackTeam);
            this.Controls.Add(this.WhiteTeam);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton WhiteTeam;
        private System.Windows.Forms.RadioButton BlackTeam;
        private System.Windows.Forms.Button startButton;
    }
}

