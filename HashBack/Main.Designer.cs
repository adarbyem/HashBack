namespace HashBack
{
    partial class Main
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
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.buttonBackupLocation = new System.Windows.Forms.Button();
            this.dataGridViewBackup = new System.Windows.Forms.DataGridView();
            this.BackupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackupLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackupDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBarBackup = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBackup)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(194, 338);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(101, 23);
            this.buttonBrowse.TabIndex = 0;
            this.buttonBrowse.Text = "New Backup";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonBackup
            // 
            this.buttonBackup.Enabled = false;
            this.buttonBackup.Location = new System.Drawing.Point(76, 338);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(75, 23);
            this.buttonBackup.TabIndex = 1;
            this.buttonBackup.Text = "Backup";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // buttonBackupLocation
            // 
            this.buttonBackupLocation.Location = new System.Drawing.Point(343, 338);
            this.buttonBackupLocation.Name = "buttonBackupLocation";
            this.buttonBackupLocation.Size = new System.Drawing.Size(101, 23);
            this.buttonBackupLocation.TabIndex = 2;
            this.buttonBackupLocation.Text = "BackupLocation";
            this.buttonBackupLocation.UseVisualStyleBackColor = true;
            this.buttonBackupLocation.Click += new System.EventHandler(this.buttonBackupLocation_Click);
            // 
            // dataGridViewBackup
            // 
            this.dataGridViewBackup.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewBackup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBackup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BackupName,
            this.BackupLocation,
            this.BackupDate});
            this.dataGridViewBackup.Location = new System.Drawing.Point(13, 13);
            this.dataGridViewBackup.Name = "dataGridViewBackup";
            this.dataGridViewBackup.Size = new System.Drawing.Size(518, 215);
            this.dataGridViewBackup.TabIndex = 3;
            // 
            // BackupName
            // 
            this.BackupName.HeaderText = "Backup Name";
            this.BackupName.Name = "BackupName";
            // 
            // BackupLocation
            // 
            this.BackupLocation.HeaderText = "Location";
            this.BackupLocation.Name = "BackupLocation";
            this.BackupLocation.Width = 275;
            // 
            // BackupDate
            // 
            this.BackupDate.HeaderText = "Date";
            this.BackupDate.Name = "BackupDate";
            // 
            // progressBarBackup
            // 
            this.progressBarBackup.Location = new System.Drawing.Point(13, 235);
            this.progressBarBackup.Name = "progressBarBackup";
            this.progressBarBackup.Size = new System.Drawing.Size(518, 23);
            this.progressBarBackup.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 373);
            this.Controls.Add(this.progressBarBackup);
            this.Controls.Add(this.dataGridViewBackup);
            this.Controls.Add(this.buttonBackupLocation);
            this.Controls.Add(this.buttonBackup);
            this.Controls.Add(this.buttonBrowse);
            this.Name = "Main";
            this.Text = "Hash Back v0.1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.EnabledChanged += new System.EventHandler(this.mainEnabledChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBackup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.Button buttonBackupLocation;
        private System.Windows.Forms.DataGridView dataGridViewBackup;
        private System.Windows.Forms.DataGridViewTextBoxColumn BackupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BackupLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn BackupDate;
        private System.Windows.Forms.ProgressBar progressBarBackup;
    }
}

