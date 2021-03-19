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

        public bool verifyAccountUser(string username)
        {
            My_DB db = new My_DB();

            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM log WHERE Username = @username", db.GetConnection);

            command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return false;
            }
            else
                return true;
        }
    }
}
