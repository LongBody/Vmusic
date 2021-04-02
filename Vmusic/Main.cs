using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;
using BUS;
using System.Text.RegularExpressions;


namespace Vmusic
{


    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }


         public WindowsMediaPlayer play1 = new WindowsMediaPlayer();
        public int form = 1;
        int durationSong = 0;
        int timeSongStart = 0;
        bool upView = true;
        int timeSongPlaying = 0;
        int volume = 50;
        bool again = false;
        bool random = false;


        public Panel panelControl
        {
            set { panel5 = value; }
            get { return panel5; }
        }

        public void SetTimeSongStart(int time)
        {
            timeSongStart = time;
        }

        public void SetUsername(string name)
        {
            button2.Text = name;
        }

        public void SetUpView()
        {
            upView = true;
        }


        public void SetForm(int formPass)
        {
            form = formPass;
        }
        public int getForm()
        {
            return form;
        }


        public void SetDurationSong(int time)
        {
            durationSong = time;
        }


        public void timer1_Tick(object sender, EventArgs e)
        {
            SongSlider.Value += 1;
            timeSongStart += 1;
            int minutes = timeSongStart / 60;
            int seconds = timeSongStart % 60;
            lblDurationStart.Text = "";
            if (seconds < 10)
            {
                lblDurationStart.Text = minutes + ":" + "0" + seconds;
            }
            else
            {
                lblDurationStart.Text = minutes + ":" + seconds;
            }
            //listen at least 50% time of songs to update view 
            //Can not use slider to update , it minus time that user use slider

            if (SongSlider.Value - timeSongPlaying > (durationSong / 2) && upView)
            {
                DataTable dt = new BUSSong().findIdSong(lblNameSong.Text);

                if(dt.Rows.Count > 0)
                {
                    // get id song is playing
                    int id = Int32.Parse(dt.Rows[0]["id"].ToString());
                    // update view song with id
                    new BUSSong().updateViewSongs(id);
                    upView = false;
                }
                
            }

            if (SongSlider.Value == durationSong)
            {
                upView = true;
               
                timer1.Stop();
                if (again)
                {
                    playAgain();
                }
                else if(random)
                {
                    playRandom();
                }
                else
                {
                    nextSongs();
                }

            }
        }

        public void PlaySongClick(string fileLocation)
        {
            timer1.Stop();
            lblDurationStart.Text = "0:00";
            play1.URL = fileLocation.Trim();
            pictureBox3.Enabled = true;
            clickNextSong.Enabled = true;
            clickPrevSong.Enabled = true;

            play1.controls.play();
            timeSongStart = 0;
            play1.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(wplayer_PlayStateChange);


        }

        void wplayer_PlayStateChange(int NewState)
        {
            if (NewState == (int)WMPLib.WMPPlayState.wmppsPlaying)
            {
                timer1.Start();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            play1.controls.play();
            timer1.Start();
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            play1.controls.pause();
            timer1.Stop();
            pictureBox4.Visible = false;
            pictureBox3.Visible = true;
        }

        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            //if (activeForm != null) activeForm.Close();
            //activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel5.Controls.Add(childForm);
            panel5.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void hideSubMenu()
        {
            //panelAccount.Visible = false;

        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            //showSubMenu(panelAccount);
            Register form = new Register();
            form.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            btnAccount.Text = "Register";
            button2.Visible = false;
            this.MaximizeBox = false;
            Form songs = new Songs();
            bunifuSlider2.Value = 50;
            openChildForm(new Search());
            play1.settings.volume = 50;
            lblSongs.Font = new Font(lblSongs.Font, FontStyle.Bold);
            lblSongs.ForeColor = Color.White;
            openChildForm(songs);
        }


        private void bunifuSlider1_Scroll(object sender, ScrollEventArgs e)
        {
            int time = SongSlider.Value;
            int minutes = time / 60;
            int seconds = time % 60;
            if (seconds < 10)
            {
                lblDurationStart.Text = minutes + ":" + "0" + seconds;
            }
            else
            {
                lblDurationStart.Text = minutes + ":" + seconds;
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {
            openChildForm(new Artist());

            lblArtist.Font = new Font(lblSongs.Font, FontStyle.Bold);
            lblArtist.ForeColor = Color.White;
            lblSongs.ForeColor = Color.Silver;
            lblSongs.Font = new Font(lblSongs.Font, FontStyle.Regular);
            lblAlbums.ForeColor = Color.Silver;
            lblAlbums.Font = new Font(lblSongs.Font, FontStyle.Regular);
        }

        private void SongSlider_ValueChanged(object sender, EventArgs e)
        {
            int time = SongSlider.Value;

            play1.controls.currentPosition = time;
            timeSongPlaying = time - timeSongStart;
            timeSongStart = time;
            int minutes = time / 60;
            int seconds = time % 60;
            if (seconds < 10)
            {
                lblDurationStart.Text = minutes + ":" + "0" + seconds;
            }
            else
            {
                lblDurationStart.Text = minutes + ":" + seconds;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

            //DataTable dt = (new BUSSong()).loadSongs();
            openChildForm(new Songs());
            //formSongOpen.loadSongInListView(dt);
            lblSongs.Font = new Font(lblSongs.Font, FontStyle.Bold);
            lblSongs.ForeColor = Color.White;
            lblArtist.ForeColor = Color.Silver;
            lblArtist.Font = new Font(lblSongs.Font, FontStyle.Regular);
            lblAlbums.ForeColor = Color.Silver;
            lblAlbums.Font = new Font(lblSongs.Font, FontStyle.Regular);


        }

        public void playAgain()
        {
            lblDurationStart.Text = "0:00";
            timeSongStart = 0;
            Songs formSongs = (Songs)Application.OpenForms["Songs"];
            ArtistDetail formArtist = (ArtistDetail)Application.OpenForms["ArtistDetail"];
            GenreDetail genArtist = (GenreDetail)Application.OpenForms["GenreDetail"];
            MostListened most = (MostListened)Application.OpenForms["MostListened"];
            Favourite favourite = (Favourite)Application.OpenForms["Favourite"];
            AlbumDetail album = (AlbumDetail)Application.OpenForms["AlbumDetail"];
            //MessageBox.Show(form+"");
            upView = true;

            if (form == 1)
            {
                formSongs.btnNext_Again();
            }

            else if (form == 2)
            {
                formArtist.btnNext_Click();
            }
            else if (form == 3)
            {
                most.btnNext_Click();
            }
            else if (form == 4)
            {
                favourite.btnNext_Click();
            }
            else if (form == 5)
            {
                genArtist.btnNext_Click();
            }
            else if (form == 6)
            {
                album.btnNext_Click();
            }
        }

        private void clickNextSong_Click(object sender, EventArgs e)
        {
            nextSongs();
           
        }

        public void playRandom()
        {
            lblDurationStart.Text = "0:00";
            timeSongStart = 0;
            Songs formSongs = (Songs)Application.OpenForms["Songs"];
            ArtistDetail formArtist = (ArtistDetail)Application.OpenForms["ArtistDetail"];
            GenreDetail genArtist = (GenreDetail)Application.OpenForms["GenreDetail"];
            MostListened most = (MostListened)Application.OpenForms["MostListened"];
            Favourite favourite = (Favourite)Application.OpenForms["Favourite"];
            AlbumDetail album = (AlbumDetail)Application.OpenForms["AlbumDetail"];
            //MessageBox.Show(form+"");
            upView = true;

            if (form == 1)
            {
                formSongs.btnRandom_click();
            }

            else if (form == 2)
            {
                formArtist.btnNext_Click();
            }
            else if (form == 3)
            {
                most.btnNext_Click();
            }
            else if (form == 4)
            {
                favourite.btnNext_Click();
            }
            else if (form == 5)
            {
                genArtist.btnNext_Click();
            }
            else if (form == 6)
            {
                album.btnNext_Click();
            }


        }

        public void nextSongs()
        {
            lblDurationStart.Text = "0:00";
            timeSongStart = 0;
            Songs formSongs = (Songs)Application.OpenForms["Songs"];
            ArtistDetail formArtist = (ArtistDetail)Application.OpenForms["ArtistDetail"];
            GenreDetail genArtist = (GenreDetail)Application.OpenForms["GenreDetail"];
            MostListened most = (MostListened)Application.OpenForms["MostListened"];
            Favourite favourite = (Favourite)Application.OpenForms["Favourite"];
            AlbumDetail album = (AlbumDetail)Application.OpenForms["AlbumDetail"];
            //MessageBox.Show(form+"");
            upView = true;

            if (form == 1)
            {
                formSongs.btnNext_Click();
            }

            else if (form == 2)
            {
                formArtist.btnNext_Click();
            }
            else if (form == 3)
            {
                most.btnNext_Click();
            }
            else if (form == 4)
            {
                favourite.btnNext_Click();
            }
            else if (form == 5)
            {
                genArtist.btnNext_Click();
            }
            else if (form == 6)
            {
                album.btnNext_Click();
            }
        }

        private void clickPrevSong_Click(object sender, EventArgs e)
        {
            Songs formSongs = (Songs)Application.OpenForms["Songs"];
            lblDurationStart.Text = "0:00";
            upView = true;
            AlbumDetail album = (AlbumDetail)Application.OpenForms["AlbumDetail"];
            ArtistDetail formArtist = (ArtistDetail)Application.OpenForms["ArtistDetail"];
            GenreDetail genArtist = (GenreDetail)Application.OpenForms["GenreDetail"];
            Favourite favourite = (Favourite)Application.OpenForms["Favourite"];
            MostListened most = (MostListened)Application.OpenForms["MostListened"];

            if (form == 1)
            {
                formSongs.btnPrev_Click();
            }

            else if (form == 2)
            {
                formArtist.btnPrev_Click();
            }
            else if (form == 3)
            {
                most.btnPrev_Click();
            }
            else if (form == 4)
            {
                favourite.btnPrev_Click();
            }
            else if (form == 5)
            {
                genArtist.btnPrev_Click();
            }
            else if (form == 6)
            {
                album.btnPrev_Click();
            }
        }





        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string txt = txtSearch.Text.Trim().ToLower();
                // string pal = txtString.Text.Trim()
                if (txt.Trim().Equals(""))
                {
                    MessageBox.Show("Enter a name song or author");
                }
                else
                {
                    Search formSongOpen = (Search)Application.OpenForms["Search"];
                    DataTable dt = (new BUSSong()).searchSongs(txt);
                    formSongOpen.loadSongInListView(dt);
                    

                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Search";
            }
        }

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            openChildForm(new Playlists());
        }

        private void bunifuSlider2_ValueChanged(object sender, EventArgs e)
        {
            play1.settings.volume = bunifuSlider2.Value;
            lblVolume.Text = bunifuSlider2.Value.ToString();
            int time = SongSlider.Value;
            timeSongPlaying = time - timeSongStart;
            volume = bunifuSlider2.Value;
            if (bunifuSlider2.Value == 0)
            {
                btnMute.Visible = true;
                btnVolume.Visible = false;
            }
            else
            {
                btnMute.Visible = false;
                btnVolume.Visible = true;
            }
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblVolume_Click(object sender, EventArgs e)
        {

        }

        private void lblAlbums_Click(object sender, EventArgs e)
        {
            openChildForm(new Album());
            lblAlbums.Font = new Font(lblSongs.Font, FontStyle.Bold);
            lblAlbums.ForeColor = Color.White;
            lblArtist.ForeColor = Color.Silver;
            lblArtist.Font = new Font(lblSongs.Font, FontStyle.Regular);
            lblSongs.ForeColor = Color.Silver;
            lblSongs.Font = new Font(lblSongs.Font, FontStyle.Regular);
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            openChildForm(new Genre());
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (!lblNameSong.Text.Equals(""))
            {
                NowPlaying now = new NowPlaying();
                this.Visible = false;
                now.Show();
                now.label1.Text = lblNameSong.Text;
                now.label1.TextAlign = ContentAlignment.MiddleCenter;
            }
            else
            {
                MessageBox.Show("You are not playing any song");
            }


        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            openChildForm(new MostListened());
            //MostListened form = (MostListened)Application.OpenForms["MostListened"];
            //DataTable dt = (new BUSSong()).loadSongs();
            //form.loadSongInListView(dt);

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            openChildForm(new Favourite());
        }

        private void btnVolume_Click(object sender, EventArgs e)
        {
            lblVolume.Text = "0";
            bunifuSlider2.Value = 0;
            play1.settings.volume = 0;
            btnMute.Visible = true;
            btnVolume.Visible = false;
        }

        private void btnMute_Click(object sender, EventArgs e)
        {

            play1.settings.volume = volume;
            lblVolume.Text = volume.ToString();
            bunifuSlider2.Value = volume;
            btnVolume.Visible = true;
            btnMute.Visible = false;
        }

        private void SongSlider_ValueChangeComplete(object sender, EventArgs e)
        {
            //int time = SongSlider.Value;
            //timeSongPlaying = time - timeSongStart;


        }

        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        int lyricsTime = 0;

        private void label1_Click_1(object sender, EventArgs e)
        {
            lyricsTime = 0;
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lyricsTime++;
            if (lyricsTime == 1)
            {
                timer2.Stop();
                string nameSong = lblNameSong.Text;
                string query = "select lyrics from song where title = N'" + nameSong + "'";
                DataTable dt = new BUSSong().loadLyrics(query);
                openChildForm(new Lyrics());
                Lyrics ly = (Lyrics)Application.OpenForms["Lyrics"];
                ly.load(dt);
            }

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Main form = (Main)Application.OpenForms["Main"];
            DataTable dt = (new BUSUser()).findIdUserByName("select id from [user] where username = N'" + form.button2.Text + "'");
            if (dt.Rows.Count > 0)
            {
                openChildForm(new LocalMusic());
            }
            else
            {
                MessageBox.Show("You need login to use this feature");
            }
        }

   

        private void button4_Click(object sender, EventArgs e)
        {
            Clock form = new Clock();
            form.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
                random = true;
            pictureBox7.Visible = false;
            pictureBox8.Visible = true;
            

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            random = false;
            pictureBox8.Visible = false;
            pictureBox7.Visible = true;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
                pictureBox9.Visible = false;
                pictureBox10.Visible = true;
                again = true;

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("oke");
            pictureBox10.Visible = false;
            pictureBox9.Visible = true;
            again = false;
        }
    }
}
