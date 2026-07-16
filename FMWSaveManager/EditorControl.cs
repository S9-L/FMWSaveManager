using FMWSaveManager.FileFormats;
using FMWSaveManager.Util;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FMWSaveManager
{
    public partial class EditorControl : UserControl
    {
        private string saveFileName { get; set; }
        public event EventHandler RouteBChange;
        public EditorControl()
        {
            InitializeComponent();
            eventFlagEditor1.RouteBChange += eventFlagEditor1_RouteBChange;
        }

        private void eventFlagEditor1_RouteBChange(object sender, EventArgs e)
        {
            EditorControl_RouteBChange(sender, e);
        }

        private void EditorControl_RouteBChange(object sender, EventArgs e)
        {
            RouteBChange?.Invoke(this, e);
        }

        private void SetParentForm_Text(string titleText)
        {
            this.ParentForm.Text = titleText;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetParentForm_Text($"{Application.ProductName} {FMWSaveManagerConstants.currentAssemblyName.Version.Major}" +
                $".{FMWSaveManagerConstants.currentAssemblyName.Version.Minor}" +
                $".{FMWSaveManagerConstants.currentAssemblyName.Version.Build}");
            Control parentPanel = this.Parent!;
            UserControl currentControl = (UserControl)parentPanel.Controls[0];
            currentControl.Dispose();
            parentPanel.Controls.Clear();

            MenuControl menuInst = new MenuControl();
            menuInst.Dock = DockStyle.Fill;

            parentPanel.Controls.Add(menuInst);
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadBrowse = new OpenFileDialog();
            if (loadBrowse.ShowDialog() == DialogResult.OK)
            {
                LoadSaveData(loadBrowse.FileName);
            }
        }

        private void LoadSaveData(string saveFilePath)
        {
            // Regex validate against expected Switch/Steam filename string
            string savePattern = @"^gsw_\d{3,}\.sav$";
            if (!Regex.IsMatch(Path.GetFileName(saveFilePath), savePattern))
            {
                MessageBox.Show("Save file name is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                GeneralData gd = new GeneralData();
                NGPlusCarryover cd = new NGPlusCarryover();
                BonusStats bonusStats = new BonusStats();
                UnsupportedFields uf = new UnsupportedFields();
                UnitData ud = new UnitData();
                CharData charData = new CharData();
                ChapterClearData chapClear = new ChapterClearData();
                Items it = new Items();
                EventFlags ev = new EventFlags();

                ISaveFile saveInst = SaveFactory.Create(GameType.CBSteam);

                try
                {
                    saveInst.ReadFile(saveFilePath);
                    saveInst.ReadSaveBytes(gd, cd, bonusStats, uf, ud, charData, chapClear, it, ev);
                }
                catch (Exception _exception)
                {
                    MessageBox.Show("Failed to read file: " + Path.GetFileName(saveFilePath) +
                        "\nException:\n" + _exception, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Init event flags first to be read for other editors
                eventFlagEditor1.EventFlags = ev;
                eventFlagEditor1.init();
                eventFlagEditor1.Enabled = true;

                generalDataEditor1.GeneralData = gd;
                generalDataEditor1.UnsupportedFields = uf; // Register unsupported fields in gd editor to save later
                generalDataEditor1.init();
                generalDataEditor1.SetEditorControlRef(this);
                generalDataEditor1.Enabled = true;

                ngPlusEditor1.CarryoverData = cd;
                ngPlusEditor1.initBind();
                ngPlusEditor1.init();
                ngPlusEditor1.Enabled = true;

                bonusEditor1.BonusStats = bonusStats;
                bonusEditor1.init();
                bonusEditor1.Enabled = true;

                entityEditor1.UnitData = ud;
                entityEditor1.UEditor.uData = ud;
                entityEditor1.UEditor.initBind();
                entityEditor1.CharData = charData;
                entityEditor1.CEditor.cData = charData;
                entityEditor1.CEditor.initBind();
                entityEditor1.init();
                entityEditor1.Enabled = true;
                entityEditor1.UEditor.Enabled = true;

                chapterEditor1.ChapterData = chapClear;
                chapterEditor1.initBind();
                chapterEditor1.Enabled = true;

                itemsEditor1.Items = it;
                itemsEditor1.init(ToolbarMenuStrip);
                itemsEditor1.Enabled = true;

                saveToolStripMenuItem.Enabled = true;
                this.saveFileName = Path.GetFileName(saveFilePath);

                SetParentForm_Text($"{Application.ProductName} {FMWSaveManagerConstants.currentAssemblyName.Version.Major}" +
                    $".{FMWSaveManagerConstants.currentAssemblyName.Version.Minor}" +
                    $".{FMWSaveManagerConstants.currentAssemblyName.Version.Build} - [{saveFilePath}]");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog writeBrowse = new SaveFileDialog())
            {
                writeBrowse.FileName = this.saveFileName;
                if (writeBrowse.ShowDialog() == DialogResult.OK)
                {
                    WriteSaveData(writeBrowse.FileName);
                }
            }
        }

        private void WriteSaveData(string saveFilePath)
        {
            ISaveFile saveInst = SaveFactory.Create(GameType.CBSteam);

            try
            {
                saveInst.WriteSaveBytes(saveFilePath,
                            generalDataEditor1.GeneralData,
                            ngPlusEditor1.CarryoverData,
                            bonusEditor1.BonusStats,
                            generalDataEditor1.UnsupportedFields,
                            entityEditor1.UnitData,
                            entityEditor1.CharData,
                            chapterEditor1.ChapterData,
                            itemsEditor1.Items,
                            eventFlagEditor1.EventFlags,
                            false);
            }
            catch (Exception _exception)
            {
                MessageBox.Show("Failed to save file: " +
                    Path.GetFileName(saveFilePath) + "\nException:\n" +
                    _exception, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.saveFileName = Path.GetFileName(saveFilePath);
            SetParentForm_Text($"{Application.ProductName} {FMWSaveManagerConstants.currentAssemblyName.Version.Major}" +
                $".{FMWSaveManagerConstants.currentAssemblyName.Version.Minor}" +
                $".{FMWSaveManagerConstants.currentAssemblyName.Version.Build} - [{saveFilePath}]");

            MessageBox.Show($"Successfully saved at [{saveFilePath}]!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutForm aboutDialog = new AboutForm())
            {
                aboutDialog.ShowDialog();
            }
        }
    }
}
