using System;
using System.IO;
using System.Data.SqlServerCe;

namespace HashBack
{
    class BackupEngine
    {
        public void backupEngine(string fileName, string hash, string destination, string simpleFileName, int backupID)
        {
            //local variables
            string sqlQuery;
            //SqlCeCommand command;
            SqlCeResultSet results = null;
            SqlQuery query = new SqlQuery();
            int hashOrdinal;
            bool exists = false;

            //Check the database for the pathname
            sqlQuery = "SELECT Path, Hash FROM Hashes WHERE Path LIKE '" + fileName +"'";
            results = (SqlCeResultSet)query.doQuery(sqlQuery, 2);
            //Process Results
            try
            {
                if (results.HasRows)
                {
                    hashOrdinal = results.GetOrdinal("Hash");
                    results.ReadFirst();
                    //Create new Crypto Instance
                    Crypto crypto = new Crypto();

                    if (results.GetString(hashOrdinal) != crypto.doHash(1, fileName))
                    {
                        //Delete current entry here
                        sqlQuery = "DELETE FROM Hashes WHERE Path LIKE '" + fileName + "'";
                        query.doQuery(sqlQuery, 1);
                    }
                    else
                    {
                        exists = true;
                    }
                    query.connection.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            //Path does NOT exist, hash the file and enter the filename and hash into the database, then copy file to backup location
            if (!exists)
            {
                try
                {
                    //Delete Old File and Copy the Changed File
                    File.Delete(destination + "\\" + simpleFileName);
                    File.Copy(fileName, destination + "\\" + simpleFileName);
                }
                catch(System.IO.FileNotFoundException)//File Not Found, Just Copy File
                {
                    File.Copy(fileName, destination + "\\" + simpleFileName);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
                //Display results and query the database
                try
                {
                    sqlQuery = "INSERT INTO Hashes (Path, Hash, Timestamp, IsBackup, BackupID) VALUES ('" + fileName + "', '" + hash + "', '" + DateTime.Now + "', '" + false.ToString() + "' , '" + backupID.ToString() + "')";
                    query.doQuery(sqlQuery, 1);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
                
            }
            //Reset exist flag
            exists = false;
        }
    }
}
