using FMWSaveManager.FileFormats;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMWSaveManager
{
    public partial class ImportControl : UserControl
    {
        private GameType importType { get; set; }
        private ImportMode importMode { get; set; }
        private bool isImporting { get; set; }
        public ImportControl()
        {
            InitializeComponent();
            Log.Logger = new LoggerConfiguration()
            .WriteTo.RichTextBox(LogBox, autoScroll: true, maxLogLines: 1000)
            .CreateLogger();
            isImporting = false;
        }

        private void BackButtonMenu_Click(object sender, EventArgs e)
        {
            Control parentPanel = this.Parent!;
            UserControl currentControl = (UserControl)parentPanel.Controls[0];
            currentControl.Dispose();
            parentPanel.Controls.Clear();

            MenuControl menuInst = new MenuControl();
            menuInst.Dock = DockStyle.Fill;

            parentPanel.Controls.Add(menuInst);
        }

        private void BrowseInputButton_Click(object sender, EventArgs e)
        {
            switch (importMode)
            {
                case ImportMode.SingleFile:
                    OpenFileDialog fSelect = new OpenFileDialog();

                    if (fSelect.ShowDialog() == DialogResult.OK)
                    {
                        InputTextBox.Text = fSelect.FileName;
                    }
                    break;

                case ImportMode.BatchImport:
                    FolderBrowserDialog fBrowse = new FolderBrowserDialog();

                    if (fBrowse.ShowDialog() == DialogResult.OK)
                    {
                        InputTextBox.Text = fBrowse.SelectedPath;
                    }
                    break;
            }
        }

        private void BrowseOutputButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fBrowse = new FolderBrowserDialog();

            if (fBrowse.ShowDialog() == DialogResult.OK)
            {
                OutputTextBox.Text = fBrowse.SelectedPath;
            }
        }

        private void ImportControl_Load(object sender, EventArgs e)
        {
            SteamButton.Checked = true;
            importType = GameType.CBSteam;

            SingleFileButton.Checked = true;
            importMode = ImportMode.SingleFile;

            this.ParentForm.FormClosing += ParentForm_FormClosing;
        }

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.isImporting)
            {
                e.Cancel = true;
            }
        }

        private void SteamButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SteamButton.Checked)
            {
                importType = GameType.CBSteam;
            }
        }

        private void SwitchButton1_1_0_CheckedChanged(object sender, EventArgs e)
        {
            if (SwitchButton1_1_0.Checked)
            {
                importType = GameType.CBSwitch1_1_0;
            }
        }

        private void SwitchButton1_2_5_CheckedChanged(object sender, EventArgs e)
        {
            if (SwitchButton1_2_5.Checked)
            {
                importType = GameType.CBSwitch1_2_5;
            }
        }

        private void SingleFileButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SingleFileButton.Checked)
            {
                importMode = ImportMode.SingleFile;
                InputTextBox.Clear();
            }
        }

        private void BatchFileButton_CheckedChanged(object sender, EventArgs e)
        {
            if (BatchFileButton.Checked)
            {
                importMode = ImportMode.BatchImport;
                InputTextBox.Clear();
            }
        }

        private async void FinalizeImport_Click(object sender, EventArgs e)
        {
            // Prepare Import Type
            string outputVersion;
            string platform;
            try
            {
                switch (importType)
                {
                    case GameType.CBSteam:
                        outputVersion = "GSWX:1.2.4";
                        platform = "Steam";
                        break;
                    case GameType.CBSwitch1_1_0:
                        outputVersion = "GSWX:1.1.0";
                        platform = "Switch";
                        break;
                    case GameType.CBSwitch1_2_5:
                        outputVersion = "GSWX:1.2.5";
                        platform = "Switch";
                        break;
                    default:
                        throw new InvalidEnumArgumentException();
                }
            }
            catch (Exception _exception)
            {
                MessageBox.Show("Output Save File Format is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (InputTextBox.Text.Count() == 0 || OutputTextBox.Text.Count() == 0)
            {
                MessageBox.Show("Textboxes cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string inputPath = InputTextBox.Text;
            string outputPath = OutputTextBox.Text + "\\";

            if (!Path.Exists(inputPath))
            {
                MessageBox.Show("Input file path is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Path.Exists(outputPath))
            {
                MessageBox.Show("Output file path is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (Control control in this.Controls)
            {
                control.Enabled = false;
            }

            LogBox.Enabled = true;
            this.isImporting = true;

            Log.CloseAndFlush();
            Log.Logger = new LoggerConfiguration()
            .WriteTo.RichTextBox(LogBox, autoScroll: true, maxLogLines: 1000)
            .CreateLogger();

            GeneralData gd = new GeneralData();
            NGPlusCarryover cd = new NGPlusCarryover();
            BonusStats bonusStats = new BonusStats();
            UnsupportedFields uf = new UnsupportedFields();
            UnitData ud = new UnitData();
            CharData charData = new CharData();
            ChapterClearData chapClear = new ChapterClearData();
            Items it = new Items();
            EventFlags ev = new EventFlags();

            ISaveFile saveRead = SaveFactory.Create(GameType.CBDoujin);
            ISaveFile saveWrite = SaveFactory.Create(importType);

            string fileMask = "*";
            if (importMode == ImportMode.SingleFile)
            {
                fileMask = Path.GetFileName(inputPath);
                inputPath = Path.GetDirectoryName(inputPath);
                Log.Information("Single file import started!");
            }
            else
            {
                Log.Information("Batch file import started!");
            }

            Log.Information($"Importing with version string {outputVersion} for {platform}...");

            Regex searchPattern = new Regex(@"^gswx_\d{2,}\.sav$");
            IEnumerable<string> CBSaveFolder = Directory.EnumerateFiles(inputPath, fileMask, SearchOption.TopDirectoryOnly)
                .Where(filePath => searchPattern.IsMatch(Path.GetFileName(filePath)));

            long start = Stopwatch.GetTimestamp();
            int success = 0;

            Log.Information($"Beginning gswx file import from [{inputPath}].");
            await Task.Run(() =>
            {
                for (int i = 0; i < CBSaveFolder.Count(); i++)
                {
                    string originalFile = CBSaveFolder.ElementAt(i);
                    Log.Information("Importing file: " + Path.GetFileName(originalFile));

                    try
                    {
                        int indexDigit = int.Parse(Regex.Match(Path.GetFileName(originalFile), @"\d{2,}").Value);

                        string endFile = $"gsw_{indexDigit:000}.sav";

                        saveRead.ReadFile(originalFile);
                        saveRead.ReadSaveBytes(gd, cd, bonusStats, uf, ud, charData, chapClear, it, ev);

                        // Update version string
                        gd.VersionStr = outputVersion;
                        SaveEdgeCaseHandling(charData);

                        saveWrite.WriteSaveBytes(outputPath + endFile,
                            gd, cd, bonusStats, uf, ud, charData, chapClear, it, ev, true);

                        Log.Information("Successfully wrote file: " + Path.GetFileName(endFile));
                        success++;
                    }
                    catch (Exception _exception)
                    {
                        Log.Error(_exception, "Failed to import file: " + Path.GetFileName(originalFile));
                    }
                }
            });
            Log.Information($"{success} gsw files were successfully written to [{outputPath}].");
            Log.Information($"Time taken: {Stopwatch.GetElapsedTime(start)}");

            foreach (Control control in this.Controls)
            {
                control.Enabled = true;
            }

            this.isImporting = false;
        }

        private void SaveEdgeCaseHandling(CharData charData)
        {
            /* Cover Eiki edge case where Skill ID of DANZAI in Doujin CB was changed to DANZAI2 in Switch/Steam
             * Steam reads this without crashing on GM 2023 due to the undefined type being accepted as string_count arg
             * Switch crashes on GM 2022 due to undefined type not matching the expected string type for string_count arg
             */
            int eikiIndex = charData.CharNames.IndexOf("Eiki");
            if (eikiIndex != -1)
            {
                // Replace current skills
                for (int i = 0; i < charData.SkillIDs[eikiIndex].Count; i++)
                {
                    if (charData.SkillIDs[eikiIndex][i] == "DANZAI")
                    {
                        charData.SkillIDs[eikiIndex][i] = "DANZAI2";
                    }
                }

                // Replace stored skills
                charData.ReserveSkills[eikiIndex] = charData.ReserveSkills[eikiIndex].Replace("|DANZAI|", "|DANZAI2|");
            }

            /* Cover Rinnosuke edge case where Skill ID ZAIKO for Inventory Usage isn't in learnset for Switch/Steam
             * However this skill still exists in the data of both game versions and won't crash in either version if imported over
             * Logic here removes the skill to keep parity with vanilla learnset for Switch/Steam versions, relevant in batch import for many files at once
             * User can add back ZAIKO skill per save as needed instead of having to reset the skill for all save file instances
             */
            int korinIndex = charData.CharNames.IndexOf("Korin");
            if (korinIndex != -1)
            {
                // Replace current skills
                for (int i = 0; i < charData.SkillIDs[korinIndex].Count; i++)
                {
                    if (charData.SkillIDs[korinIndex][i] == "ZAIKO")
                    {
                        charData.SkillIDs[korinIndex][i] = "NONE";
                    }
                }

                // Replace stored skills
                charData.ReserveSkills[korinIndex] = charData.ReserveSkills[korinIndex].Replace("|ZAIKO|0|", "|");
            }
        }
    }
}
