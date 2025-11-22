using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonMittelstedtProject2.Model
{
    /// <summary>
    /// Represents a single high score entry recorded in the game,
    /// including the player's name, score, duration of the round,
    /// and the UTC timestamp of when the score was recorded.
    /// </summary>
    public class HighScoreEntry
    {
        /// <summary>
        /// Gets or sets the name of the player who achieved the score.
        /// </summary>
        public string PlayerName { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the numeric score achieved by the player.
        /// </summary>
        public int Score { get; set; } = 0;
        /// <summary>
        /// Gets or sets the duration of the game round in seconds.
        /// Defaults to 60 seconds.
        /// </summary>
        public int DurationSeconds { get; set; } = 60;
        /// <summary>
        /// Gets or sets the date and time the score was recorded,
        /// stored in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime DateUtc { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Reference to the owning <see cref="MainForm"/>, if needed.
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
