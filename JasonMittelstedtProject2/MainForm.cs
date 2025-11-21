using JasonMittelstedtProject2.Model;
using System.Collections.Generic;
using Timer = System.Windows.Forms.Timer;

namespace JasonMittelstedtProject2
{
    public partial class MainForm : Form
    {
        private Round currentRound = new();
        private JsonDictionary dict = new();
        private HighScoreManager highScores = new();
        private char[] letters = new char[7];
        private HashSet<string> alreadyValid = new();
        private int remainingSeconds = 60;
        private Timer gameTimer = new();
        private Dictionary dictionary = new();
        public MainForm()
        {
            InitializeComponent();
            this.Text = "Text Twist by Mittelstedt";

            dictionary = dict.Load("dictionary.json");

            if (dictionary.isEmpty())
            {
                MessageBox.Show("dictionary.json missing or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {

                gameTimer.Interval = 1000;
                gameTimer.Tick += GameTimer_Tick;

                StartNewRound();
            }
        }

        private void StartNewRound()
        {
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

        private void UpdateLetterButtons()
        {
            Button[] buttons = { btnLetter0, btnLetter1, btnLetter2, btnLetter3, btnLetter4, btnLetter5, btnLetter6 };
            for (int i = 0; i < 7; i++)
            {
                buttons[i].Text = letters[i].ToString().ToUpper();
                buttons[i].Enabled = true;
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            remainingSeconds--;
            lblTimer.Text = TimeSpan.FromSeconds(remainingSeconds).ToString(@"mm\:ss");
            if (remainingSeconds <= 0)
            {
                gameTimer.Stop();
                MessageBox.Show($"Time's up! Round score: {currentRound.TotalScore}", "Round Over");
                highScores.Load();
                highScores.Add(new HighScoreEntry { PlayerName = "Player", Score = currentRound.TotalScore, DurationSeconds = currentRound.DurationSeconds });
                highScores.Save();
            }
        }

        private void EnableAllLetterButtons()
        {
            Button[] buttons = { btnLetter0, btnLetter1, btnLetter2, btnLetter3, btnLetter4, btnLetter5, btnLetter6 };
            foreach (var b in buttons) b.Enabled = true;
        }

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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCurrentWord.Clear();
            EnableAllLetterButtons();
        }

        private void btnTwist_Click(object sender, EventArgs e)
        {
            LetterBag.Twist(ref letters);
            UpdateLetterButtons();
        }
    }
}
