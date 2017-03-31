using System;
using System.Data;
using System.Data.SqlServerCe;

namespace HashBack
{
    class SqlQuery
    {
        //Global Variables
        public SqlCeConnection connection;
        //Type 1: NonQuery
        //Type 2: Results
        //Type 3: Create Database
        public object doQuery(string sqlQuery, int type)
        {
            //local variables
            const string FILENAME = "hashes.sdf";
            const string PASSWORD = "hashback";
            string connectionString = string.Format("DataSource = '{0}'; Password = '{1}'", FILENAME, PASSWORD);
            SqlCeResultSet results = null;
            try
            {
                //Connect to Database
                connection = new SqlCeConnection(connectionString);
                if (connection.State == ConnectionState.Closed && type != 3)
                {
                    connection.Open();
                }
                //Execute Query based on Type
                SqlCeCommand command = new SqlCeCommand(sqlQuery, connection);
                switch (type)
                {
                    case 1:
                        command.ExecuteNonQuery();
                        break;
                    case 2:
                        command.CommandType = CommandType.Text;
                        results = command.ExecuteResultSet(ResultSetOptions.Scrollable);
                        break;
                    case 3:
                        SqlCeEngine engine = new SqlCeEngine(connectionString);
                        engine.CreateDatabase();
                        break;
                }
                /*
                This leaves the connection open for the calling function to
                Process the results and close the connection on it's own
                if there are results, otherwise the connection is closed here
                */
                if (type == 2)
                {
                    return results;
                }
                else
                {
                    connection.Close();
                    return "success";
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("An Error Occured");
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
