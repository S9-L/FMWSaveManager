using FMWSaveManager.FileFormats;
using FMWSaveManager.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FMWSaveManager.Editors
{
    public partial class ChapterEditor : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ChapterClearData ChapterData { get; set; }
        public ChapterEditor()
        {
            InitializeComponent();
            BindingHelper.SetDoubleBuffer(ChapterListBox, true);
            BindingHelper.SetDoubleBuffer(DifficultyComboBox, true);
        }

        public void init(int index)
        {
            DifficultyComboBox.DataBindings.Clear();
            BindingSource difficultyBinding = new BindingSource();
            difficultyBinding.DataSource = ChapterData.ChapDifficulties;
            difficultyBinding.Position = index;

            DifficultyComboBox.DisplayMember = "Value";
            DifficultyComboBox.ValueMember = "Key";
            DifficultyComboBox.DataSource = new BindingSource(FMWSaveManagerConstants.diffMap, null);

            DifficultyComboBox.DataBindings.Add("SelectedValue", difficultyBinding, "", false, DataSourceUpdateMode.OnPropertyChanged);

            BindingHelper.BindListValues(TurnsTakenInc, "Value", ChapterData.ChapTurns, index);
            BindingHelper.BindListValues(ClearTimeInc, "Value", ChapterData.ChapPlayTime, index);
            BindingHelper.BindListValues(KillsInc, "Value", ChapterData.ChapKills, index);
            BindingHelper.BindListValues(EnemiesInc, "Value", ChapterData.ChapEnemies, index);
            BindingHelper.BindListValues(CasualtiesInc, "Value", ChapterData.ChapCasualties, index);
            BindingHelper.BindListValues(PointsInc, "Value", ChapterData.ChapPoints, index);
            BindingHelper.BindListValues(SpellcardsInc, "Value", ChapterData.ChapSpellsCaptured, index);
            BindingHelper.BindListValues(TotalSpellcardsCapturedInc, "Value", ChapterData.ChapTotalSpells, index);
            BindingHelper.BindListValues(GameOverInc, "Value", ChapterData.ChapGameOvers, index);

            BonusCheckBox.Checked = ChapterData.ChapBonusAchieved[ChapterListBox.SelectedIndex] == 1;

            BindingHelper.BindListValues(SavesInc, "Value", ChapterData.ChapSaves, index);
            BindingHelper.BindListValues(LoadsInc, "Value", ChapterData.ChapLoads, index);
        }

        public void initBind()
        {
            sbyte prevChapter = -1;
            HashSet<sbyte> interludeChapters = new HashSet<sbyte> { 11, 49 };
            List<string> displayChapters = new List<string>(ChapterData
                .Chaps
                .Select(chap =>
                {
                    if (interludeChapters.Contains(prevChapter))
                    {
                        prevChapter = -1;
                        return "Chapter " + chap.ToString() + "x";
                    }
                    else
                    {
                        prevChapter = (sbyte)chap;
                        return "Chapter " + chap.ToString();
                    }
                })
                .ToList());
            ChapterListBox.DataSource = displayChapters;
        }

        private void ChapterListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            init((sender as AlternateListBox).SelectedIndex);
        }

        private void BonusCheckBox_Click(object sender, EventArgs e)
        {
            ChapterData.ChapBonusAchieved[ChapterListBox.SelectedIndex] = (byte)(BonusCheckBox.Checked ? 1 : 0);
        }
    }
}
