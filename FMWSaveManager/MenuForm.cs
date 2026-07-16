using FMWSaveManager.Util;
using System;
using System.Windows.Forms;

namespace FMWSaveManager
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            BindingHelper.SetDoubleBuffer(ViewPanel, true);
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Application.ProductName} {FMWSaveManagerConstants.currentAssemblyName.Version.Major}" +
                $".{FMWSaveManagerConstants.currentAssemblyName.Version.Minor}" +
                $".{FMWSaveManagerConstants.currentAssemblyName.Version.Build}";
        }
    }
}
