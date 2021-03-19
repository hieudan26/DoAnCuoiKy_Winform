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
        Form1 f;
        public UC_Signin()
        {
            InitializeComponent();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            User user = new User();
            try
            {
               if (!user.verifyAccountUser(this.txtUser.Text.ToString()))
               {
                    throw new Exception("Account already exists !! please try again");
               }
               else
               {
                    if (this.Captcha.Checked == false)
                    {
                        MessageBox.Show("Robot ", "Register", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtUser.Text = "";
                        this.txtPass.Text = "";
                        this.txtConfirmPass.Text = "";
                        this.txtUser.Focus();
                    }
                    else if (this.verifyPass() == true)
                    {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtUser.Text = "";
                this.txtPass.Text = "";
                this.txtConfirmPass.Text = "";
                this.txtUser.Focus();
            }
        }

        private bool verifyPass()
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
            f.btnSignIn.BaseColor1 = Color.LightPink;
            f.btnSignIn.BaseColor2 = Color.LightBlue;
            f.btnSignIn.BorderColor = Color.Black;
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
        public void SetParent(Form1 F)
        {
            this.f = F;
        }
    }
}
