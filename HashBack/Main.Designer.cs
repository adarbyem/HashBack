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
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            this.panelControls = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBackup)).BeginInit();
            this.panelControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(126, 4);
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
            this.buttonBackup.Location = new System.Drawing.Point(8, 4);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(75, 23);
            this.buttonBackup.TabIndex = 1;
            this.buttonBackup.Text = "Backup";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // buttonBackupLocation
            // 
            this.buttonBackupLocation.Location = new System.Drawing.Point(275, 4);
            this.buttonBackupLocation.Name = "buttonBackupLocation";
            this.buttonBackupLocation.Size = new System.Drawing.Size(101, 23);
            this.buttonBackupLocation.TabIndex = 2;
            this.buttonBackupLocation.Text = "BackupLocation";
            this.buttonBackupLocation.UseVisualStyleBackColor = true;
            this.buttonBackupLocation.Click += new System.EventHandler(this.buttonBackupLocation_Click);
            // 
            // dataGridViewBackup
            // 
            this.dataGridViewBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBackup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBackup.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridViewBackup.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewBackup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBackup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BackupName,
            this.BackupLocation,
            this.BackupDate});
            this.dataGridViewBackup.Location = new System.Drawing.Point(13, 13);
            this.dataGridViewBackup.Name = "dataGridViewBackup";
            this.dataGridViewBackup.Size = new System.Drawing.Size(514, 215);
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
            // 
            // BackupDate
            // 
            this.BackupDate.HeaderText = "Date";
            this.BackupDate.Name = "BackupDate";
            // 
            // progressBarBackup
            // 
            this.progressBarBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarBackup.Location = new System.Drawing.Point(13, 235);
            this.progressBarBackup.Name = "progressBarBackup";
            this.progressBarBackup.Size = new System.Drawing.Size(514, 23);
            this.progressBarBackup.TabIndex = 4;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 272);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(74, 13);
            this.labelStatus.TabIndex = 5;
            this.labelStatus.Text = "Status: Ready";
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(12, 294);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(176, 13);
            this.labelFile.TabIndex = 6;
            this.labelFile.Text = "Current File: No backup in progress.";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 319);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(176, 13);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "Backup Name: Select New Backup";
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(12, 343);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(227, 13);
            this.labelLocation.TabIndex = 8;
            this.labelLocation.Text = "Backup Location: Select New Bakup Location";
            this.labelLocation.Click += new System.EventHandler(this.labelLocation_Click);
            // 
            // panelControls
            // 
            this.panelControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelControls.Controls.Add(this.buttonBackup);
            this.panelControls.Controls.Add(this.buttonBrowse);
            this.panelControls.Controls.Add(this.buttonBackupLocation);
            this.panelControls.Location = new System.Drawing.Point(0, 376);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(397, 47);
            this.panelControls.TabIndex = 9;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 422);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.progressBarBackup);
            this.Controls.Add(this.dataGridViewBackup);
            this.Name = "Main";
            this.Text = "Hash Back v0.1.1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.EnabledChanged += new System.EventHandler(this.mainEnabledChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBackup)).EndInit();
            this.panelControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.Panel panelControls;
    }
}

