using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JasonMittelstedtProject2.Model
{
    public class DictionaryLoader
    {
        public HashSet<string> Words { get; private set; } = new();

        public bool Load(string path)
        {
            if (!File.Exists(path)) return false;
            try
            {
                string json = File.ReadAllText(path);
                var list = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
                Words = new HashSet<string>(list.Select(w => w.ToLowerInvariant()));
                return true;
            }
            catch { return false; }
        }

        public bool Contains(string word) => Words.Contains(word.ToLowerInvariant());
    }
}
