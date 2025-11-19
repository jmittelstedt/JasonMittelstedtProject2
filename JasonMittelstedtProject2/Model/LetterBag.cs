using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonMittelstedtProject2.Model
{
    public class LetterBag
    {
        private readonly List<char> bag = new();
        private readonly Random rng = new();

        public static LetterBag CreateDefault()
        {
            var lb = new LetterBag();
            void add(string s, int n) { foreach (var c in s) for (int i = 0; i < n; i++) lb.bag.Add(c); }

            add("e", 11); add("t", 9); add("o", 8);
            add("a", 6); add("i", 6); add("n", 6); add("s", 6);
            add("h", 5); add("r", 5);
            add("l", 4);
            add("d", 3); add("u", 3); add("w", 3); add("y", 3);
            add("b", 2); add("c", 2); add("f", 2); add("g", 2); add("m", 2); add("p", 2); add("v", 2);
            add("j", 1); add("k", 1); add("q", 1); add("x", 1); add("z", 1);
            return lb;
        }

        public char[] DrawSeven()
        {
            if (bag.Count < 7) throw new InvalidOperationException("Not enough letters in bag.");
            var result = new List<char>(7);
            for (int i = 0; i < 7; i++)
            {
                int idx = rng.Next(bag.Count);
                result.Add(bag[idx]);
                bag.RemoveAt(idx);
            }
            return result.ToArray();
        }

        public static void Twist(ref char[] letters)
        {
            var rng = new Random();
            for (int i = letters.Length - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (letters[i], letters[j]) = (letters[j], letters[i]);
            }
        }

        public (bool, string) ValidateWord(string word, char[] letters, HashSet<string> dict, HashSet<string> alreadyValidWords)
        {
            if (string.IsNullOrWhiteSpace(word)) return (false, "Empty");
            word = word.Trim().ToLowerInvariant();
            if (word.Length < 3) return (false, "Word too short");

            // letter availability
            var letterCounts = new Dictionary<char, int>();
            foreach (var c in letters)
            {
                var low = char.ToLower(c);
                if (!letterCounts.ContainsKey(low)) letterCounts[low] = 0;
                letterCounts[low]++;
            }

            foreach (var ch in word)
            {
                if (!letterCounts.ContainsKey(ch) || letterCounts[ch] == 0)
                    return (false, $"Uses unavailable letter '{ch}'");
                letterCounts[ch]--;
            }

            if (!dict.Contains(word))
                return (false, "Not in dictionary");

            if (alreadyValidWords.Contains(word))
                return (false, "Already entered");

            return (true, "Valid");
        }

        public int ScoreForWord(string word)
        {
            int len = word.Length;
            return len switch
            {
                3 => 90,
                4 => 160,
                5 => 250,
                6 => 360,
                7 => 490,
                _ => 0 // treat >7 as invalid since only 7 letters available
            };
        }
    }
}
