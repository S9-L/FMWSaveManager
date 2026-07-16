using FMWSaveManager.FileFormats;
using FMWSaveManager.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FMWSaveManager.Editors
{
    public partial class ItemsEditor : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Items Items { get; set; }
        public string oldValue;
        public ToolStripMenuItem fileMenu;

        public ItemsEditor()
        {
            InitializeComponent();
            BindingHelper.SetDoubleBuffer(ItemsDataGridView, true);
        }

        public class ItemDGV
        {
            public Items ItemsObj { get; set; }
            public string ItemName { get { return ToggleItemView ? DatabaseLoad.ItemRecords[ItemsObj.ItemIDs[index]] : ItemsObj.ItemIDs[index]; } set { ItemsObj.ItemIDs[index] = value; } }
            private int index;
            public static bool ToggleItemView { get; set; }
            public string ItemNums { get { return ItemsObj.ItemNums[index].ToString(); } set { ItemsObj.ItemNums[index] = (!string.IsNullOrWhiteSpace(value)) ? Convert.ToByte(value) : (byte)0; } }
            public byte TotalItemNums { get { return ItemsObj.TotalItemNums[index]; } set { ItemsObj.TotalItemNums[index] = value; } }

            public ItemDGV(Items items, int index)
            {
                this.ItemsObj = items;
                this.index = index;
            }
        }

        public void init(MenuStrip menu)
        {
            this.fileMenu = (ToolStripMenuItem)menu.Items["fileToolStripMenuItem"];
            ItemsDataGridView.AutoGenerateColumns = false;
            ItemsDataGridView.Columns.Clear();
            ItemsDataGridView.AllowUserToResizeRows = false;
            ItemsDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn colItemName = new DataGridViewTextBoxColumn()
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                Name = "ItemName",
                HeaderText = "Item",
                DataPropertyName = "ItemName",
                ReadOnly = true
            };

            DataGridViewTextBoxColumn colItemNum = new DataGridViewTextBoxColumn()
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                Name = "ItemNum",
                HeaderText = "Edit Inventory Quantity",
                DataPropertyName = "ItemNums",
                MaxInputLength = 2
            };

            DataGridViewTextBoxColumn colTotalItemNum = new DataGridViewTextBoxColumn()
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                Name = "TotalItemNum",
                HeaderText = "Total Item Quantity",
                DataPropertyName = "TotalItemNums",
                ReadOnly = true
            };

            colTotalItemNum.DefaultCellStyle.BackColor = Color.LightGray;
            colTotalItemNum.DefaultCellStyle.Font = new Font(ItemsDataGridView.DefaultCellStyle.Font, FontStyle.Bold);
            colTotalItemNum.HeaderCell.Style.Font = new Font(ItemsDataGridView.DefaultCellStyle.Font, FontStyle.Bold);

            ItemsDataGridView.Columns.Add(colItemName);
            ItemsDataGridView.Columns.Add(colItemNum);
            ItemsDataGridView.Columns.Add(colTotalItemNum);

            ItemDGV.ToggleItemView = Properties.Settings.Default.ToggleItemNameEditor;
            List<ItemDGV> itemList = new List<ItemDGV>();

            for (int i = 0; i < Items.ItemIDs.Count; i++)
            {
                itemList.Add(new ItemDGV(Items, i));
            }

            BindingList<ItemDGV> itemBindList = new BindingList<ItemDGV>(itemList);
            ItemsDataGridView.DataSource = itemBindList;
        }

        private void ItemsDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            foreach (ToolStripItem menuItem in fileMenu.DropDownItems)
            {
                menuItem.Enabled = false;
            }
            oldValue = (string)ItemsDataGridView.CurrentCell.Value;
        }

        private void ItemsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            byte maxVal = 255;
            sbyte incrementVal = (sbyte)(Convert.ToByte(ItemsDataGridView.CurrentCell.Value) - Convert.ToByte(oldValue));
            if (incrementVal > 0 && Items.TotalItemNums[e.RowIndex] > maxVal - incrementVal)
            {
                ItemsDataGridView.CurrentCell.Value = (Convert.ToByte(ItemsDataGridView.CurrentCell.Value) - (incrementVal - (maxVal - Items.TotalItemNums[e.RowIndex]))).ToString();
                Items.TotalItemNums[e.RowIndex] = maxVal;
            }
            else
            {
                Items.TotalItemNums[e.RowIndex] += (byte)incrementVal;
            }
            foreach (ToolStripItem menuItem in fileMenu.DropDownItems)
            {
                menuItem.Enabled = true;
            }
            ItemsDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            ItemsDataGridView.Refresh();
        }

        private void ItemsDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox cellNumeric = (TextBox)e.Control;
            cellNumeric.KeyPress += ItemsDataGridView_NumberOnly;
        }

        private void ItemsDataGridView_NumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsAsciiDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ToggleNamesButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ToggleItemNameEditor = !Properties.Settings.Default.ToggleItemNameEditor;
            ItemDGV.ToggleItemView = Properties.Settings.Default.ToggleItemNameEditor;
            ItemsDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            ItemsDataGridView.Refresh();
        }
    }
}
