using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using BUS;

namespace Vmusic
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "Enter Name")
            {
                txtName.Text = "";
                txtName.ForeColor = Color.Black;
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.Text = "Enter Name";
                txtName.ForeColor = Color.Silver;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVmusic.Checked == true)
            {
                btnRegister.Enabled = true;
                btnRegister.BackColor = Color.Green;
                btnRegister.ForeColor = Color.White;
            }
            else
            {
                btnRegister.Enabled = false;
                btnRegister.BackColor = Color.Silver;
                btnRegister.ForeColor = Color.Black;
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

        private void Register_Load(object sender, EventArgs e)
        {
            btnRegister.Enabled = false;
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

        private void txtCPassword_Enter(object sender, EventArgs e)
        {
            if (txtCPassword.Text == "Enter Confirm Password")
            {
                txtCPassword.Text = "";
                txtCPassword.ForeColor = Color.Black;
            }
        }

        private void txtCPassword_Leave(object sender, EventArgs e)
        {
            if (txtCPassword.Text == "")
            {
                txtCPassword.Text = "Enter Confirm Password";
                txtCPassword.ForeColor = Color.Silver;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() != "")
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtCPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtCPassword.Text.Trim() != "")
            {
                txtCPassword.PasswordChar = '*';
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool gen = true;
            label1.Text = "";
            if (txtName.Text.Trim().Equals("") || txtName.Text.Trim().Equals("Enter Name"))
            {
                MessageBox.Show("Enter a name");
            }
            else
            {
                if (txtEmail.Text.Trim().Equals("") || txtEmail.Text.Trim().Equals("Enter Email"))
                {
                    MessageBox.Show("Enter a email");
                }
                else
                {
                    if (txtPassword.Text.Trim() != txtCPassword.Text.Trim())
                    {
                        MessageBox.Show("Password not match");
                    }
                    else
                    {
                        if (radioButtonMale.Checked == false && radioButtonFemale.Checked == false)
                        {
                            MessageBox.Show("Select your gender");
                        }

                        else
                        {
                            DataTable dt = new BUSUser().findIdUserByName("select * from [user] where email = N'" + txtEmail.Text.Trim() + "'");
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Account already exist !!!");
                            }

                            else
                            {

                                try
                                {
                                    SmtpClient client = new SmtpClient();
                                    client.Port = 587;
                                    client.Host = "smtp.gmail.com";
                                    client.EnableSsl = true;
                                    MailMessage mail = new MailMessage();
                                    mail.From = new MailAddress("NameOfYourEmail");
                                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                                    client.UseDefaultCredentials = false;
                                    client.Credentials = new System.Net.NetworkCredential ("youtemail@gmail.com", "YourPassword");

                                 
                                    mail.To.Add(txtEmail.Text);
                                    Random r = new Random();
                                    var x = r.Next(0, 1000000);
                                    string s = x.ToString("000000");
                                    mail.Subject = "Verify your account";
                                    mail.IsBodyHtml = true;
                                    mail.Body = "<img src='https://firebasestorage.googleapis.com/v0/b/cleverclass-2efd1.appspot.com/o/logoMusc.ico?alt=media&token=72171dd7-aa9c-49f7-97d6-510abcc021d2'/> <div style='font-weight:bold'> Hello " + txtName.Text + " </div> <div>Your code verify :" + s + "</div>";

                                    if (radioButtonFemale.Checked)
                                    {
                                        gen = false;
                                    }

                                    string query = "insert into [user]  values(" + "N'" + txtEmail.Text + "' , N'" + txtName.Text + "' , N'" + txtPassword.Text + "' ,'" + gen + "' , 'False')";
                                    new BUSUser().addNewUser(query);
                                    label1.Text = "Check your email to verify account";
                                    VerifyAccount verifyForm = new VerifyAccount();
                                    verifyForm.SetCodeSend(s);
                                    verifyForm.SetName(txtName.Text);
                                    verifyForm.SetEmail(txtEmail.Text);
                                    verifyForm.Show();                                  
                                    client.Send(mail);
                                }
                                catch (Exception ex)
                                {

                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                    }
                }
            }      

        }
    }
}
