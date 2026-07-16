using System.Drawing;
using System.Windows.Forms;

namespace FMWSaveManager
{
    partial class MenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            ViewPanel = new Panel();
            menuControl = new MenuControl();
            ViewPanel.SuspendLayout();
            SuspendLayout();
            // 
            // ViewPanel
            // 
            ViewPanel.Controls.Add(menuControl);
            ViewPanel.Dock = DockStyle.Fill;
            ViewPanel.Location = new Point(0, 0);
            ViewPanel.Margin = new Padding(3, 2, 3, 2);
            ViewPanel.Name = "ViewPanel";
            ViewPanel.Size = new Size(935, 543);
            ViewPanel.TabIndex = 3;
            // 
            // menuControl
            // 
            menuControl.Dock = DockStyle.Fill;
            menuControl.Location = new Point(0, 0);
            menuControl.Name = "menuControl";
            menuControl.Size = new Size(935, 543);
            menuControl.TabIndex = 0;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 543);
            Controls.Add(ViewPanel);
            Font = new Font("Segoe UI", 9F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(951, 582);
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FMWSaveManager";
            FormClosing += MenuForm_FormClosing;
            Load += MenuForm_Load;
            ViewPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel ViewPanel;
        private MenuControl menuControl;
    }
}
