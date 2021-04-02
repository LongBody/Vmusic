using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vmusic
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim().Equals(""))
            {
                MessageBox.Show("Enter email");
            }
            else
            {
                if (txtPassword.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Enter password");
                }
                else
                {
                    DataTable dt = new BUSUser().findIdUserByName("select * from [user] where email = N'" + txtEmail.Text.Trim() + "' and password = N'" + txtPassword.Text.Trim() + "'");
                    if(dt.Rows.Count > 0)
                    {

                        if(dt.Rows[0]["verify"].ToString().Equals("True"))
                        {
                            Main form = (Main)Application.OpenForms["Main"];
                            Songs formSong = (Songs)Application.OpenForms["Songs"];
                            form.SetUsername(dt.Rows[0]["username"].ToString());
                            form.button1.Visible = false;
                            form.button2.Visible = true;
                            form.button2.Font = new Font("ariel", 8);
                            form.btnAccount.Visible = false;
                            form.openChildForm(new Songs());
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("You need to verify account");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email or password is incorrect !!!");
                    }
                }
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Enter Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Enter Email";
                txtEmail.ForeColor = Color.Silver;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Enter Password";
                txtPassword.ForeColor = Color.Silver;
            }
        }
    }
}
