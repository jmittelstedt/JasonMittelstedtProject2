using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonMittelstedtProject2.Model
{
    public class Round
    {
        public DateTime StartUtc { get; set; } = DateTime.UtcNow;
        public int DurationSeconds { get; set; } = 60;
        public char[] Letters { get; set; } = Array.Empty<char>();
        public List<WordEntry> ValidWords { get; set; } = new();
        public List<WordEntry> InvalidWords { get; set; } = new();
        public int TotalScore => ValidWords.Sum(w => w.Points);
    }
}
