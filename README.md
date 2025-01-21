# Match-3 Puzzle Game 🎮  
Bu proje, temel **match-3 eşleştirme mekaniğine** sahip bir bulmaca oyunudur. Oyun, dört farklı renkli taş ve dört özel joker taşı (Roket, Helikopter, Bomba, Gökkuşağı) içerir. Proje, dinamik bir oyun alanı ve kullanıcı dostu arayüzüyle eğlenceli bir oyun deneyimi sunar.

## 📋 Proje Özellikleri  
- **Match-3 Mekaniği**: Aynı renkten 3 veya daha fazla taş yan yana geldiğinde temizlenir.  
- **Özel Jokerler**:  
  - **Roket**: Satırdaki tüm taşları temizler.  
  - **Helikopter**: Sütundaki tüm taşları temizler.  
  - **Bomba**: 3x3'lük bir alanı patlatır.  
  - **Gökkuşağı**: Tüm taşları temizler.  
- **Dinamik Oyun Alanı**: Temizlenen taşların yerine yukarıdan yeni taşlar düşer.  
- **Zamanlayıcı ve Skor Takibi**: Oyun süresi boyunca skorunuzu ve geçen süreyi takip edebilirsiniz.  
- **Fare ve Klavye Kontrolleri**:  
  - Taşları seçmek ve hareket ettirmek için fare kullanabilirsiniz.  
  - Klavye kısayollarıyla oyunu kontrol edebilirsiniz (ör. pause).  
- **Pause Fonksiyonu**: Oyun sırasında duraklatabilirsiniz.  
- **En İyi 5 Skor Takibi**: En yüksek skorlar kayıt edilir.  
- **Menü Ekranı**: Oyuncu adı girişi ve oyun başlatma seçeneği içerir.  

---

## 🚀 Kurulum  
1. **Proje dosyalarını klonlayın**:
   ```bash
   git clone https://github.com/kullaniciadi/match-3-puzzle.git
   cd match-3-puzzle
Geliştirme ortamını hazırlayın:

Visual Studio (C#) kurulu olmalıdır.
.NET Framework veya Core desteği sağlanmalıdır.
Projeyi başlatın:

Visual Studio ile projeyi açın ve Start butonuna tıklayın.
📖 Kod Yapısı
1. Tile.cs
Tile sınıfı, oyundaki taşların özelliklerini ve davranışlarını tanımlar.

Özellikler:
Renk
Joker türü (Roket, Helikopter, Bomba, Gökkuşağı)
Metotlar:
CreateTile: Yeni bir taş oluşturur.
IsMatch: Taş eşleşmelerini kontrol eder.
ActivateJoker: Joker etkisini uygular.
2. GameManager.cs
Oyun akışını ve kurallarını kontrol eder.

Özellikler:
Skor
Zamanlayıcı
Metotlar:
StartGame: Oyunu başlatır ve taşları yerleştirir.
UpdateBoard: Taşlar temizlendikten sonra tahtayı günceller.
CheckMatches: Oyun tahtasında eşleşmeleri kontrol eder.
3. MenuScreen.cs
Oyunun menü ekranını yönetir.

Oyuncu adını alır ve oyunu başlatır.
4. HighScoreManager.cs
En yüksek skorların kaydını tutar ve görüntüler.

Metotlar:
SaveHighScore: Skoru kaydeder.
GetTopScores: En yüksek 5 skoru döndürür.
5. InputManager.cs
Kullanıcı girişlerini (fare ve klavye) işler.

Fare Kontrolü: Taş seçme ve hareket ettirme.
Klavyeyle Pause: Oyun sırasında duraklatma.
🎯 Scoring (Puanlama Sistemi)
3 taş eşleşmesi: 10 puan
4 taş eşleşmesi: 20 puan
5 taş eşleşmesi: 50 puan
Joker kullanımı: 100 puan
📅 Geliştirme Süreci
Tamamlananlar:
Match-3 mekaniği
Zamanlayıcı ve skor takibi
Jokerler ve özel efektler
Eksikler:
Menü ekranı
En iyi skor fonksiyonu
👾 Ekran Görüntüleri
Oyun Ekranı
![image](https://github.com/user-attachments/assets/5eeda635-d700-4676-9b58-63a70a17866a)
Menü Ekranı
![image](https://github.com/user-attachments/assets/f831f91f-28be-4ee6-ab26-39dba0035a66)



🤝 Katkıda Bulunma
Projeye katkıda bulunmak için:

Bu repoyu forklayın.
Kendi branch'inizi oluşturun (feature/özellik-adi).
Değişikliklerinizi yapın ve commit edin.
Bir pull request gönderin.

🛠️ Kullanılan Teknolojiler
C#
.NET Framework/Core
Visual Studio IDE
👩‍💻 Geliştirici
Bu proje Zumra tarafından geliştirilmiştir. 
Sorularınız veya geri bildirimleriniz için iletişime geçmekten çekinmeyin!


