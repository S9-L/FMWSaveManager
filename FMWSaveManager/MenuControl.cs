using System;
using System.Windows.Forms;

namespace FMWSaveManager
{
    public partial class MenuControl : UserControl
    {
        public MenuControl()
        {
            InitializeComponent();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            Control parentPanel = this.Parent!;
            UserControl currentControl = (UserControl)parentPanel.Controls[0];
            currentControl.Dispose();
            parentPanel.Controls.Clear();

            ImportControl importInst = new ImportControl();
            importInst.Dock = DockStyle.Fill;

            parentPanel.Controls.Add(importInst);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Control parentPanel = this.Parent!;
            UserControl currentControl = (UserControl)parentPanel.Controls[0];
            currentControl.Dispose();
            parentPanel.Controls.Clear();

            EditorControl editorInst = new EditorControl();
            editorInst.Dock = DockStyle.Fill;

            parentPanel.Controls.Add(editorInst);
        }
    }
}
