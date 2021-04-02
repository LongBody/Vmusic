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
    public partial class VerifyAccount : Form
    {
        public VerifyAccount()
        {
            InitializeComponent();
        }

        string codeSend;
        string name;
        string email;
        string password;
        bool gen;

        public void SetCodeSend(string code)
        {
            codeSend = code;
        }
        public void SetName(string namePass)
        {
            name = namePass;
        }

        public void SetEmail(string emailPass)
        {
            email = emailPass;
        }

        private void VerifyAccount_Load(object sender, EventArgs e)
        {
         

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            if (textBox1.Text.Trim().Equals(""))
            {
                MessageBox.Show("Enter Code");
            }
            else
            {
                string codeEnter = textBox1.Text.Trim();
                if (codeEnter.Equals(codeSend))
                {
                    DataTable dt_1 = (new BUSUser()).findIdUserByName("select id from [user] where email = N'" + email  + "' and username = N'" + name  + "'");
                    int id = Int32.Parse(dt_1.Rows[0]["id"].ToString());
                    new BUSUser().addNewUser("update [user] set verify = 1 where id = " + id);
                    Main form = (Main)Application.OpenForms["Main"];
                    Register form1 = (Register)Application.OpenForms["Register"];
                    if(form1!= null)
                    {
                        form1.Hide();
                    }
                   
                    VerifyAccount form2 = (VerifyAccount)Application.OpenForms["VerifyAccount"];
                    form2.Hide();
                    MessageBox.Show("Verify account success !!!");
                    form.button1.Visible = false;
                    form.btnAccount.Visible = false;
                    form.button2.Visible = true;
                    form.SetUsername(name);
                }
                else
                {
                    MessageBox.Show("Code is incorrect !!!");
                }
            }
        }
    }
}
