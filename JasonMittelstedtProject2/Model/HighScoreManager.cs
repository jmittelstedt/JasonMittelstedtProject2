using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JasonMittelstedtProject2.Model
{
    public class HighScoreManager
    {
        private const string FileName = "highscores.json";
        public List<HighScoreEntry> HighScores { get; private set; } = new();

        public HighScoreManager() => Load();

        public void Load()
        {
            if (!File.Exists(FileName)) { HighScores = new(); return; }
            try
            {
                HighScores = JsonSerializer.Deserialize<List<HighScoreEntry>>(File.ReadAllText(FileName)) ?? new();
            }
            catch { HighScores = new(); }
        }

        public void Save()
        {
            var json = JsonSerializer.Serialize(HighScores, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FileName, json);
        }

        public void Add(HighScoreEntry entry)
        {
            HighScores.Add(entry);
            HighScores = HighScores.OrderByDescending(h => h.Score)
                                   .ThenBy(h => h.DurationSeconds)
                                   .ToList();
            Save();
        }

        public void Reset()
        {
            HighScores.Clear();
            Save();
        }
    }
}
