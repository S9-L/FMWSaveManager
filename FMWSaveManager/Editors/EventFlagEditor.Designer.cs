namespace FMWSaveManager.Editors
{
    partial class EventFlagEditor
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
            FlagBox = new System.Windows.Forms.GroupBox();
            FlagsDataGridView = new System.Windows.Forms.DataGridView();
            FlagBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FlagsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // FlagBox
            // 
            FlagBox.Controls.Add(FlagsDataGridView);
            FlagBox.Location = new System.Drawing.Point(0, 0);
            FlagBox.Name = "FlagBox";
            FlagBox.Size = new System.Drawing.Size(924, 468);
            FlagBox.TabIndex = 0;
            FlagBox.TabStop = false;
            FlagBox.Text = "Flags";
            // 
            // FlagsDataGridView
            // 
            FlagsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            FlagsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FlagsDataGridView.Location = new System.Drawing.Point(6, 22);
            FlagsDataGridView.Name = "FlagsDataGridView";
            FlagsDataGridView.Size = new System.Drawing.Size(278, 436);
            FlagsDataGridView.TabIndex = 1;
            FlagsDataGridView.CurrentCellDirtyStateChanged += FlagsDataGridView_CurrentCellDirtyStateChanged;
            // 
            // EventFlagEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(FlagBox);
            Enabled = false;
            Name = "EventFlagEditor";
            Size = new System.Drawing.Size(927, 471);
            FlagBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)FlagsDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox FlagBox;
        private System.Windows.Forms.DataGridView FlagsDataGridView;
    }
}
