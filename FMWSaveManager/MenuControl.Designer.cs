namespace FMWSaveManager
{
    partial class MenuControl
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
            EditButton = new System.Windows.Forms.Button();
            ImportButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // EditButton
            // 
            EditButton.Location = new System.Drawing.Point(185, 175);
            EditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            EditButton.Name = "EditButton";
            EditButton.Size = new System.Drawing.Size(570, 91);
            EditButton.TabIndex = 2;
            EditButton.Text = "Edit FMW Switch/Steam Save File";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // ImportButton
            // 
            ImportButton.Location = new System.Drawing.Point(185, 300);
            ImportButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            ImportButton.Name = "ImportButton";
            ImportButton.Size = new System.Drawing.Size(570, 91);
            ImportButton.TabIndex = 3;
            ImportButton.Text = "Import Legacy FMW Save into Steam/Switch";
            ImportButton.UseVisualStyleBackColor = true;
            ImportButton.Click += ImportButton_Click;
            // 
            // MenuControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(ImportButton);
            Controls.Add(EditButton);
            Name = "MenuControl";
            Size = new System.Drawing.Size(935, 543);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button ImportButton;
    }
}
