namespace FMWSaveManager
{
    partial class ImportControl
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
            BackButtonMenu = new System.Windows.Forms.Button();
            SaveFormatBox = new System.Windows.Forms.GroupBox();
            SwitchButton1_2_5 = new System.Windows.Forms.RadioButton();
            SteamButton = new System.Windows.Forms.RadioButton();
            SwitchButton1_1_0 = new System.Windows.Forms.RadioButton();
            FinalizeImport = new System.Windows.Forms.Button();
            LogBox = new System.Windows.Forms.RichTextBox();
            InputDirectoryBox = new System.Windows.Forms.GroupBox();
            BrowseInputButton = new System.Windows.Forms.Button();
            InputSaveLabel = new System.Windows.Forms.Label();
            InputTextBox = new System.Windows.Forms.TextBox();
            OutputDirectoryBox = new System.Windows.Forms.GroupBox();
            BrowseOutputButton = new System.Windows.Forms.Button();
            OutputSaveLabel = new System.Windows.Forms.Label();
            OutputTextBox = new System.Windows.Forms.TextBox();
            ImportModeBox = new System.Windows.Forms.GroupBox();
            BatchFileButton = new System.Windows.Forms.RadioButton();
            SingleFileButton = new System.Windows.Forms.RadioButton();
            SaveFormatBox.SuspendLayout();
            InputDirectoryBox.SuspendLayout();
            OutputDirectoryBox.SuspendLayout();
            ImportModeBox.SuspendLayout();
            SuspendLayout();
            // 
            // BackButtonMenu
            // 
            BackButtonMenu.Location = new System.Drawing.Point(24, 37);
            BackButtonMenu.Name = "BackButtonMenu";
            BackButtonMenu.Size = new System.Drawing.Size(94, 29);
            BackButtonMenu.TabIndex = 3;
            BackButtonMenu.Text = "Back";
            BackButtonMenu.UseVisualStyleBackColor = true;
            BackButtonMenu.Click += BackButtonMenu_Click;
            // 
            // SaveFormatBox
            // 
            SaveFormatBox.Controls.Add(SwitchButton1_2_5);
            SaveFormatBox.Controls.Add(SteamButton);
            SaveFormatBox.Controls.Add(SwitchButton1_1_0);
            SaveFormatBox.Location = new System.Drawing.Point(24, 91);
            SaveFormatBox.Name = "SaveFormatBox";
            SaveFormatBox.Size = new System.Drawing.Size(297, 243);
            SaveFormatBox.TabIndex = 4;
            SaveFormatBox.TabStop = false;
            SaveFormatBox.Text = "Output Save File Format";
            // 
            // SwitchButton1_2_5
            // 
            SwitchButton1_2_5.AutoSize = true;
            SwitchButton1_2_5.Location = new System.Drawing.Point(7, 99);
            SwitchButton1_2_5.Name = "SwitchButton1_2_5";
            SwitchButton1_2_5.Size = new System.Drawing.Size(169, 24);
            SwitchButton1_2_5.TabIndex = 7;
            SwitchButton1_2_5.Text = "Switch (Version 1.2.5)";
            SwitchButton1_2_5.UseVisualStyleBackColor = true;
            SwitchButton1_2_5.CheckedChanged += SwitchButton1_2_5_CheckedChanged;
            // 
            // SteamButton
            // 
            SteamButton.AutoSize = true;
            SteamButton.Location = new System.Drawing.Point(7, 39);
            SteamButton.Name = "SteamButton";
            SteamButton.Size = new System.Drawing.Size(168, 24);
            SteamButton.TabIndex = 5;
            SteamButton.TabStop = true;
            SteamButton.Text = "Steam (Version 1.2.4)";
            SteamButton.UseVisualStyleBackColor = true;
            SteamButton.CheckedChanged += SteamButton_CheckedChanged;
            // 
            // SwitchButton1_1_0
            // 
            SwitchButton1_1_0.AutoSize = true;
            SwitchButton1_1_0.Location = new System.Drawing.Point(7, 69);
            SwitchButton1_1_0.Name = "SwitchButton1_1_0";
            SwitchButton1_1_0.Size = new System.Drawing.Size(169, 24);
            SwitchButton1_1_0.TabIndex = 6;
            SwitchButton1_1_0.Text = "Switch (Version 1.1.0)";
            SwitchButton1_1_0.UseVisualStyleBackColor = true;
            SwitchButton1_1_0.CheckedChanged += SwitchButton1_1_0_CheckedChanged;
            // 
            // FinalizeImport
            // 
            FinalizeImport.Location = new System.Drawing.Point(24, 341);
            FinalizeImport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            FinalizeImport.Name = "FinalizeImport";
            FinalizeImport.Size = new System.Drawing.Size(1030, 76);
            FinalizeImport.TabIndex = 7;
            FinalizeImport.Text = "Import Selected Saves";
            FinalizeImport.UseVisualStyleBackColor = true;
            FinalizeImport.Click += FinalizeImport_Click;
            // 
            // LogBox
            // 
            LogBox.Location = new System.Drawing.Point(24, 425);
            LogBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            LogBox.Name = "LogBox";
            LogBox.ReadOnly = true;
            LogBox.Size = new System.Drawing.Size(1029, 275);
            LogBox.TabIndex = 8;
            LogBox.Text = "";
            // 
            // InputDirectoryBox
            // 
            InputDirectoryBox.Controls.Add(BrowseInputButton);
            InputDirectoryBox.Controls.Add(InputSaveLabel);
            InputDirectoryBox.Controls.Add(InputTextBox);
            InputDirectoryBox.Location = new System.Drawing.Point(528, 91);
            InputDirectoryBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            InputDirectoryBox.Name = "InputDirectoryBox";
            InputDirectoryBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            InputDirectoryBox.Size = new System.Drawing.Size(526, 117);
            InputDirectoryBox.TabIndex = 9;
            InputDirectoryBox.TabStop = false;
            InputDirectoryBox.Text = "Original Save";
            // 
            // BrowseInputButton
            // 
            BrowseInputButton.Location = new System.Drawing.Point(485, 51);
            BrowseInputButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            BrowseInputButton.Name = "BrowseInputButton";
            BrowseInputButton.Size = new System.Drawing.Size(39, 28);
            BrowseInputButton.TabIndex = 11;
            BrowseInputButton.Text = "...";
            BrowseInputButton.UseVisualStyleBackColor = true;
            BrowseInputButton.Click += BrowseInputButton_Click;
            // 
            // InputSaveLabel
            // 
            InputSaveLabel.AutoSize = true;
            InputSaveLabel.Location = new System.Drawing.Point(25, 55);
            InputSaveLabel.Name = "InputSaveLabel";
            InputSaveLabel.Size = new System.Drawing.Size(43, 20);
            InputSaveLabel.TabIndex = 10;
            InputSaveLabel.Text = "Input";
            // 
            // InputTextBox
            // 
            InputTextBox.Location = new System.Drawing.Point(72, 51);
            InputTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            InputTextBox.Name = "InputTextBox";
            InputTextBox.Size = new System.Drawing.Size(405, 27);
            InputTextBox.TabIndex = 10;
            // 
            // OutputDirectoryBox
            // 
            OutputDirectoryBox.Controls.Add(BrowseOutputButton);
            OutputDirectoryBox.Controls.Add(OutputSaveLabel);
            OutputDirectoryBox.Controls.Add(OutputTextBox);
            OutputDirectoryBox.Location = new System.Drawing.Point(528, 216);
            OutputDirectoryBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            OutputDirectoryBox.Name = "OutputDirectoryBox";
            OutputDirectoryBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            OutputDirectoryBox.Size = new System.Drawing.Size(526, 117);
            OutputDirectoryBox.TabIndex = 10;
            OutputDirectoryBox.TabStop = false;
            OutputDirectoryBox.Text = "Output Save Folder";
            // 
            // BrowseOutputButton
            // 
            BrowseOutputButton.Location = new System.Drawing.Point(485, 51);
            BrowseOutputButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            BrowseOutputButton.Name = "BrowseOutputButton";
            BrowseOutputButton.Size = new System.Drawing.Size(39, 28);
            BrowseOutputButton.TabIndex = 12;
            BrowseOutputButton.Text = "...";
            BrowseOutputButton.UseVisualStyleBackColor = true;
            BrowseOutputButton.Click += BrowseOutputButton_Click;
            // 
            // OutputSaveLabel
            // 
            OutputSaveLabel.AutoSize = true;
            OutputSaveLabel.Location = new System.Drawing.Point(14, 55);
            OutputSaveLabel.Name = "OutputSaveLabel";
            OutputSaveLabel.Size = new System.Drawing.Size(55, 20);
            OutputSaveLabel.TabIndex = 11;
            OutputSaveLabel.Text = "Output";
            // 
            // OutputTextBox
            // 
            OutputTextBox.Location = new System.Drawing.Point(72, 51);
            OutputTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            OutputTextBox.Name = "OutputTextBox";
            OutputTextBox.Size = new System.Drawing.Size(405, 27);
            OutputTextBox.TabIndex = 12;
            // 
            // ImportModeBox
            // 
            ImportModeBox.Controls.Add(BatchFileButton);
            ImportModeBox.Controls.Add(SingleFileButton);
            ImportModeBox.Location = new System.Drawing.Point(328, 91);
            ImportModeBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ImportModeBox.Name = "ImportModeBox";
            ImportModeBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ImportModeBox.Size = new System.Drawing.Size(193, 243);
            ImportModeBox.TabIndex = 13;
            ImportModeBox.TabStop = false;
            ImportModeBox.Text = "Save Import Mode";
            // 
            // BatchFileButton
            // 
            BatchFileButton.AutoSize = true;
            BatchFileButton.Location = new System.Drawing.Point(7, 69);
            BatchFileButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            BatchFileButton.Name = "BatchFileButton";
            BatchFileButton.Size = new System.Drawing.Size(182, 24);
            BatchFileButton.TabIndex = 15;
            BatchFileButton.TabStop = true;
            BatchFileButton.Text = "Batch Import By Folder";
            BatchFileButton.UseVisualStyleBackColor = true;
            BatchFileButton.CheckedChanged += BatchFileButton_CheckedChanged;
            // 
            // SingleFileButton
            // 
            SingleFileButton.AutoSize = true;
            SingleFileButton.Location = new System.Drawing.Point(7, 39);
            SingleFileButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            SingleFileButton.Name = "SingleFileButton";
            SingleFileButton.Size = new System.Drawing.Size(98, 24);
            SingleFileButton.TabIndex = 14;
            SingleFileButton.TabStop = true;
            SingleFileButton.Text = "Single File";
            SingleFileButton.UseVisualStyleBackColor = true;
            SingleFileButton.CheckedChanged += SingleFileButton_CheckedChanged;
            // 
            // ImportControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(ImportModeBox);
            Controls.Add(OutputDirectoryBox);
            Controls.Add(InputDirectoryBox);
            Controls.Add(LogBox);
            Controls.Add(FinalizeImport);
            Controls.Add(SaveFormatBox);
            Controls.Add(BackButtonMenu);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "ImportControl";
            Size = new System.Drawing.Size(1069, 724);
            Load += ImportControl_Load;
            SaveFormatBox.ResumeLayout(false);
            SaveFormatBox.PerformLayout();
            InputDirectoryBox.ResumeLayout(false);
            InputDirectoryBox.PerformLayout();
            OutputDirectoryBox.ResumeLayout(false);
            OutputDirectoryBox.PerformLayout();
            ImportModeBox.ResumeLayout(false);
            ImportModeBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button BackButtonMenu;
        private System.Windows.Forms.GroupBox SaveFormatBox;
        private System.Windows.Forms.RadioButton SteamButton;
        private System.Windows.Forms.RadioButton SwitchButton1_1_0;
        private System.Windows.Forms.Button FinalizeImport;
        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.GroupBox InputDirectoryBox;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.Label InputSaveLabel;
        private System.Windows.Forms.GroupBox OutputDirectoryBox;
        private System.Windows.Forms.Label OutputSaveLabel;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.Button BrowseInputButton;
        private System.Windows.Forms.Button BrowseOutputButton;
        private System.Windows.Forms.GroupBox ImportModeBox;
        private System.Windows.Forms.RadioButton BatchFileButton;
        private System.Windows.Forms.RadioButton SingleFileButton;
        private System.Windows.Forms.RadioButton SwitchButton1_2_5;
    }
}
