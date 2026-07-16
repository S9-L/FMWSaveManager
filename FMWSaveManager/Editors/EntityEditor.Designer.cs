namespace FMWSaveManager.Editors
{
    partial class EntityEditor
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
            EntityTabControl = new System.Windows.Forms.TabControl();
            UnitTab = new System.Windows.Forms.TabPage();
            unitEditor1 = new UnitEditor();
            CharacterTab = new System.Windows.Forms.TabPage();
            charEditor1 = new CharEditor();
            EntityTabControl.SuspendLayout();
            UnitTab.SuspendLayout();
            CharacterTab.SuspendLayout();
            SuspendLayout();
            // 
            // EntityTabControl
            // 
            EntityTabControl.Controls.Add(UnitTab);
            EntityTabControl.Controls.Add(CharacterTab);
            EntityTabControl.Location = new System.Drawing.Point(3, 3);
            EntityTabControl.Name = "EntityTabControl";
            EntityTabControl.SelectedIndex = 0;
            EntityTabControl.Size = new System.Drawing.Size(921, 509);
            EntityTabControl.TabIndex = 3;
            // 
            // UnitTab
            // 
            UnitTab.Controls.Add(unitEditor1);
            UnitTab.Location = new System.Drawing.Point(4, 24);
            UnitTab.Name = "UnitTab";
            UnitTab.Padding = new System.Windows.Forms.Padding(3);
            UnitTab.Size = new System.Drawing.Size(913, 481);
            UnitTab.TabIndex = 0;
            UnitTab.Text = "Unit";
            UnitTab.UseVisualStyleBackColor = true;
            // 
            // unitEditor1
            // 
            unitEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            unitEditor1.Enabled = false;
            unitEditor1.Location = new System.Drawing.Point(3, 3);
            unitEditor1.Name = "unitEditor1";
            unitEditor1.Size = new System.Drawing.Size(907, 475);
            unitEditor1.TabIndex = 0;
            // 
            // CharacterTab
            // 
            CharacterTab.Controls.Add(charEditor1);
            CharacterTab.Location = new System.Drawing.Point(4, 24);
            CharacterTab.Name = "CharacterTab";
            CharacterTab.Padding = new System.Windows.Forms.Padding(3);
            CharacterTab.Size = new System.Drawing.Size(913, 401);
            CharacterTab.TabIndex = 1;
            CharacterTab.Text = "Character";
            CharacterTab.UseVisualStyleBackColor = true;
            // 
            // charEditor1
            // 
            charEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            charEditor1.Enabled = false;
            charEditor1.Location = new System.Drawing.Point(3, 3);
            charEditor1.Name = "charEditor1";
            charEditor1.Size = new System.Drawing.Size(907, 395);
            charEditor1.TabIndex = 0;
            // 
            // EntityEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(EntityTabControl);
            Enabled = false;
            Name = "EntityEditor";
            Size = new System.Drawing.Size(927, 512);
            EntityTabControl.ResumeLayout(false);
            UnitTab.ResumeLayout(false);
            CharacterTab.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TabControl EntityTabControl;
        private System.Windows.Forms.TabPage UnitTab;
        private System.Windows.Forms.TabPage CharacterTab;
        private UnitEditor unitEditor1;
        private CharEditor charEditor1;
    }
}
