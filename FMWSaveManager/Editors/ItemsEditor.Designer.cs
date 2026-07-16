namespace FMWSaveManager.Editors
{
    partial class ItemsEditor
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
            ItemsBox = new System.Windows.Forms.GroupBox();
            ItemsDataGridView = new System.Windows.Forms.DataGridView();
            ToggleNamesButton = new System.Windows.Forms.Button();
            ItemsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ItemsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // ItemsBox
            // 
            ItemsBox.Controls.Add(ToggleNamesButton);
            ItemsBox.Controls.Add(ItemsDataGridView);
            ItemsBox.Location = new System.Drawing.Point(1, 1);
            ItemsBox.Name = "ItemsBox";
            ItemsBox.Size = new System.Drawing.Size(924, 468);
            ItemsBox.TabIndex = 1;
            ItemsBox.TabStop = false;
            ItemsBox.Text = "Items";
            // 
            // ItemsDataGridView
            // 
            ItemsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            ItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ItemsDataGridView.Location = new System.Drawing.Point(6, 22);
            ItemsDataGridView.Name = "ItemsDataGridView";
            ItemsDataGridView.Size = new System.Drawing.Size(460, 428);
            ItemsDataGridView.TabIndex = 2;
            ItemsDataGridView.CellBeginEdit += ItemsDataGridView_CellBeginEdit;
            ItemsDataGridView.CellEndEdit += ItemsDataGridView_CellEndEdit;
            ItemsDataGridView.EditingControlShowing += ItemsDataGridView_EditingControlShowing;
            // 
            // ToggleNamesButton
            // 
            ToggleNamesButton.Location = new System.Drawing.Point(472, 22);
            ToggleNamesButton.Name = "ToggleNamesButton";
            ToggleNamesButton.Size = new System.Drawing.Size(175, 33);
            ToggleNamesButton.TabIndex = 27;
            ToggleNamesButton.Text = "Toggle Item Names";
            ToggleNamesButton.UseVisualStyleBackColor = true;
            ToggleNamesButton.Click += ToggleNamesButton_Click;
            // 
            // ItemsEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(ItemsBox);
            Enabled = false;
            Name = "ItemsEditor";
            Size = new System.Drawing.Size(927, 471);
            ItemsBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ItemsDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox ItemsBox;
        private System.Windows.Forms.DataGridView ItemsDataGridView;
        private System.Windows.Forms.Button ToggleNamesButton;
    }
}
