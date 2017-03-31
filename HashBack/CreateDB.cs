using System.Windows.Forms;

namespace HashBack
{
    class CreateDB
    {
        public void createDB()
        {
            //local variables
            SqlQuery query = new SqlQuery();
            string results;

            //Create the database
            query.doQuery("", 3);
            results = (string)query.doQuery("CREATE TABLE Hashes(Path nvarchar(256), Hash nvarchar(36), Timestamp nvarchar(256), IsBackup nvarchar(256), BackupID nvarchar(256), Name nvarchar(256))", 1);
            if(results == "success")MessageBox.Show("Database Created!");
            else MessageBox.Show("Database Creation Failed!");
        }
    }
}
