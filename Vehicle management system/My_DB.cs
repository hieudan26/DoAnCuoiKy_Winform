using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_management_system
{
    class My_DB
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DE070V4\D2T;Initial Catalog=DoAnWinF;Integrated Security=True");

        public SqlConnection GetConnection
        {
            get { return con; }
        }

        public void openConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
