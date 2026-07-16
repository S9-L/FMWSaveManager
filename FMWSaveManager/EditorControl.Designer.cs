namespace FMWSaveManager
{
    partial class EditorControl
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
            ToolbarMenuStrip = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tabControl1 = new System.Windows.Forms.TabControl();
            GeneralDataTab = new System.Windows.Forms.TabPage();
            generalDataEditor1 = new FMWSaveManager.Editors.GeneralDataEditor();
            EntitiesTab = new System.Windows.Forms.TabPage();
            entityEditor1 = new FMWSaveManager.Editors.EntityEditor();
            ItemsTab = new System.Windows.Forms.TabPage();
            itemsEditor1 = new FMWSaveManager.Editors.ItemsEditor();
            NGPlusTab = new System.Windows.Forms.TabPage();
            ngPlusEditor1 = new FMWSaveManager.Editors.NGPlusEditor();
            BonusStatsTab = new System.Windows.Forms.TabPage();
            bonusEditor1 = new FMWSaveManager.Editors.BonusEditor();
            ChapClearTab = new System.Windows.Forms.TabPage();
            chapterEditor1 = new FMWSaveManager.Editors.ChapterEditor();
            EventTab = new System.Windows.Forms.TabPage();
            eventFlagEditor1 = new FMWSaveManager.Editors.EventFlagEditor();
            ToolbarMenuStrip.SuspendLayout();
            tabControl1.SuspendLayout();
            GeneralDataTab.SuspendLayout();
            EntitiesTab.SuspendLayout();
            ItemsTab.SuspendLayout();
            NGPlusTab.SuspendLayout();
            BonusStatsTab.SuspendLayout();
            ChapClearTab.SuspendLayout();
            EventTab.SuspendLayout();
            SuspendLayout();
            // 
            // ToolbarMenuStrip
            // 
            ToolbarMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            ToolbarMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, aboutToolStripMenuItem });
            ToolbarMenuStrip.Location = new System.Drawing.Point(0, 0);
            ToolbarMenuStrip.Name = "ToolbarMenuStrip";
            ToolbarMenuStrip.Size = new System.Drawing.Size(935, 24);
            ToolbarMenuStrip.TabIndex = 5;
            ToolbarMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { openFileToolStripMenuItem, saveToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openFileToolStripMenuItem
            // 
            openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            openFileToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O;
            openFileToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            openFileToolStripMenuItem.Text = "&Open File...";
            openFileToolStripMenuItem.Click += openFileToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            saveToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            saveToolStripMenuItem.Text = "&Save...";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            aboutToolStripMenuItem.Text = "&About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(GeneralDataTab);
            tabControl1.Controls.Add(EntitiesTab);
            tabControl1.Controls.Add(ItemsTab);
            tabControl1.Controls.Add(NGPlusTab);
            tabControl1.Controls.Add(BonusStatsTab);
            tabControl1.Controls.Add(ChapClearTab);
            tabControl1.Controls.Add(EventTab);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 24);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(935, 519);
            tabControl1.TabIndex = 6;
            // 
            // GeneralDataTab
            // 
            GeneralDataTab.Controls.Add(generalDataEditor1);
            GeneralDataTab.Location = new System.Drawing.Point(4, 24);
            GeneralDataTab.Name = "GeneralDataTab";
            GeneralDataTab.Padding = new System.Windows.Forms.Padding(3);
            GeneralDataTab.Size = new System.Drawing.Size(927, 491);
            GeneralDataTab.TabIndex = 0;
            GeneralDataTab.Text = "General Data";
            GeneralDataTab.UseVisualStyleBackColor = true;
            // 
            // generalDataEditor1
            // 
            generalDataEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            generalDataEditor1.Enabled = false;
            generalDataEditor1.Location = new System.Drawing.Point(3, 3);
            generalDataEditor1.Name = "generalDataEditor1";
            generalDataEditor1.Size = new System.Drawing.Size(921, 485);
            generalDataEditor1.TabIndex = 0;
            // 
            // EntitiesTab
            // 
            EntitiesTab.Controls.Add(entityEditor1);
            EntitiesTab.Location = new System.Drawing.Point(4, 24);
            EntitiesTab.Name = "EntitiesTab";
            EntitiesTab.Padding = new System.Windows.Forms.Padding(3);
            EntitiesTab.Size = new System.Drawing.Size(927, 491);
            EntitiesTab.TabIndex = 1;
            EntitiesTab.Text = "Entities";
            EntitiesTab.UseVisualStyleBackColor = true;
            // 
            // entityEditor1
            // 
            entityEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            entityEditor1.Enabled = false;
            entityEditor1.Location = new System.Drawing.Point(3, 3);
            entityEditor1.Name = "entityEditor1";
            entityEditor1.Size = new System.Drawing.Size(921, 485);
            entityEditor1.TabIndex = 0;
            // 
            // ItemsTab
            // 
            ItemsTab.Controls.Add(itemsEditor1);
            ItemsTab.Location = new System.Drawing.Point(4, 24);
            ItemsTab.Name = "ItemsTab";
            ItemsTab.Size = new System.Drawing.Size(927, 491);
            ItemsTab.TabIndex = 5;
            ItemsTab.Text = "Items";
            ItemsTab.UseVisualStyleBackColor = true;
            // 
            // itemsEditor1
            // 
            itemsEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            itemsEditor1.Enabled = false;
            itemsEditor1.Location = new System.Drawing.Point(0, 0);
            itemsEditor1.Name = "itemsEditor1";
            itemsEditor1.Size = new System.Drawing.Size(927, 491);
            itemsEditor1.TabIndex = 0;
            // 
            // NGPlusTab
            // 
            NGPlusTab.Controls.Add(ngPlusEditor1);
            NGPlusTab.Location = new System.Drawing.Point(4, 24);
            NGPlusTab.Name = "NGPlusTab";
            NGPlusTab.Size = new System.Drawing.Size(927, 491);
            NGPlusTab.TabIndex = 2;
            NGPlusTab.Text = "NG+ Carryover";
            NGPlusTab.UseVisualStyleBackColor = true;
            // 
            // ngPlusEditor1
            // 
            ngPlusEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            ngPlusEditor1.Enabled = false;
            ngPlusEditor1.Location = new System.Drawing.Point(0, 0);
            ngPlusEditor1.Name = "ngPlusEditor1";
            ngPlusEditor1.Size = new System.Drawing.Size(927, 491);
            ngPlusEditor1.TabIndex = 0;
            // 
            // BonusStatsTab
            // 
            BonusStatsTab.Controls.Add(bonusEditor1);
            BonusStatsTab.Location = new System.Drawing.Point(4, 24);
            BonusStatsTab.Name = "BonusStatsTab";
            BonusStatsTab.Size = new System.Drawing.Size(927, 491);
            BonusStatsTab.TabIndex = 3;
            BonusStatsTab.Text = "Bonus Stats";
            BonusStatsTab.UseVisualStyleBackColor = true;
            // 
            // bonusEditor1
            // 
            bonusEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            bonusEditor1.Enabled = false;
            bonusEditor1.Location = new System.Drawing.Point(0, 0);
            bonusEditor1.Name = "bonusEditor1";
            bonusEditor1.Size = new System.Drawing.Size(927, 491);
            bonusEditor1.TabIndex = 0;
            // 
            // ChapClearTab
            // 
            ChapClearTab.Controls.Add(chapterEditor1);
            ChapClearTab.Location = new System.Drawing.Point(4, 24);
            ChapClearTab.Name = "ChapClearTab";
            ChapClearTab.Size = new System.Drawing.Size(927, 491);
            ChapClearTab.TabIndex = 4;
            ChapClearTab.Text = "Chapter Clear Stats";
            ChapClearTab.UseVisualStyleBackColor = true;
            // 
            // chapterEditor1
            // 
            chapterEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            chapterEditor1.Enabled = false;
            chapterEditor1.Location = new System.Drawing.Point(0, 0);
            chapterEditor1.Name = "chapterEditor1";
            chapterEditor1.Size = new System.Drawing.Size(927, 491);
            chapterEditor1.TabIndex = 0;
            // 
            // EventTab
            // 
            EventTab.Controls.Add(eventFlagEditor1);
            EventTab.Location = new System.Drawing.Point(4, 24);
            EventTab.Name = "EventTab";
            EventTab.Size = new System.Drawing.Size(927, 491);
            EventTab.TabIndex = 6;
            EventTab.Text = "Event Flags";
            EventTab.UseVisualStyleBackColor = true;
            // 
            // eventFlagEditor1
            // 
            eventFlagEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            eventFlagEditor1.Enabled = false;
            eventFlagEditor1.Location = new System.Drawing.Point(0, 0);
            eventFlagEditor1.Name = "eventFlagEditor1";
            eventFlagEditor1.Size = new System.Drawing.Size(927, 491);
            eventFlagEditor1.TabIndex = 0;
            // 
            // EditorControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Controls.Add(ToolbarMenuStrip);
            Name = "EditorControl";
            Size = new System.Drawing.Size(935, 543);
            ToolbarMenuStrip.ResumeLayout(false);
            ToolbarMenuStrip.PerformLayout();
            tabControl1.ResumeLayout(false);
            GeneralDataTab.ResumeLayout(false);
            EntitiesTab.ResumeLayout(false);
            ItemsTab.ResumeLayout(false);
            NGPlusTab.ResumeLayout(false);
            BonusStatsTab.ResumeLayout(false);
            ChapClearTab.ResumeLayout(false);
            EventTab.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip ToolbarMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage GeneralDataTab;
        private System.Windows.Forms.TabPage EntitiesTab;
        private System.Windows.Forms.TabPage NGPlusTab;
        private System.Windows.Forms.TabPage ItemsTab;
        private System.Windows.Forms.TabPage BonusStatsTab;
        private System.Windows.Forms.TabPage ChapClearTab;
        private System.Windows.Forms.TabPage EventTab;
        private Editors.GeneralDataEditor generalDataEditor1;
        private Editors.EntityEditor entityEditor1;
        private Editors.ItemsEditor itemsEditor1;
        private Editors.NGPlusEditor ngPlusEditor1;
        private Editors.BonusEditor bonusEditor1;
        private Editors.ChapterEditor chapterEditor1;
        private Editors.EventFlagEditor eventFlagEditor1;
    }
}
