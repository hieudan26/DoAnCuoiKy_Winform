using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vehicle_management_system
{
    public partial class UC_Signin : UserControl
    {
        public UC_Signin()
        {
            InitializeComponent();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (this.Captcha.Checked == false)
            {
                MessageBox.Show("Robot ", "Register", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtUser.Text = "";
                this.txtPass.Text = "";
                this.txtConfirmPass.Text = "";
                this.txtUser.Focus();
            }
            else if (this.verify() == true)
            {
                User user = new User();
                string username = this.txtUser.Text;
                string pass = this.txtPass.Text;
                user.insertUser(username, pass);
                MessageBox.Show("Successfully!!");
            }
            else
            {
                this.txtUser.Text = "";
                this.txtPass.Text = "";
                this.txtConfirmPass.Text = "";
                this.txtUser.Focus();
            }
        }

        private bool verify()
        {
            if (this.txtPass.Text == "" || this.txtUser.Text == "")
            {
                MessageBox.Show("Empty Fields", "Register", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                if (this.txtConfirmPass.Text != this.txtPass.Text)
                {
                    MessageBox.Show("Pass different with Confirm Pass", "Register", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    if (!checkPass(this.txtPass.Text))
                    {
                        MessageBox.Show("Worng format of Password", "Register", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    else
                        return true;
                }
            }
        }

        private bool checkPass(string pass)
        {
            if (pass.Length >= 7)
            {
                int flagChu = 0;
                int flagSo = 0;
                for (int i = 0; i < pass.Length; i++)
                {
                    if (flagChu == 1 && flagSo == 1)
                    {
                        return true;
                    }

                    if ((pass[i] >= 'A' && pass[i] <= 'Z') || (pass[i] >= 'a' && pass[i] <= 'z'))
                    {
                        flagChu = 1;
                    }

                    if (pass[i] >= '0' && pass[i] <= '9')
                    {
                        flagSo = 1;
                    }
                }
                return false;
            }
            else
                return false;
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
