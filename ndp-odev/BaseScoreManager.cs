// NDP 2024-2025 Proje
//Devoloper: Berfin Zümra Karacakaya
//No: B231200038
using System;
using System.Collections.Generic;
using System.IO;

namespace ndp_odev
{
    public class BaseScoreManager
    {
        protected string filePath; // Dosya yolu

        // BaseScoreManager sınıfının kurucusu
        public BaseScoreManager(string filePath)
        {
            this.filePath = filePath;
        }

        // Skorları dosyadan okur
        public virtual List<string> ReadScores()
        {
            List<string> scores = new List<string>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                scores.AddRange(lines);
            }

            return scores;
        }

        // Skorları sıralar
        public virtual List<string> SortScores(List<string> scores)
        {
            return scores;
        }

        // Skorları dosyaya yazar
        public virtual void WriteScores(List<string> scores)
        {
            File.WriteAllLines(filePath, scores);
        }

        // Skorları kaydeder
        public virtual void SaveScore(string playerName, int score)
        {
            string scoreLine = $"{playerName} - {score}";
            List<string> scores = ReadScores();
            scores.Add(scoreLine);
            scores = SortScores(scores); // Skorları sıralar
            WriteScores(scores); // Sıralı skorları dosyaya yazar
        }
    }
}
