using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace HashBack
{
    class VerifyBackup
    {
        //Global Variables
        public List<string> path = new List<string>();
        public List<string> hash = new List<string>();
        public List<string> backupId = new List<string>();
        public List<string> backupName = new List<string>();
        public List<string> date = new List<string>();
        public void verify()
        {
            //Local Variables
            SqlCeResultSet results = null;
            SqlQuery query = new SqlQuery();
            Crypto crypto = new Crypto();
            DialogResult dr;
            string queryString = "SELECT Path, Hash, BackupID, IsBackup, Timestamp, Name FROM Hashes WHERE IsBackup LIKE 'True'";
            bool needsRefreshed = false;

            //Query the database for valid backups
            results = (SqlCeResultSet)query.doQuery(queryString, 2);

            //Clear the Lists
            path.Clear();
            hash.Clear();
            backupId.Clear();
            backupName.Clear();
            date.Clear();

            //Process the results and store the values in a list
            while (results.Read())
            {
                try
                {
                    path.Add(results.GetString(results.GetOrdinal("Path")));
                    hash.Add(results.GetString(results.GetOrdinal("Hash")));
                    backupId.Add(results.GetString(results.GetOrdinal("BackupID")));
                    backupName.Add(results.GetString(results.GetOrdinal("Name")));
                    date.Add(results.GetString(results.GetOrdinal("Timestamp")));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    break;
                }
                
            }

            //Close the connection
            query.connection.Close();

            //Verify the existence of backup files
            for(int count = 0; count < backupId.Count; count++)
            {
                if (!File.Exists(path.ElementAt(count)))
                {
                    Console.WriteLine("Backup: " + path.ElementAt(count) + " is missing.");
                    //PROCESS MISSING DATABASES HERE
                    dr = MessageBox.Show("The Backup at: " + path.ElementAt(count) + " is missing. Would you like to remove all references to the associated backup?", "Missing File", MessageBoxButtons.YesNo);
                    if(dr == DialogResult.Yes)
                    {
                        query.doQuery("DELETE FROM Hashes WHERE BackupID LIKE '" + backupId.ElementAt(count) + "'", 1);
                        needsRefreshed = true;
                    }
                    else
                    {
                        MessageBox.Show("Creating an additional backup of the files from the missing backup may have unexpected results. It is recommended that you find the missing backkup file or remove references to this file.");
                    }
                }
            }

            //Verify the hash of the backup files
            for (int count = 0; count < backupId.Count; count++)
            {
                if (crypto.doHash(1, path.ElementAt(count)) != hash.ElementAt(count) && File.Exists(path.ElementAt(count)))
                {
                    //PROCESS ALTERED DATABASES HERE
                    File.Delete(path.ElementAt(count));
                    query.doQuery("DELETE FROM Hashes WHERE BackupID LIKE '" + backupId.ElementAt(count) + "'", 1);
                    needsRefreshed = true;
                    MessageBox.Show("Backup: " + path.ElementAt(count) + "BackupID: " + backupId.ElementAt(count) + " has been altered! All references to this backup have been removed and the backup file deleted.\n\n It is recommended that you perform a fresh backup of the desired files.");
                }
            }
            //Refreshes the list if the backups were missing or altered
            if (needsRefreshed)
            {
                needsRefreshed = false;
                verify();
            }
        }
    }
}
