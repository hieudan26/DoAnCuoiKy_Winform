using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_management_system
{
    class User
    {
        My_DB mydb = new My_DB();

        public DataTable getUser(SqlCommand cmd)
        {
            cmd.Connection = mydb.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool insertUser(string Username, string Password)
        {
            My_DB mydb = new My_DB();
            SqlCommand cmd = new SqlCommand("INSERT INTO log (Username, Password)" +
         "VALUES (@username, @pass)", mydb.GetConnection);
            cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = Username;
            cmd.Parameters.Add("@pass", SqlDbType.NVarChar).Value = Password;

            mydb.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
    }
}
