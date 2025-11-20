using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JasonMittelstedtProject2.Model
{
    public class LoadJsonDictionary
    {
        public HashSet<string> Words { get; private set; } = new();

        public Dictionary Load(string fileName)
        {
            string executePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string solutionPath = Directory.GetParent(executePath).Parent.Parent.Parent.FullName;
          
            string completeFileName = Path.Combine(solutionPath, "Data", fileName);
            if (!File.Exists(completeFileName)) return new Dictionary();
            try
            {
                string json = File.ReadAllText(completeFileName);
                var list = JsonSerializer.Deserialize<List<DictionaryLetter>>(json) ?? new List<DictionaryLetter>();
                
                return new Dictionary(list);
            }
            catch { return new Dictionary(); }
        }
    }
}
