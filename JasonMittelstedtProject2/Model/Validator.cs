using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonMittelstedtProject2.Model
{
    /// <summary>
    /// Provides helper methods for validating player-submitted words 
    /// and calculating their score in the Text Twist game.
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// Reference to the main game form (unused placeholder property).
        /// </summary>
        public MainForm MainForm
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Validates a word entered by the player using game rules, 
        /// available letters, dictionary lookup, and previous submissions.
        /// </summary>
        /// <param name="word">The word submitted by the player.</param>
        /// <param name="letters">The set of 7 letters available in the current round.</param>
        /// <param name="dictionary">The dictionary used to check word validity.</param>
        /// <param name="alreadyValidWords">Words that were previously used and accepted.</param>
        /// <returns>
        ///   An empty string if the word is valid, or a reason describing why it is invalid:
        ///   <list type="bullet">
        ///     <item><description>"Empty"</description></item>
        ///     <item><description>"Word is too short"</description></item>
        ///     <item><description>"Invalid letter 'x'"</description></item>
        ///     <item><description>"Used 'x' too many times"</description></item>
        ///     <item><description>"Not found in dictionary"</description></item>
        ///     <item><description>"Word already used"</description></item>
        ///   </list>
        /// </returns>
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

        /// <summary>
        /// Calculates the score for a valid word based on its length.
        /// </summary>
        /// <param name="word">The valid player-submitted word.</param>
        /// <returns>
        /// The score awarded:
        /// <list type="bullet">
        ///   <item><description>3 letters = 90</description></item>
        ///   <item><description>4 letters = 160</description></item>
        ///   <item><description>5 letters = 250</description></item>
        ///   <item><description>6 letters = 360</description></item>
        ///   <item><description>7 letters = 490</description></item>
        ///   <item><description>All others = 0</description></item>
        /// </list>
        /// </returns>
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
