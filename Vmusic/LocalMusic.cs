using AxWMPLib;
using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace Vmusic
{
    public partial class LocalMusic : Form
    {
        public LocalMusic()
        {
            InitializeComponent();
        }

        int countSongs = 1;

        String file = "";

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            string fileName = openFileDialog2.FileName;         
                file = fileName;

            
            
            
        }


        WindowsMediaPlayer play1 = new WindowsMediaPlayer();
        private void button2_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Trim().Equals(""))
            {
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                play1.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(wplayer_PlayStateChange);
                play1.URL = file;
                timer1.Start();
                play1.settings.volume = 0;
                play1.settings.rate = 100000;
            }
            else
            {
                MessageBox.Show("You need enter a name song");
            }
           
        }

        public void btnPrev_Click()
        {
            // get current row in listview
            Main form = (Main)Application.OpenForms["Main"];
            foreach (ListViewItem item in listView.Items)

            {
                // get the song is playing in form main
                if (item.SubItems[1].Text.Equals(form.lblNameSong.Text))
                {
                    int indexGet = Int32.Parse(item.SubItems[0].Text);
                    listView.Items[indexGet - 1].Selected = true;

                }

            }
            // get current row in listview
            int indexCurrent = listView.SelectedIndices[0];
            listView.Items[indexCurrent].Selected = false;
            // prev one row in list view
            int index;
            if (indexCurrent == 0)
            {
                index = countSongs - 2;
            }
            else
            {
                // prev one row in list view
                index = indexCurrent - 1;
            }
            //In case we're in the last row
            if (index >= listView.Items.Count)
                return;

            // row current after prev set selected is true ( color in row) 
            listView.Items[index].Selected = true;
            // play next song after click prev song button
            playSong(listView.Items[index].SubItems[5].Text.ToString(), listView.Items[index].SubItems[1].Text.ToString(), listView.Items[index].SubItems[3].Text.ToString(), listView.Items[index].SubItems[6].Text.ToString());
        }

        public void btnNext_Click()
        {
            Main form = (Main)Application.OpenForms["Main"];
            foreach (ListViewItem item in listView.Items)

            {
                // get the song is playing in form main
                if (item.SubItems[1].Text.Equals(form.lblNameSong.Text))
                {
                    int indexGet = Int32.Parse(item.SubItems[0].Text);
                    listView.Items[indexGet - 1].Selected = true;

                }

            }
            // get current row in listview
            int indexCurrent = listView.SelectedIndices[0];
            listView.Items[indexCurrent].Selected = false;
            // next one row in list view
            int index;
            if (indexCurrent == countSongs - 2)
            {
                index = 0;
            }
            else
            {
                // prev one row in list view
                index = indexCurrent + 1;
            }
            //In case we're in the last row
            if (index >= listView.Items.Count)
                return;

            // row current after next set selected is true ( color in row) 
            listView.Items[index].Selected = true;
            // play next song after click next song button
            playSong(listView.Items[index].SubItems[5].Text.ToString(), listView.Items[index].SubItems[1].Text.ToString(), listView.Items[index].SubItems[3].Text.ToString(), listView.Items[index].SubItems[6].Text.ToString());
        }

        private void SetHeight(ListView listView, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            listView.SmallImageList = imgList;
        }

        void wplayer_PlayStateChange(int NewState)
        {
            if (NewState == (int)WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                timer1.Stop();
                Main form = (Main)Application.OpenForms["Main"];
                DataTable dt = (new BUSUser()).findIdUserByName("select id from [user] where username = N'" + form.button2.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    int id = Int32.Parse(dt.Rows[0]["id"].ToString());
                    double time = play1.currentMedia.duration;
                    int time_song = (int)time;
                    progressBar1.Value = progressBar1.Maximum;
                    string query = "insert into localMusic values ( N' " + textBox1.Text + "', N'" + file + "', " + time_song + "," + id + ")";              
                    new BUSMusicLocal().Excute(query); 
                    DataTable dt_local = new BUSMusicLocal().loadMusicLocal("select * from localMusic where user_id = " + id);
                    loadSongs(dt_local);
                    MessageBox.Show("Add Successfully!!!");


                }
                 
               
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 1;
        }


        private void playSong(string fileLocation, string titleSong, string durationSongEnd, string durationSeconds)
        {
            Main form = (Main)Application.OpenForms["Main"];
            form.SongSlider.Value = 0;
            form.SetTimeSongStart(0);
            form.SetUpView();

            form.lblNameSong.MaximumSize = new Size(100, 0);
            form.lblNameSong.AutoSize = true;
            form.lblNameSong.Text = titleSong;

            int durationSong = Int32.Parse(durationSeconds);

            form.SetDurationSong(durationSong);

            form.lblDurationEnd.Text = durationSongEnd;
            form.SongSlider.MaximumValue = durationSong;

            form.PlaySongClick(fileLocation.Trim());
            form.SetForm(7);

            form.pictureBox3.Visible = false;
            form.pictureBox4.Visible = true;
        }

        private void LocalMusic_Load(object sender, EventArgs e)
        {
            button1.Text = "Choose File";
            progressBar1.Visible = false;
            button1.ForeColor = Color.Black;
            timer1.Stop();
            Main form = (Main)Application.OpenForms["Main"];
            DataTable dt_user = (new BUSUser()).findIdUserByName("select id from [user] where username = N'" + form.button2.Text + "'");
            int id = Int32.Parse(dt_user.Rows[0]["id"].ToString());
            DataTable dt = new BUSMusicLocal().loadMusicLocal("select * from localMusic where user_id = " + id);

            loadSongs(dt);

            
        }


        public void loadSongs(DataTable dt)
        {
            listView.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item1 = new ListViewItem(countSongs.ToString());
                item1.SubItems.Add(dt.Rows[i]["title"].ToString());
                int hours = Int32.Parse(dt.Rows[i]["duration"].ToString()) / 3600;
                int minutes = (Int32.Parse(dt.Rows[i]["duration"].ToString())) / 60;
                int seconds = Int32.Parse(dt.Rows[i]["duration"].ToString()) % 60;
                if (seconds < 10)
                {
                    item1.SubItems.Add(minutes + ":0" + seconds);
                }
                else
                {
                    item1.SubItems.Add(minutes + ":" + seconds);
                }
                item1.SubItems.Add(dt.Rows[i]["file"].ToString());
                item1.SubItems.Add(dt.Rows[i]["duration"].ToString());
                countSongs += 1;

                listView.Items.Add(item1);

                SetHeight(listView, 26);

            }
        }

        private void listView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Menu.Show(Cursor.Position.X, Cursor.Position.Y);
            }

            else
            {
                if (listView.SelectedItems.Count > 0)
                {
                    ListViewItem item = listView.SelectedItems[0];
                    playSong(item.SubItems[3].Text.ToString(), item.SubItems[1].Text.ToString(), item.SubItems[2].Text.ToString(), item.SubItems[4].Text.ToString());
                }
            }
        }

        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int indexCurrent = listView.SelectedIndices[0];
            if (e.ClickedItem.ToString().Equals("Delete"))
            {

                string name = listView.Items[indexCurrent].SubItems[1].Text.ToString();
                Main form = (Main)Application.OpenForms["Main"];
                DataTable dt_1 = (new BUSUser()).findIdUserByName("select id from [user] where username = N'" + form.button2.Text + "'");
                int user_id = Int32.Parse(dt_1.Rows[0]["id"].ToString());
                DataTable dt = new BUSMusicLocal().loadMusicLocal("select * from localMusic where title = N'" + name + "'and user_id =" + user_id);
               
                // get id song is playing
                int id = Int32.Parse(dt.Rows[0]["id"].ToString());
                string query = "delete from localMusic where id =  " + id + " and user_id = " + user_id;
                new BUSMusicLocal().Excute(query);
                DataTable dt_local = new BUSMusicLocal().loadMusicLocal("select * from localMusic where user_id = " + user_id);
                loadSongs(dt_local);


            }
        }
    }
}
