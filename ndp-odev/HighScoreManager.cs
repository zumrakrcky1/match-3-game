using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ndp_odev
{
    public class HighScoreManager : BaseScoreManager
    {
        public HighScoreManager(string filePath) : base(filePath) { }

        // Skorları sıralar (en yüksekten en düşüğe)
        public override List<string> SortScores(List<string> scores)
        {
            return scores.OrderByDescending(score => int.Parse(score.Split('-')[1].Trim())).ToList();
        }

        // Yüksek skorları almak için
        public List<string> GetTopScores(int topCount)
        {
            List<string> scores = ReadScores();
            return scores.Take(topCount).ToList(); // İlk N skoru alır
        }
    }
}
