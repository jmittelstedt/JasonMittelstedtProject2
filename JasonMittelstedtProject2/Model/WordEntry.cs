using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonMittelstedtProject2.Model
{
    /// <summary>
    /// Represents a word submitted by the player during a round, including its
    /// validity, score value, submission time, and any invalidation reason.
    /// </summary>
    public class WordEntry
    {
        /// <summary>
        /// Gets or sets the word submitted by the player.
        /// </summary>
        public string Word { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the word was valid
        /// according to the game's dictionary and rules.
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// Gets or sets the number of points awarded for the word.
        /// This is only applied if the word is valid.
        /// </summary>
        public int Points { get; set; } = 0;
        /// <summary>
        /// Gets or sets the number of seconds elapsed in the round
        /// when the word was submitted.
        /// </summary>
        public int GameTimeSeconds { get; set; } // seconds since round start
        /// <summary>
        /// Gets or sets the timestamp (UTC) of when the word was submitted.
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// Gets or sets the reason the word was considered invalid,
        /// or an empty string if the word was valid.
        /// </summary>
        public string InvalidReason { get; set; } = string.Empty;

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
