// NDP 2024-2025 Proje
//Devoloper: Berfin Zümra Karacakaya
//No: B231200038

using ndp_odev;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NdpOdev
{
    public partial class AnaForm : Form
    {
        private const int GridSize = 8; // 8x8 oyun alanı
        private Tile[,] gameGrid; // 2D dizi
        private Random random = new Random();
        private Timer gameTimer;
        private int timeElapsed;
        private int score;
        private string playerName;



        public AnaForm(string playerName)
        {
            this.playerName = playerName;
            InitializeComponent();
            InitializeGame(); // Oyun başlatma
            CreateGameGrid(); // Oyun alanını oluştur
            CustomizeGameForm();
        }

        private List<Button> gameButtons = new List<Button>(); // Butonlar listesi
        private Button btnPause; // Pause butonu
        private Button btnRestart; // Restart butonu
        private bool isGamePaused = false; // Oyunun duraklatılıp duraklatılmadığı kontrolü

        // Skor ve Zaman Label'ları
        private Label lblScores;
        private Label lblTimes;


        private void CustomizeGameForm()
        {
            // Arka plan rengini belirleyelim
            this.BackColor = Color.Aquamarine;
            this.BackgroundImage = Image.FromFile("şekils\\indir.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;



            // Skor label'ı
            Label lblScore = new Label();
            lblScore.Text = "Puan: 0";
            lblScore.Font = new Font("Arial", 14);
            lblScore.ForeColor = Color.Black;
            lblScore.AutoSize = true;
            lblScore.Location = new Point(20, 80);
            this.Controls.Add(lblScore);


        }

        private void InitializeGame()
        {
            // Timer'ı oluştur ve ayarla
            gameTimer = new Timer
            {
                Interval = 1000 // Her saniye tetiklenecek
            };
            gameTimer.Tick += GameTimer_Tick;

            // Başlangıçta geçen süreyi sıfırlayın
            timeElapsed = 0;

            // Pause ve Restart butonlarını başlat
            InitializePauseButton();
            InitializeRestartButton();

            gameTimer.Start(); // Zamanlayıcıyı başlat

            // Skor ve Zaman etiketlerini başlat
            InitializeScoreAndTimeLabels();
        }

        private void InitializeScoreAndTimeLabels()
        {
            // Skor Label'ı
            lblScores = new Label
            {
                Text = "Skor: 0",
                Location = new Point(10, 10),
                Size = new Size(150, 30),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            this.Controls.Add(lblScores);

            // Zaman Label'ı
            lblTimes = new Label
            {
                Text = "Süre: 0",
                Location = new Point(200, 10),
                Size = new Size(150, 30),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            this.Controls.Add(lblTimes);
        }

        private void InitializePauseButton()
        {
            btnPause = new Button
            {
                Text = "Pause",
                Location = new Point(10, 450), // Alt kısımda yer
                Size = new Size(100, 50)
            };
            btnPause.Click += BtnPause_Click;
            this.Controls.Add(btnPause);
        }

        private void InitializeRestartButton()
        {
            btnRestart = new Button
            {
                Text = "Restart",
                Location = new Point(120, 450), // Alt kısımda yer
                Size = new Size(100, 50),
                Enabled = false  // Başlangıçta devre dışı bırak
            };
            btnRestart.Click += BtnRestart_Click;
            this.Controls.Add(btnRestart);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            timeElapsed++; // Her saniye geçen süreyi artırıyoruz
            Console.WriteLine("Süre: " + timeElapsed);  // Debug çıktısı ekleyin

            // Zaman etiketini güncelle
            lblTime.Text = "Süre: " + timeElapsed;

            // 3 dakika (180 saniye) geçtikten sonra oyun bitmeli
            if (timeElapsed >= 180)
            {
                gameTimer.Stop(); // Zamanlayıcıyı durdur
                GameOver(); // Oyunu bitir
            }
        }
        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        private void BtnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
        private void PauseGame()
        {
            // Timer'ı durdur
            gameTimer.Stop();
            isGamePaused = true;
            btnPause.Text = "Resume";

            // Oyun butonlarını devre dışı bırak
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    // Pause ve Restart butonları hariç diğer butonları devre dışı bırak
                    if (button != btnPause && button != btnRestart)
                    {
                        button.Enabled = false;
                    }
                }
            }

            btnRestart.Enabled = true;
        }
        private void ResumeGame()
        {
            // Timer'ı başlat
            gameTimer.Start();
            isGamePaused = false;
            btnPause.Text = "Pause";

            // Oyun butonlarını aktif hale getir
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    // Pause ve Restart butonları hariç diğer butonları aktif et
                    if (button != btnPause && button != btnRestart)
                    {
                        button.Enabled = true;
                    }
                }
            }

            btnRestart.Enabled = false;
        }
        private void RestartGame()
        {
            // Oyunu sıfırlama işlemleri
            gameTimer.Stop(); // Timer'ı durdur
            timeElapsed = 0;  // Süreyi sıfırlayın
            isGamePaused = false;
            btnPause.Text = "Pause";

            // Oyun butonlarını yeniden başlat
            foreach (var button in gameButtons)
            {
                button.Enabled = true; // Butonları etkinleştir
            }

            btnRestart.Enabled = false;

            // Yeniden başlatma işlemlerini burada yapabilirsiniz
        }

        // Oyun bittiğinde yapılacak işlemler
        private void GameOver()
        {
            // Oyuncuya süre dolduğunu bildiren bir mesaj
            MessageBox.Show($"Oyun Süresi Doldu! Oyun Bitti. Skor: {score}", "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Oyun butonlarını devre dışı bırak
            foreach (var button in gameButtons)
            {
                button.Enabled = false; // Butonları devre dışı bırak
            }

            // Yeniden başlatma butonunu etkinleştir
            btnRestart.Enabled = true;

            // Skoru kaydetmek için HighScoreManager'ı kullan
            HighScoreManager highScoreManager = new HighScoreManager("scores.txt"); // Skorları kaydedeceğimiz dosya
            highScoreManager.SaveScore(playerName, score); // Skoru kaydet
        }
        private Button GetButtonAt(int row, int col)
        {
            foreach (Control control in Controls)
            {
                if (control is Button button && button.Tag != null)
                {
                    var coords = (ValueTuple<int, int>)button.Tag;
                    if (coords.Item1 == row && coords.Item2 == col)
                    {
                        return button;
                    }
                }
            }
            return null;
        }
        //oyun ızgarasını oluşturma
        private void CreateGameGrid()
        {
            gameGrid = new Tile[GridSize, GridSize];

            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize; col++)
                {
                    Tile tile;

                    // %10 ihtimalle joker ekle
                    if (random.Next(100) < 10)
                    {
                        tile = GetRandomJoker();
                    }
                    else
                    {
                        // Normal şekil seçimi
                        string shapeName = GetRandomShape();
                        tile = new Tile(shapeName); // Normal bir Tile oluştur
                    }

                    gameGrid[row, col] = tile; // Tile'ı grid'e ekle

                    // Buton oluştur ve ayarla
                    Button tileButton = new Button
                    {
                        Width = 50,
                        Height = 50,
                        Location = new Point(col * 50, row * 50 + 50), // Skor/süre için 50px yukarıda
                        Tag = (row, col), // Koordinatları sakla
                        BackgroundImage = tile.ShapeImage, // Tile'ın görselini kullan
                        BackgroundImageLayout = ImageLayout.Stretch // Görseli düğmeye uyarla
                    };

                    tileButton.Click += TileButton_Click; // Tıklama olayına ekleyin

                    Controls.Add(tileButton); // Form'a düğmeyi ekle
                }
            }
        }
        private Tile GetRandomJoker()
        {
            // Jokerlerden rastgele birini döndür
            string[] jokers = { "Roket dikey", "Roket yatay", "Helikopter", "Bomba", "Gökkuşağı" };
            return new Tile(jokers[random.Next(jokers.Length)]);
        }
        private string GetRandomShape()
        {
            // Rastgele 4 şekil arasından birini seç
            string[] shapes = { "Kare", "Taç", "Kalkan", "Yonca" };
            return shapes[random.Next(shapes.Length)];
        }
        //eşleşme kontrolü yapma
        private List<List<(int row, int col)>> FindMatches()
        {
            List<List<(int row, int col)>> matches = new List<List<(int row, int col)>>();

            // Yatay eşleşmeleri bul
            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize - 2; col++)
                {
                    string name1 = gameGrid[row, col]?.Name;
                    string name2 = gameGrid[row, col + 1]?.Name;
                    string name3 = gameGrid[row, col + 2]?.Name;

                    if (name1 != null && name1 == name2 && name2 == name3)
                    {
                        List<(int row, int col)> match = new List<(int row, int col)>
                {
                    (row, col), (row, col + 1), (row, col + 2)
                };

                        matches.Add(match);
                    }
                }
            }

            // Dikey eşleşmeleri bul
            for (int col = 0; col < GridSize; col++)
            {
                for (int row = 0; row < GridSize - 2; row++)
                {
                    string name1 = gameGrid[row, col]?.Name;
                    string name2 = gameGrid[row + 1, col]?.Name;
                    string name3 = gameGrid[row + 2, col]?.Name;

                    if (name1 != null && name1 == name2 && name2 == name3)
                    {
                        List<(int row, int col)> match = new List<(int row, int col)>
                {
                    (row, col), (row + 1, col), (row + 2, col)
                };

                        matches.Add(match);
                    }
                }
            }

            return matches;
        }
       //boşlukalrı taşlarla doldurma
        private void RefillBoard()
        {
            // Her sütun için taşları kaydırma
            for (int col = 0; col < GridSize; col++)
            {
                // Sütunda en alt satırdan yukarıya doğru ilerliyoruz
                for (int row = GridSize - 1; row >= 0; row--)
                {
                    if (gameGrid[row, col] == null)
                    {
                        // Eğer bir taş boşsa, yukarıdaki taşları aşağıya kaydırıyoruz
                        for (int r = row - 1; r >= 0; r--)
                        {
                            gameGrid[r + 1, col] = gameGrid[r, col];
                            gameGrid[r, col] = null;

                            // Görselde taşları kaydır
                            Button currentButton = GetButtonAt(r + 1, col);
                            Button aboveButton = GetButtonAt(r, col);

                            if (currentButton != null && aboveButton != null)
                            {
                                currentButton.BackgroundImage = aboveButton.BackgroundImage;
                                aboveButton.BackgroundImage = null;
                            }
                        }

                        // Boş hücreyi doldurmak için yeni taş ekle
                        if (gameGrid[row, col] == null)
                        {
                            Tile newTile = new Tile(GetRandomShape());
                            gameGrid[row, col] = newTile;

                            // Butonun görselini güncelle
                            Button button = GetButtonAt(row, col);
                            if (button != null)
                            {
                                button.BackgroundImage = newTile.ShapeImage;
                            }
                        }
                    }
                }
            }
        }
        private void HighlightTilesBeforeRemoval(List<List<(int row, int col)>> matches)
        {
            foreach (var match in matches)
            {
                foreach (var (row, col) in match)
                {
                    Button button = GetButtonAt(row, col);
                    if (button != null)
                    {
                        // Vurgulama için renk değişikliği
                        button.BackColor = Color.Purple; // Vurgulama rengi
                    }
                }
            }
            // Vurgulama işlemi tamamlandıktan sonra, bekleme işlemi
            Task.Delay(500).Wait(); // 1 saniye bekle
            RestoreOriginalColors(matches); // Renkleri geri al
        }

        private void RestoreOriginalColors(List<List<(int row, int col)>> matches)
        {
            foreach (var match in matches)
            {
                foreach (var (row, col) in match)
                {
                    Button button = GetButtonAt(row, col);
                    if (button != null)
                    {
                        button.BackColor = DefaultBackColor; // Eski rengi geri getir
                    }
                }
            }
        }
        // taş kontrolüne göre taşları patlat 
        private void ExplodeTiles(List<List<(int row, int col)>> matches)
        {
            int points = 0;
            HashSet<(int, int)> explodedTiles = new HashSet<(int, int)>();  // Patlatılan taşları takip et

            // Taşları vurgula
            HighlightTilesBeforeRemoval(matches);

            // Her eşleşme için taşları patlat
            foreach (var match in matches)
            {
                int matchCount = match.Count;

                // Puan hesaplama
                if (matchCount == 3)
                    points += 10; // 3'lü eşleşme için 10 puan
                else if (matchCount == 4)
                    points += 20; // 4'lü eşleşme için 20 puan
                else if (matchCount == 5)
                    points += 30; // 5'li eşleşme için 30 puan

                // Taşları patlat
                foreach (var (row, col) in match)
                {
                    if (!explodedTiles.Contains((row, col))) // Eğer bu taş daha önce patlatılmadıysa
                    {
                        var tile = gameGrid[row, col];

                        // Eğer bu taş bir jokerse
                        if (tile != null && !string.IsNullOrEmpty(tile.JokerType))
                        {
                            HandleJokerEffect(tile.JokerType, row, col); // Jokerin etkisini uygula
                        }
                        else
                        {
                            gameGrid[row, col] = null; // Patlatılan taşları kaldır
                            Button button = GetButtonAt(row, col);
                            if (button != null)
                            {
                                button.BackgroundImage = null; // Görseli kaldır
                            }
                        }
                        explodedTiles.Add((row, col)); // Bu taşı patlatıldı olarak işaretle
                    }
                }
            }

            UpdateScore(points); // Puanı güncelle
        }
        // Joker taşlarının etkilerini işleyelim
        private async void HandleJokerEffect(string jokerType, int row, int col)
        {
            switch (jokerType)
            {
                case "Roket dikey":
                    // Dikeydeki tüm taşları patlat
                    for (int i = 0; i < GridSize; i++)
                    {
                        if (gameGrid[i, col] != null)
                        {
                            Button button = GetButtonAt(i, col);

                            if (button != null)
                            {
                                button.BackColor = Color.Orange;
                                await Task.Delay(200);
                                button.BackColor = DefaultBackColor;
                                button.BackgroundImage = null;
                            }

                            gameGrid[i, col] = null;
                            UpdateScore(10);
                        }
                    }
                    break;

                case "Roket yatay":
                    // Yataydaki tüm taşları patlat
                    for (int i = 0; i < GridSize; i++)
                    {
                        if (gameGrid[row, i] != null)
                        {
                            Button button = GetButtonAt(row, i);

                            if (button != null)
                            {
                                button.BackColor = Color.Orange;
                                await Task.Delay(200);
                                button.BackColor = DefaultBackColor;
                                button.BackgroundImage = null;
                            }

                            gameGrid[row, i] = null;
                            UpdateScore(10);
                        }
                    }
                    break;

                case "Helikopter":
                    // Oyun alanındaki rastgele bir taşı patlat
                    Random random = new Random();
                    int randRow = random.Next(0, GridSize);
                    int randCol = random.Next(0, GridSize);

                    while (gameGrid[randRow, randCol] == null)
                    {
                        randRow = random.Next(0, GridSize);
                        randCol = random.Next(0, GridSize);
                    }

                    Button randomButton = GetButtonAt(randRow, randCol);
                    if (randomButton != null)
                    {
                        randomButton.BackColor = Color.Red;
                        await Task.Delay(500);
                        randomButton.BackColor = DefaultBackColor;
                        randomButton.BackgroundImage = null;
                    }

                    gameGrid[randRow, randCol] = null;
                    UpdateScore(10);

                    // Helikopter jokerini de patlat
                    Button heliButton = GetButtonAt(row, col);
                    if (heliButton != null)
                    {
                        heliButton.BackgroundImage = null;
                    }
                    gameGrid[row, col] = null;
                    break;

                case "Gökkuşağı":
                    // Rastgele bir renk seç ve bu renkteki tüm taşları patlat
                    string randomColor = GetRandomColor();

                    for (int i = 0; i < GridSize; i++)
                    {
                        for (int j = 0; j < GridSize; j++)
                        {
                            if (gameGrid[i, j] != null && gameGrid[i, j].Name == randomColor)
                            {
                                Button button = GetButtonAt(i, j);

                                if (button != null)
                                {
                                    button.BackColor = Color.Magenta;
                                    await Task.Delay(100);
                                    button.BackColor = DefaultBackColor;
                                    button.BackgroundImage = null;
                                }

                                gameGrid[i, j] = null;
                                UpdateScore(10);
                            }
                        }
                    }

                    // Gökkuşağı jokerini de patlat
                    Button rainbowButton = GetButtonAt(row, col);
                    if (rainbowButton != null)
                    {
                        rainbowButton.BackgroundImage = null;
                    }
                    gameGrid[row, col] = null;
                    break;

                case "Bomba":
                    // Bomba etrafındaki taşları patlat (8 komşu)
                    for (int i = Math.Max(0, row - 1); i <= Math.Min(GridSize - 1, row + 1); i++)
                    {
                        for (int j = Math.Max(0, col - 1); j <= Math.Min(GridSize - 1, col + 1); j++)
                        {
                            if (gameGrid[i, j] != null)
                            {
                                Button button = GetButtonAt(i, j);

                                if (button != null)
                                {
                                    button.BackColor = Color.Yellow;
                                    await Task.Delay(200);
                                    button.BackColor = DefaultBackColor;
                                    button.BackgroundImage = null;
                                }

                                gameGrid[i, j] = null;
                                UpdateScore(10);
                            }
                        }
                    }
                    break;
            }

            // Joker kullanıldıktan sonra tahtayı yeniden doldur
            RefillBoard();

            // Yeni eşleşme var mı kontrol et
            CheckAndHandleMatches();
        }
        private string GetRandomColor()
        {
            // Rastgele bir renk seç
            string[] colors = { "Kare", "Taç", "Kalkan", "Yonca" }; // Bunu renklerle değiştirebilirsiniz
            return colors[random.Next(colors.Length)];
        }
        private void CheckAndHandleMatches()
        {
            var matches = FindMatches();

            if (matches.Count > 0)
            {
                ExplodeTiles(matches); // Eşleşen taşları patlat
                RefillBoard();          // Yeni taşlarla tahtayı doldur
                CheckAndHandleMatches(); // Yeni eşleşmeleri kontrol et
            }
        }
        private void UpdateScore(int points)
        {
            score += points;
            lblScore.Text = $"Score: {score}";
        }

        // Oyun başladıktan sonra timer'ı başlat
        private void AnaForm_Load(object sender, EventArgs e)
        {
            gameTimer.Start();
        }

        private (int row, int col)? selectedTile = null; // Seçili taşı tutar
        private void TileButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null || clickedButton.Tag == null) return;

            // Tıklanan düğmenin koordinatlarını al
            var (row, col) = ((int, int))clickedButton.Tag;

            if (selectedTile == null)
            {
                // Henüz seçim yapılmamışsa, bu düğmeyi seç
                selectedTile = (row, col);
                clickedButton.FlatAppearance.BorderColor = Color.Red; // Seçim göstergesi
                clickedButton.FlatAppearance.BorderSize = 2;
            }
            else
            {
                // İkinci taş seçildi, yer değiştirme işlemini yap
                var (selectedRow, selectedCol) = selectedTile.Value;

                // Komşu mu kontrol et (hem yatay hem dikey)
                if (Math.Abs(selectedRow - row) + Math.Abs(selectedCol - col) == 1)
                {
                    SwapTiles(selectedRow, selectedCol, row, col);
                }

                // Seçimi temizle
                Button previousButton = GetButtonAt(selectedRow, selectedCol);
                if (previousButton != null)
                {
                    previousButton.FlatAppearance.BorderSize = 0;
                }
                selectedTile = null;
            }

            // Eşleşmeleri kontrol et ve patlayan taşları kaydır
            CheckAndHandleMatches();
        }
        private void UpdateButtonVisuals()
        {
            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize; col++)
                {
                    Button button = GetButtonAt(row, col);
                    if (button != null && gameGrid[row, col] != null)
                    {
                        button.BackgroundImage = gameGrid[row, col].ShapeImage;
                    }
                }
            }
        }
        // değişim ve eşelştirme kontrolü
        private void SwapTiles(int row1, int col1, int row2, int col2)
        {
            // Taşları geçici olarak değiştir
            Tile temp = gameGrid[row1, col1];
            gameGrid[row1, col1] = gameGrid[row2, col2];
            gameGrid[row2, col2] = temp;

            // Eşleşme kontrolü
            List<List<(int row, int col)>> matches = FindMatches();

            if (matches.Count > 0)
            {
                // Eşleşme varsa görseli güncelle
                UpdateButtonVisuals();
                ExplodeTiles(matches); // Taşları patlat
                RefillBoard(); // Taşları doldur
            }
            else
            {
                // Eşleşme yoksa taşları geri al
                gameGrid[row2, col2] = gameGrid[row1, col1];
                gameGrid[row1, col1] = temp;

                // Görselleri geri al
                UpdateButtonVisuals();
            }

            // Joker etkisi için her iki taşın da joker olup olmadığını kontrol et
            HandleJokerEffectIfNeeded(row1, col1);
            HandleJokerEffectIfNeeded(row2, col2);
        }
        // Joker etkisi için her iki taşın da joker olup olmadığını kontrol et
        private void HandleJokerEffectIfNeeded(int row, int col)
        {
            var tile = gameGrid[row, col];
            if (tile != null && !string.IsNullOrEmpty(tile.JokerType))
            {
                HandleJokerEffect(tile.JokerType, row, col);
            }
        }
    }
}
