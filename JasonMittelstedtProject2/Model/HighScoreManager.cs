using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JasonMittelstedtProject2.Model
{
    /// <summary>
    /// Manages high score data for the Text Twist game, including
    /// loading, saving, sorting, and resetting high score entries.
    /// </summary>
    public class HighScoreManager
    {
        /// <summary>
        /// The file name used to store high score data in JSON format.
        /// </summary>
        private const string FileName = "highscores.json";
        /// <summary>
        /// The list of high score entries currently loaded from storage.
        /// </summary>
        public List<HighScoreEntry> HighScores { get; private set; } = new();

        /// <summary>
        /// Reference to the main form (currently unused placeholder property).
        /// </summary>
        public MainForm MainForm
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HighScoreManager"/> class
        /// and automatically loads any existing high scores.
        /// </summary>
        public HighScoreManager() => Load();

        /// <summary>
        /// Loads the high scores from the JSON file. If the file does not exist
        /// or is unreadable, an empty list is created.
        /// </summary>
        public void Load()
        {
            var completeFileName = Locator.getFileName(FileName);
            if (!File.Exists(completeFileName)) { HighScores = new(); return; }
            try
            {
                HighScores = JsonSerializer.Deserialize<List<HighScoreEntry>>(File.ReadAllText(completeFileName)) ?? new();
            }
            catch { HighScores = new(); }
        }

        /// <summary>
        /// Saves the current list of high scores to the JSON file.
        /// </summary>
        public void Save()
        {
            var json = JsonSerializer.Serialize(HighScores, new JsonSerializerOptions { WriteIndented = true });
            var completeFileName = Locator.getFileName(FileName);
            File.WriteAllText(completeFileName, json);
        }

        /// <summary>
        /// Adds a new high score entry, re-sorts the list by descending score
        /// and ascending duration, and then saves the results.
        /// </summary>
        /// <param name="entry">The high score entry to add.</param>
        public void Add(HighScoreEntry entry)
        {
            HighScores.Add(entry);
            HighScores = HighScores.OrderByDescending(h => h.Score)
                                   .ThenBy(h => h.DurationSeconds)
                                   .ToList();
            Save();
        }

        /// <summary>
        /// Clears all high score entries and saves the empty list.
        /// </summary>
        public void Reset()
        {
            HighScores.Clear();
            Save();
        }
    }
}
