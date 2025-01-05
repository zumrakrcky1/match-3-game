// NDP 2024-2025 Proje
//Devoloper: Berfin Zümra Karacakaya
//No: B231200038
using NdpOdev;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ndp_odev
{
    public partial class MenuForm : Form
    {
        private PictureBox welcomeCharacter;
        private TextBox playerNameTextBox;
        private Label welcomeLabel;
        private Label playerNameLabel;
        private const string highScoreFilePath = "scores.txt"; // Yüksek skor dosyasının yolu

        public MenuForm()
        {
            InitializeComponent();
            CustomizeMenuForm();
        }

        private void CustomizeMenuForm()
        {
            // Arka plan resmi ekleyelim
            this.BackgroundImage = Image.FromFile("şekils\\menü.jpg"); // Arka plan resmi yolu
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Hoşgeldiniz yazısı
            welcomeLabel = new Label();
            welcomeLabel.Text = "ZümdyCrush'a Hoşgeldiniz!";
            welcomeLabel.Font = new Font("Comic Sans MS", 24, FontStyle.Bold);
            welcomeLabel.ForeColor = Color.Black;
            welcomeLabel.BackColor = Color.Transparent;
            welcomeLabel.AutoSize = true;
            welcomeLabel.Location = new Point(this.Width / 4 - welcomeLabel.Width / 2);
            this.Controls.Add(welcomeLabel);

            // "Adınızı Giriniz" yazısı
            playerNameLabel = new Label();
            playerNameLabel.Text = "Adınızı Giriniz:";
            playerNameLabel.Font = new Font("Comic Sans MS", 18, FontStyle.Italic);
            playerNameLabel.ForeColor = Color.Black;
            playerNameLabel.BackColor = Color.Transparent;
            playerNameLabel.AutoSize = true;
            playerNameLabel.Location = new Point(this.Width / 3 - playerNameLabel.Width / 2, welcomeLabel.Bottom + 20);
            this.Controls.Add(playerNameLabel);

            // Oyuncu adı giriş kutusu
            playerNameTextBox = new TextBox();
            playerNameTextBox.Font = new Font("Comic Sans MS", 16);
            playerNameTextBox.Size = new Size(250, 40);
            playerNameTextBox.Location = new Point(this.Width / 2 - playerNameTextBox.Width / 2, playerNameLabel.Bottom + 10);
            this.Controls.Add(playerNameTextBox);

            // Oyunu Başlat Butonu
            Button startButton = new Button();
            startButton.Text = "Oyunu Başlat";
            startButton.Font = new Font("Comic Sans MS", 16, FontStyle.Bold);
            startButton.BackColor = Color.FromArgb(50, 205, 50);
            startButton.ForeColor = Color.White;
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.Size = new Size(200, 60);
            startButton.Location = new Point(this.Width / 2 - startButton.Width / 2, playerNameTextBox.Bottom + 20);
            startButton.Click += (sender, e) => StartGame();
            this.Controls.Add(startButton);

            // Oyun Hakkında Bilgi Butonu
            Button infoButton = new Button();
            infoButton.Text = "Oyun Hakkında";
            infoButton.Font = new Font("Comic Sans MS", 14, FontStyle.Bold);
            infoButton.BackColor = Color.MediumSlateBlue;
            infoButton.ForeColor = Color.White;
            infoButton.FlatStyle = FlatStyle.Flat;
            infoButton.Size = new Size(200, 50);
            infoButton.Location = new Point(this.Width / 2 - infoButton.Width / 2, startButton.Bottom + 20);
            infoButton.Click += (sender, e) => ShowGameInfo();
            this.Controls.Add(infoButton);

            // Yüksek Skorlar Butonu
            Button highScoresButton = new Button();
            highScoresButton.Text = "Yüksek Skorlar";
            highScoresButton.Font = new Font("Comic Sans MS", 14, FontStyle.Bold);
            highScoresButton.BackColor = Color.MediumPurple;
            highScoresButton.ForeColor = Color.White;
            highScoresButton.FlatStyle = FlatStyle.Flat;
            highScoresButton.Size = new Size(200, 50);
            highScoresButton.Location = new Point(this.Width / 2 - highScoresButton.Width / 2, infoButton.Bottom + 20);
            highScoresButton.Click += (sender, e) => ShowHighScores();
            this.Controls.Add(highScoresButton);
        }

        private void StartGame()
        {
            string playerName = playerNameTextBox.Text;
            if (string.IsNullOrEmpty(playerName))
            {
                MessageBox.Show("Lütfen isminizi girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ana formu başlat
            AnaForm gameForm = new AnaForm(playerName);
            gameForm.Show();
            this.Hide();
        }

        private void ShowGameInfo()
        {
            string gameInfo = "Üçlü Eşleştirme Oyunu Kuralları:\n\n" +
                              "1. Oyun alanında 4 farklı renkte taş bulunur.\n" +
                              "2. Amaç, en az 3 aynı renkte taşı yatay veya dikey olarak eşleştirmektir.\n" +
                              "3. Özel taşlar (Rocket, Copter, Bomb, Rainbow) ile daha büyük etkiler yaratabilirsiniz:\n" +
                              "   - **Rocket**: Bir satırı temizler.\n" +
                              "   - **Copter**: Bir sütunu temizler.\n" +
                              "   - **Bomb**: Çevresindeki taşları patlatır.\n" +
                              "   - **Rainbow**: Aynı renkteki tüm taşları temizler.\n" +
                              "4. Her eşleştirme puan kazandırır. Büyük kombinasyonlar daha fazla puan getirir.\n" +
                              "5. Süre bitmeden mümkün olduğunca çok puan kazanın!";
            MessageBox.Show(gameInfo, "Oyun Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowHighScores()
        {
            HighScoresForm highScoresForm = new HighScoresForm();
            highScoresForm.Show();
        }
    }
}
