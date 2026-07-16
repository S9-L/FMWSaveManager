namespace FMWSaveManager.Editors
{
    partial class GeneralDataEditor
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
            PlaythroughGroupBox = new System.Windows.Forms.GroupBox();
            ChapterNameLabel = new System.Windows.Forms.Label();
            ChapterNameTextBox = new System.Windows.Forms.TextBox();
            ChapterIDLabel = new System.Windows.Forms.Label();
            RouteComboBox = new System.Windows.Forms.ComboBox();
            RouteLabel = new System.Windows.Forms.Label();
            DifficultyComboBox = new System.Windows.Forms.ComboBox();
            DifficultyLabel = new System.Windows.Forms.Label();
            TurnsTakenInc = new System.Windows.Forms.NumericUpDown();
            TurnsTakenLabel = new System.Windows.Forms.Label();
            ChapterNumInc = new System.Windows.Forms.NumericUpDown();
            ChapterNumberLabel = new System.Windows.Forms.Label();
            FirstPlaythoughLabel = new System.Windows.Forms.Label();
            PlaythroughsInc = new System.Windows.Forms.NumericUpDown();
            PlaythroughsLabel = new System.Windows.Forms.Label();
            PointsInc = new System.Windows.Forms.NumericUpDown();
            PointsLabel = new System.Windows.Forms.Label();
            WPInc = new System.Windows.Forms.NumericUpDown();
            WPLabel = new System.Windows.Forms.Label();
            BonusAchievedLabel = new System.Windows.Forms.Label();
            TotalBonusesLabel = new System.Windows.Forms.Label();
            BonusesInc = new System.Windows.Forms.NumericUpDown();
            TotalBonusesInc = new System.Windows.Forms.NumericUpDown();
            GameOverLabel = new System.Windows.Forms.Label();
            GameOverInc = new System.Windows.Forms.NumericUpDown();
            ArmyNameTextBox = new System.Windows.Forms.TextBox();
            ArmyNameLabel = new System.Windows.Forms.Label();
            MiscGroupBox = new System.Windows.Forms.GroupBox();
            ResourceGroupBox = new System.Windows.Forms.GroupBox();
            PlaythroughGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TurnsTakenInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ChapterNumInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlaythroughsInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PointsInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WPInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BonusesInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TotalBonusesInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GameOverInc).BeginInit();
            MiscGroupBox.SuspendLayout();
            ResourceGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // PlaythroughGroupBox
            // 
            PlaythroughGroupBox.Controls.Add(ChapterNameLabel);
            PlaythroughGroupBox.Controls.Add(ChapterNameTextBox);
            PlaythroughGroupBox.Controls.Add(ChapterIDLabel);
            PlaythroughGroupBox.Controls.Add(RouteComboBox);
            PlaythroughGroupBox.Controls.Add(RouteLabel);
            PlaythroughGroupBox.Controls.Add(DifficultyComboBox);
            PlaythroughGroupBox.Controls.Add(DifficultyLabel);
            PlaythroughGroupBox.Controls.Add(TurnsTakenInc);
            PlaythroughGroupBox.Controls.Add(TurnsTakenLabel);
            PlaythroughGroupBox.Controls.Add(ChapterNumInc);
            PlaythroughGroupBox.Controls.Add(ChapterNumberLabel);
            PlaythroughGroupBox.Controls.Add(FirstPlaythoughLabel);
            PlaythroughGroupBox.Controls.Add(PlaythroughsInc);
            PlaythroughGroupBox.Controls.Add(PlaythroughsLabel);
            PlaythroughGroupBox.Location = new System.Drawing.Point(3, 3);
            PlaythroughGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            PlaythroughGroupBox.Name = "PlaythroughGroupBox";
            PlaythroughGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            PlaythroughGroupBox.Size = new System.Drawing.Size(370, 295);
            PlaythroughGroupBox.TabIndex = 0;
            PlaythroughGroupBox.TabStop = false;
            PlaythroughGroupBox.Text = "Playthrough Info";
            // 
            // ChapterNameLabel
            // 
            ChapterNameLabel.AutoSize = true;
            ChapterNameLabel.Location = new System.Drawing.Point(38, 179);
            ChapterNameLabel.Name = "ChapterNameLabel";
            ChapterNameLabel.Size = new System.Drawing.Size(49, 20);
            ChapterNameLabel.TabIndex = 24;
            ChapterNameLabel.Text = "Name";
            // 
            // ChapterNameTextBox
            // 
            ChapterNameTextBox.Location = new System.Drawing.Point(89, 175);
            ChapterNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ChapterNameTextBox.Name = "ChapterNameTextBox";
            ChapterNameTextBox.ReadOnly = true;
            ChapterNameTextBox.Size = new System.Drawing.Size(274, 27);
            ChapterNameTextBox.TabIndex = 15;
            // 
            // ChapterIDLabel
            // 
            ChapterIDLabel.AutoSize = true;
            ChapterIDLabel.Location = new System.Drawing.Point(143, 139);
            ChapterIDLabel.Name = "ChapterIDLabel";
            ChapterIDLabel.Size = new System.Drawing.Size(80, 20);
            ChapterIDLabel.TabIndex = 14;
            ChapterIDLabel.Text = "Chapter ID";
            // 
            // RouteComboBox
            // 
            RouteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            RouteComboBox.FormattingEnabled = true;
            RouteComboBox.Location = new System.Drawing.Point(89, 32);
            RouteComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            RouteComboBox.Name = "RouteComboBox";
            RouteComboBox.Size = new System.Drawing.Size(97, 28);
            RouteComboBox.TabIndex = 2;
            RouteComboBox.SelectedIndexChanged += RouteComboBox_SelectedIndexChanged;
            // 
            // RouteLabel
            // 
            RouteLabel.AutoSize = true;
            RouteLabel.Location = new System.Drawing.Point(39, 36);
            RouteLabel.Name = "RouteLabel";
            RouteLabel.Size = new System.Drawing.Size(48, 20);
            RouteLabel.TabIndex = 7;
            RouteLabel.Text = "Route";
            // 
            // DifficultyComboBox
            // 
            DifficultyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            DifficultyComboBox.FormattingEnabled = true;
            DifficultyComboBox.Location = new System.Drawing.Point(89, 84);
            DifficultyComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            DifficultyComboBox.Name = "DifficultyComboBox";
            DifficultyComboBox.Size = new System.Drawing.Size(97, 28);
            DifficultyComboBox.TabIndex = 0;
            // 
            // DifficultyLabel
            // 
            DifficultyLabel.AutoSize = true;
            DifficultyLabel.Location = new System.Drawing.Point(19, 88);
            DifficultyLabel.Name = "DifficultyLabel";
            DifficultyLabel.Size = new System.Drawing.Size(69, 20);
            DifficultyLabel.TabIndex = 10;
            DifficultyLabel.Text = "Difficulty";
            // 
            // TurnsTakenInc
            // 
            TurnsTakenInc.Location = new System.Drawing.Point(89, 213);
            TurnsTakenInc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            TurnsTakenInc.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            TurnsTakenInc.Name = "TurnsTakenInc";
            TurnsTakenInc.Size = new System.Drawing.Size(71, 27);
            TurnsTakenInc.TabIndex = 4;
            // 
            // TurnsTakenLabel
            // 
            TurnsTakenLabel.AutoSize = true;
            TurnsTakenLabel.Location = new System.Drawing.Point(3, 216);
            TurnsTakenLabel.Name = "TurnsTakenLabel";
            TurnsTakenLabel.Size = new System.Drawing.Size(85, 20);
            TurnsTakenLabel.TabIndex = 8;
            TurnsTakenLabel.Text = "Turns Taken";
            // 
            // ChapterNumInc
            // 
            ChapterNumInc.Location = new System.Drawing.Point(89, 136);
            ChapterNumInc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ChapterNumInc.Maximum = new decimal(new int[] { 80, 0, 0, 0 });
            ChapterNumInc.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ChapterNumInc.Name = "ChapterNumInc";
            ChapterNumInc.Size = new System.Drawing.Size(47, 27);
            ChapterNumInc.TabIndex = 3;
            ChapterNumInc.Value = new decimal(new int[] { 1, 0, 0, 0 });
            ChapterNumInc.ValueChanged += ChapterNumInc_ValueChanged;
            // 
            // ChapterNumberLabel
            // 
            ChapterNumberLabel.AutoSize = true;
            ChapterNumberLabel.Location = new System.Drawing.Point(15, 139);
            ChapterNumberLabel.Name = "ChapterNumberLabel";
            ChapterNumberLabel.Size = new System.Drawing.Size(74, 20);
            ChapterNumberLabel.TabIndex = 9;
            ChapterNumberLabel.Text = "Chapter #";
            // 
            // FirstPlaythoughLabel
            // 
            FirstPlaythoughLabel.AutoSize = true;
            FirstPlaythoughLabel.Location = new System.Drawing.Point(143, 255);
            FirstPlaythoughLabel.Name = "FirstPlaythoughLabel";
            FirstPlaythoughLabel.Size = new System.Drawing.Size(140, 20);
            FirstPlaythoughLabel.TabIndex = 13;
            FirstPlaythoughLabel.Text = "Is First Playthrough?";
            // 
            // PlaythroughsInc
            // 
            PlaythroughsInc.Location = new System.Drawing.Point(89, 252);
            PlaythroughsInc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            PlaythroughsInc.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            PlaythroughsInc.Name = "PlaythroughsInc";
            PlaythroughsInc.Size = new System.Drawing.Size(47, 27);
            PlaythroughsInc.TabIndex = 0;
            PlaythroughsInc.ValueChanged += PlaythroughsInc_ValueChanged;
            // 
            // PlaythroughsLabel
            // 
            PlaythroughsLabel.AutoSize = true;
            PlaythroughsLabel.Location = new System.Drawing.Point(34, 255);
            PlaythroughsLabel.Name = "PlaythroughsLabel";
            PlaythroughsLabel.Size = new System.Drawing.Size(53, 20);
            PlaythroughsLabel.TabIndex = 0;
            PlaythroughsLabel.Text = "NG+ #";
            // 
            // PointsInc
            // 
            PointsInc.Location = new System.Drawing.Point(99, 33);
            PointsInc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            PointsInc.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            PointsInc.Name = "PointsInc";
            PointsInc.Size = new System.Drawing.Size(111, 27);
            PointsInc.TabIndex = 5;
            // 
            // PointsLabel
            // 
            PointsLabel.AutoSize = true;
            PointsLabel.Location = new System.Drawing.Point(47, 36);
            PointsLabel.Name = "PointsLabel";
            PointsLabel.Size = new System.Drawing.Size(48, 20);
            PointsLabel.TabIndex = 11;
            PointsLabel.Text = "Points";
            // 
            // WPInc
            // 
            WPInc.Location = new System.Drawing.Point(99, 85);
            WPInc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            WPInc.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            WPInc.Name = "WPInc";
            WPInc.Size = new System.Drawing.Size(111, 27);
            WPInc.TabIndex = 0;
            // 
            // WPLabel
            // 
            WPLabel.AutoSize = true;
            WPLabel.Location = new System.Drawing.Point(64, 88);
            WPLabel.Name = "WPLabel";
            WPLabel.Size = new System.Drawing.Size(31, 20);
            WPLabel.TabIndex = 12;
            WPLabel.Text = "WP";
            // 
            // BonusAchievedLabel
            // 
            BonusAchievedLabel.AutoSize = true;
            BonusAchievedLabel.Location = new System.Drawing.Point(47, 165);
            BonusAchievedLabel.Name = "BonusAchievedLabel";
            BonusAchievedLabel.Size = new System.Drawing.Size(128, 20);
            BonusAchievedLabel.TabIndex = 14;
            BonusAchievedLabel.Text = "Bonuses Achieved";
            // 
            // TotalBonusesLabel
            // 
            TotalBonusesLabel.AutoSize = true;
            TotalBonusesLabel.Location = new System.Drawing.Point(75, 217);
            TotalBonusesLabel.Name = "TotalBonusesLabel";
            TotalBonusesLabel.Size = new System.Drawing.Size(100, 20);
            TotalBonusesLabel.TabIndex = 15;
            TotalBonusesLabel.Text = "Total Bonuses";
            // 
            // BonusesInc
            // 
            BonusesInc.Location = new System.Drawing.Point(182, 163);
            BonusesInc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            BonusesInc.Maximum = new decimal(new int[] { 82, 0, 0, 0 });
            BonusesInc.Name = "BonusesInc";
            BonusesInc.Size = new System.Drawing.Size(47, 27);
            BonusesInc.TabIndex = 16;
            // 
            // TotalBonusesInc
            // 
            TotalBonusesInc.Location = new System.Drawing.Point(182, 215);
            TotalBonusesInc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            TotalBonusesInc.Maximum = new decimal(new int[] { 82, 0, 0, 0 });
            TotalBonusesInc.Name = "TotalBonusesInc";
            TotalBonusesInc.Size = new System.Drawing.Size(47, 27);
            TotalBonusesInc.TabIndex = 17;
            // 
            // GameOverLabel
            // 
            GameOverLabel.AutoSize = true;
            GameOverLabel.Location = new System.Drawing.Point(11, 35);
            GameOverLabel.Name = "GameOverLabel";
            GameOverLabel.Size = new System.Drawing.Size(89, 20);
            GameOverLabel.TabIndex = 18;
            GameOverLabel.Text = "Game Overs";
            // 
            // GameOverInc
            // 
            GameOverInc.Location = new System.Drawing.Point(99, 32);
            GameOverInc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            GameOverInc.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            GameOverInc.Name = "GameOverInc";
            GameOverInc.Size = new System.Drawing.Size(47, 27);
            GameOverInc.TabIndex = 19;
            // 
            // ArmyNameTextBox
            // 
            ArmyNameTextBox.Location = new System.Drawing.Point(99, 85);
            ArmyNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ArmyNameTextBox.Name = "ArmyNameTextBox";
            ArmyNameTextBox.Size = new System.Drawing.Size(313, 27);
            ArmyNameTextBox.TabIndex = 20;
            // 
            // ArmyNameLabel
            // 
            ArmyNameLabel.AutoSize = true;
            ArmyNameLabel.Location = new System.Drawing.Point(11, 88);
            ArmyNameLabel.Name = "ArmyNameLabel";
            ArmyNameLabel.Size = new System.Drawing.Size(88, 20);
            ArmyNameLabel.TabIndex = 21;
            ArmyNameLabel.Text = "Army Name";
            // 
            // MiscGroupBox
            // 
            MiscGroupBox.Controls.Add(GameOverInc);
            MiscGroupBox.Controls.Add(ArmyNameLabel);
            MiscGroupBox.Controls.Add(GameOverLabel);
            MiscGroupBox.Controls.Add(ArmyNameTextBox);
            MiscGroupBox.Location = new System.Drawing.Point(637, 3);
            MiscGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MiscGroupBox.Name = "MiscGroupBox";
            MiscGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MiscGroupBox.Size = new System.Drawing.Size(419, 295);
            MiscGroupBox.TabIndex = 22;
            MiscGroupBox.TabStop = false;
            MiscGroupBox.Text = "Misc. Info";
            // 
            // ResourceGroupBox
            // 
            ResourceGroupBox.Controls.Add(PointsLabel);
            ResourceGroupBox.Controls.Add(PointsInc);
            ResourceGroupBox.Controls.Add(TotalBonusesInc);
            ResourceGroupBox.Controls.Add(WPLabel);
            ResourceGroupBox.Controls.Add(BonusesInc);
            ResourceGroupBox.Controls.Add(WPInc);
            ResourceGroupBox.Controls.Add(TotalBonusesLabel);
            ResourceGroupBox.Controls.Add(BonusAchievedLabel);
            ResourceGroupBox.Location = new System.Drawing.Point(381, 3);
            ResourceGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ResourceGroupBox.Name = "ResourceGroupBox";
            ResourceGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ResourceGroupBox.Size = new System.Drawing.Size(249, 291);
            ResourceGroupBox.TabIndex = 23;
            ResourceGroupBox.TabStop = false;
            ResourceGroupBox.Text = "Resource Info";
            // 
            // GeneralDataEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(ResourceGroupBox);
            Controls.Add(MiscGroupBox);
            Controls.Add(PlaythroughGroupBox);
            Enabled = false;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "GeneralDataEditor";
            Size = new System.Drawing.Size(1059, 655);
            PlaythroughGroupBox.ResumeLayout(false);
            PlaythroughGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TurnsTakenInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)ChapterNumInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlaythroughsInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)PointsInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)WPInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)BonusesInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)TotalBonusesInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)GameOverInc).EndInit();
            MiscGroupBox.ResumeLayout(false);
            MiscGroupBox.PerformLayout();
            ResourceGroupBox.ResumeLayout(false);
            ResourceGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox PlaythroughGroupBox;
        private System.Windows.Forms.ComboBox DifficultyComboBox;
        private System.Windows.Forms.ComboBox RouteComboBox;
        private System.Windows.Forms.NumericUpDown ChapterNumInc;
        private System.Windows.Forms.NumericUpDown TurnsTakenInc;
        private System.Windows.Forms.NumericUpDown PointsInc;
        private System.Windows.Forms.Label RouteLabel;
        private System.Windows.Forms.Label TurnsTakenLabel;
        private System.Windows.Forms.Label ChapterNumberLabel;
        private System.Windows.Forms.Label DifficultyLabel;
        private System.Windows.Forms.Label PointsLabel;
        private System.Windows.Forms.NumericUpDown WPInc;
        private System.Windows.Forms.Label WPLabel;
        private System.Windows.Forms.NumericUpDown PlaythroughsInc;
        private System.Windows.Forms.Label PlaythroughsLabel;
        private System.Windows.Forms.Label FirstPlaythoughLabel;
        private System.Windows.Forms.Label BonusAchievedLabel;
        private System.Windows.Forms.Label TotalBonusesLabel;
        private System.Windows.Forms.NumericUpDown BonusesInc;
        private System.Windows.Forms.NumericUpDown TotalBonusesInc;
        private System.Windows.Forms.Label GameOverLabel;
        private System.Windows.Forms.NumericUpDown GameOverInc;
        private System.Windows.Forms.TextBox ArmyNameTextBox;
        private System.Windows.Forms.Label ArmyNameLabel;
        private System.Windows.Forms.GroupBox MiscGroupBox;
        private System.Windows.Forms.GroupBox ResourceGroupBox;
        private System.Windows.Forms.Label ChapterIDLabel;
        private System.Windows.Forms.TextBox ChapterNameTextBox;
        private System.Windows.Forms.Label ChapterNameLabel;
    }
}
