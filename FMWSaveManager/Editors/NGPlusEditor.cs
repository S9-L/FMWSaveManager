using FMWSaveManager.FileFormats;
using FMWSaveManager.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace FMWSaveManager.Editors
{
    public partial class NGPlusEditor : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NGPlusCarryover CarryoverData { get; set; }
        private int previousUnitIndex = -1;
        private int previousCharIndex = -1;
        private string[] unitSort;
        private int[] originalUnitIndices;
        private string[] charSort;
        private int[] originalCharIndices;
        private static Dictionary<int, int> sortUnitIndexMap = new Dictionary<int, int>();
        private static Dictionary<int, int> sortCharIndexMap = new Dictionary<int, int>();

        public NGPlusEditor()
        {
            InitializeComponent();
            BindingHelper.SetDoubleBuffer(NGPlusUnitListBox, true);
            BindingHelper.SetDoubleBuffer(NGPlusCharListBox, true);
        }

        public void initBind()
        {
            AlphabetSortUnitCheckBox.Checked = Properties.Settings.Default.NGPlusUnitSort;
            if (Properties.Settings.Default.NGPlusUnitSort)
            {
                TriggerUnitSort();
            }
            else
            {
                NGPlusUnitListBox.DataBindings.Clear();
                BindingList<string> bindingUnitNames = new BindingList<string>(CarryoverData.NgPlusUnitNames);
                BindingSource bindingWrapper = new BindingSource();
                bindingWrapper.DataSource = bindingUnitNames;
                NGPlusUnitListBox.DataSource = bindingWrapper;
            }

            AlphabetSortCharCheckBox.Checked = Properties.Settings.Default.NGPlusCharSort;
            if (Properties.Settings.Default.NGPlusCharSort)
            {
                TriggerCharSort();
            }
            else
            {
                NGPlusCharListBox.DataBindings.Clear();
                BindingList<string> bindingCharNames = new BindingList<string>(CarryoverData.NgPlusCharNames);
                BindingSource bindingWrapper = new BindingSource();
                bindingWrapper.DataSource = bindingCharNames;
                NGPlusCharListBox.DataSource = bindingWrapper;
            }

            if (CarryoverData.NgPlusUnitNames.Count == 0)
            {
                UnitNameTextBox.Clear();
                UnitIDTextBox.Clear();
            }

            if (CarryoverData.NgPlusCharNames.Count == 0)
            {
                CharNameTextBox.Clear();
                CharIDTextBox.Clear();

                CPPInc.Value = CPPInc.Minimum;
                CKillsInc.Value = CKillsInc.Minimum;
            }
        }

        public void init()
        {
            CTotalPointsInc.DataBindings.Clear();
            CTotalPointsInc.DataBindings.Add("Value", CarryoverData, "c_TotalPoints", false, DataSourceUpdateMode.OnPropertyChanged);

            CTotalWPInc.DataBindings.Clear();
            CTotalWPInc.DataBindings.Add("Value", CarryoverData, "c_TotalWP", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void NGPlusUnitListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TriggerUnitInitialization();
        }

        private void TriggerUnitInitialization()
        {
            NGPlusUnitListBox.SelectedIndexChanged -= NGPlusUnitListBox_SelectedIndexChanged;
            // Update ListBox name
            if (previousUnitIndex != -1)
            {
                if (Properties.Settings.Default.NGPlusUnitSort && UnitNameTextBox.Modified)
                {
                    unitSort[sortUnitIndexMap[previousUnitIndex]] = UnitNameTextBox.Text;
                    (NGPlusUnitListBox.DataSource as BindingSource).ResetItem(sortUnitIndexMap[previousUnitIndex]);
                    UnitNameTextBox.Modified = false;
                }
                else
                {
                    if (previousUnitIndex == 0)
                    {
                        (NGPlusUnitListBox.DataSource as BindingSource).ResetBindings(false);
                    }
                    else
                    {
                        (NGPlusUnitListBox.DataSource as BindingSource).ResetItem(previousUnitIndex);
                    }
                }
            }
            NGPlusUnitListBox.SelectedIndexChanged += NGPlusUnitListBox_SelectedIndexChanged;
            if (Properties.Settings.Default.NGPlusUnitSort)
            {
                previousUnitIndex = originalUnitIndices[NGPlusUnitListBox.SelectedIndex];
            }
            else
            {
                previousUnitIndex = NGPlusUnitListBox.SelectedIndex;
            }

            BindNGPlusUnits(previousUnitIndex);
        }

        private void BindNGPlusUnits(int index)
        {
            BindingHelper.BindListValues(UnitNameTextBox, "Text", CarryoverData.NgPlusUnitNames, index);
            if (CarryoverData.NgPlusUnitNames[index] == "Seirensen")
            {
                // Hardcoded save format to not associate any UnitID with the Palanquin Ship
                UnitIDTextBox.DataBindings.Clear();
                UnitIDTextBox.Clear();
                UnitIDTextBox.ReadOnly = true;
            }
            else
            {
                UnitIDTextBox.ReadOnly = false;
                BindingHelper.BindListValues(UnitIDTextBox, "Text", CarryoverData.NgPlusUnitIDs, index);
            }
        }

        private void NGPlusCharListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TriggerCharInitialization();
        }

        private void TriggerCharInitialization()
        {
            NGPlusCharListBox.SelectedIndexChanged -= NGPlusCharListBox_SelectedIndexChanged;
            // Update ListBox name
            if (previousCharIndex != -1)
            {
                if (Properties.Settings.Default.NGPlusCharSort && CharNameTextBox.Modified)
                {
                    charSort[sortCharIndexMap[previousCharIndex]] = CharNameTextBox.Text;
                    (NGPlusCharListBox.DataSource as BindingSource).ResetItem(sortCharIndexMap[previousCharIndex]);
                    CharNameTextBox.Modified = false;
                }
                else
                {
                    if (previousCharIndex == 0)
                    {
                        (NGPlusCharListBox.DataSource as BindingSource).ResetBindings(false);
                    }
                    else
                    {
                        (NGPlusCharListBox.DataSource as BindingSource).ResetItem(previousCharIndex);
                    }
                }
            }
            NGPlusCharListBox.SelectedIndexChanged += NGPlusCharListBox_SelectedIndexChanged;
            if (Properties.Settings.Default.NGPlusCharSort)
            {
                previousCharIndex = originalCharIndices[NGPlusCharListBox.SelectedIndex];
            }
            else
            {
                previousCharIndex = NGPlusCharListBox.SelectedIndex;
            }

            BindNGPlusChars(previousCharIndex);
        }

        private void BindNGPlusChars(int index)
        {
            BindingHelper.BindListValues(CharNameTextBox, "Text", CarryoverData.NgPlusCharNames, index);
            BindingHelper.BindListValues(CharIDTextBox, "Text", CarryoverData.NgPlusCharIDs, index);

            BindingHelper.BindListValues(CPPInc, "Value", CarryoverData.c_PP, index);
            BindingHelper.BindListValues(CKillsInc, "Value", CarryoverData.c_Kills, index);
        }

        private void AddNGPlusUnitButton_Click(object sender, EventArgs e)
        {
            UnitNameTextBox.Modified = false;
            int initialSelect = NGPlusUnitListBox.SelectedIndex;
            int topIndex = NGPlusUnitListBox.TopIndex;

            // Need to insert at beginning to preserve original hardcoded last element Palanquin Ship not having a UnitID 
            CarryoverData.NgPlusUnitNames.Insert(0, FMWSaveManagerConstants.addUnitName);
            CarryoverData.NgPlusUnitIDs.Insert(0, FMWSaveManagerConstants.addUnitID);

            NGPlusUnitListBox.BeginUpdate();
            if (Properties.Settings.Default.NGPlusUnitSort)
            {
                TriggerUnitSort();
                NGPlusUnitListBox.SelectedIndexChanged -= NGPlusUnitListBox_SelectedIndexChanged;
                NGPlusUnitListBox.SelectedIndex = initialSelect;
                NGPlusUnitListBox.SelectedIndexChanged += NGPlusUnitListBox_SelectedIndexChanged;
            }

            if (CarryoverData.NgPlusUnitNames.Count == 1)
            {
                (NGPlusUnitListBox.DataSource as BindingSource).ResetBindings(false);
                TriggerUnitInitialization();
            }
            else
            {
                TriggerUnitInitialization();
                (NGPlusUnitListBox.DataSource as BindingSource).ResetBindings(false);
            }
            NGPlusUnitListBox.TopIndex = topIndex;
            NGPlusUnitListBox.EndUpdate();
        }

        private void RemoveNGPlusUnitButton_Click(object sender, EventArgs e)
        {
            // Disallow removing Palanquin Ship to preserve original NgPlusUnitNames format
            int removeIndex = (Properties.Settings.Default.NGPlusUnitSort) ? originalUnitIndices[NGPlusUnitListBox.SelectedIndex] : NGPlusUnitListBox.SelectedIndex;
            if (NGPlusUnitListBox.Items.Count > 0 && CarryoverData.NgPlusUnitNames[removeIndex] != "Seirensen")
            {
                UnitNameTextBox.Modified = false;
                int initialSelect = NGPlusUnitListBox.SelectedIndex;
                int topIndex = NGPlusUnitListBox.TopIndex;

                CarryoverData.NgPlusUnitNames.RemoveAt(removeIndex);
                CarryoverData.NgPlusUnitIDs.RemoveAt(removeIndex);

                NGPlusUnitListBox.BeginUpdate();
                if (Properties.Settings.Default.NGPlusUnitSort)
                {
                    TriggerUnitSort();
                    if (CarryoverData.NgPlusUnitNames.Count > 0)
                    {
                        NGPlusUnitListBox.SelectedIndex = Math.Min(initialSelect, CarryoverData.NgPlusUnitNames.Count - 1);
                    }

                }

                (NGPlusUnitListBox.DataSource as BindingSource).ResetBindings(false);
                NGPlusUnitListBox.TopIndex = topIndex;
                NGPlusUnitListBox.EndUpdate();

                int updatedIndex = (Properties.Settings.Default.NGPlusUnitSort && CarryoverData.NgPlusUnitNames.Count > 0) ? originalUnitIndices[NGPlusUnitListBox.SelectedIndex] : NGPlusUnitListBox.SelectedIndex;

                if (NGPlusUnitListBox.Items.Count == 0)
                {
                    UnitNameTextBox.DataBindings.Clear();
                    UnitNameTextBox.Clear();
                    UnitIDTextBox.DataBindings.Clear();
                    UnitIDTextBox.Clear();
                }
                else
                {
                    if (removeIndex == updatedIndex)
                    {
                        TriggerUnitInitialization();
                    }
                }
            }
        }

        private void AddNGPlusCharButton_Click(object sender, EventArgs e)
        {
            CharNameTextBox.Modified = false;
            int initialSelect = NGPlusCharListBox.SelectedIndex;
            int topIndex = NGPlusCharListBox.TopIndex;

            CarryoverData.NgPlusCharNames.Insert(0, FMWSaveManagerConstants.addCharName);
            CarryoverData.NgPlusCharIDs.Insert(0, FMWSaveManagerConstants.addCharID);

            // c_PP and c_Kills are adhoc lists that can grow based on previous playthrough units that may also not exist
            CarryoverData.c_PP.Insert(0, FMWSaveManagerConstants.addc_PP);
            CarryoverData.c_Kills.Insert(0, FMWSaveManagerConstants.addc_Kills);

            NGPlusCharListBox.BeginUpdate();
            if (Properties.Settings.Default.NGPlusCharSort)
            {
                TriggerCharSort();
                NGPlusCharListBox.SelectedIndexChanged -= NGPlusCharListBox_SelectedIndexChanged;
                NGPlusCharListBox.SelectedIndex = initialSelect;
                NGPlusCharListBox.SelectedIndexChanged += NGPlusCharListBox_SelectedIndexChanged;
            }

            if (CarryoverData.NgPlusCharNames.Count == 1)
            {
                (NGPlusCharListBox.DataSource as BindingSource).ResetBindings(false);
                TriggerCharInitialization();
            }
            else
            {
                TriggerCharInitialization();
                (NGPlusCharListBox.DataSource as BindingSource).ResetBindings(false);
            }
            NGPlusCharListBox.TopIndex = topIndex;
            NGPlusCharListBox.EndUpdate();
        }

        private void RemoveNGPlusCharButton_Click(object sender, EventArgs e)
        {
            if (NGPlusCharListBox.Items.Count > 0)
            {
                CharNameTextBox.Modified = false;
                int initialSelect = NGPlusCharListBox.SelectedIndex;
                int topIndex = NGPlusCharListBox.TopIndex;
                int removeIndex = (Properties.Settings.Default.NGPlusCharSort) ? originalCharIndices[NGPlusCharListBox.SelectedIndex] : NGPlusCharListBox.SelectedIndex;

                CarryoverData.NgPlusCharNames.RemoveAt(removeIndex);
                CarryoverData.NgPlusCharIDs.RemoveAt(removeIndex);
                CarryoverData.c_PP.RemoveAt(removeIndex);
                CarryoverData.c_Kills.RemoveAt(removeIndex);

                NGPlusCharListBox.BeginUpdate();
                if (Properties.Settings.Default.NGPlusCharSort)
                {
                    TriggerCharSort();
                    if (CarryoverData.NgPlusCharNames.Count > 0)
                    {
                        NGPlusCharListBox.SelectedIndex = Math.Min(initialSelect, CarryoverData.NgPlusCharNames.Count - 1);
                    }

                }

                (NGPlusCharListBox.DataSource as BindingSource).ResetBindings(false);
                NGPlusCharListBox.TopIndex = topIndex;
                NGPlusCharListBox.EndUpdate();

                int updatedIndex = (Properties.Settings.Default.NGPlusCharSort && CarryoverData.NgPlusCharNames.Count > 0) ? originalCharIndices[NGPlusCharListBox.SelectedIndex] : NGPlusCharListBox.SelectedIndex;

                if (NGPlusCharListBox.Items.Count == 0)
                {
                    CharNameTextBox.DataBindings.Clear();
                    CharNameTextBox.Clear();
                    CharIDTextBox.DataBindings.Clear();
                    CharIDTextBox.Clear();
                    CPPInc.DataBindings.Clear();
                    CPPInc.Value = CPPInc.Minimum;
                    CKillsInc.DataBindings.Clear();
                    CKillsInc.Value = CKillsInc.Minimum;
                }
                else
                {
                    if (removeIndex == updatedIndex)
                    {
                        TriggerCharInitialization();
                    }
                }
            }
        }

        private void TriggerUnitSort()
        {
            // Simple Array-Original Index pairing sort
            unitSort = CarryoverData.NgPlusUnitNames.ToArray();
            originalUnitIndices = Enumerable.Range(0, CarryoverData.NgPlusUnitNames.Count).ToArray();

            Array.Sort(unitSort, originalUnitIndices);
            sortUnitIndexMap.Clear();

            for (int i = 0; i < originalUnitIndices.Length; i++)
            {
                sortUnitIndexMap[originalUnitIndices[i]] = i;
            }

            sortUnitIndexMap.Add(-1, -1);
            previousUnitIndex = sortUnitIndexMap.GetValueOrDefault(previousUnitIndex, -1);

            NGPlusUnitListBox.DataBindings.Clear();
            BindingList<string> bindingUnitNames = new BindingList<string>(unitSort);
            BindingSource bindingWrapper = new BindingSource();
            bindingWrapper.DataSource = bindingUnitNames;
            NGPlusUnitListBox.DataSource = bindingWrapper;
        }

        private void TriggerCharSort()
        {
            // Simple Array-Original Index pairing sort
            charSort = CarryoverData.NgPlusCharNames.ToArray();
            originalCharIndices = Enumerable.Range(0, CarryoverData.NgPlusCharNames.Count).ToArray();

            Array.Sort(charSort, originalCharIndices);
            sortCharIndexMap.Clear();

            for (int i = 0; i < originalCharIndices.Length; i++)
            {
                sortCharIndexMap[originalCharIndices[i]] = i;
            }

            sortCharIndexMap.Add(-1, -1);
            previousCharIndex = sortCharIndexMap.GetValueOrDefault(previousCharIndex, -1);

            NGPlusCharListBox.DataBindings.Clear();
            BindingList<string> bindingCharNames = new BindingList<string>(charSort);
            BindingSource bindingWrapper = new BindingSource();
            bindingWrapper.DataSource = bindingCharNames;
            NGPlusCharListBox.DataSource = bindingWrapper;
        }

        private void AlphabetSortUnitCheckBox_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.NGPlusUnitSort = AlphabetSortUnitCheckBox.Checked;
            int initialSelect = NGPlusUnitListBox.SelectedIndex;
            int topIndex = NGPlusUnitListBox.TopIndex;

            NGPlusUnitListBox.BeginUpdate();
            if (Properties.Settings.Default.NGPlusUnitSort && NGPlusUnitListBox.Items.Count > 0)
            {
                TriggerUnitSort();
            }
            else
            {
                sortUnitIndexMap.Clear();
                NGPlusUnitListBox.DataBindings.Clear();
                BindingList<string> bindingUnitNames = new BindingList<string>(CarryoverData.NgPlusUnitNames);
                BindingSource bindingWrapper = new BindingSource();
                bindingWrapper.DataSource = bindingUnitNames;
                NGPlusUnitListBox.DataSource = bindingWrapper;
            }
            NGPlusUnitListBox.SelectedIndex = initialSelect;
            NGPlusUnitListBox.TopIndex = topIndex;
            NGPlusUnitListBox.EndUpdate();
        }

        private void AlphabetSortCharCheckBox_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.NGPlusCharSort = AlphabetSortCharCheckBox.Checked;
            int initialSelect = NGPlusCharListBox.SelectedIndex;
            int topIndex = NGPlusCharListBox.TopIndex;

            NGPlusCharListBox.BeginUpdate();
            if (Properties.Settings.Default.NGPlusCharSort && NGPlusCharListBox.Items.Count > 0)
            {
                TriggerCharSort();
            }
            else
            {
                sortCharIndexMap.Clear();
                NGPlusCharListBox.DataBindings.Clear();
                BindingList<string> bindingCharNames = new BindingList<string>(CarryoverData.NgPlusCharNames);
                BindingSource bindingWrapper = new BindingSource();
                bindingWrapper.DataSource = bindingCharNames;
                NGPlusCharListBox.DataSource = bindingWrapper;
            }
            NGPlusCharListBox.SelectedIndex = initialSelect;
            NGPlusCharListBox.TopIndex = topIndex;
            NGPlusCharListBox.EndUpdate();
        }
    }
}
