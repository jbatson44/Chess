namespace Chess
{
    partial class Game
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
            this.turnSign = new System.Windows.Forms.TextBox();
            this.checkText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // turnSign
            // 
            this.turnSign.Enabled = false;
            this.turnSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnSign.Location = new System.Drawing.Point(12, 12);
            this.turnSign.Name = "turnSign";
            this.turnSign.Size = new System.Drawing.Size(269, 45);
            this.turnSign.TabIndex = 0;
            // 
            // checkText
            // 
            this.checkText.Enabled = false;
            this.checkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkText.Location = new System.Drawing.Point(287, 12);
            this.checkText.Name = "checkText";
            this.checkText.Size = new System.Drawing.Size(269, 45);
            this.checkText.TabIndex = 1;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 853);
            this.Controls.Add(this.checkText);
            this.Controls.Add(this.turnSign);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox turnSign;
        private System.Windows.Forms.TextBox checkText;
    }
}