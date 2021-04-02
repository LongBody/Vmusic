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
    public partial class Clock : Form
    {
        public Clock()
        {
            InitializeComponent();
        }
        int time = 0;
        int c = 0;

        private void SongSlider_ValueChanged(object sender, EventArgs e)
        {
            int times = SongSlider.Value;
            int hour = times / 3600;
            int minute = (times - hour * 3600) / 60;
            int seconds = (times - hour * 3600) % 60;
            label1.Text = hour + " hour " + minute + " minute" + seconds + " second ";
            c = times;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            Main form = (Main)Application.OpenForms["Main"];
            if (c == time)
            {
                timer1.Stop();
                this.Hide();
                form.play1.controls.pause();
                form.timer1.Stop();
                MessageBox.Show("Time ups");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            this.Visible = false;
        }

        private void Clock_Load(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
