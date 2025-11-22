using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JasonMittelstedtProject2.Model
{

    /// <summary>
    /// Represents the game's dictionary used for validating words.
    /// Stores a collection of <see cref="DictionaryLetter"/> entries,
    /// each containing a letter and all words beginning with that letter.
    /// </summary>
    public class Dictionary
    {
        /// <summary>
        /// Internal list of dictionary entries, each grouping words by starting letter.
        /// </summary>
        private List<DictionaryLetter> dictionary = null;

        /// <summary>
        /// Initializes an empty dictionary.
        /// </summary>
        public Dictionary() { dictionary = new();  }

        /// <summary>
        /// Initializes a dictionary using the provided list of <see cref="DictionaryLetter"/> entries.
        /// </summary>
        /// <param name="dict">The preloaded dictionary entries.</param>
        public Dictionary(List<DictionaryLetter> dict) {
            dictionary = dict;
        }

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

        /// <summary>
        /// Determines whether the dictionary contains any entries.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the dictionary has no entries; otherwise <c>false</c>.
        /// </returns>
        public bool isEmpty() {
            if (dictionary.Count == 0)
            {
                return true;
            }
            else { 
                return false;
            }
        }

        /// <summary>
        /// Checks whether the specified word exists in the dictionary.
        /// </summary>
        /// <param name="word">The word to search for.</param>
        /// <returns>
        /// <c>true</c> if the word is found; otherwise <c>false</c>.
        /// </returns>
        public bool isFound(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return false;
            char letter = word[0];
            DictionaryLetter foundLetter = dictionary.Find(dictionaryLetter => dictionaryLetter.letter == letter);
            if (foundLetter == null)
            {
                return false;
            }
            else {
                int index = Array.IndexOf(foundLetter.words, word);
                if (index == -1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
