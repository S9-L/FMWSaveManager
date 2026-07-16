namespace FMWSaveManager.Editors
{
    partial class ChapterEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ChapterListBox = new FMWSaveManager.Util.AlternateListBox();
            ClearedChapterGroupBox = new System.Windows.Forms.GroupBox();
            ClearTimeLabel = new System.Windows.Forms.Label();
            ClearTimeInc = new System.Windows.Forms.NumericUpDown();
            LoadsInc = new System.Windows.Forms.NumericUpDown();
            LoadsLabel = new System.Windows.Forms.Label();
            SavesInc = new System.Windows.Forms.NumericUpDown();
            SavesLabel = new System.Windows.Forms.Label();
            CasualtiesLabel = new System.Windows.Forms.Label();
            CasualtiesInc = new System.Windows.Forms.NumericUpDown();
            EnemiesLabel = new System.Windows.Forms.Label();
            EnemiesInc = new System.Windows.Forms.NumericUpDown();
            KillsLabel = new System.Windows.Forms.Label();
            KillsInc = new System.Windows.Forms.NumericUpDown();
            GameOverInc = new System.Windows.Forms.NumericUpDown();
            GameOverLabel = new System.Windows.Forms.Label();
            BonusCheckBox = new System.Windows.Forms.CheckBox();
            TotalSpellcardsCapturedInc = new System.Windows.Forms.NumericUpDown();
            SpellcardsInc = new System.Windows.Forms.NumericUpDown();
            TotalSpellcardsCapturedLabel = new System.Windows.Forms.Label();
            SpellcardsCapturedLabel = new System.Windows.Forms.Label();
            PointsLabel = new System.Windows.Forms.Label();
            PointsInc = new System.Windows.Forms.NumericUpDown();
            DifficultyComboBox = new System.Windows.Forms.ComboBox();
            DifficultyLabel = new System.Windows.Forms.Label();
            TurnsTakenInc = new System.Windows.Forms.NumericUpDown();
            TurnTakenLabel = new System.Windows.Forms.Label();
            ClearedChapterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ClearTimeInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LoadsInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SavesInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CasualtiesInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EnemiesInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KillsInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GameOverInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TotalSpellcardsCapturedInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SpellcardsInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PointsInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TurnsTakenInc).BeginInit();
            SuspendLayout();
            // 
            // ChapterListBox
            // 
            ChapterListBox.AlternateBackColorOnDraw = true;
            ChapterListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            ChapterListBox.FormattingEnabled = true;
            ChapterListBox.Location = new System.Drawing.Point(3, 3);
            ChapterListBox.Name = "ChapterListBox";
            ChapterListBox.Size = new System.Drawing.Size(143, 468);
            ChapterListBox.TabIndex = 18;
            ChapterListBox.SelectedIndexChanged += ChapterListBox_SelectedIndexChanged;
            // 
            // ClearedChapterGroupBox
            // 
            ClearedChapterGroupBox.Controls.Add(ClearTimeLabel);
            ClearedChapterGroupBox.Controls.Add(ClearTimeInc);
            ClearedChapterGroupBox.Controls.Add(LoadsInc);
            ClearedChapterGroupBox.Controls.Add(LoadsLabel);
            ClearedChapterGroupBox.Controls.Add(SavesInc);
            ClearedChapterGroupBox.Controls.Add(SavesLabel);
            ClearedChapterGroupBox.Controls.Add(CasualtiesLabel);
            ClearedChapterGroupBox.Controls.Add(CasualtiesInc);
            ClearedChapterGroupBox.Controls.Add(EnemiesLabel);
            ClearedChapterGroupBox.Controls.Add(EnemiesInc);
            ClearedChapterGroupBox.Controls.Add(KillsLabel);
            ClearedChapterGroupBox.Controls.Add(KillsInc);
            ClearedChapterGroupBox.Controls.Add(GameOverInc);
            ClearedChapterGroupBox.Controls.Add(GameOverLabel);
            ClearedChapterGroupBox.Controls.Add(BonusCheckBox);
            ClearedChapterGroupBox.Controls.Add(TotalSpellcardsCapturedInc);
            ClearedChapterGroupBox.Controls.Add(SpellcardsInc);
            ClearedChapterGroupBox.Controls.Add(TotalSpellcardsCapturedLabel);
            ClearedChapterGroupBox.Controls.Add(SpellcardsCapturedLabel);
            ClearedChapterGroupBox.Controls.Add(PointsLabel);
            ClearedChapterGroupBox.Controls.Add(PointsInc);
            ClearedChapterGroupBox.Controls.Add(DifficultyComboBox);
            ClearedChapterGroupBox.Controls.Add(DifficultyLabel);
            ClearedChapterGroupBox.Controls.Add(TurnsTakenInc);
            ClearedChapterGroupBox.Controls.Add(TurnTakenLabel);
            ClearedChapterGroupBox.Location = new System.Drawing.Point(152, 0);
            ClearedChapterGroupBox.Name = "ClearedChapterGroupBox";
            ClearedChapterGroupBox.Size = new System.Drawing.Size(393, 459);
            ClearedChapterGroupBox.TabIndex = 19;
            ClearedChapterGroupBox.TabStop = false;
            ClearedChapterGroupBox.Text = "Cleared Chapter Info";
            // 
            // ClearTimeLabel
            // 
            ClearTimeLabel.AutoSize = true;
            ClearTimeLabel.Location = new System.Drawing.Point(22, 115);
            ClearTimeLabel.Name = "ClearTimeLabel";
            ClearTimeLabel.Size = new System.Drawing.Size(63, 15);
            ClearTimeLabel.TabIndex = 88;
            ClearTimeLabel.Text = "Clear Time";
            // 
            // ClearTimeInc
            // 
            ClearTimeInc.Location = new System.Drawing.Point(97, 113);
            ClearTimeInc.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            ClearTimeInc.Name = "ClearTimeInc";
            ClearTimeInc.Size = new System.Drawing.Size(64, 23);
            ClearTimeInc.TabIndex = 87;
            // 
            // LoadsInc
            // 
            LoadsInc.Location = new System.Drawing.Point(120, 347);
            LoadsInc.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            LoadsInc.Name = "LoadsInc";
            LoadsInc.Size = new System.Drawing.Size(41, 23);
            LoadsInc.TabIndex = 86;
            // 
            // LoadsLabel
            // 
            LoadsLabel.AutoSize = true;
            LoadsLabel.Location = new System.Drawing.Point(76, 349);
            LoadsLabel.Name = "LoadsLabel";
            LoadsLabel.Size = new System.Drawing.Size(38, 15);
            LoadsLabel.TabIndex = 85;
            LoadsLabel.Text = "Loads";
            // 
            // SavesInc
            // 
            SavesInc.Location = new System.Drawing.Point(120, 313);
            SavesInc.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            SavesInc.Name = "SavesInc";
            SavesInc.Size = new System.Drawing.Size(41, 23);
            SavesInc.TabIndex = 84;
            // 
            // SavesLabel
            // 
            SavesLabel.AutoSize = true;
            SavesLabel.Location = new System.Drawing.Point(78, 315);
            SavesLabel.Name = "SavesLabel";
            SavesLabel.Size = new System.Drawing.Size(36, 15);
            SavesLabel.TabIndex = 83;
            SavesLabel.Text = "Saves";
            // 
            // CasualtiesLabel
            // 
            CasualtiesLabel.AutoSize = true;
            CasualtiesLabel.Location = new System.Drawing.Point(192, 349);
            CasualtiesLabel.Name = "CasualtiesLabel";
            CasualtiesLabel.Size = new System.Drawing.Size(60, 15);
            CasualtiesLabel.TabIndex = 82;
            CasualtiesLabel.Text = "Casualties";
            // 
            // CasualtiesInc
            // 
            CasualtiesInc.Location = new System.Drawing.Point(258, 347);
            CasualtiesInc.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            CasualtiesInc.Name = "CasualtiesInc";
            CasualtiesInc.Size = new System.Drawing.Size(64, 23);
            CasualtiesInc.TabIndex = 81;
            // 
            // EnemiesLabel
            // 
            EnemiesLabel.AutoSize = true;
            EnemiesLabel.Location = new System.Drawing.Point(167, 149);
            EnemiesLabel.Name = "EnemiesLabel";
            EnemiesLabel.Size = new System.Drawing.Size(51, 15);
            EnemiesLabel.TabIndex = 80;
            EnemiesLabel.Text = "Enemies";
            // 
            // EnemiesInc
            // 
            EnemiesInc.Location = new System.Drawing.Point(224, 147);
            EnemiesInc.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            EnemiesInc.Name = "EnemiesInc";
            EnemiesInc.Size = new System.Drawing.Size(64, 23);
            EnemiesInc.TabIndex = 79;
            // 
            // KillsLabel
            // 
            KillsLabel.AutoSize = true;
            KillsLabel.Location = new System.Drawing.Point(57, 149);
            KillsLabel.Name = "KillsLabel";
            KillsLabel.Size = new System.Drawing.Size(28, 15);
            KillsLabel.TabIndex = 78;
            KillsLabel.Text = "Kills";
            // 
            // KillsInc
            // 
            KillsInc.Location = new System.Drawing.Point(97, 147);
            KillsInc.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            KillsInc.Name = "KillsInc";
            KillsInc.Size = new System.Drawing.Size(64, 23);
            KillsInc.TabIndex = 77;
            // 
            // GameOverInc
            // 
            GameOverInc.Location = new System.Drawing.Point(120, 279);
            GameOverInc.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            GameOverInc.Name = "GameOverInc";
            GameOverInc.Size = new System.Drawing.Size(41, 23);
            GameOverInc.TabIndex = 76;
            // 
            // GameOverLabel
            // 
            GameOverLabel.AutoSize = true;
            GameOverLabel.Location = new System.Drawing.Point(43, 282);
            GameOverLabel.Name = "GameOverLabel";
            GameOverLabel.Size = new System.Drawing.Size(71, 15);
            GameOverLabel.TabIndex = 75;
            GameOverLabel.Text = "Game Overs";
            // 
            // BonusCheckBox
            // 
            BonusCheckBox.AutoSize = true;
            BonusCheckBox.Location = new System.Drawing.Point(45, 249);
            BonusCheckBox.Name = "BonusCheckBox";
            BonusCheckBox.Size = new System.Drawing.Size(116, 19);
            BonusCheckBox.TabIndex = 74;
            BonusCheckBox.Text = "Bonus Achieved?";
            BonusCheckBox.UseVisualStyleBackColor = true;
            BonusCheckBox.Click += BonusCheckBox_Click;
            // 
            // TotalSpellcardsCapturedInc
            // 
            TotalSpellcardsCapturedInc.Location = new System.Drawing.Point(338, 215);
            TotalSpellcardsCapturedInc.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            TotalSpellcardsCapturedInc.Name = "TotalSpellcardsCapturedInc";
            TotalSpellcardsCapturedInc.Size = new System.Drawing.Size(41, 23);
            TotalSpellcardsCapturedInc.TabIndex = 21;
            // 
            // SpellcardsInc
            // 
            SpellcardsInc.Location = new System.Drawing.Point(133, 215);
            SpellcardsInc.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            SpellcardsInc.Name = "SpellcardsInc";
            SpellcardsInc.Size = new System.Drawing.Size(41, 23);
            SpellcardsInc.TabIndex = 20;
            // 
            // TotalSpellcardsCapturedLabel
            // 
            TotalSpellcardsCapturedLabel.AutoSize = true;
            TotalSpellcardsCapturedLabel.Location = new System.Drawing.Point(182, 217);
            TotalSpellcardsCapturedLabel.Name = "TotalSpellcardsCapturedLabel";
            TotalSpellcardsCapturedLabel.Size = new System.Drawing.Size(140, 15);
            TotalSpellcardsCapturedLabel.TabIndex = 19;
            TotalSpellcardsCapturedLabel.Text = "Total Spellcards Captured";
            // 
            // SpellcardsCapturedLabel
            // 
            SpellcardsCapturedLabel.AutoSize = true;
            SpellcardsCapturedLabel.Location = new System.Drawing.Point(10, 217);
            SpellcardsCapturedLabel.Name = "SpellcardsCapturedLabel";
            SpellcardsCapturedLabel.Size = new System.Drawing.Size(112, 15);
            SpellcardsCapturedLabel.TabIndex = 18;
            SpellcardsCapturedLabel.Text = "Spellcards Captured";
            // 
            // PointsLabel
            // 
            PointsLabel.AutoSize = true;
            PointsLabel.Location = new System.Drawing.Point(45, 183);
            PointsLabel.Name = "PointsLabel";
            PointsLabel.Size = new System.Drawing.Size(40, 15);
            PointsLabel.TabIndex = 16;
            PointsLabel.Text = "Points";
            // 
            // PointsInc
            // 
            PointsInc.Location = new System.Drawing.Point(97, 181);
            PointsInc.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            PointsInc.Name = "PointsInc";
            PointsInc.Size = new System.Drawing.Size(97, 23);
            PointsInc.TabIndex = 15;
            // 
            // DifficultyComboBox
            // 
            DifficultyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            DifficultyComboBox.FormattingEnabled = true;
            DifficultyComboBox.Location = new System.Drawing.Point(97, 45);
            DifficultyComboBox.Name = "DifficultyComboBox";
            DifficultyComboBox.Size = new System.Drawing.Size(85, 23);
            DifficultyComboBox.TabIndex = 11;
            // 
            // DifficultyLabel
            // 
            DifficultyLabel.AutoSize = true;
            DifficultyLabel.Location = new System.Drawing.Point(30, 48);
            DifficultyLabel.Name = "DifficultyLabel";
            DifficultyLabel.Size = new System.Drawing.Size(55, 15);
            DifficultyLabel.TabIndex = 14;
            DifficultyLabel.Text = "Difficulty";
            // 
            // TurnsTakenInc
            // 
            TurnsTakenInc.Location = new System.Drawing.Point(97, 79);
            TurnsTakenInc.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            TurnsTakenInc.Name = "TurnsTakenInc";
            TurnsTakenInc.Size = new System.Drawing.Size(64, 23);
            TurnsTakenInc.TabIndex = 12;
            // 
            // TurnTakenLabel
            // 
            TurnTakenLabel.AutoSize = true;
            TurnTakenLabel.Location = new System.Drawing.Point(16, 81);
            TurnTakenLabel.Name = "TurnTakenLabel";
            TurnTakenLabel.Size = new System.Drawing.Size(69, 15);
            TurnTakenLabel.TabIndex = 13;
            TurnTakenLabel.Text = "Turns Taken";
            // 
            // ChapterEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(ClearedChapterGroupBox);
            Controls.Add(ChapterListBox);
            Enabled = false;
            Name = "ChapterEditor";
            Size = new System.Drawing.Size(927, 471);
            ClearedChapterGroupBox.ResumeLayout(false);
            ClearedChapterGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ClearTimeInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)LoadsInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)SavesInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)CasualtiesInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)EnemiesInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)KillsInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)GameOverInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)TotalSpellcardsCapturedInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)SpellcardsInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)PointsInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)TurnsTakenInc).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Util.AlternateListBox ChapterListBox;
        private System.Windows.Forms.GroupBox ClearedChapterGroupBox;
        private System.Windows.Forms.ComboBox DifficultyComboBox;
        private System.Windows.Forms.Label DifficultyLabel;
        private System.Windows.Forms.NumericUpDown TurnsTakenInc;
        private System.Windows.Forms.Label TurnTakenLabel;
        private System.Windows.Forms.Label PointsLabel;
        private System.Windows.Forms.NumericUpDown PointsInc;
        private System.Windows.Forms.NumericUpDown TotalSpellcardsCapturedInc;
        private System.Windows.Forms.NumericUpDown SpellcardsInc;
        private System.Windows.Forms.Label TotalSpellcardsCapturedLabel;
        private System.Windows.Forms.Label SpellcardsCapturedLabel;
        private System.Windows.Forms.CheckBox BonusCheckBox;
        private System.Windows.Forms.NumericUpDown GameOverInc;
        private System.Windows.Forms.Label GameOverLabel;
        private System.Windows.Forms.Label KillsLabel;
        private System.Windows.Forms.NumericUpDown KillsInc;
        private System.Windows.Forms.Label EnemiesLabel;
        private System.Windows.Forms.NumericUpDown EnemiesInc;
        private System.Windows.Forms.Label CasualtiesLabel;
        private System.Windows.Forms.NumericUpDown CasualtiesInc;
        private System.Windows.Forms.NumericUpDown LoadsInc;
        private System.Windows.Forms.Label LoadsLabel;
        private System.Windows.Forms.NumericUpDown SavesInc;
        private System.Windows.Forms.Label SavesLabel;
        private System.Windows.Forms.Label ClearTimeLabel;
        private System.Windows.Forms.NumericUpDown ClearTimeInc;
    }
}
