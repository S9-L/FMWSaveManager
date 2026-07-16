using System.Windows.Forms;

namespace FMWSaveManager.Editors
{
    partial class UnitEditor
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
            HPLabel = new Label();
            HPInc = new NumericUpDown();
            MPInc = new NumericUpDown();
            MobilityInc = new NumericUpDown();
            ArmorInc = new NumericUpDown();
            WeaponInc = new NumericUpDown();
            MPLabel = new Label();
            MobilityLabel = new Label();
            ArmorLabel = new Label();
            WeaponLabel = new Label();
            UnitNameLabel = new Label();
            UnitNameTextBox = new TextBox();
            UnitIDTextBox = new TextBox();
            UnitIDLabel = new Label();
            FUBLabel = new Label();
            FUBComboBox = new ComboBox();
            EntityUnitListBox = new FMWSaveManager.Util.AlternateListBox();
            Item1ComboBox = new ComboBox();
            Item1Label = new Label();
            Item2ComboBox = new ComboBox();
            Item2Label = new Label();
            Item3ComboBox = new ComboBox();
            Item3Label = new Label();
            Item4ComboBox = new ComboBox();
            Item4Label = new Label();
            UpgradesGroupBox = new GroupBox();
            ItemsGroupBox = new GroupBox();
            ToggleNamesButton = new Button();
            UnitGroupBox = new GroupBox();
            UnitBGMLabel = new Label();
            UnitBGMTextBox = new TextBox();
            AddUnitButton = new Button();
            RemoveUnitButton = new Button();
            AlphabetSortCheckBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)HPInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MPInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MobilityInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ArmorInc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WeaponInc).BeginInit();
            UpgradesGroupBox.SuspendLayout();
            ItemsGroupBox.SuspendLayout();
            UnitGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // HPLabel
            // 
            HPLabel.AutoSize = true;
            HPLabel.Location = new System.Drawing.Point(102, 44);
            HPLabel.Name = "HPLabel";
            HPLabel.Size = new System.Drawing.Size(23, 15);
            HPLabel.TabIndex = 0;
            HPLabel.Text = "HP";
            // 
            // HPInc
            // 
            HPInc.Location = new System.Drawing.Point(147, 42);
            HPInc.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            HPInc.Name = "HPInc";
            HPInc.Size = new System.Drawing.Size(64, 23);
            HPInc.TabIndex = 1;
            // 
            // MPInc
            // 
            MPInc.Location = new System.Drawing.Point(147, 71);
            MPInc.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            MPInc.Name = "MPInc";
            MPInc.Size = new System.Drawing.Size(64, 23);
            MPInc.TabIndex = 2;
            // 
            // MobilityInc
            // 
            MobilityInc.Location = new System.Drawing.Point(147, 100);
            MobilityInc.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            MobilityInc.Name = "MobilityInc";
            MobilityInc.Size = new System.Drawing.Size(64, 23);
            MobilityInc.TabIndex = 3;
            // 
            // ArmorInc
            // 
            ArmorInc.Location = new System.Drawing.Point(147, 129);
            ArmorInc.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            ArmorInc.Name = "ArmorInc";
            ArmorInc.Size = new System.Drawing.Size(64, 23);
            ArmorInc.TabIndex = 4;
            // 
            // WeaponInc
            // 
            WeaponInc.Location = new System.Drawing.Point(147, 158);
            WeaponInc.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            WeaponInc.Name = "WeaponInc";
            WeaponInc.Size = new System.Drawing.Size(64, 23);
            WeaponInc.TabIndex = 5;
            // 
            // MPLabel
            // 
            MPLabel.AutoSize = true;
            MPLabel.Location = new System.Drawing.Point(100, 73);
            MPLabel.Name = "MPLabel";
            MPLabel.Size = new System.Drawing.Size(25, 15);
            MPLabel.TabIndex = 6;
            MPLabel.Text = "MP";
            // 
            // MobilityLabel
            // 
            MobilityLabel.AutoSize = true;
            MobilityLabel.Location = new System.Drawing.Point(74, 102);
            MobilityLabel.Name = "MobilityLabel";
            MobilityLabel.Size = new System.Drawing.Size(51, 15);
            MobilityLabel.TabIndex = 7;
            MobilityLabel.Text = "Mobility";
            // 
            // ArmorLabel
            // 
            ArmorLabel.AutoSize = true;
            ArmorLabel.Location = new System.Drawing.Point(84, 131);
            ArmorLabel.Name = "ArmorLabel";
            ArmorLabel.Size = new System.Drawing.Size(41, 15);
            ArmorLabel.TabIndex = 8;
            ArmorLabel.Text = "Armor";
            // 
            // WeaponLabel
            // 
            WeaponLabel.AutoSize = true;
            WeaponLabel.Location = new System.Drawing.Point(74, 160);
            WeaponLabel.Name = "WeaponLabel";
            WeaponLabel.Size = new System.Drawing.Size(51, 15);
            WeaponLabel.TabIndex = 9;
            WeaponLabel.Text = "Weapon";
            // 
            // UnitNameLabel
            // 
            UnitNameLabel.AutoSize = true;
            UnitNameLabel.Location = new System.Drawing.Point(14, 31);
            UnitNameLabel.Name = "UnitNameLabel";
            UnitNameLabel.Size = new System.Drawing.Size(64, 15);
            UnitNameLabel.TabIndex = 10;
            UnitNameLabel.Text = "Unit Name";
            // 
            // UnitNameTextBox
            // 
            UnitNameTextBox.Location = new System.Drawing.Point(84, 28);
            UnitNameTextBox.Name = "UnitNameTextBox";
            UnitNameTextBox.Size = new System.Drawing.Size(116, 23);
            UnitNameTextBox.TabIndex = 11;
            // 
            // UnitIDTextBox
            // 
            UnitIDTextBox.Location = new System.Drawing.Point(84, 57);
            UnitIDTextBox.Name = "UnitIDTextBox";
            UnitIDTextBox.Size = new System.Drawing.Size(116, 23);
            UnitIDTextBox.TabIndex = 13;
            // 
            // UnitIDLabel
            // 
            UnitIDLabel.AutoSize = true;
            UnitIDLabel.Location = new System.Drawing.Point(35, 60);
            UnitIDLabel.Name = "UnitIDLabel";
            UnitIDLabel.Size = new System.Drawing.Size(43, 15);
            UnitIDLabel.TabIndex = 12;
            UnitIDLabel.Text = "Unit ID";
            // 
            // FUBLabel
            // 
            FUBLabel.AutoSize = true;
            FUBLabel.Location = new System.Drawing.Point(15, 209);
            FUBLabel.Name = "FUBLabel";
            FUBLabel.Size = new System.Drawing.Size(110, 15);
            FUBLabel.TabIndex = 14;
            FUBLabel.Text = "Full Upgrade Bonus";
            // 
            // FUBComboBox
            // 
            FUBComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            FUBComboBox.FormattingEnabled = true;
            FUBComboBox.Location = new System.Drawing.Point(147, 206);
            FUBComboBox.Name = "FUBComboBox";
            FUBComboBox.Size = new System.Drawing.Size(175, 23);
            FUBComboBox.TabIndex = 16;
            // 
            // EntityUnitListBox
            // 
            EntityUnitListBox.AlternateBackColorOnDraw = true;
            EntityUnitListBox.DrawMode = DrawMode.OwnerDrawFixed;
            EntityUnitListBox.FormattingEnabled = true;
            EntityUnitListBox.Location = new System.Drawing.Point(3, 3);
            EntityUnitListBox.Name = "EntityUnitListBox";
            EntityUnitListBox.Size = new System.Drawing.Size(143, 388);
            EntityUnitListBox.TabIndex = 17;
            EntityUnitListBox.SelectedIndexChanged += EntityUnitListBox_SelectedIndexChanged;
            // 
            // Item1ComboBox
            // 
            Item1ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Item1ComboBox.FormattingEnabled = true;
            Item1ComboBox.Location = new System.Drawing.Point(61, 41);
            Item1ComboBox.Name = "Item1ComboBox";
            Item1ComboBox.Size = new System.Drawing.Size(175, 23);
            Item1ComboBox.TabIndex = 19;
            // 
            // Item1Label
            // 
            Item1Label.AutoSize = true;
            Item1Label.Location = new System.Drawing.Point(15, 44);
            Item1Label.Name = "Item1Label";
            Item1Label.Size = new System.Drawing.Size(40, 15);
            Item1Label.TabIndex = 18;
            Item1Label.Text = "Item 1";
            // 
            // Item2ComboBox
            // 
            Item2ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Item2ComboBox.FormattingEnabled = true;
            Item2ComboBox.Location = new System.Drawing.Point(61, 70);
            Item2ComboBox.Name = "Item2ComboBox";
            Item2ComboBox.Size = new System.Drawing.Size(175, 23);
            Item2ComboBox.TabIndex = 21;
            // 
            // Item2Label
            // 
            Item2Label.AutoSize = true;
            Item2Label.Location = new System.Drawing.Point(15, 73);
            Item2Label.Name = "Item2Label";
            Item2Label.Size = new System.Drawing.Size(40, 15);
            Item2Label.TabIndex = 20;
            Item2Label.Text = "Item 2";
            // 
            // Item3ComboBox
            // 
            Item3ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Item3ComboBox.FormattingEnabled = true;
            Item3ComboBox.Location = new System.Drawing.Point(61, 99);
            Item3ComboBox.Name = "Item3ComboBox";
            Item3ComboBox.Size = new System.Drawing.Size(175, 23);
            Item3ComboBox.TabIndex = 23;
            // 
            // Item3Label
            // 
            Item3Label.AutoSize = true;
            Item3Label.Location = new System.Drawing.Point(15, 102);
            Item3Label.Name = "Item3Label";
            Item3Label.Size = new System.Drawing.Size(40, 15);
            Item3Label.TabIndex = 22;
            Item3Label.Text = "Item 3";
            // 
            // Item4ComboBox
            // 
            Item4ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Item4ComboBox.FormattingEnabled = true;
            Item4ComboBox.Location = new System.Drawing.Point(61, 128);
            Item4ComboBox.Name = "Item4ComboBox";
            Item4ComboBox.Size = new System.Drawing.Size(175, 23);
            Item4ComboBox.TabIndex = 25;
            // 
            // Item4Label
            // 
            Item4Label.AutoSize = true;
            Item4Label.Location = new System.Drawing.Point(15, 131);
            Item4Label.Name = "Item4Label";
            Item4Label.Size = new System.Drawing.Size(40, 15);
            Item4Label.TabIndex = 24;
            Item4Label.Text = "Item 4";
            // 
            // UpgradesGroupBox
            // 
            UpgradesGroupBox.Controls.Add(HPLabel);
            UpgradesGroupBox.Controls.Add(HPInc);
            UpgradesGroupBox.Controls.Add(MPInc);
            UpgradesGroupBox.Controls.Add(MobilityInc);
            UpgradesGroupBox.Controls.Add(ArmorInc);
            UpgradesGroupBox.Controls.Add(WeaponInc);
            UpgradesGroupBox.Controls.Add(MPLabel);
            UpgradesGroupBox.Controls.Add(MobilityLabel);
            UpgradesGroupBox.Controls.Add(ArmorLabel);
            UpgradesGroupBox.Controls.Add(WeaponLabel);
            UpgradesGroupBox.Controls.Add(FUBComboBox);
            UpgradesGroupBox.Controls.Add(FUBLabel);
            UpgradesGroupBox.Location = new System.Drawing.Point(152, 136);
            UpgradesGroupBox.Name = "UpgradesGroupBox";
            UpgradesGroupBox.Size = new System.Drawing.Size(333, 248);
            UpgradesGroupBox.TabIndex = 26;
            UpgradesGroupBox.TabStop = false;
            UpgradesGroupBox.Text = "Upgrades";
            // 
            // ItemsGroupBox
            // 
            ItemsGroupBox.Controls.Add(ToggleNamesButton);
            ItemsGroupBox.Controls.Add(Item4ComboBox);
            ItemsGroupBox.Controls.Add(Item1Label);
            ItemsGroupBox.Controls.Add(Item1ComboBox);
            ItemsGroupBox.Controls.Add(Item4Label);
            ItemsGroupBox.Controls.Add(Item2Label);
            ItemsGroupBox.Controls.Add(Item3ComboBox);
            ItemsGroupBox.Controls.Add(Item2ComboBox);
            ItemsGroupBox.Controls.Add(Item3Label);
            ItemsGroupBox.Location = new System.Drawing.Point(491, 136);
            ItemsGroupBox.Name = "ItemsGroupBox";
            ItemsGroupBox.Size = new System.Drawing.Size(283, 248);
            ItemsGroupBox.TabIndex = 27;
            ItemsGroupBox.TabStop = false;
            ItemsGroupBox.Text = "Items";
            // 
            // ToggleNamesButton
            // 
            ToggleNamesButton.Location = new System.Drawing.Point(61, 163);
            ToggleNamesButton.Name = "ToggleNamesButton";
            ToggleNamesButton.Size = new System.Drawing.Size(175, 33);
            ToggleNamesButton.TabIndex = 26;
            ToggleNamesButton.Text = "Toggle Item Names";
            ToggleNamesButton.UseVisualStyleBackColor = true;
            ToggleNamesButton.Click += ToggleNamesButton_Click;
            // 
            // UnitGroupBox
            // 
            UnitGroupBox.Controls.Add(UnitBGMLabel);
            UnitGroupBox.Controls.Add(UnitBGMTextBox);
            UnitGroupBox.Controls.Add(UnitNameTextBox);
            UnitGroupBox.Controls.Add(UnitNameLabel);
            UnitGroupBox.Controls.Add(UnitIDLabel);
            UnitGroupBox.Controls.Add(UnitIDTextBox);
            UnitGroupBox.Location = new System.Drawing.Point(152, 0);
            UnitGroupBox.Name = "UnitGroupBox";
            UnitGroupBox.Size = new System.Drawing.Size(333, 130);
            UnitGroupBox.TabIndex = 28;
            UnitGroupBox.TabStop = false;
            UnitGroupBox.Text = "Unit Info";
            // 
            // UnitBGMLabel
            // 
            UnitBGMLabel.AutoSize = true;
            UnitBGMLabel.Location = new System.Drawing.Point(20, 89);
            UnitBGMLabel.Name = "UnitBGMLabel";
            UnitBGMLabel.Size = new System.Drawing.Size(58, 15);
            UnitBGMLabel.TabIndex = 14;
            UnitBGMLabel.Text = "Unit BGM";
            // 
            // UnitBGMTextBox
            // 
            UnitBGMTextBox.Location = new System.Drawing.Point(84, 86);
            UnitBGMTextBox.Name = "UnitBGMTextBox";
            UnitBGMTextBox.Size = new System.Drawing.Size(180, 23);
            UnitBGMTextBox.TabIndex = 15;
            // 
            // AddUnitButton
            // 
            AddUnitButton.Location = new System.Drawing.Point(3, 388);
            AddUnitButton.Name = "AddUnitButton";
            AddUnitButton.Size = new System.Drawing.Size(143, 30);
            AddUnitButton.TabIndex = 29;
            AddUnitButton.Text = "Add";
            AddUnitButton.UseVisualStyleBackColor = true;
            AddUnitButton.Click += AddUnitButton_Click;
            // 
            // RemoveUnitButton
            // 
            RemoveUnitButton.Location = new System.Drawing.Point(3, 424);
            RemoveUnitButton.Name = "RemoveUnitButton";
            RemoveUnitButton.Size = new System.Drawing.Size(143, 30);
            RemoveUnitButton.TabIndex = 30;
            RemoveUnitButton.Text = "Remove";
            RemoveUnitButton.UseVisualStyleBackColor = true;
            RemoveUnitButton.Click += RemoveUnitButton_Click;
            // 
            // AlphabetSortCheckBox
            // 
            AlphabetSortCheckBox.AutoSize = true;
            AlphabetSortCheckBox.Location = new System.Drawing.Point(152, 390);
            AlphabetSortCheckBox.Name = "AlphabetSortCheckBox";
            AlphabetSortCheckBox.Size = new System.Drawing.Size(70, 19);
            AlphabetSortCheckBox.TabIndex = 86;
            AlphabetSortCheckBox.Text = "A-Z Sort";
            AlphabetSortCheckBox.UseVisualStyleBackColor = true;
            AlphabetSortCheckBox.Click += AlphabetSortCheckBox_Click;
            // 
            // UnitEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(AlphabetSortCheckBox);
            Controls.Add(RemoveUnitButton);
            Controls.Add(AddUnitButton);
            Controls.Add(UnitGroupBox);
            Controls.Add(ItemsGroupBox);
            Controls.Add(UpgradesGroupBox);
            Controls.Add(EntityUnitListBox);
            Name = "UnitEditor";
            Size = new System.Drawing.Size(774, 491);
            ((System.ComponentModel.ISupportInitialize)HPInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)MPInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)MobilityInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)ArmorInc).EndInit();
            ((System.ComponentModel.ISupportInitialize)WeaponInc).EndInit();
            UpgradesGroupBox.ResumeLayout(false);
            UpgradesGroupBox.PerformLayout();
            ItemsGroupBox.ResumeLayout(false);
            ItemsGroupBox.PerformLayout();
            UnitGroupBox.ResumeLayout(false);
            UnitGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label HPLabel;
        private System.Windows.Forms.NumericUpDown HPInc;
        private System.Windows.Forms.NumericUpDown MPInc;
        private System.Windows.Forms.NumericUpDown MobilityInc;
        private System.Windows.Forms.NumericUpDown ArmorInc;
        private System.Windows.Forms.NumericUpDown WeaponInc;
        private System.Windows.Forms.Label MPLabel;
        private System.Windows.Forms.Label MobilityLabel;
        private System.Windows.Forms.Label ArmorLabel;
        private System.Windows.Forms.Label WeaponLabel;
        private System.Windows.Forms.Label UnitNameLabel;
        private System.Windows.Forms.TextBox UnitNameTextBox;
        private System.Windows.Forms.TextBox UnitIDTextBox;
        private System.Windows.Forms.Label UnitIDLabel;
        private System.Windows.Forms.Label FUBLabel;
        private System.Windows.Forms.ComboBox FUBComboBox;
        private Util.AlternateListBox EntityUnitListBox;
        private ComboBox Item1ComboBox;
        private Label Item1Label;
        private ComboBox Item2ComboBox;
        private Label Item2Label;
        private ComboBox Item3ComboBox;
        private Label Item3Label;
        private ComboBox Item4ComboBox;
        private Label Item4Label;
        private GroupBox UpgradesGroupBox;
        private GroupBox ItemsGroupBox;
        private GroupBox UnitGroupBox;
        private Button AddUnitButton;
        private Button RemoveUnitButton;
        private Label UnitBGMLabel;
        private TextBox UnitBGMTextBox;
        private Button ToggleNamesButton;
        private CheckBox AlphabetSortCheckBox;
    }
}
