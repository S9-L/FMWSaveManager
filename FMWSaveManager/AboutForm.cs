using FMWSaveManager.Util;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FMWSaveManager
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Application.ProductName} {FMWSaveManagerConstants.currentAssemblyName.Version.Major}" +
                $".{FMWSaveManagerConstants.currentAssemblyName.Version.Minor}" +
                $".{FMWSaveManagerConstants.currentAssemblyName.Version.Build}";
            AuthorLabel.Text = $"{FMWSaveManagerConstants.copyrightText} - ";
            GHLink.Text = $"{FMWSaveManagerConstants.ghLink}";
            CommunityLink.Text = FMWSaveManagerConstants.communityLink;
        }

        private void GHLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = ((LinkLabel)sender).Text,
                UseShellExecute = true
            };
            Process.Start(startInfo);

            GHLink.LinkVisited = true;
        }

        private void CommunityLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = ((LinkLabel)sender).Text,
                UseShellExecute = true
            };
            Process.Start(startInfo);

            CommunityLink.LinkVisited = true;
        }
    }
}
