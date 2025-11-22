using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JasonMittelstedtProject2.Model
{
    /// <summary>
    /// Loads dictionary data from a JSON file and constructs
    /// a <see cref="Dictionary"/> object used for word validation.
    /// </summary>
    public class JsonDictionary
    {
        /// <summary>
        /// A set of words loaded from the JSON dictionary file.
        /// Primarily used for debugging or internal representation.
        /// </summary>
        public HashSet<string> Words { get; private set; } = new();

        /// <summary>
        /// Reference to the main form (unused placeholder property).
        /// </summary>
        public MainForm MainForm
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Loads the dictionary from a JSON file and converts the resulting
        /// list of <see cref="DictionaryLetter"/> objects into a <see cref="Dictionary"/>.
        /// </summary>
        /// <param name="fileName">The JSON file containing dictionary data.</param>
        /// <returns>
        /// A <see cref="Dictionary"/> populated from the JSON file,
        /// or an empty dictionary if the file is missing or invalid.
        /// </returns>
        public Dictionary Load(string fileName)
        {
            var completeFileName = Locator.getFileName(fileName);
            if (!File.Exists(completeFileName)) return new Dictionary();
            try
            {
                string json = File.ReadAllText(completeFileName);
                var list = JsonSerializer.Deserialize<List<DictionaryLetter>>(json) ?? new List<DictionaryLetter>();
                
                return new Dictionary(list);
            }
            catch { 
                return new Dictionary(); 
            }
        }
    }
}
