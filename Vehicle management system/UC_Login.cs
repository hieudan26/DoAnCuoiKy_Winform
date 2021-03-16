using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vehicle_management_system
{
    public partial class UC_Login : UserControl
    {
        public UC_Login()
        {
            InitializeComponent();
        }

        private void UC_Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            My_DB db = new My_DB();

            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM log WHERE Username = @username AND Password = @password", db.GetConnection);

            command.Parameters.Add("@username", SqlDbType.NVarChar).Value = this.txtUser.Text;
            command.Parameters.Add("@password", SqlDbType.NVarChar).Value = this.txtPass.Text;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                //MessageBox.Show("OK, next time will be go to Main Menu of App");
                Form mainForm = new test();
                this.Hide();
                mainForm.ShowDialog();
                this.Show();
                //this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (this.txtUser.Text == "")
            {
                this.txtUser.Text = "Write your username";
                this.txtUser.ForeColor = Color.Silver;
            }    
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (this.txtUser.Text == "Write your username")
            {
                this.txtUser.Text = "";
                this.txtUser.ForeColor = Color.Black;
            }
        }
    }
}
