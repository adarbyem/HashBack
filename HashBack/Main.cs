using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HashBack
{
    public partial class Main : Form
    {
        //Global Variables
        string backupSourcePath;
        string backupDestinationPath;
        string originalDestination;
        string originalSource;
        string hash;
        bool hasPickedSource = false;
        bool hasPickedDestination = false;
        double folderSize = 0.0;
        double current = 0.0;
        Crypto crypto = new Crypto();
        VerifyBackup verify = new VerifyBackup();
        InputDialog inputDialog;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Local Variables
            bool databaseExists = false;

            //Check for a local database file
            databaseExists = File.Exists("hashes.sdf");

            //Check for required dependencies
            if (!File.Exists("System.Data.SqlServerCe.dll"))
            {
                MessageBox.Show("The file: System.Data.SqlServerCe.dll is missing or corrupt. Please reinstall the application to continue.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else if (!File.Exists("sqlceme40.dll"))
            {
                MessageBox.Show("The file: sqlceme40.dll is missing or corrupt. Please reinstall the application to continue.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }


            //Check the integrity of backup files if the database exists
            if (databaseExists)
            {
                verify.verify();
            }

            //Populate the Database Table
            populateData();

            //Create local database file if it does not exist
            if (!databaseExists)
            {
                MessageBox.Show("The database file is missing or corrupted. If this is the first time running this program this is normal, the program will create this file for you now");
                CreateDB createdb = new CreateDB();
                createdb.createDB();
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            //Local Variables
            Browse browse = new Browse();
            //Browse for a file
            FolderBrowserDialog dialogue = browse.browseFolder();
            if (dialogue != null)
            {
                backupSourcePath = dialogue.SelectedPath;
                originalSource = backupSourcePath;
                hasPickedSource = true;
                //Call the function to check for valid source and destination
                inputDialog = new InputDialog();
                inputDialog.Show();
            }
        }

        private void mainEnabledChanged(object sender, EventArgs e)
        {
            checkBackupReady();
        }
        
        private void buttonBackup_Click(object sender, EventArgs e)
        {
            //Local Variables
            int backupID = 0;

            if (!File.Exists(backupSourcePath))
            {
                //File or folder is valid and reset path flags to false
                buttonBackup.Enabled = false;
                hasPickedSource = false;
                hasPickedDestination = false;
                labelStatus.Text = "Status: Determining Backup Size";
                this.Update();
                FolderSize folder = new FolderSize();
                folderSize = folder.getSize(backupSourcePath);
                progressBarBackup.Maximum = (int)folderSize;
                progressBarBackup.Refresh();
                labelStatus.Text = "Status: Creating Backup Folder";
                this.Update();
                Directory.CreateDirectory(backupDestinationPath);
                labelStatus.Text = "Status: Performing Backup";
                this.Update();
                //Get the next backupID
                for(int count = 0; count < verify.backupId.Count(); count++)
                {
                    if (backupID < int.Parse(verify.backupId.ElementAt(count)))
                    {
                        backupID = int.Parse(verify.backupId.ElementAt(count));
                    }
                }
                backupID++;
                tree(backupSourcePath, backupID);
                labelStatus.Text = "Status: Compressing Backup and Deleting Temporary Files";
                //Begin Cleanup and Compression
                CleanUp cleanUp = new CleanUp();
                cleanUp.cleanUp(originalDestination, inputDialog.name, backupID);
                labelStatus.Text = "Status: Verifying Backup";
                this.Update();
                verify.verify();
                //Set Program to Defaults
                labelStatus.Text = "Status: Ready";
                labelFile.Text = "Current File:";
                labelName.Text = "Backup Name: Select New Backup";
                labelLocation.Text = "Backup Location: Select New Bakup Location";
                populateData();
                progressBarBackup.Value = 0;
                current = 0.0;
            }
            else
                //Invalide file or folder
                MessageBox.Show("That was an invalid file or pathname!");
        }

        private void buttonBackupLocation_Click(object sender, EventArgs e)
        {
            //Local Variables
            Browse browse = new Browse();
            FolderBrowserDialog folderDialogue = browse.browseFolder();
            if (folderDialogue != null)
            {
                backupDestinationPath = folderDialogue.SelectedPath;
                originalDestination = backupDestinationPath;
                backupDestinationPath += "\\Temp";
                labelLocation.Text = "Backup Location: " + originalDestination;
                hasPickedDestination = true;
            }
            //Call the function to check for valid source and destination   
            checkBackupReady();
        }
        
        //Function to verify that the user has selected a source and destination folder for the backup
        private void checkBackupReady()
        {
            if (hasPickedDestination && hasPickedSource)
            {
                buttonBackup.Enabled = true;
                labelName.Text = "Backup Name: " + inputDialog.name;
            }
        }

        //Recursive function to go through the source and destination trees
        //Analysing the files and folders and making fuction calls accordingly
        private void tree(string directory, int backupID)
        {
            //local variables
            int parentLen = 0;
            int dirLen = 0;
            string charTrim;
            string extSource;
            FileInfo info;
            foreach (string x in Directory.GetFiles(directory))
            {
                info = new FileInfo(x);
                progressBarBackup.Value = (int)current;
                labelFile.Text = "Current File: " + x;
                labelStatus.Text = "Status: Hashing File...";
                this.Update();
                //Hash the file
                hash = crypto.doHash(1, x);
                //Start Backup Engine
                charTrim = x;
                while (charTrim.Contains('\\'))
                {
                    charTrim = charTrim.Remove(0, charTrim.IndexOf('\\')+1);
                }
                extSource = x.Substring(originalSource.Length, x.Length - originalSource.Length);
                extSource = extSource.Substring(0, extSource.Length - charTrim.Length);
                labelStatus.Text = "Status: Performing Backup - Total Progress: " + progressBarBackup.Value + " KB / " + progressBarBackup.Maximum + " KB";
                this.Update();//Update the UI
                BackupEngine backupEngine = new BackupEngine();
                backupEngine.backupEngine(x, hash, backupDestinationPath+extSource, charTrim, backupID);
                current += info.Length / 1024;
            }
            foreach (string y in Directory.GetDirectories(directory))
            {
                //Get the length of the parent folder and the full folder path
                parentLen = directory.Length;
                dirLen = y.Length;
                //Create the folder
                Directory.CreateDirectory(backupDestinationPath + y.Substring(originalSource.Length, y.Length - originalSource.Length));
                tree(y, backupID);
            }
        }
        public void populateData()
        {
            dataGridViewBackup.Rows.Clear();
            for (int count = 0; count < verify.backupName.Count; count++)
            {
                dataGridViewBackup.Rows.Add(verify.backupName.ElementAt(count), verify.path.ElementAt(count), verify.date.ElementAt(count));
            }
            
        }

        private void labelLocation_Click(object sender, EventArgs e)
        {

        }
    }
}
