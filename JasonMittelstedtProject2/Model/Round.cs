using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonMittelstedtProject2.Model
{
    /// <summary>
    /// Represents a single round of gameplay, including its start time,
    /// duration, letters provided to the player, and all valid and invalid
    /// words submitted during the round.
    /// </summary>
    public class Round
    {
        /// <summary>
        /// Gets or sets the UTC timestamp when the round began.
        /// </summary>
        public DateTime StartUtc { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// Gets or sets the total time allowed for the round, in seconds.
        /// </summary>
        public int DurationSeconds { get; set; } = 60;
        /// <summary>
        /// Gets or sets the set of seven letters assigned for the round.
        /// </summary>
        public char[] Letters { get; set; } = Array.Empty<char>();
        /// <summary>
        /// Gets the list of valid words submitted by the player during the round.
        /// </summary>
        public List<WordEntry> ValidWords { get; set; } = new();
        /// <summary>
        /// Gets the list of invalid words submitted by the player during the round,
        /// including reasons for invalidation.
        /// </summary>
        public List<WordEntry> InvalidWords { get; set; } = new();
        /// <summary>
        /// Calculates the total score for the round based on the valid words submitted.
        /// </summary>
        public int TotalScore => ValidWords.Sum(w => w.Points);

        /// <summary>
        /// Optional reference to the main form.
        /// </summary>
        public MainForm MainForm
        {
            get => default;
            set
            {
            }
        }
    }
}
