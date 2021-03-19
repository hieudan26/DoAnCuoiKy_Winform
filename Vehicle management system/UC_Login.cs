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

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (this.txtUser.Text == "Write your username")
            {
                this.txtUser.Text = "";
                this.txtUser.ForeColor = Color.Black;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (this.txtUser.Text == "")
            {
                this.txtUser.Text = "Write your username";
                this.txtUser.ForeColor = Color.Silver;
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if (this.txtUser.Text != "Write your username")
            {
                this.txtUser.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtUser.ForeColor = Color.Black;
            }
            else
            {
                this.txtUser.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtUser.ForeColor = Color.Silver;
            }
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
                Form mainForm = new test();
                this.Hide();
                mainForm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lLForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            My_DB db = new My_DB();

            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM log WHERE Username = @username", db.GetConnection);

            command.Parameters.Add("@username", SqlDbType.NVarChar).Value = this.txtUser.Text;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                string tmp = table.Rows[0]["Password"].ToString();
                MessageBox.Show("Don't forget your password anymore: \n=> Your pass: " + tmp, "Account usename", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtUserCurr_Enter(object sender, EventArgs e)
        {
            if (this.txtUserCurr.Text == "Write your username")
            {
                this.txtUserCurr.Text = "";
                this.txtUserCurr.ForeColor = Color.Black;
            }
        }

        private void txtUserCurr_Leave(object sender, EventArgs e)
        {
            if (this.txtUserCurr.Text == "")
            {
                this.txtUserCurr.Text = "Write your username";
                this.txtUserCurr.ForeColor = Color.Silver;
            }
        }

        private void txtUserCurr_TextChanged(object sender, EventArgs e)
        {
            if (this.txtUserCurr.Text != "Write your username")
            {
                this.txtUserCurr.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtUserCurr.ForeColor = Color.Black;
            }
            else
            {
                this.txtUserCurr.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtUserCurr.ForeColor = Color.Silver;
            }
        }

        private void txtUserNew_Leave(object sender, EventArgs e)
        {
            if (this.txtUserNew.Text == "")
            {
                this.txtUserNew.Text = "Write your username";
                this.txtUserNew.ForeColor = Color.Silver;
            }
        }

        private void txtUserNew_Enter(object sender, EventArgs e)
        {
            if (this.txtUserNew.Text == "Write your username")
            {
                this.txtUserNew.Text = "";
                this.txtUserNew.ForeColor = Color.Black;
            }
        }

        private void txtUserNew_TextChanged(object sender, EventArgs e)
        {
            if (this.txtUserNew.Text != "Write your username")
            {
                this.txtUserNew.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtUserNew.ForeColor = Color.Black;
            }
            else
            {
                this.txtUserNew.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtUserNew.ForeColor = Color.Silver;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            My_DB db = new My_DB();

            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM log WHERE Username = @username", db.GetConnection);

            command.Parameters.Add("@username", SqlDbType.NVarChar).Value = this.txtUserCurr.Text;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                int id = Convert.ToInt32(table.Rows[0]["ID"]);

                command = new SqlCommand("UPDATE log SET Username = @usernamenew, PASSWORD = @passwordnew WHERE ID = @id", db.GetConnection);

                command.Parameters.Add("@usernamenew", SqlDbType.NVarChar).Value = this.txtUserNew.Text;

                command.Parameters.Add("@passwordnew", SqlDbType.NVarChar).Value = this.txtPassNew.Text;

                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                adapter.SelectCommand = command;

                adapter.Fill(table);

                //check


                SqlDataAdapter adapter2 = new SqlDataAdapter();

                DataTable table2 = new DataTable();
                SqlCommand command2 = new SqlCommand("SELECT Username FROM log WHERE ID = " + id, db.GetConnection);

                adapter2.SelectCommand = command2;

                adapter2.Fill(table2);

                if (table2.Rows.Count > 0)
                {
                    MessageBox.Show("Successfully");
                }
                else
                {
                    MessageBox.Show("Unsuccessfully");
                }
            }
            else
            {
                MessageBox.Show("Account not exists");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
