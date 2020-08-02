namespace Rename_Image_Files
{
    partial class FormRename
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BtnSelect = new System.Windows.Forms.Button();
            this.LblPath = new System.Windows.Forms.Label();
            this.BtnRename = new System.Windows.Forms.Button();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.LVFilenames = new System.Windows.Forms.ListView();
            this.CLBFileType = new System.Windows.Forms.CheckedListBox();
            this.gbDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BtnSelect
            // 
            this.BtnSelect.Location = new System.Drawing.Point(21, 12);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(75, 23);
            this.BtnSelect.TabIndex = 0;
            this.BtnSelect.Text = "Select &Folder";
            this.BtnSelect.UseVisualStyleBackColor = true;
            this.BtnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // LblPath
            // 
            this.LblPath.AutoSize = true;
            this.LblPath.Location = new System.Drawing.Point(6, 27);
            this.LblPath.Name = "LblPath";
            this.LblPath.Size = new System.Drawing.Size(42, 13);
            this.LblPath.TabIndex = 1;
            this.LblPath.Text = "Folder: ";
            // 
            // BtnRename
            // 
            this.BtnRename.Location = new System.Drawing.Point(163, 12);
            this.BtnRename.Name = "BtnRename";
            this.BtnRename.Size = new System.Drawing.Size(75, 23);
            this.BtnRename.TabIndex = 2;
            this.BtnRename.Text = "&Rename";
            this.BtnRename.UseVisualStyleBackColor = true;
            this.BtnRename.Click += new System.EventHandler(this.BtnRename_Click);
            // 
            // gbDetails
            // 
            this.gbDetails.AutoSize = true;
            this.gbDetails.Controls.Add(this.LVFilenames);
            this.gbDetails.Controls.Add(this.LblPath);
            this.gbDetails.Location = new System.Drawing.Point(12, 51);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(237, 295);
            this.gbDetails.TabIndex = 4;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Details";
            // 
            // LVFilenames
            // 
            this.LVFilenames.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.LVFilenames.AllowColumnReorder = true;
            this.LVFilenames.HideSelection = false;
            this.LVFilenames.Location = new System.Drawing.Point(9, 44);
            this.LVFilenames.Name = "LVFilenames";
            this.LVFilenames.Size = new System.Drawing.Size(217, 232);
            this.LVFilenames.TabIndex = 2;
            this.LVFilenames.UseCompatibleStateImageBehavior = false;
            this.LVFilenames.View = System.Windows.Forms.View.List;
            // 
            // CLBFileType
            // 
            this.CLBFileType.FormattingEnabled = true;
            this.CLBFileType.Location = new System.Drawing.Point(269, 51);
            this.CLBFileType.Name = "CLBFileType";
            this.CLBFileType.Size = new System.Drawing.Size(120, 94);
            this.CLBFileType.TabIndex = 5;
            // 
            // FormRename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 348);
            this.Controls.Add(this.CLBFileType);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.BtnRename);
            this.Controls.Add(this.BtnSelect);
            this.Name = "FormRename";
            this.Text = "Rename Image Files";
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BtnSelect;
        private System.Windows.Forms.Label LblPath;
        private System.Windows.Forms.Button BtnRename;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.ListView LVFilenames;
        private System.Windows.Forms.CheckedListBox CLBFileType;
    }
}

