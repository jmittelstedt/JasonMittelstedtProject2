using JasonMittelstedtProject2.Model;
using System.Collections.Generic;
using Timer = System.Windows.Forms.Timer;

namespace JasonMittelstedtProject2
{
    /// <summary>
    /// The main Windows Form for the Text Twist game application.
    /// Handles game state, round flow, timers, UI updates,
    /// word validation, scoring, and high score management.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The current active game round.
        /// </summary>
        private Round currentRound = new();
        /// <summary>
        /// JSON-backed dictionary loader for word lookup.
        /// </summary>
        private JsonDictionary dict = new();
        /// <summary>
        /// Manages loading, saving, and adding player high scores.
        /// </summary>
        private HighScoreManager highScores = new();
        /// <summary>
        /// The 7 letters generated for the player this round.
        /// </summary>
        private char[] letters = new char[7];
        /// <summary>
        /// Tracks words the player has already submitted successfully.
        /// Prevents awarding points for duplicates.
        /// </summary>
        private HashSet<string> alreadyValid = new();
        /// <summary>
        /// Countdown timer for the current game round (in seconds).
        /// </summary>
        private int remainingSeconds = 0;
        /// <summary>
        /// Windows Forms timer that fires every second to update the UI countdown.
        /// </summary>
        private Timer gameTimer = new();
        /// <summary>
        /// The loaded dictionary containing all valid game words.
        /// </summary>
        private Dictionary dictionary = new();
        /// <summary>
        /// Player's cumulative score across all completed rounds of this session.
        /// </summary>
        private int sessionScore = 0;
        /// <summary>
        /// Initializes the main game window, loads the dictionary,
        /// and starts a new round if dictionary is valid.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.Text = "Text Twist by Mittelstedt";

            dictionary = dict.Load("dictionary.json");

            if (dictionary.isEmpty())
            {
                MessageBox.Show("dictionary.json missing or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                gameTimer.Interval = 1000;
                gameTimer.Tick += GameTimer_Tick;
                StartNewRound();
            }
        }

        /// <summary>
        /// Sets up a new game round by generating letters, resetting timers,
        /// clearing the UI, and starting the countdown.
        /// </summary>
        private void StartNewRound()
        {
            
            remainingSeconds = 120;

            LetterBag lb = LetterBag.CreateDefault();
            letters = lb.DrawSeven();
            currentRound = new Round { Letters = letters, DurationSeconds = remainingSeconds };
            alreadyValid.Clear();
            UpdateLetterButtons();
            txtCurrentWord.Text = "";
            lstValidWords.Items.Clear();
            lstValidWords.View = View.Details;
            lstValidWords.Columns[0].Width = 300;
            lstValidWords.Columns[0].Text = "Valid Words";
            lstInvalidWords.Items.Clear();
            lstInvalidWords.View = View.Details;
            lstInvalidWords.Columns[0].Width = 400;
            lstInvalidWords.Columns[0].Text = "Invalid Words";
            lblTimer.Text = TimeSpan.FromSeconds(remainingSeconds).ToString(@"mm\:ss");
            gameTimer.Start();
        }

        /// <summary>
        /// Updates the seven letter buttons on the UI to match the current round's letters.
        /// </summary>
        private void UpdateLetterButtons()
        {
            Button[] buttons = { btnLetter0, btnLetter1, btnLetter2, btnLetter3, btnLetter4, btnLetter5, btnLetter6 };
            for (int i = 0; i < 7; i++)
            {
                buttons[i].Text = letters[i].ToString().ToUpper();
                buttons[i].Enabled = true;
            }
        }

        /// <summary>
        /// Handles the countdown timer tick event. Updates the timer label,
        /// ends the round when time expires, saves high scores,
        /// and prompts the player to continue or exit.
        /// </summary>
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            remainingSeconds--;
            lblTimer.Text = TimeSpan.FromSeconds(remainingSeconds).ToString(@"mm\:ss");
            if (remainingSeconds <= 0)
            {
                gameTimer.Stop();
                sessionScore += currentRound.TotalScore;
                roundScoreLabel.Text = currentRound.TotalScore.ToString();
                sessionScoreLabel.Text = sessionScore.ToString();
                
                highScores.Load();
                highScores.Add(new HighScoreEntry { PlayerName = "Player", Score = currentRound.TotalScore, DurationSeconds = currentRound.DurationSeconds });
                highScores.Save();
                var result = MessageBox.Show(
                    $"Time's up! Round score: {currentRound.TotalScore} Do you want to play again?",
                    "Text Twist",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    StartNewRound();
                } else
                {
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// Enables all letter buttons. Used after clearing or submitting a word.
        /// </summary>
        private void EnableAllLetterButtons()
        {
            Button[] buttons = { btnLetter0, btnLetter1, btnLetter2, btnLetter3, btnLetter4, btnLetter5, btnLetter6 };
            foreach (var b in buttons) b.Enabled = true;
        }

        /// <summary>
        /// Handles the submit button: validates the word, scores it if valid,
        /// adds it to the appropriate list, and resets the current word input.
        /// </summary>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string word = txtCurrentWord.Text.Trim().ToLower();
            int elapsed = currentRound.DurationSeconds - remainingSeconds;

            var reason = Validator.ValidateWord(word, letters, dictionary, alreadyValid);
            var isValid = reason == "" ? true : false;
            var entry = new WordEntry { Word = word, GameTimeSeconds = elapsed, IsValid = isValid, InvalidReason = reason };
            if (isValid)
            {
                entry.Points = Validator.ScoreForWord(word);
                currentRound.ValidWords.Add(entry);
                alreadyValid.Add(word);
                lstValidWords.Items.Add($"{word} ({entry.Points})");
            }
            else
            {
                currentRound.InvalidWords.Add(entry);
                lstInvalidWords.Items.Add($"{word} ({reason})");
            }

            txtCurrentWord.Clear();
            EnableAllLetterButtons();
        }

        /// <summary>
        /// Clears the current word input and re-enables all letter selection buttons.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCurrentWord.Clear();
            EnableAllLetterButtons();
        }

        /// <summary>
        /// Randomly rearranges (twists) the current set of letters and updates the UI.
        /// </summary>
        private void btnTwist_Click(object sender, EventArgs e)
        {
            LetterBag.Twist(ref letters);
            UpdateLetterButtons();
        }

        /// <summary>
        /// Prevents non-letter characters from being typed in the word input box.
        /// </summary>
        private void txtCurrentWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Only allow letters through
            }
        }
    }
}
