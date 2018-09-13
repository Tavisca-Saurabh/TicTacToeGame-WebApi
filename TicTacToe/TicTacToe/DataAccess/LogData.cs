using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Model;

namespace TicTacToe.DataAccess
{
    public class LogData
    {
        public  bool Add(Log Log)
        {
            try
            {
                using (var connection = new SqlConnection("Data Source=TAVDESK005;Initial Catalog=TicTacToe;User ID=sa;Password=test123!@#"))
                {
                    connection.Open();
                    string sql = "INSERT INTO Log(Request,Response,Exception,Date) VALUES(@Request,@Response,@Exception,@Date)";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@Request", Log.Request);
                    cmd.Parameters.AddWithValue("@Response", Log.Response);
                    cmd.Parameters.AddWithValue("@Exception", Log.Exception);
                    cmd.Parameters.AddWithValue("@Date", Log.TimeStamp);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception exc)
            {
                return false;
            }
        }
    }
}
