using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonMittelstedtProject2.Model
{
    /// <summary>
    /// Represents a collection of letter tiles used for random draws,
    /// similar to a Scrabble-style letter bag. Letters are added based
    /// on frequency and can be drawn or shuffled.
    /// </summary>
    public class LetterBag
    {
        /// <summary>
        /// Internal list holding all letters currently in the bag.
        /// </summary>
        private readonly List<char> bag = new();
        /// <summary>
        /// Random number generator used for drawing letters.
        /// </summary>
        private readonly Random random = new();

        /// <summary>
        /// Reference to the owning <see cref="MainForm"/> if needed.
        /// </summary>
        public MainForm MainForm
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Creates a default <see cref="LetterBag"/> pre-filled with letters
        /// according to English letter frequency distribution.
        /// </summary>
        /// <returns>A new populated <see cref="LetterBag"/> instance.</returns>
        public static LetterBag CreateDefault()
        {
            var lb = new LetterBag();

            lb.addToBag("e", 11);
            lb.addToBag("t", 9);
            lb.addToBag("o", 8);
            lb.addToBag("a", 6); lb.addToBag("i", 6); lb.addToBag("n", 6); lb.addToBag("s", 6);
            lb.addToBag("h", 5); lb.addToBag("r", 5);
            lb.addToBag("l", 4);
            lb.addToBag("d", 3); lb.addToBag("u", 3); lb.addToBag("w", 3); lb.addToBag("y", 3);
            lb.addToBag("b", 2); lb.addToBag("c", 2); lb.addToBag("f", 2); lb.addToBag("g", 2); lb.addToBag("m", 2); lb.addToBag("p", 2); lb.addToBag("v", 2);
            lb.addToBag("j", 1); lb.addToBag("k", 1); lb.addToBag("q", 1); lb.addToBag("x", 1); lb.addToBag("z", 1);
            return lb;
        }

        /// <summary>
        /// Randomly draws seven letters from the bag, ensuring that at least
        /// one vowel (a, e, i, o, u, or y) is included in the result.
        /// Letters are selected with replacement and are not removed from the bag.
        /// </summary>
        /// <returns>An array of seven randomly selected letters.</returns>
        public char[] DrawSeven()
        {
            var result = new List<char>();
            bool done = false;
            while (!done) {
                result = new List<char>();
                for (int i = 0; i < 7; i++)
                {
                    int idx = random.Next(bag.Count);
                    result.Add(bag[idx]);
                }
                done = result.Contains('a') || result.Contains('e') || result.Contains('i') || result.Contains('o') || result.Contains('u') || result.Contains('y');
            }
            return result.ToArray();
        }

        /// <summary>
        /// Randomly shuffles the given array of letters using the Fisher–Yates algorithm.
        /// </summary>
        /// <param name="letters">Reference to the letter array to shuffle.</param>
        public static void Twist(ref char[] letters)
        {
            var rng = new Random();
            for (int i = letters.Length - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                char temp = letters[i];
                letters[i] = letters[j];
                letters[j] = temp;
            }
        }

        /// <summary>
        /// Adds the specified character to the internal bag a given number of times.
        /// </summary>
        /// <param name="s">String containing the character(s) to add.</param>
        /// <param name="n">Number of times to add each character.</param>
        private void addToBag(string s, int n)
        {
            foreach (var c in s)
            {
                for (int i = 0; i < n; i++)
                {
                    bag.Add(c);
                }
            }
        }
    }
}
