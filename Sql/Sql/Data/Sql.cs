using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql
{
    internal class Sql
    {
        private const string ConnectionString = "server=localhost;database=ADODatabase;trusted_connection=true";
        private static SqlConnection _conn=new SqlConnection(ConnectionString);


        public int ExecuteCommand(string cmd)
        {
            int result = 0;
            try
            {
                _conn.Open();
                SqlCommand sqlCommand = new SqlCommand(cmd, _conn);
                result = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { _conn.Close(); }
            return result;
        }

        public DataTable ExecuteQuery(string cmd)
        {
            DataTable table = new DataTable();
            try
            {
                _conn.Open();
                SqlDataAdapter query = new SqlDataAdapter(cmd, _conn);
                query.Fill(table);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { _conn.Close(); }

            return table;
        }
    }
}
