using FMWSaveManager.FileFormats;
using FMWSaveManager.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace FMWSaveManager.Editors
{
    public partial class CharEditor : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CharData cData { get; set; }
        private NumericUpDown[] statArray;
        private ComboBox[] skillArray;
        private NumericUpDown[] skillLvlArray;
        private int previousIndex = -1;
        private uint previousPP;
        private bool EXPUpdate = false;
        private bool LvlUpdate = false;
        private string[] charSort;
        private int[] originalIndices;
        private static Dictionary<int, int> sortIndexMap = new Dictionary<int, int>();
        public CharEditor()
        {
            InitializeComponent();
            BindingHelper.SetDoubleBuffer(EntityCharListBox, true);
            this.statArray = [MeleeInc, RangeInc, SkillInc, DefenseInc, EvadeInc, AccuracyInc];
            this.skillArray = [SkillSlot1, SkillSlot2, SkillSlot3, SkillSlot4, SkillSlot5, SkillSlot6, SkillSlot7, SkillSlot8];
            this.skillLvlArray = [SkillLvl1, SkillLvl2, SkillLvl3, SkillLvl4, SkillLvl5, SkillLvl6, SkillLvl7, SkillLvl8];
            for (int i = 0; i < this.skillArray.Length; i++)
            {
                BindingHelper.SetDoubleBuffer(this.skillArray[i], true);
            }
            BindingHelper.SetDoubleBuffer(WP1ComboBox, true);
            BindingHelper.SetDoubleBuffer(WP2ComboBox, true);
        }

        public void initBind()
        {
            AlphabetSortCheckBox.Checked = Properties.Settings.Default.EntityCharSort;
            if (Properties.Settings.Default.EntityCharSort)
            {
                TriggerSort();
            }
            else
            {
                EntityCharListBox.DataBindings.Clear();
                BindingList<string> bindingCharNames = new BindingList<string>(cData.CharNames);
                BindingSource bindingWrapper = new BindingSource();
                bindingWrapper.DataSource = bindingCharNames;
                EntityCharListBox.DataSource = bindingWrapper;
            }

            if (cData.CharNames.Count == 0)
            {
                CharNameTextBox.Clear();
                CharIDTextBox.Clear();

                foreach (NumericUpDown ctl in statArray)
                {
                    ctl.Value = ctl.Minimum;
                }

                foreach (ComboBox ctl in skillArray)
                {
                    ctl.Text = FMWSaveManagerConstants.SkillComboBoxDefaultText;
                }

                foreach (NumericUpDown ctl in skillLvlArray)
                {
                    ctl.Value = ctl.Minimum;
                }

                EXPInc.Value = EXPInc.Minimum;
                LevelInc.Value = LevelInc.Minimum;
                KillsInc.Value = KillsInc.Minimum;
                CurrPPInc.Value = CurrPPInc.Minimum;
                CurrentWPInc.Value = CurrentWPInc.Minimum;
                TotalPPLabel.Text = "Total PP";

                StoredSkillsTextBox.Clear();

                WP1ComboBox.Text = FMWSaveManagerConstants.WPComboBoxDefaultText;
                WP2ComboBox.Text = FMWSaveManagerConstants.WPComboBoxDefaultText;

                WP1ComboBox.Enabled = false;
                WP2ComboBox.Enabled = false;
                WPB1Label.Enabled = false;
                WPB2Label.Enabled = false;

                WPBonusAdded.Checked = false;
                WPBonusAdded.Enabled = false;
            }

            this.Enabled = true;
        }

        public void init(int index)
        {
            BindingHelper.BindListValues(CharNameTextBox, "Text", cData.CharNames, index);
            BindingHelper.BindListValues(CharIDTextBox, "Text", cData.CharIDs, index);

            BindingHelper.BindListValues(this.statArray, "Value", cData.StatsLv[index]);

            for (int i = 0; i < skillArray.Length; i++)
            {
                skillArray[i].DataBindings.Clear();
                BindingSource skillBinding = new BindingSource();

                skillBinding.DataSource = cData.SkillIDs[index];
                skillBinding.Position = i;

                skillArray[i].DataBindings.Add("Text", skillBinding, "", false, DataSourceUpdateMode.OnPropertyChanged);
            }

            BindingHelper.BindListValues(this.skillLvlArray, "Value", cData.SkillsLv[index]);
            BindingHelper.BindListValues(EXPInc, "Value", cData.Curr_EXP, index);
            LevelInc.Value = (cData.Curr_EXP[index] / 500) + 1;
            BindingHelper.BindListValues(KillsInc, "Value", cData.Curr_Kills, index);
            previousPP = cData.Curr_PP[index];
            BindingHelper.BindListValues(CurrPPInc, "Value", cData.Curr_PP, index);
            TotalPPLabel.Text = $"Total PP - {cData.TotalPP[index]}";
            BindingHelper.BindListValues(CurrentWPInc, "Value", cData.Curr_WP, index);
            BindingHelper.BindListValues(StoredSkillsTextBox, "Text", cData.ReserveSkills, index);

            WP1ComboBox.DataSource = FMWSaveManagerConstants.WPB1List;
            WP2ComboBox.DataSource = FMWSaveManagerConstants.WPB2List;

            WPBonusAdded.Enabled = true;
            if (cData.SelectedWPB[index] != -1)
            {
                WP1ComboBox.SelectedIndex = (cData.SelectedWPB[index] / 10) - 1;
                WP2ComboBox.SelectedIndex = (cData.SelectedWPB[index] % 10) - 1;

                WP1ComboBox.Enabled = true;
                WP2ComboBox.Enabled = true;
                WPB1Label.Enabled = true;
                WPB2Label.Enabled = true;

                WPBonusAdded.Checked = true;
            }
            else
            {
                WP1ComboBox.SelectedIndex = 0;
                WP2ComboBox.SelectedIndex = 0;

                WP1ComboBox.Enabled = false;
                WP2ComboBox.Enabled = false;
                WPB1Label.Enabled = false;
                WPB2Label.Enabled = false;

                WPBonusAdded.Checked = false;
            }
        }

        private void EntityCharListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TriggerInitialization();
        }

        private void TriggerInitialization()
        {
            EntityCharListBox.SelectedIndexChanged -= EntityCharListBox_SelectedIndexChanged;
            // Update ListBox name
            if (previousIndex != -1)
            {
                if (Properties.Settings.Default.EntityCharSort && CharNameTextBox.Modified)
                {
                    charSort[sortIndexMap[previousIndex]] = CharNameTextBox.Text;
                    (EntityCharListBox.DataSource as BindingSource).ResetItem(sortIndexMap[previousIndex]);
                    CharNameTextBox.Modified = false;
                }
                if (previousIndex == 0)
                {
                    (EntityCharListBox.DataSource as BindingSource).ResetBindings(false);
                }
                else
                {
                    (EntityCharListBox.DataSource as BindingSource).ResetItem(previousIndex);
                }
            }
            EntityCharListBox.SelectedIndexChanged += EntityCharListBox_SelectedIndexChanged;
            if (Properties.Settings.Default.EntityCharSort)
            {
                previousIndex = originalIndices[EntityCharListBox.SelectedIndex];
            }
            else
            {
                previousIndex = EntityCharListBox.SelectedIndex;
            }
            InitializeEntityCharData(previousIndex);
        }

        private void InitializeEntityCharData(int index)
        {
            this.init(index);
        }

        private void CurrPPInc_ValueChanged(object sender, EventArgs e)
        {
            int typeIndex = (Properties.Settings.Default.EntityCharSort) ? originalIndices[EntityCharListBox.SelectedIndex] : EntityCharListBox.SelectedIndex;
            if (typeIndex != -1)
            {
                int incrementVal = (int)(CurrPPInc.Value - previousPP);
                if (incrementVal > 0 && cData.TotalPP[typeIndex] > FMWSaveManagerConstants.maxPP - incrementVal)
                {
                    CurrPPInc.Value = CurrPPInc.Value - (incrementVal - (FMWSaveManagerConstants.maxPP - cData.TotalPP[typeIndex]));
                    cData.TotalPP[typeIndex] = (uint)FMWSaveManagerConstants.maxPP;
                }
                else
                {
                    cData.TotalPP[typeIndex] = (uint)Math.Max(0, cData.TotalPP[typeIndex] + incrementVal);
                }
                TotalPPLabel.Text = $"Total PP - {cData.TotalPP[typeIndex]}";
                previousPP = (uint)CurrPPInc.Value;
            }
        }

        private void LevelInc_ValueChanged(object sender, EventArgs e)
        {
            if (EXPUpdate)
            {
                return;
            }

            LvlUpdate = true;
            EXPInc.Value = 500 * (LevelInc.Value - 1);
            LvlUpdate = false;
        }

        private void EXPInc_ValueChanged(object sender, EventArgs e)
        {
            if (LvlUpdate)
            {
                return;
            }

            EXPUpdate = true;
            LevelInc.Value = ((int)EXPInc.Value / 500) + 1;
            EXPUpdate = false;
        }

        private void WPBonusAdded_Click(object sender, EventArgs e)
        {
            int typeIndex = (Properties.Settings.Default.EntityCharSort) ? originalIndices[EntityCharListBox.SelectedIndex] : EntityCharListBox.SelectedIndex;
            if (WPBonusAdded.Checked)
            {
                cData.SelectedWPB[typeIndex] = (sbyte)(((sbyte)(WP1ComboBox.SelectedIndex + 1) * 10) + (sbyte)WP2ComboBox.SelectedIndex + 1);

                WP1ComboBox.Enabled = true;
                WP2ComboBox.Enabled = true;
                WPB1Label.Enabled = true;
                WPB2Label.Enabled = true;
            }
            else
            {
                cData.SelectedWPB[typeIndex] = -1;

                WP1ComboBox.Enabled = false;
                WP2ComboBox.Enabled = false;
                WPB1Label.Enabled = false;
                WPB2Label.Enabled = false;
            }
        }

        private void WP1ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int typeIndex = (Properties.Settings.Default.EntityCharSort) ? originalIndices[EntityCharListBox.SelectedIndex] : EntityCharListBox.SelectedIndex;
            cData.SelectedWPB[typeIndex] = (sbyte)(((WP1ComboBox.SelectedIndex + 1) * 10) + WP2ComboBox.SelectedIndex + 1);
        }

        private void WP2ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int typeIndex = (Properties.Settings.Default.EntityCharSort) ? originalIndices[EntityCharListBox.SelectedIndex] : EntityCharListBox.SelectedIndex;
            cData.SelectedWPB[typeIndex] = (sbyte)(((WP1ComboBox.SelectedIndex + 1) * 10) + WP2ComboBox.SelectedIndex + 1);
        }

        private void AddCharButton_Click(object sender, EventArgs e)
        {
            CharNameTextBox.Modified = false;
            int initialSelect = EntityCharListBox.SelectedIndex;
            int topIndex = EntityCharListBox.TopIndex;
            int charListSize = cData.CharNames.Count;

            cData.CharNames.Insert(charListSize, FMWSaveManagerConstants.addCharName);
            cData.CharIDs.Insert(charListSize, FMWSaveManagerConstants.addCharID);
            cData.StatsLv.Insert(charListSize, FMWSaveManagerConstants.addStats);
            cData.SkillIDs.Insert(charListSize, FMWSaveManagerConstants.addSkillIDs);
            cData.SkillsLv.Insert(charListSize, FMWSaveManagerConstants.addSkillLvs);
            cData.Curr_EXP.Insert(charListSize, FMWSaveManagerConstants.addEXP);
            cData.Curr_Kills.Insert(charListSize, FMWSaveManagerConstants.addKills);
            cData.Curr_PP.Insert(charListSize, FMWSaveManagerConstants.addPP);
            cData.TotalPP.Insert(charListSize, FMWSaveManagerConstants.addTotalPP);
            cData.Curr_WP.Insert(charListSize, FMWSaveManagerConstants.addWP);
            cData.ReserveSkills.Insert(charListSize, FMWSaveManagerConstants.addReserveSkills);
            cData.SelectedWPB.Insert(charListSize, FMWSaveManagerConstants.addWPB);

            EntityCharListBox.BeginUpdate();
            if (Properties.Settings.Default.EntityCharSort)
            {
                TriggerSort();
                EntityCharListBox.SelectedIndexChanged -= EntityCharListBox_SelectedIndexChanged;
                EntityCharListBox.SelectedIndex = initialSelect;
                EntityCharListBox.SelectedIndexChanged += EntityCharListBox_SelectedIndexChanged;

            }

            if (cData.CharNames.Count == 1)
            {
                (EntityCharListBox.DataSource as BindingSource).ResetBindings(false);
                TriggerInitialization();
            }
            else
            {
                TriggerInitialization();
                (EntityCharListBox.DataSource as BindingSource).ResetBindings(false);
            }
            EntityCharListBox.TopIndex = topIndex;
            EntityCharListBox.EndUpdate();
        }

        private void RemoveCharButton_Click(object sender, EventArgs e)
        {
            if (EntityCharListBox.Items.Count > 0)
            {
                CharNameTextBox.Modified = false;
                int initialSelect = EntityCharListBox.SelectedIndex;
                int topIndex = EntityCharListBox.TopIndex;
                int removeIndex = (Properties.Settings.Default.EntityCharSort) ? originalIndices[EntityCharListBox.SelectedIndex] : EntityCharListBox.SelectedIndex;

                cData.CharNames.RemoveAt(removeIndex);
                cData.CharIDs.RemoveAt(removeIndex);
                cData.StatsLv.RemoveAt(removeIndex);
                cData.SkillIDs.RemoveAt(removeIndex);
                cData.SkillsLv.RemoveAt(removeIndex);
                cData.Curr_EXP.RemoveAt(removeIndex);
                cData.Curr_Kills.RemoveAt(removeIndex);
                cData.Curr_PP.RemoveAt(removeIndex);
                cData.TotalPP.RemoveAt(removeIndex);
                cData.Curr_WP.RemoveAt(removeIndex);
                cData.ReserveSkills.RemoveAt(removeIndex);
                cData.SelectedWPB.RemoveAt(removeIndex);

                EntityCharListBox.BeginUpdate();
                if (Properties.Settings.Default.EntityCharSort)
                {
                    TriggerSort();

                    if (cData.CharNames.Count > 0)
                    {
                        EntityCharListBox.SelectedIndex = Math.Min(initialSelect, cData.CharNames.Count - 1);
                    }
                }

                (EntityCharListBox.DataSource as BindingSource).ResetBindings(false);
                EntityCharListBox.TopIndex = topIndex;
                EntityCharListBox.EndUpdate();

                int updatedIndex = (Properties.Settings.Default.EntityCharSort && cData.CharNames.Count > 0) ? originalIndices[EntityCharListBox.SelectedIndex] : EntityCharListBox.SelectedIndex;

                if (EntityCharListBox.Items.Count == 0)
                {
                    CharNameTextBox.DataBindings.Clear();
                    CharNameTextBox.Clear();
                    CharIDTextBox.DataBindings.Clear();
                    CharIDTextBox.Clear();

                    foreach (NumericUpDown ctl in statArray)
                    {
                        ctl.DataBindings.Clear();
                        ctl.Value = ctl.Minimum;
                    }

                    foreach (ComboBox ctl in skillArray)
                    {
                        ctl.DataBindings.Clear();
                        ctl.Text = FMWSaveManagerConstants.SkillComboBoxDefaultText;
                    }

                    foreach (NumericUpDown ctl in skillLvlArray)
                    {
                        ctl.DataBindings.Clear();
                        ctl.Value = ctl.Minimum;
                    }

                    EXPInc.DataBindings.Clear();
                    EXPInc.Value = EXPInc.Minimum;
                    LevelInc.Value = LevelInc.Minimum;
                    KillsInc.DataBindings.Clear();
                    KillsInc.Value = KillsInc.Minimum;
                    CurrPPInc.DataBindings.Clear();
                    CurrPPInc.Value = CurrPPInc.Minimum;
                    CurrentWPInc.DataBindings.Clear();
                    CurrentWPInc.Value = CurrentWPInc.Minimum;
                    TotalPPLabel.Text = "Total PP";

                    WP1ComboBox.SelectedIndex = 0;
                    WP2ComboBox.SelectedIndex = 0;

                    WP1ComboBox.Enabled = false;
                    WP2ComboBox.Enabled = false;
                    WPB1Label.Enabled = false;
                    WPB2Label.Enabled = false;

                    WPBonusAdded.Checked = false;
                    WPBonusAdded.Enabled = false;

                    StoredSkillsTextBox.DataBindings.Clear();
                    StoredSkillsTextBox.Clear();
                }
                else
                {
                    if (removeIndex == updatedIndex)
                    {
                        TriggerInitialization();
                    }
                }
            }
        }

        private void TriggerSort()
        {
            // Simple Array-Original Index pairing sort
            charSort = cData.CharNames.ToArray();
            originalIndices = Enumerable.Range(0, cData.CharNames.Count).ToArray();

            Array.Sort(charSort, originalIndices);
            sortIndexMap.Clear();

            for (int i = 0; i < originalIndices.Length; i++)
            {
                sortIndexMap[originalIndices[i]] = i;
            }

            sortIndexMap.Add(-1, -1);
            previousIndex = sortIndexMap.GetValueOrDefault(previousIndex, -1);

            EntityCharListBox.DataBindings.Clear();
            BindingList<string> bindingCharNames = new BindingList<string>(charSort);
            BindingSource bindingWrapper = new BindingSource();
            bindingWrapper.DataSource = bindingCharNames;
            EntityCharListBox.DataSource = bindingWrapper;
        }

        private void AlphabetSortCheckBox_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.EntityCharSort = AlphabetSortCheckBox.Checked;
            int initialSelect = EntityCharListBox.SelectedIndex;
            int topIndex = EntityCharListBox.TopIndex;

            EntityCharListBox.BeginUpdate();
            if (Properties.Settings.Default.EntityCharSort && EntityCharListBox.Items.Count > 0)
            {
                TriggerSort();
            }
            else
            {
                sortIndexMap.Clear();
                EntityCharListBox.DataBindings.Clear();
                BindingList<string> bindingCharNames = new BindingList<string>(cData.CharNames);
                BindingSource bindingWrapper = new BindingSource();
                bindingWrapper.DataSource = bindingCharNames;
                EntityCharListBox.DataSource = bindingWrapper;
            }
            EntityCharListBox.SelectedIndex = initialSelect;
            EntityCharListBox.TopIndex = topIndex;
            EntityCharListBox.EndUpdate();
        }
    }
}
