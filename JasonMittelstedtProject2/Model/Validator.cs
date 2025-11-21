using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonMittelstedtProject2.Model
{
    public class Validator
    {
        public static string ValidateWord(string word, char[] letters, Dictionary dictionary, HashSet<string> alreadyValidWords)
        {
            if (string.IsNullOrWhiteSpace(word)) return "Empty";
            word = word.Trim().ToLowerInvariant();
            if (word.Length < 3) return "Word is too short";

            // letter availability
            var letterMapCount = new Dictionary<char, int>();
            foreach (var c in letters)
            {
                letterMapCount[char.ToLower(c)] = 0;
            }
            foreach (var c in letters)
            {
                letterMapCount[char.ToLower(c)]++;
            }

            foreach (var ch in word)
            {
                if (!letterMapCount.ContainsKey(ch))
                    return $"Invalid letter '{ch}'";
                if (letterMapCount[ch] == 0)
                    return $"Used'{ch}' too many times";
                letterMapCount[ch]--;
            }

            if (!dictionary.isFound(word))
                return "Not found in dictionary";

            if (alreadyValidWords.Contains(word))
                return "Word already used";

            return "";
        }

        public static int ScoreForWord(string word)
        {
            return word.Length switch
            {
                3 => 90,
                4 => 160,
                5 => 250,
                6 => 360,
                7 => 490,
                _ => 0
            };
        }
    }
}
