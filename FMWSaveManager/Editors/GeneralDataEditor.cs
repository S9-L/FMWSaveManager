using FMWSaveManager.FileFormats;
using FMWSaveManager.Util;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FMWSaveManager.Editors
{
    public partial class GeneralDataEditor : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public GeneralData GeneralData { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UnsupportedFields UnsupportedFields { get; set; }
        private EditorControl parentControl;
        public GeneralDataEditor()
        {
            InitializeComponent();
            BindingHelper.SetDoubleBuffer(RouteComboBox, true);
            BindingHelper.SetDoubleBuffer(DifficultyComboBox, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }

        private void GeneralDataEditor_RouteBChange(object sender, EventArgs e)
        {
            CheckChapter();
        }

        public void SetEditorControlRef(EditorControl userCtl)
        {
            parentControl = userCtl;
            parentControl.RouteBChange += GeneralDataEditor_RouteBChange;
        }

        public void init()
        {
            // Save initial IM init setting
            byte IMInit = GeneralData.ApplyIMInit;

            RouteComboBox.DataBindings.Clear();
            switch (GeneralData.RouteStr)
            {
                case "Sakuya":
                    ChapterNumInc.Maximum = FMWSaveManagerConstants.maxChapterNumSakuya;
                    RouteComboBox.DataSource = new BindingSource(FMWSaveManagerConstants.fullRouteList, null);
                    RouteComboBox.Enabled = false;
                    break;

                case "Meko":
                    ChapterNumInc.Maximum = FMWSaveManagerConstants.maxChapterNumMeeko;
                    RouteComboBox.DataSource = new BindingSource(FMWSaveManagerConstants.fullRouteList, null);
                    RouteComboBox.Enabled = false;
                    break;

                default:
                    ChapterNumInc.Maximum = FMWSaveManagerConstants.maxChapterNumGeneral;
                    RouteComboBox.DataSource = new BindingSource(FMWSaveManagerConstants.routeList, null);
                    RouteComboBox.Enabled = true;
                    break;
            }
            RouteComboBox.DataBindings.Add("Text", GeneralData, "RouteStr", false, DataSourceUpdateMode.OnPropertyChanged);

            DifficultyComboBox.DataBindings.Clear();
            DifficultyComboBox.DisplayMember = "Value";
            DifficultyComboBox.ValueMember = "Key";
            DifficultyComboBox.DataSource = new BindingSource(FMWSaveManagerConstants.diffMap, null);
            DifficultyComboBox.DataBindings.Add("SelectedValue", GeneralData, "Difficulty", false, DataSourceUpdateMode.OnPropertyChanged);

            ChapterNumInc.DataBindings.Clear();
            ChapterNumInc.DataBindings.Add("Value", GeneralData, "Chapter", false, DataSourceUpdateMode.OnPropertyChanged);

            ChapterIDLabel.Text = $"Chapter ID - {GeneralData.ChapterID}";

            TurnsTakenInc.DataBindings.Clear();
            TurnsTakenInc.DataBindings.Add("Value", GeneralData, "TotalTurns", false, DataSourceUpdateMode.OnPropertyChanged);

            PointsInc.DataBindings.Clear();
            PointsInc.DataBindings.Add("Value", GeneralData, "TotalPoints", false, DataSourceUpdateMode.OnPropertyChanged);

            WPInc.DataBindings.Clear();
            WPInc.DataBindings.Add("Value", GeneralData, "TotalWP", false, DataSourceUpdateMode.OnPropertyChanged);

            PlaythroughsInc.DataBindings.Clear();
            PlaythroughsInc.DataBindings.Add("Value", GeneralData, "Playthroughs", false, DataSourceUpdateMode.OnPropertyChanged);

            if (GeneralData.Ng0Playthrough == 113)
            {
                FirstPlaythoughLabel.Text = "Is First Playthrough: True";
            }
            else
            {
                FirstPlaythoughLabel.Text = "Is First Playthrough: False";
            }

            BonusesInc.DataBindings.Clear();
            BonusesInc.DataBindings.Add("Value", GeneralData, "BonusAchieved", false, DataSourceUpdateMode.OnPropertyChanged);

            TotalBonusesInc.DataBindings.Clear();
            TotalBonusesInc.DataBindings.Add("Value", GeneralData, "TotalBonus", false, DataSourceUpdateMode.OnPropertyChanged);

            GameOverInc.DataBindings.Clear();
            GameOverInc.DataBindings.Add("Value", GeneralData, "GameOvers", false, DataSourceUpdateMode.OnPropertyChanged);

            ArmyNameTextBox.DataBindings.Clear();
            ArmyNameTextBox.DataBindings.Add("Text", GeneralData, "ArmyName", false, DataSourceUpdateMode.OnPropertyChanged);

            CheckChapter();
            // Restore initial IM init setting to stop editor initialization from always setting ApplyIMInit = 0
            GeneralData.ApplyIMInit = IMInit;
        }

        private void PlaythroughsInc_ValueChanged(object sender, EventArgs e)
        {
            if (PlaythroughsInc.Value == 0)
            {
                // ID val for NG0
                GeneralData.Ng0Playthrough = 113;
                FirstPlaythoughLabel.Text = "Is First Playthrough: True";
            }
            else
            {
                sbyte randVal = (sbyte)Random.Shared.Next(sbyte.MinValue, sbyte.MaxValue);
                if (randVal == 113)
                {
                    randVal++;
                }
                GeneralData.Ng0Playthrough = randVal;
                FirstPlaythoughLabel.Text = "Is First Playthrough: False";
            }
        }

        private void ChapterNumInc_ValueChanged(object sender, EventArgs e)
        {
            CheckChapter();
        }

        private void RouteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckChapter();
        }

        private void CheckChapter()
        {
            if (ChapterNumInc.Value < 78)
            {
                string chapterRouteID = $"{ChapterNumInc.Value:00}{RouteComboBox.Text}";
                string chapterCommonID = $"{ChapterNumInc.Value:00}Common";
                string chapterCommonBID = $"{ChapterNumInc.Value:00}CommonB";
                if (DatabaseLoad.ChapterRecords.ContainsKey(chapterRouteID))
                {
                    GeneralData.ChapterID = chapterRouteID;
                    ChapterNameTextBox.Text = DatabaseLoad.ChapterRecords[chapterRouteID];
                    ChapterIDLabel.Text = $"Chapter ID - {chapterRouteID}";
                }
                else if (EventFlagEditor.RouteBEnabled && DatabaseLoad.ChapterRecords.ContainsKey(chapterCommonBID))
                {
                    GeneralData.ChapterID = chapterCommonBID;
                    ChapterNameTextBox.Text = DatabaseLoad.ChapterRecords[chapterCommonBID];
                    ChapterIDLabel.Text = $"Chapter ID - {chapterCommonBID}";
                }
                else if (DatabaseLoad.ChapterRecords.ContainsKey(chapterCommonID))
                {
                    // Route B Fallback to 75B to prevent selecting chapter nums that do not exist on Route B
                    if (EventFlagEditor.RouteBEnabled && ((ChapterNumInc.Value == 76) || (ChapterNumInc.Value == 77)))
                    {
                        chapterCommonID = "75CommonB";
                        GeneralData.Chapter = 75;
                    }

                    GeneralData.ChapterID = chapterCommonID;
                    ChapterNameTextBox.Text = DatabaseLoad.ChapterRecords[chapterCommonID];
                    ChapterIDLabel.Text = $"Chapter ID - {chapterCommonID}";
                }
            }
            else
            {
                // Dream Again chapter handling
                string chapterDAID = $"{(ChapterNumInc.Value - 77):00}OST";
                GeneralData.ChapterID = chapterDAID;
                ChapterNameTextBox.Text = DatabaseLoad.ChapterRecords[chapterDAID];
                ChapterIDLabel.Text = $"Chapter ID - {chapterDAID}";
            }

            /* Must be set to 0/False after changing route/chapter
             * to signal to Intermission handler that 
             * team data/deployment slots/bonus data have not been initialized
             * Game will then run routine to initialize these structures and correctly update them according to chapter
             */
            GeneralData.ApplyIMInit = 0;
        }
    }
}
