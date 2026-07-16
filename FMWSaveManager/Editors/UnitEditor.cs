using FMWSaveManager.FileFormats;
using FMWSaveManager.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace FMWSaveManager.Editors
{
    public partial class UnitEditor : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UnitData uData { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Button buttonAdd { get { return AddUnitButton; } set { AddUnitButton = value; } }
        private Control[] upgradeArray;
        private ComboBox[] itemArray;
        private string[] unitSort;
        private int[] originalIndices;
        private int previousIndex = -1;
        private static Dictionary<int, int> sortIndexMap = new Dictionary<int, int>();

        public UnitEditor()
        {
            InitializeComponent();
            BindingHelper.SetDoubleBuffer(FUBComboBox, true);
            BindingHelper.SetDoubleBuffer(Item1ComboBox, true);
            BindingHelper.SetDoubleBuffer(Item2ComboBox, true);
            BindingHelper.SetDoubleBuffer(Item3ComboBox, true);
            BindingHelper.SetDoubleBuffer(Item4ComboBox, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            BindingHelper.SetDoubleBuffer(EntityUnitListBox, true);
            this.upgradeArray = [HPInc, MPInc, MobilityInc, ArmorInc, WeaponInc];
            this.itemArray = [Item1ComboBox, Item2ComboBox, Item3ComboBox, Item4ComboBox];
        }

        public void initBind()
        {
            AlphabetSortCheckBox.Checked = Properties.Settings.Default.EntityUnitSort;
            if (Properties.Settings.Default.EntityUnitSort)
            {
                TriggerSort();
            }
            else
            {
                EntityUnitListBox.DataBindings.Clear();
                BindingList<string> bindingUnitNames = new BindingList<string>(uData.UnitNames);
                BindingSource bindingWrapper = new BindingSource();
                bindingWrapper.DataSource = bindingUnitNames;
                EntityUnitListBox.DataSource = bindingWrapper;
            }

            if (uData.UnitNames.Count == 0)
            {
                foreach (NumericUpDown ctl in this.upgradeArray)
                {
                    ctl.Value = ctl.Minimum;
                }

                UnitNameTextBox.Clear();
                UnitIDTextBox.Clear();
                UnitBGMTextBox.Clear();
                FUBComboBox.Text = FMWSaveManagerConstants.FUBComboBoxDefaultText;

                foreach (ComboBox ctl in itemArray)
                {
                    ctl.Text = FMWSaveManagerConstants.ItemComboBoxDefaultText;
                }
            }

            this.Enabled = true;
        }

        public void init(int index)
        {
            BindingHelper.BindListValues(this.upgradeArray, "Value", uData.u_UpgradesLv[index]);
            BindingHelper.BindListValues(UnitNameTextBox, "Text", uData.UnitNames, index);
            BindingHelper.BindListValues(UnitIDTextBox, "Text", uData.UnitIDs, index);
            BindingHelper.BindListValues(UnitBGMTextBox, "Text", uData.u_BGM, index);

            FUBComboBox.DataBindings.Clear();
            BindingSource FUBBinding = new BindingSource();
            FUBBinding.DataSource = uData.SelectedFUB;
            FUBBinding.Position = index;

            FUBComboBox.DisplayMember = "Value";
            FUBComboBox.ValueMember = "Key";
            FUBComboBox.DataSource = new BindingSource(FMWSaveManagerConstants.FUBMap, null);

            FUBComboBox.DataBindings.Add("SelectedValue", FUBBinding, "", false, DataSourceUpdateMode.OnPropertyChanged);

            for (int i = 0; i < itemArray.Length; i++)
            {
                itemArray[i].BeginUpdate();
                itemArray[i].DataBindings.Clear();
                itemArray[i].DisplayMember = (Properties.Settings.Default.ToggleItemNameUnit) ? "Value" : "Key";
                itemArray[i].ValueMember = "Key";
                itemArray[i].DataSource = new BindingSource(DatabaseLoad.ItemRecords, null);

                BindingSource itemBinding = new BindingSource();
                itemBinding.DataSource = uData.u_ItemIDs[index];
                itemBinding.Position = i;

                itemArray[i].DataBindings.Add("SelectedValue", itemBinding, "", false, DataSourceUpdateMode.OnPropertyChanged);
                itemArray[i].EndUpdate();
            }
        }

        private void EntityUnitListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TriggerInitialization();
        }

        private void TriggerInitialization()
        {
            EntityUnitListBox.SelectedIndexChanged -= EntityUnitListBox_SelectedIndexChanged;
            // Update ListBox name
            if (previousIndex != -1)
            {
                if (Properties.Settings.Default.EntityUnitSort && UnitNameTextBox.Modified)
                {
                    unitSort[sortIndexMap[previousIndex]] = UnitNameTextBox.Text;
                    (EntityUnitListBox.DataSource as BindingSource).ResetItem(sortIndexMap[previousIndex]);
                    UnitNameTextBox.Modified = false;
                }
                if (previousIndex == 0)
                {
                    (EntityUnitListBox.DataSource as BindingSource).ResetBindings(false);
                }
                else
                {
                    (EntityUnitListBox.DataSource as BindingSource).ResetItem(previousIndex);
                }
            }
            EntityUnitListBox.SelectedIndexChanged += EntityUnitListBox_SelectedIndexChanged;
            if (Properties.Settings.Default.EntityUnitSort)
            {
                previousIndex = originalIndices[EntityUnitListBox.SelectedIndex];
            }
            else
            {
                previousIndex = EntityUnitListBox.SelectedIndex;
            }
            InitializeEntityUnitData(previousIndex);
        }

        private void InitializeEntityUnitData(int index)
        {
            this.init(index);
        }

        private void AddUnitButton_Click(object sender, EventArgs e)
        {
            UnitNameTextBox.Modified = false;
            int initialSelect = EntityUnitListBox.SelectedIndex;
            int topIndex = EntityUnitListBox.TopIndex;
            int unitListSize = uData.UnitNames.Count;

            uData.u_UpgradesLv.Insert(unitListSize, FMWSaveManagerConstants.addUnitUpgrades);
            uData.UnitNames.Insert(unitListSize, FMWSaveManagerConstants.addUnitName);
            uData.UnitIDs.Insert(unitListSize, FMWSaveManagerConstants.addUnitID);
            uData.SelectedFUB.Insert(unitListSize, FMWSaveManagerConstants.addFUB);
            uData.u_ItemIDs.Insert(unitListSize, FMWSaveManagerConstants.addItemIDs);
            uData.u_BGM.Insert(unitListSize, FMWSaveManagerConstants.addBGM);

            EntityUnitListBox.BeginUpdate();
            if (Properties.Settings.Default.EntityUnitSort)
            {
                TriggerSort();
                EntityUnitListBox.SelectedIndexChanged -= EntityUnitListBox_SelectedIndexChanged;
                EntityUnitListBox.SelectedIndex = initialSelect;
                EntityUnitListBox.SelectedIndexChanged += EntityUnitListBox_SelectedIndexChanged;
            }

            if (uData.UnitNames.Count == 1)
            {
                (EntityUnitListBox.DataSource as BindingSource).ResetBindings(false);
                TriggerInitialization();
            }
            else
            {
                TriggerInitialization();
                (EntityUnitListBox.DataSource as BindingSource).ResetBindings(false);
            }
            EntityUnitListBox.TopIndex = topIndex;
            EntityUnitListBox.EndUpdate();
        }

        private void RemoveUnitButton_Click(object sender, EventArgs e)
        {
            if (EntityUnitListBox.Items.Count > 0)
            {
                UnitNameTextBox.Modified = false;
                int initialSelect = EntityUnitListBox.SelectedIndex;
                int topIndex = EntityUnitListBox.TopIndex;
                int removeIndex = (Properties.Settings.Default.EntityUnitSort) ? originalIndices[EntityUnitListBox.SelectedIndex] : EntityUnitListBox.SelectedIndex;

                uData.u_UpgradesLv.RemoveAt(removeIndex);
                uData.UnitNames.RemoveAt(removeIndex);
                uData.UnitIDs.RemoveAt(removeIndex);
                uData.SelectedFUB.RemoveAt(removeIndex);
                uData.u_ItemIDs.RemoveAt(removeIndex);
                uData.u_BGM.RemoveAt(removeIndex);

                EntityUnitListBox.BeginUpdate();
                if (Properties.Settings.Default.EntityUnitSort)
                {
                    TriggerSort();
                    if (uData.UnitNames.Count > 0)
                    {
                        EntityUnitListBox.SelectedIndex = Math.Min(initialSelect, uData.UnitNames.Count - 1);
                    }
                }

                (EntityUnitListBox.DataSource as BindingSource).ResetBindings(false);
                EntityUnitListBox.TopIndex = topIndex;
                EntityUnitListBox.EndUpdate();

                int updatedIndex = (Properties.Settings.Default.EntityUnitSort && uData.UnitNames.Count > 0) ? originalIndices[EntityUnitListBox.SelectedIndex] : EntityUnitListBox.SelectedIndex;

                if (EntityUnitListBox.Items.Count == 0)
                {
                    foreach (NumericUpDown ctl in this.upgradeArray)
                    {
                        ctl.DataBindings.Clear();
                        ctl.Value = ctl.Minimum;
                    }

                    UnitNameTextBox.DataBindings.Clear();
                    UnitNameTextBox.Clear();
                    UnitIDTextBox.DataBindings.Clear();
                    UnitIDTextBox.Clear();
                    UnitBGMTextBox.DataBindings.Clear();
                    UnitBGMTextBox.Clear();
                    FUBComboBox.DataBindings.Clear();
                    FUBComboBox.Text = FMWSaveManagerConstants.FUBComboBoxDefaultText;

                    foreach (ComboBox ctl in itemArray)
                    {
                        ctl.DataBindings.Clear();
                        ctl.Text = FMWSaveManagerConstants.ItemComboBoxDefaultText;
                    }
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

        private void ToggleNamesButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ToggleItemNameUnit = !Properties.Settings.Default.ToggleItemNameUnit;
            for (int i = 0; i < itemArray.Length; i++)
            {
                itemArray[i].DisplayMember = (Properties.Settings.Default.ToggleItemNameUnit) ? "Value" : "Key";
            }
        }

        private void TriggerSort()
        {
            // Simple Array-Original Index pairing sort
            unitSort = uData.UnitNames.ToArray();
            originalIndices = Enumerable.Range(0, uData.UnitNames.Count).ToArray();

            Array.Sort(unitSort, originalIndices);
            sortIndexMap.Clear();

            for (int i = 0; i < originalIndices.Length; i++)
            {
                sortIndexMap[originalIndices[i]] = i;
            }

            sortIndexMap.Add(-1, -1);
            previousIndex = sortIndexMap.GetValueOrDefault(previousIndex, -1);

            EntityUnitListBox.DataBindings.Clear();
            BindingList<string> bindingUnitNames = new BindingList<string>(unitSort);
            BindingSource bindingWrapper = new BindingSource();
            bindingWrapper.DataSource = bindingUnitNames;
            EntityUnitListBox.DataSource = bindingWrapper;
        }

        private void AlphabetSortCheckBox_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.EntityUnitSort = AlphabetSortCheckBox.Checked;
            int initialSelect = EntityUnitListBox.SelectedIndex;
            int topIndex = EntityUnitListBox.TopIndex;

            EntityUnitListBox.BeginUpdate();
            if (Properties.Settings.Default.EntityUnitSort && EntityUnitListBox.Items.Count > 0)
            {
                TriggerSort();
            }
            else
            {
                sortIndexMap.Clear();
                EntityUnitListBox.DataBindings.Clear();
                BindingList<string> bindingUnitNames = new BindingList<string>(uData.UnitNames);
                BindingSource bindingWrapper = new BindingSource();
                bindingWrapper.DataSource = bindingUnitNames;
                EntityUnitListBox.DataSource = bindingWrapper;
            }
            EntityUnitListBox.SelectedIndex = initialSelect;
            EntityUnitListBox.TopIndex = topIndex;
            EntityUnitListBox.EndUpdate();
        }
    }
}
