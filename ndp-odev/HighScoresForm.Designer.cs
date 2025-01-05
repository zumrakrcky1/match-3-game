namespace ndp_odev
{
    partial class HighScoresForm
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
            this.SuspendLayout();
            // 
            // HighScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "HighScoreForm";
            this.Text = "HighScoreForm";
            this.Load += new System.EventHandler(this.HighScoresForm_Load);
            this.ResumeLayout(false);
            this.SuspendLayout();
            // 
            // HighScoresForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "HighScoresForm";
            this.Load += new System.EventHandler(this.HighScoresForm_Load);  // Burada Load olayını bağlıyoruz
            this.ResumeLayout(false);

        }

       
        #endregion
    }
}