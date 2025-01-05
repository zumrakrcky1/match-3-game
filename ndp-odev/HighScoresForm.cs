// NDP 2024-2025 Proje
//Devoloper: Berfin Zümra Karacakaya
//No: B231200038
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ndp_odev
{
    public partial class HighScoresForm : Form
    {
        private readonly HighScoreManager _highScoreManager;

        public HighScoresForm()
        {
            _highScoreManager = new HighScoreManager("scores.txt"); // Yüksek skor dosyasını belirtiyoruz
            InitializeComponent();
        }

        // Form yüklendiğinde yüksek skorları yükler
        private void HighScoresForm_Load(object sender, EventArgs e)
        {
            LoadHighScores();
        }

        private void LoadHighScores()
        {
            var topScores = _highScoreManager.GetTopScores(5);
            ListBox scoreListBox = new ListBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 12)
            };

            foreach (var score in topScores)
            {
                scoreListBox.Items.Add(score);
            }
            this.Controls.Add(scoreListBox);
        }
    }
}
