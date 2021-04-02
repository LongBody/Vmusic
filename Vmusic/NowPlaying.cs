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
    public partial class NowPlaying : Form
    {
        public NowPlaying()
        {
            InitializeComponent();
        }

        int durationSong = 0;
        int timeSongStart = 0;


        public void SetTimeSongStart(int time)
        {
            timeSongStart = time;
        }


        public void SetDurationSong(int time)
        {
            durationSong = time;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void bunifuSlider2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NowPlaying_Load(object sender, EventArgs e)
        {
           
        }

        private void NowPlaying_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main form = (Main)Application.OpenForms["Main"];
            form.Visible = true;
        }
    }
}
