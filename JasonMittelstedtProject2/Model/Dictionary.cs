using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JasonMittelstedtProject2.Model
{
    
    public class Dictionary
    {
        private List<DictionaryLetter> dictionary = null;

        public Dictionary() { dictionary = new();  }

        public Dictionary(List<DictionaryLetter> dict) {
            dictionary = dict;
        }
        public bool isEmpty() {
            if (dictionary.Count == 0)
            {
                return true;
            }
            else { 
                return false;
            }
        }

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
