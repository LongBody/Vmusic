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
    public partial class Lyrics : Form
    {
        public Lyrics()
        {
            InitializeComponent();
        }

        private void Lyrics_Load(object sender, EventArgs e)
        {

        }

        public void load(DataTable dt)
        {
            flowLayoutPanel1.Controls.Clear();
            Label lbl= new Label();
            //lbl.Margin = new Padding(4, 4, 4, 4);
            lbl.AutoSize = true;
            lbl.ForeColor = Color.White;
            //lbl.TextAlign = ContentAlignment.MiddleCenter;
            //lbl.Left = (140 - lbl.Size.Width) / 2;
            lbl.Font = new Font("Arial", 15, FontStyle.Bold);
            flowLayoutPanel1.AutoScroll = true;
            lbl.Text = dt.Rows[0][0].ToString();
            flowLayoutPanel1.Controls.Add(lbl);
        }
    }
}
