namespace JasonMittelstedtProject2
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLetter0 = new Button();
            btnLetter1 = new Button();
            btnLetter2 = new Button();
            btnLetter3 = new Button();
            btnLetter4 = new Button();
            btnLetter5 = new Button();
            btnLetter6 = new Button();
            btnSubmit = new Button();
            txtCurrentWord = new TextBox();
            lstValidWords = new ListView();
            columnHeader2 = new ColumnHeader();
            lstInvalidWords = new ListView();
            columnHeader1 = new ColumnHeader();
            lblTimer = new Label();
            lblRoundScore = new Label();
            lblSessionScore = new Label();
            menuStrip1 = new MenuStrip();
            btnClear = new Button();
            btnTwist = new Button();
            label1 = new Label();
            roundScoreLabel = new Label();
            sessionScoreLabel = new Label();
            SuspendLayout();
            // 
            // btnLetter0
            // 
            btnLetter0.Location = new Point(80, 148);
            btnLetter0.Name = "btnLetter0";
            btnLetter0.Size = new Size(94, 29);
            btnLetter0.TabIndex = 0;
            btnLetter0.Text = "button1";
            btnLetter0.UseVisualStyleBackColor = true;
            // 
            // btnLetter1
            // 
            btnLetter1.Location = new Point(215, 148);
            btnLetter1.Name = "btnLetter1";
            btnLetter1.Size = new Size(94, 29);
            btnLetter1.TabIndex = 1;
            btnLetter1.Text = "button1";
            btnLetter1.UseVisualStyleBackColor = true;
            // 
            // btnLetter2
            // 
            btnLetter2.Location = new Point(340, 148);
            btnLetter2.Name = "btnLetter2";
            btnLetter2.Size = new Size(94, 29);
            btnLetter2.TabIndex = 2;
            btnLetter2.Text = "button1";
            btnLetter2.UseVisualStyleBackColor = true;
            // 
            // btnLetter3
            // 
            btnLetter3.Location = new Point(467, 148);
            btnLetter3.Name = "btnLetter3";
            btnLetter3.Size = new Size(94, 29);
            btnLetter3.TabIndex = 3;
            btnLetter3.Text = "button1";
            btnLetter3.UseVisualStyleBackColor = true;
            // 
            // btnLetter4
            // 
            btnLetter4.Location = new Point(587, 148);
            btnLetter4.Name = "btnLetter4";
            btnLetter4.Size = new Size(94, 29);
            btnLetter4.TabIndex = 4;
            btnLetter4.Text = "button1";
            btnLetter4.UseVisualStyleBackColor = true;
            // 
            // btnLetter5
            // 
            btnLetter5.Location = new Point(718, 148);
            btnLetter5.Name = "btnLetter5";
            btnLetter5.Size = new Size(94, 29);
            btnLetter5.TabIndex = 5;
            btnLetter5.Text = "button1";
            btnLetter5.UseVisualStyleBackColor = true;
            // 
            // btnLetter6
            // 
            btnLetter6.Location = new Point(840, 148);
            btnLetter6.Name = "btnLetter6";
            btnLetter6.Size = new Size(94, 29);
            btnLetter6.TabIndex = 6;
            btnLetter6.Text = "button1";
            btnLetter6.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(60, 292);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 7;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // txtCurrentWord
            // 
            txtCurrentWord.Location = new Point(34, 225);
            txtCurrentWord.Multiline = true;
            txtCurrentWord.Name = "txtCurrentWord";
            txtCurrentWord.Size = new Size(125, 36);
            txtCurrentWord.TabIndex = 8;
            txtCurrentWord.KeyPress += txtCurrentWord_KeyPress;
            // 
            // lstValidWords
            // 
            lstValidWords.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
            lstValidWords.Location = new Point(180, 263);
            lstValidWords.Name = "lstValidWords";
            lstValidWords.Size = new Size(368, 255);
            lstValidWords.TabIndex = 9;
            lstValidWords.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader2
            // 
            columnHeader2.Width = -1;
            // 
            // lstInvalidWords
            // 
            lstInvalidWords.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            lstInvalidWords.Location = new Point(575, 263);
            lstInvalidWords.Name = "lstInvalidWords";
            lstInvalidWords.Size = new Size(422, 255);
            lstInvalidWords.TabIndex = 10;
            lstInvalidWords.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            columnHeader1.Width = -1;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Location = new Point(112, 58);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(47, 20);
            lblTimer.TabIndex = 11;
            lblTimer.Text = "Timer";
            // 
            // lblRoundScore
            // 
            lblRoundScore.AutoSize = true;
            lblRoundScore.Location = new Point(201, 58);
            lblRoundScore.Name = "lblRoundScore";
            lblRoundScore.Size = new Size(89, 20);
            lblRoundScore.TabIndex = 12;
            lblRoundScore.Text = "RoundScore";
            // 
            // lblSessionScore
            // 
            lblSessionScore.AutoSize = true;
            lblSessionScore.Location = new Point(312, 58);
            lblSessionScore.Name = "lblSessionScore";
            lblSessionScore.Size = new Size(95, 20);
            lblSessionScore.TabIndex = 13;
            lblSessionScore.Text = "SessionScore";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1031, 28);
            menuStrip1.TabIndex = 14;
            menuStrip1.Text = "menuStrip1";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(60, 327);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnTwist
            // 
            btnTwist.Location = new Point(60, 362);
            btnTwist.Name = "btnTwist";
            btnTwist.Size = new Size(94, 29);
            btnTwist.TabIndex = 16;
            btnTwist.Text = "Twist";
            btnTwist.UseVisualStyleBackColor = true;
            btnTwist.Click += btnTwist_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 193);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 17;
            label1.Text = "Enter word here";
            // 
            // roundScoreLabel
            // 
            roundScoreLabel.Location = new Point(201, 88);
            roundScoreLabel.Name = "roundScoreLabel";
            roundScoreLabel.Size = new Size(89, 25);
            roundScoreLabel.TabIndex = 18;
            // 
            // sessionScoreLabel
            // 
            sessionScoreLabel.Location = new Point(312, 88);
            sessionScoreLabel.Name = "sessionScoreLabel";
            sessionScoreLabel.Size = new Size(89, 25);
            sessionScoreLabel.TabIndex = 19;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1031, 530);
            Controls.Add(sessionScoreLabel);
            Controls.Add(roundScoreLabel);
            Controls.Add(label1);
            Controls.Add(btnTwist);
            Controls.Add(btnClear);
            Controls.Add(lblSessionScore);
            Controls.Add(lblRoundScore);
            Controls.Add(lblTimer);
            Controls.Add(lstInvalidWords);
            Controls.Add(lstValidWords);
            Controls.Add(txtCurrentWord);
            Controls.Add(btnSubmit);
            Controls.Add(btnLetter6);
            Controls.Add(btnLetter5);
            Controls.Add(btnLetter4);
            Controls.Add(btnLetter3);
            Controls.Add(btnLetter2);
            Controls.Add(btnLetter1);
            Controls.Add(btnLetter0);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Text Twist by Mittelstedt";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLetter0;
        private Button btnLetter1;
        private Button btnLetter2;
        private Button btnLetter3;
        private Button btnLetter4;
        private Button btnLetter5;
        private Button btnLetter6;
        private Button btnSubmit;
        private TextBox txtCurrentWord;
        private ListView lstValidWords;
        private ListView lstInvalidWords;
        private Label lblTimer;
        private Label lblRoundScore;
        private Label lblSessionScore;
        private MenuStrip menuStrip1;
        private Button btnClear;
        private Button btnTwist;
        private Label label1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Label roundScoreLabel;
        private Label sessionScoreLabel;
    }
}
