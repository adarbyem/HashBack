using System;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;

namespace HashBack
{
    class CleanUp
    {
        public void cleanUp(string path, string name)
        {
            //Local Variables
            string timestamp = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            string zipHash;
            string zipPath;
            SqlQuery query = new SqlQuery();
            Crypto crypto = new Crypto();
            //Zip the backup destination folder
            zipPath = path + "\\Backup" + timestamp + ".zip";
            ZipFile.CreateFromDirectory(path + "\\Temp", zipPath);
            //Delete temp folder
            try
            {
                Directory.Delete(path + "\\Temp", true);
                MessageBox.Show("The Backup was Successful!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("The backup was successful! However, there was a problem deleting the Temp folder, perhaps some of the files are read only?");
            }
            
            //Hash the zip folder and store that hash in the database
            zipHash = crypto.doHash(1, zipPath);
            query.doQuery("INSERT INTO Hashes (Path, Hash, Timestamp, IsBackup, BackupID, Name) VALUES ('" + zipPath + "', '" + zipHash + "', '" + DateTime.Now + "', '" + true.ToString() + "', '" + 1.ToString() + "', '" + name + "')", 1);
        }
    }
}
