// NDP 2024-2025 Proje
//Devoloper: Berfin Zümra Karacakaya
//No: B231200038
using System;
using System.Drawing;

public interface ITile
{
    string Name { get; set; }
    bool IsExploded { get; set; }
    Image ShapeImage { get; set; }
    string JokerType { get; set; }

    bool IsJoker();
    void InitializeTile();
}

public class Tile : ITile
{
    public string Name { get; set; }
    public bool IsExploded { get; set; } // Patlamış mı?
    public Image ShapeImage { get; set; }
    public string JokerType { get; set; } // Joker türü (örneğin "Roket dikey", "Roket yatay" vb.)

    private static readonly string[] JokerTypes =
        { "Roket dikey", "Roket yatay", "Helikopter", "Bomba", "Gökkuşağı" };

    // Şekil ya da jokerle bir tile başlatmak için kurucu metot
    public Tile(string name)
    {
        Name = name;
        IsExploded = false;
        InitializeTile();
    }

    // Joker olup olmadığını kontrol eden metot
    public bool IsJoker()
    {
        return Array.Exists(JokerTypes, joker => joker == Name);
    }

    // Tile'ı başlatan metot
    public void InitializeTile()
    {
        if (IsJoker())
        {
            JokerType = Name;  // Joker türünü kaydet
            Console.WriteLine($"Joker Türü: {JokerType}"); // Hata ayıklama çıktısı
        }
        else
        {
            JokerType = null; // Bu bir normal şekil
        }

        ShapeImage = GetShapeImage(Name);

        // Eğer görsel yüklenemediyse, hata ayıklama için log yazalım
        if (ShapeImage == null)
        {
            Console.WriteLine($"Görsel yüklenemedi: {Name}");
        }
    }

    // Şekil ya da joker adına göre görsel döndüren özel bir metot
    private Image GetShapeImage(string shapeName)
    {
        try
        {
            switch (shapeName)
            {
                case "Kare":
                    return Image.FromFile("şekils\\Kare.png");
                case "Taç":
                    return Image.FromFile("şekils\\taç.png");
                case "Kalkan":
                    return Image.FromFile("şekils\\kalkan.png");
                case "Yonca":
                    return Image.FromFile("şekils\\yonca.png");
                case "Roket dikey":
                    return Image.FromFile("şekils\\roket-dikey.png");
                case "Roket yatay":
                    return Image.FromFile("şekils\\roket-yatay.png");
                case "Helikopter":
                    return Image.FromFile("şekils\\kopter.png");
                case "Bomba":
                    return Image.FromFile("şekils\\bomba.png");
                case "Gökkuşağı":
                    return Image.FromFile("şekils\\gökkuşağı.png");
                default:
                    return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Görsel yüklenirken hata: {ex.Message}");
            return null;
        }
    }
}
