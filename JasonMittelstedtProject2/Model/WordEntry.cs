using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonMittelstedtProject2.Model
{
    public class WordEntry
    {
        public string Word { get; set; }
        public bool IsValid { get; set; }
        public int Points { get; set; } = 0;
        public int GameTimeSeconds { get; set; } // seconds since round start
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string InvalidReason { get; set; } = string.Empty;
    }
}
