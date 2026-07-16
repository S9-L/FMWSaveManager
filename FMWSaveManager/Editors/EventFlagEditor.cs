using FMWSaveManager.FileFormats;
using FMWSaveManager.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace FMWSaveManager.Editors
{
    public partial class EventFlagEditor : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EventFlags EventFlags { get; set; }
        public static bool RouteBEnabled { get; set; }
        public event EventHandler RouteBChange;
        public EventFlagEditor()
        {
            InitializeComponent();
            BindingHelper.SetDoubleBuffer(FlagsDataGridView, true);
        }

        public class FlagPair
        {
            public EventFlags EventFlagsObj { get; set; }
            public string FlagName { get { return EventFlagsObj.FlagIDs[index]; } set { EventFlagsObj.FlagIDs[index] = value; } }
            private int index;
            public bool FlagCheckedBool { get { return EventFlagsObj.FlagONList[index] == 1; } set { EventFlagsObj.FlagONList[index] = value ? (sbyte)1 : (sbyte)0; } }

            public FlagPair(EventFlags eventFlags, int index)
            {
                this.EventFlagsObj = eventFlags;
                this.index = index;
            }
        }

        public void init()
        {
            FlagsDataGridView.AutoGenerateColumns = false;
            FlagsDataGridView.Columns.Clear();
            FlagsDataGridView.RowHeadersVisible = false;
            FlagsDataGridView.AllowUserToResizeRows = false;
            FlagsDataGridView.AllowUserToResizeColumns = false;
            FlagsDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn colFlagName = new DataGridViewTextBoxColumn()
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                Name = "FlagName",
                HeaderText = "Flag ID",
                DataPropertyName = "FlagName",
                ReadOnly = true
            };

            DataGridViewCheckBoxColumn colFlagON = new DataGridViewCheckBoxColumn()
            {
                CellTemplate = new DataGridViewCheckBoxCell(),
                Name = "FlagON",
                HeaderText = "Enabled?",
                DataPropertyName = "FlagCheckedBool"
            };

            FlagsDataGridView.Columns.Add(colFlagName);
            FlagsDataGridView.Columns.Add(colFlagON);

            List<FlagPair> flagList = new List<FlagPair>();

            for (int i = 0; i < EventFlags.FlagIDs.Count; i++)
            {
                flagList.Add(new FlagPair(EventFlags, i));
                if (EventFlags.FlagIDs[i] == "SC_BROUTE")
                {
                    RouteBEnabled = EventFlags.FlagONList[i] == 1;
                }
            }

            BindingList<FlagPair> flagBindList = new BindingList<FlagPair>(flagList);

            FlagsDataGridView.DataSource = flagBindList;
        }

        private void FlagsDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (FlagsDataGridView.IsCurrentCellDirty)
            {
                FlagsDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                if (EventFlags.FlagIDs[FlagsDataGridView.CurrentRow.Index] == "SC_BROUTE")
                {
                    RouteBEnabled = EventFlags.FlagONList[FlagsDataGridView.CurrentRow.Index] == 1;
                    FlagsDataGridView_RouteChange(sender, e);
                }
            }
        }

        private void FlagsDataGridView_RouteChange(object sender, EventArgs e)
        {
            RouteBChange?.Invoke(this, e);
        }
    }
}
