using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool isFound(string word) {
            return false;
        }
    }
}
