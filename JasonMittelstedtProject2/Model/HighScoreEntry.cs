using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonMittelstedtProject2.Model
{
    public class HighScoreEntry
    {
        public string PlayerName { get; set; } = string.Empty;
        public int Score { get; set; } = 0;
        public int DurationSeconds { get; set; } = 60;
        public DateTime DateUtc { get; set; } = DateTime.UtcNow;
    }
}
