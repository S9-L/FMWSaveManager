namespace FMWSaveManager
{
    partial class AboutForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            DescriptionLabel = new System.Windows.Forms.Label();
            AuthorLabel = new System.Windows.Forms.Label();
            CommunityLabel = new System.Windows.Forms.Label();
            CommunityLink = new System.Windows.Forms.LinkLabel();
            GHLink = new System.Windows.Forms.LinkLabel();
            SuspendLayout();
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new System.Drawing.Point(109, 85);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new System.Drawing.Size(282, 20);
            DescriptionLabel.TabIndex = 0;
            DescriptionLabel.Text = "A Save Manager for Fantasy Maiden Wars";
            // 
            // AuthorLabel
            // 
            AuthorLabel.AutoSize = true;
            AuthorLabel.Location = new System.Drawing.Point(107, 123);
            AuthorLabel.Name = "AuthorLabel";
            AuthorLabel.Size = new System.Drawing.Size(78, 20);
            AuthorLabel.TabIndex = 1;
            AuthorLabel.Text = "Written by";
            // 
            // CommunityLabel
            // 
            CommunityLabel.AutoSize = true;
            CommunityLabel.Location = new System.Drawing.Point(61, 161);
            CommunityLabel.Name = "CommunityLabel";
            CommunityLabel.Size = new System.Drawing.Size(373, 20);
            CommunityLabel.TabIndex = 2;
            CommunityLabel.Text = "You can reach out in the unofficial FMW Discord server!";
            // 
            // CommunityLink
            // 
            CommunityLink.AutoSize = true;
            CommunityLink.Location = new System.Drawing.Point(143, 199);
            CommunityLink.Name = "CommunityLink";
            CommunityLink.Size = new System.Drawing.Size(111, 20);
            CommunityLink.TabIndex = 3;
            CommunityLink.TabStop = true;
            CommunityLink.Text = "CommunityLink";
            CommunityLink.LinkClicked += CommunityLink_LinkClicked;
            // 
            // GHLink
            // 
            GHLink.AutoSize = true;
            GHLink.Location = new System.Drawing.Point(228, 123);
            GHLink.Name = "GHLink";
            GHLink.Size = new System.Drawing.Size(86, 20);
            GHLink.TabIndex = 4;
            GHLink.TabStop = true;
            GHLink.Text = "GitHub Link";
            GHLink.LinkClicked += GHLink_LinkClicked;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(490, 300);
            Controls.Add(GHLink);
            Controls.Add(CommunityLink);
            Controls.Add(CommunityLabel);
            Controls.Add(AuthorLabel);
            Controls.Add(DescriptionLabel);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "AboutForm";
            Text = "FMWSaveManager";
            Load += AboutForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.Label CommunityLabel;
        private System.Windows.Forms.LinkLabel CommunityLink;
        private System.Windows.Forms.LinkLabel GHLink;
    }
}