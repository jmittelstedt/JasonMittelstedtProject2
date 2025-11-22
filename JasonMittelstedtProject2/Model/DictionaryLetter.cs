using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonMittelstedtProject2.Model
{
    /// <summary>
    /// Represents a dictionary entry containing a starting letter
    /// and the list of words that begin with that letter.
    /// Used as part of the JSON dictionary structure.
    /// </summary>
    public class DictionaryLetter
    {
        /// <summary>
        /// The letter associated with this dictionary entry.
        /// All words in <see cref="words"/> begin with this character.
        /// </summary>
        public char letter { get; set; }

        /// <summary>
        /// An array of all words that begin with the corresponding <see cref="letter"/>.
        /// </summary>
        public string[] words { get; set; }

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
    }
}
