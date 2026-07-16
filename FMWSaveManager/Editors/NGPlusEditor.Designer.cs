namespace FMWSaveManager.Editors
{
    partial class NGPlusEditor
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
            CTotalPointsLabel = new System.Windows.Forms.Label();
            CTotalWPCarryover = new System.Windows.Forms.Label();
            CTotalPointsInc = new System.Windows.Forms.NumericUpDown();
            CTotalWPInc = new System.Windows.Forms.NumericUpDown();
            CarryoverGroupBox = new System.Windows.Forms.GroupBox();
            NGPlusUnitGroupBox = new System.Windows.Forms.GroupBox();
            UnitNameTextBox = new System.Windows.Forms.TextBox();
            UnitNameLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            UnitIDTextBox = new System.Windows.Forms.TextBox();
            NGPlusUnitListBox = new FMWSaveManager.Util.AlternateListBox();
            NGPlusCharListBox = new FMWSaveManager.Util.AlternateListBox();
            NGPlusCharGroupBox = new System.Windows.Forms.GroupBox();
            KillsCarryoverLabel = new System.Windows.Forms.Label();
            CarryoverPPLabel = new System.Windows.Forms.Label();
            CKillsInc = new System.Windows.Forms.NumericUpDown();
            CPPInc = new System.Windows.Forms.NumericUpDown();
            CharNameTextBox = new System.Windows.Forms.TextBox();
            CharacterNameLabel = new System.Windows.Forms.Label();
            UnitIDLabel = new System.Windows.Forms.Label();
            CharIDTextBox = new System.Windows.Forms.TextBox();
            RemoveNGPlusUnitButton = new System.Windows.Forms.Button();
            AddNGPlusUnitButton = new System.Windows.Forms.Button();
            RemoveNGPlusCharButton = new System.Windows.Forms.Button();
            AddNGPlusCharButton = new System.Windows.Forms.Button();
            AlphabetSortUnitCheckBox = new System.Windows.Forms.CheckBox();
            AlphabetSortCharCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)CTotalPointsInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CTotalWPInc).BeginInit();
            CarryoverGroupBox.SuspendLayout();
            NGPlusUnitGroupBox.SuspendLayout();
            NGPlusCharGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CKillsInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CPPInc).BeginInit();
            SuspendLayout();
            // 
            // CTotalPointsLabel
            // 
            CTotalPointsLabel.AutoSize = true;
            CTotalPointsLabel.Location = new System.Drawing.Point(24, 46);
            CTotalPointsLabel.Name = "CTotalPointsLabel";
            CTotalPointsLabel.Size = new System.Drawing.Size(122, 15);
            CTotalPointsLabel.TabIndex = 0;
            CTotalPointsLabel.Text = "Total Points Carryover";
            // 
            // CTotalWPCarryover
            // 
            CTotalWPCarryover.AutoSize = true;
            CTotalWPCarryover.Location = new System.Drawing.Point(39, 83);
            CTotalWPCarryover.Name = "CTotalWPCarryover";
            CTotalWPCarryover.Size = new System.Drawing.Size(107, 15);
            CTotalWPCarryover.TabIndex = 2;
            CTotalWPCarryover.Text = "Total WP Carryover";
            // 
            // CTotalPointsInc
            // 
            CTotalPointsInc.Location = new System.Drawing.Point(171, 43);
            CTotalPointsInc.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            CTotalPointsInc.Name = "CTotalPointsInc";
            CTotalPointsInc.Size = new System.Drawing.Size(121, 23);
            CTotalPointsInc.TabIndex = 3;
            // 
            // CTotalWPInc
            // 
            CTotalWPInc.Location = new System.Drawing.Point(171, 80);
            CTotalWPInc.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            CTotalWPInc.Name = "CTotalWPInc";
            CTotalWPInc.Size = new System.Drawing.Size(121, 23);
            CTotalWPInc.TabIndex = 4;
            // 
            // CarryoverGroupBox
            // 
            CarryoverGroupBox.Controls.Add(CTotalPointsLabel);
            CarryoverGroupBox.Controls.Add(CTotalWPInc);
            CarryoverGroupBox.Controls.Add(CTotalWPCarryover);
            CarryoverGroupBox.Controls.Add(CTotalPointsInc);
            CarryoverGroupBox.Location = new System.Drawing.Point(625, 0);
            CarryoverGroupBox.Name = "CarryoverGroupBox";
            CarryoverGroupBox.Size = new System.Drawing.Size(302, 379);
            CarryoverGroupBox.TabIndex = 5;
            CarryoverGroupBox.TabStop = false;
            CarryoverGroupBox.Text = "Carryover Info";
            // 
            // NGPlusUnitGroupBox
            // 
            NGPlusUnitGroupBox.Controls.Add(UnitNameTextBox);
            NGPlusUnitGroupBox.Controls.Add(UnitNameLabel);
            NGPlusUnitGroupBox.Controls.Add(label1);
            NGPlusUnitGroupBox.Controls.Add(UnitIDTextBox);
            NGPlusUnitGroupBox.Location = new System.Drawing.Point(113, 0);
            NGPlusUnitGroupBox.Name = "NGPlusUnitGroupBox";
            NGPlusUnitGroupBox.Size = new System.Drawing.Size(195, 379);
            NGPlusUnitGroupBox.TabIndex = 6;
            NGPlusUnitGroupBox.TabStop = false;
            NGPlusUnitGroupBox.Text = "NG+ Unit Info";
            // 
            // UnitNameTextBox
            // 
            UnitNameTextBox.Location = new System.Drawing.Point(56, 43);
            UnitNameTextBox.Name = "UnitNameTextBox";
            UnitNameTextBox.Size = new System.Drawing.Size(116, 23);
            UnitNameTextBox.TabIndex = 15;
            // 
            // UnitNameLabel
            // 
            UnitNameLabel.AutoSize = true;
            UnitNameLabel.Location = new System.Drawing.Point(11, 46);
            UnitNameLabel.Name = "UnitNameLabel";
            UnitNameLabel.Size = new System.Drawing.Size(39, 15);
            UnitNameLabel.TabIndex = 14;
            UnitNameLabel.Text = "Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 83);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 15);
            label1.TabIndex = 16;
            label1.Text = "Unit ID";
            // 
            // UnitIDTextBox
            // 
            UnitIDTextBox.Location = new System.Drawing.Point(56, 80);
            UnitIDTextBox.Name = "UnitIDTextBox";
            UnitIDTextBox.Size = new System.Drawing.Size(116, 23);
            UnitIDTextBox.TabIndex = 17;
            // 
            // NGPlusUnitListBox
            // 
            NGPlusUnitListBox.AlternateBackColorOnDraw = true;
            NGPlusUnitListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            NGPlusUnitListBox.FormattingEnabled = true;
            NGPlusUnitListBox.Location = new System.Drawing.Point(3, 3);
            NGPlusUnitListBox.Name = "NGPlusUnitListBox";
            NGPlusUnitListBox.Size = new System.Drawing.Size(104, 388);
            NGPlusUnitListBox.TabIndex = 7;
            NGPlusUnitListBox.SelectedIndexChanged += NGPlusUnitListBox_SelectedIndexChanged;
            // 
            // NGPlusCharListBox
            // 
            NGPlusCharListBox.AlternateBackColorOnDraw = true;
            NGPlusCharListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            NGPlusCharListBox.FormattingEnabled = true;
            NGPlusCharListBox.Location = new System.Drawing.Point(314, 3);
            NGPlusCharListBox.Name = "NGPlusCharListBox";
            NGPlusCharListBox.Size = new System.Drawing.Size(104, 388);
            NGPlusCharListBox.TabIndex = 8;
            NGPlusCharListBox.SelectedIndexChanged += NGPlusCharListBox_SelectedIndexChanged;
            // 
            // NGPlusCharGroupBox
            // 
            NGPlusCharGroupBox.Controls.Add(KillsCarryoverLabel);
            NGPlusCharGroupBox.Controls.Add(CarryoverPPLabel);
            NGPlusCharGroupBox.Controls.Add(CKillsInc);
            NGPlusCharGroupBox.Controls.Add(CPPInc);
            NGPlusCharGroupBox.Controls.Add(CharNameTextBox);
            NGPlusCharGroupBox.Controls.Add(CharacterNameLabel);
            NGPlusCharGroupBox.Controls.Add(UnitIDLabel);
            NGPlusCharGroupBox.Controls.Add(CharIDTextBox);
            NGPlusCharGroupBox.Location = new System.Drawing.Point(424, 0);
            NGPlusCharGroupBox.Name = "NGPlusCharGroupBox";
            NGPlusCharGroupBox.Size = new System.Drawing.Size(195, 379);
            NGPlusCharGroupBox.TabIndex = 7;
            NGPlusCharGroupBox.TabStop = false;
            NGPlusCharGroupBox.Text = "NG+ Character Info";
            // 
            // KillsCarryoverLabel
            // 
            KillsCarryoverLabel.AutoSize = true;
            KillsCarryoverLabel.Location = new System.Drawing.Point(17, 163);
            KillsCarryoverLabel.Name = "KillsCarryoverLabel";
            KillsCarryoverLabel.Size = new System.Drawing.Size(82, 15);
            KillsCarryoverLabel.TabIndex = 79;
            KillsCarryoverLabel.Text = "Kills Carryover";
            // 
            // CarryoverPPLabel
            // 
            CarryoverPPLabel.AutoSize = true;
            CarryoverPPLabel.Location = new System.Drawing.Point(24, 126);
            CarryoverPPLabel.Name = "CarryoverPPLabel";
            CarryoverPPLabel.Size = new System.Drawing.Size(75, 15);
            CarryoverPPLabel.TabIndex = 81;
            CarryoverPPLabel.Text = "PP Carryover";
            // 
            // CKillsInc
            // 
            CKillsInc.Location = new System.Drawing.Point(114, 161);
            CKillsInc.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            CKillsInc.Name = "CKillsInc";
            CKillsInc.Size = new System.Drawing.Size(64, 23);
            CKillsInc.TabIndex = 78;
            // 
            // CPPInc
            // 
            CPPInc.Location = new System.Drawing.Point(114, 124);
            CPPInc.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            CPPInc.Name = "CPPInc";
            CPPInc.Size = new System.Drawing.Size(64, 23);
            CPPInc.TabIndex = 80;
            // 
            // CharNameTextBox
            // 
            CharNameTextBox.Location = new System.Drawing.Point(62, 43);
            CharNameTextBox.Name = "CharNameTextBox";
            CharNameTextBox.Size = new System.Drawing.Size(116, 23);
            CharNameTextBox.TabIndex = 39;
            // 
            // CharacterNameLabel
            // 
            CharacterNameLabel.AutoSize = true;
            CharacterNameLabel.Location = new System.Drawing.Point(17, 46);
            CharacterNameLabel.Name = "CharacterNameLabel";
            CharacterNameLabel.Size = new System.Drawing.Size(39, 15);
            CharacterNameLabel.TabIndex = 38;
            CharacterNameLabel.Text = "Name";
            // 
            // UnitIDLabel
            // 
            UnitIDLabel.AutoSize = true;
            UnitIDLabel.Location = new System.Drawing.Point(10, 83);
            UnitIDLabel.Name = "UnitIDLabel";
            UnitIDLabel.Size = new System.Drawing.Size(46, 15);
            UnitIDLabel.TabIndex = 40;
            UnitIDLabel.Text = "Char ID";
            // 
            // CharIDTextBox
            // 
            CharIDTextBox.Location = new System.Drawing.Point(62, 80);
            CharIDTextBox.Name = "CharIDTextBox";
            CharIDTextBox.Size = new System.Drawing.Size(116, 23);
            CharIDTextBox.TabIndex = 41;
            // 
            // RemoveNGPlusUnitButton
            // 
            RemoveNGPlusUnitButton.Location = new System.Drawing.Point(3, 424);
            RemoveNGPlusUnitButton.Name = "RemoveNGPlusUnitButton";
            RemoveNGPlusUnitButton.Size = new System.Drawing.Size(104, 30);
            RemoveNGPlusUnitButton.TabIndex = 85;
            RemoveNGPlusUnitButton.Text = "Remove";
            RemoveNGPlusUnitButton.UseVisualStyleBackColor = true;
            RemoveNGPlusUnitButton.Click += RemoveNGPlusUnitButton_Click;
            // 
            // AddNGPlusUnitButton
            // 
            AddNGPlusUnitButton.Location = new System.Drawing.Point(3, 388);
            AddNGPlusUnitButton.Name = "AddNGPlusUnitButton";
            AddNGPlusUnitButton.Size = new System.Drawing.Size(104, 30);
            AddNGPlusUnitButton.TabIndex = 84;
            AddNGPlusUnitButton.Text = "Add";
            AddNGPlusUnitButton.UseVisualStyleBackColor = true;
            AddNGPlusUnitButton.Click += AddNGPlusUnitButton_Click;
            // 
            // RemoveNGPlusCharButton
            // 
            RemoveNGPlusCharButton.Location = new System.Drawing.Point(314, 424);
            RemoveNGPlusCharButton.Name = "RemoveNGPlusCharButton";
            RemoveNGPlusCharButton.Size = new System.Drawing.Size(104, 30);
            RemoveNGPlusCharButton.TabIndex = 87;
            RemoveNGPlusCharButton.Text = "Remove";
            RemoveNGPlusCharButton.UseVisualStyleBackColor = true;
            RemoveNGPlusCharButton.Click += RemoveNGPlusCharButton_Click;
            // 
            // AddNGPlusCharButton
            // 
            AddNGPlusCharButton.Location = new System.Drawing.Point(314, 388);
            AddNGPlusCharButton.Name = "AddNGPlusCharButton";
            AddNGPlusCharButton.Size = new System.Drawing.Size(104, 30);
            AddNGPlusCharButton.TabIndex = 86;
            AddNGPlusCharButton.Text = "Add";
            AddNGPlusCharButton.UseVisualStyleBackColor = true;
            AddNGPlusCharButton.Click += AddNGPlusCharButton_Click;
            // 
            // AlphabetSortUnitCheckBox
            // 
            AlphabetSortUnitCheckBox.AutoSize = true;
            AlphabetSortUnitCheckBox.Location = new System.Drawing.Point(113, 385);
            AlphabetSortUnitCheckBox.Name = "AlphabetSortUnitCheckBox";
            AlphabetSortUnitCheckBox.Size = new System.Drawing.Size(70, 19);
            AlphabetSortUnitCheckBox.TabIndex = 88;
            AlphabetSortUnitCheckBox.Text = "A-Z Sort";
            AlphabetSortUnitCheckBox.UseVisualStyleBackColor = true;
            AlphabetSortUnitCheckBox.Click += AlphabetSortUnitCheckBox_Click;
            // 
            // AlphabetSortCharCheckBox
            // 
            AlphabetSortCharCheckBox.AutoSize = true;
            AlphabetSortCharCheckBox.Location = new System.Drawing.Point(424, 385);
            AlphabetSortCharCheckBox.Name = "AlphabetSortCharCheckBox";
            AlphabetSortCharCheckBox.Size = new System.Drawing.Size(70, 19);
            AlphabetSortCharCheckBox.TabIndex = 89;
            AlphabetSortCharCheckBox.Text = "A-Z Sort";
            AlphabetSortCharCheckBox.UseVisualStyleBackColor = true;
            AlphabetSortCharCheckBox.Click += AlphabetSortCharCheckBox_Click;
            // 
            // NGPlusEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(AlphabetSortCharCheckBox);
            Controls.Add(AlphabetSortUnitCheckBox);
            Controls.Add(RemoveNGPlusCharButton);
            Controls.Add(AddNGPlusCharButton);
            Controls.Add(RemoveNGPlusUnitButton);
            Controls.Add(AddNGPlusUnitButton);
            Controls.Add(NGPlusCharGroupBox);
            Controls.Add(NGPlusCharListBox);
            Controls.Add(NGPlusUnitListBox);
            Controls.Add(NGPlusUnitGroupBox);
            Controls.Add(CarryoverGroupBox);
            Enabled = false;
            Name = "NGPlusEditor";
            Size = new System.Drawing.Size(927, 471);
            ((System.ComponentModel.ISupportInitialize)CTotalPointsInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)CTotalWPInc).EndInit();
            CarryoverGroupBox.ResumeLayout(false);
            CarryoverGroupBox.PerformLayout();
            NGPlusUnitGroupBox.ResumeLayout(false);
            NGPlusUnitGroupBox.PerformLayout();
            NGPlusCharGroupBox.ResumeLayout(false);
            NGPlusCharGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CKillsInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)CPPInc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label CTotalPointsLabel;
        private System.Windows.Forms.Label CTotalWPCarryover;
        private System.Windows.Forms.NumericUpDown CTotalPointsInc;
        private System.Windows.Forms.NumericUpDown CTotalWPInc;
        private System.Windows.Forms.GroupBox CarryoverGroupBox;
        private System.Windows.Forms.GroupBox NGPlusUnitGroupBox;
        private Util.AlternateListBox NGPlusUnitListBox;
        private Util.AlternateListBox NGPlusCharListBox;
        private System.Windows.Forms.GroupBox NGPlusCharGroupBox;
        private System.Windows.Forms.TextBox CharNameTextBox;
        private System.Windows.Forms.Label CharacterNameLabel;
        private System.Windows.Forms.Label UnitIDLabel;
        private System.Windows.Forms.TextBox CharIDTextBox;
        private System.Windows.Forms.TextBox UnitNameTextBox;
        private System.Windows.Forms.Label UnitNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UnitIDTextBox;
        private System.Windows.Forms.Button RemoveNGPlusUnitButton;
        private System.Windows.Forms.Button AddNGPlusUnitButton;
        private System.Windows.Forms.Button RemoveNGPlusCharButton;
        private System.Windows.Forms.Button AddNGPlusCharButton;
        private System.Windows.Forms.Label KillsCarryoverLabel;
        private System.Windows.Forms.Label CarryoverPPLabel;
        private System.Windows.Forms.NumericUpDown CKillsInc;
        private System.Windows.Forms.NumericUpDown CPPInc;
        private System.Windows.Forms.CheckBox AlphabetSortUnitCheckBox;
        private System.Windows.Forms.CheckBox AlphabetSortCharCheckBox;
    }
}
