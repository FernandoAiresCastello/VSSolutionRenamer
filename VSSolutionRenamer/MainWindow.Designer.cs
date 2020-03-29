namespace VSSolutionRenamer
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.TxtOldPath = new System.Windows.Forms.TextBox();
            this.BtnSelectOld = new System.Windows.Forms.Button();
            this.TxtNew = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnRename = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtFileSearchPattern = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbLanguage = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Original solution folder path";
            // 
            // TxtOldPath
            // 
            this.TxtOldPath.Location = new System.Drawing.Point(177, 43);
            this.TxtOldPath.Name = "TxtOldPath";
            this.TxtOldPath.Size = new System.Drawing.Size(436, 23);
            this.TxtOldPath.TabIndex = 1;
            // 
            // BtnSelectOld
            // 
            this.BtnSelectOld.Image = global::VSSolutionRenamer.Properties.Resources.folder;
            this.BtnSelectOld.Location = new System.Drawing.Point(619, 40);
            this.BtnSelectOld.Name = "BtnSelectOld";
            this.BtnSelectOld.Size = new System.Drawing.Size(49, 27);
            this.BtnSelectOld.TabIndex = 2;
            this.BtnSelectOld.UseVisualStyleBackColor = true;
            this.BtnSelectOld.Click += new System.EventHandler(this.BtnSelectOld_Click);
            // 
            // TxtNew
            // 
            this.TxtNew.Location = new System.Drawing.Point(177, 72);
            this.TxtNew.Name = "TxtNew";
            this.TxtNew.Size = new System.Drawing.Size(436, 23);
            this.TxtNew.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "New solution / project name";
            // 
            // BtnRename
            // 
            this.BtnRename.Location = new System.Drawing.Point(12, 147);
            this.BtnRename.Name = "BtnRename";
            this.BtnRename.Size = new System.Drawing.Size(185, 45);
            this.BtnRename.TabIndex = 9;
            this.BtnRename.Text = "Duplicate and Rename";
            this.BtnRename.UseVisualStyleBackColor = true;
            this.BtnRename.Click += new System.EventHandler(this.BtnRename_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(207, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(455, 45);
            this.label2.TabIndex = 10;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // TxtFileSearchPattern
            // 
            this.TxtFileSearchPattern.Location = new System.Drawing.Point(406, 108);
            this.TxtFileSearchPattern.Name = "TxtFileSearchPattern";
            this.TxtFileSearchPattern.Size = new System.Drawing.Size(207, 23);
            this.TxtFileSearchPattern.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(388, 30);
            this.label4.TabIndex = 11;
            this.label4.Text = "Replace all occurrences of the old solution name with the new \r\nsolution name in " +
    "all files in solution folder with the following extensions:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Select solution language";
            // 
            // CmbLanguage
            // 
            this.CmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLanguage.FormattingEnabled = true;
            this.CmbLanguage.Location = new System.Drawing.Point(177, 12);
            this.CmbLanguage.Name = "CmbLanguage";
            this.CmbLanguage.Size = new System.Drawing.Size(183, 23);
            this.CmbLanguage.TabIndex = 14;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 206);
            this.Controls.Add(this.CmbLanguage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtFileSearchPattern);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnRename);
            this.Controls.Add(this.TxtNew);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnSelectOld);
            this.Controls.Add(this.TxtOldPath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VSSolutionRenamer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtOldPath;
        private System.Windows.Forms.Button BtnSelectOld;
        private System.Windows.Forms.TextBox TxtNew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnRename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtFileSearchPattern;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbLanguage;
    }
}

