using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using BUS;
using System.Windows.Forms;
using WMPLib;
using System.Net;
using System.IO;

namespace Vmusic
{
    public partial class Songs : Form
    {

        
        public Songs()
        {
            InitializeComponent();
        }

        bool load = false;


        public void loadMenuSub()
        {

            Main form = (Main)Application.OpenForms["Main"];
            DataTable dt = (new BUSUser()).findIdUserByName("select id from [user] where username = N'" + form.button2.Text + "'");
            if (dt.Rows.Count > 0)
            {
                int id = Int32.Parse(dt.Rows[0]["id"].ToString());
                DataTable dt_0 = new BUSPlaylist().loadPlaylist("select count(distinct title) from playlist where user_id = " + id);

                for (int i = 0; i < dt_0.Rows.Count; i++)
                {
                    (Menu.Items[i] as ToolStripMenuItem).DropDownItems.Clear();
                }
                DataTable dt_2 = new BUSPlaylist().loadPlaylist("select distinct title from playlist where user_id = " + id);
                (Menu.Items[0] as ToolStripMenuItem).DropDownItems.Add("Create a new playlist", null, createNewPlaylist);
                for (int i = 0; i < dt_2.Rows.Count; i++)
                {
                    (Menu.Items[0] as ToolStripMenuItem).DropDownItems.Add(dt_2.Rows[i]["title"].ToString(), null, addToPlayList);
                }
            }


        }
        private void addToPlayList(object sender, EventArgs e)
        {
            Main form = (Main)Application.OpenForms["Main"];
            DataTable dt = (new BUSUser()).findIdUserByName("select id from [user] where username = N'" + form.button2.Text + "'");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("You need login to use this feature");
            }
            else
            {
                int indexCurrent = listView.SelectedIndices[0];
                string playlist = (sender as ToolStripMenuItem).Text;
                string nameSong = listView.Items[indexCurrent].SubItems[1].Text;

                int id = Int32.Parse(dt.Rows[0]["id"].ToString());
                DataTable dt_1 = new BUSSong().findIdSong(nameSong);
                // get id song is playing
                int id_song = Int32.Parse(dt_1.Rows[0]["id"].ToString());
                DataTable dt_2 = new BUSPlaylist().checkSongExistPlaylist(id_song, id, playlist);
                if (dt_2.Rows.Count > 0)
                {
                    MessageBox.Show("This song is already in this playlist");
                }
                else
                {
                    new BUSPlaylist().addToPlayList(id_song, id, playlist);
                    MessageBox.Show("Add song in " + playlist);
                    loadMenuSub();
                }
            }


        }

        private void createNewPlaylist(object sender, EventArgs e)
        {
            Main formMain = (Main)Application.OpenForms["Main"];
            DataTable dt = (new BUSUser()).findIdUserByName("select id from [user] where username = N'" + formMain.button2.Text + "'");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("You need login to use this feature");
            }
            else
            {
                int indexCurrent = listView.SelectedIndices[0];
                string nameSong = listView.Items[indexCurrent].SubItems[1].Text;

                int id = Int32.Parse(dt.Rows[0]["id"].ToString());
                DataTable dt_1 = new BUSSong().findIdSong(nameSong);
                // get id song is playing
                int id_song = Int32.Parse(dt_1.Rows[0]["id"].ToString());
                CreateNewPlaylist form = new CreateNewPlaylist();
                form.Show();
                form.SetForm(1);
                form.SetSongId(id_song);
                form.SetUserId(id);


            }
        }



        public void btnPrev_Click()
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
            playSong(listView.Items[index].SubItems[6].Text.ToString(), listView.Items[index].SubItems[1].Text.ToString(), listView.Items[index].SubItems[4].Text.ToString(), listView.Items[index].SubItems[7].Text.ToString());
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

            try
            {
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
                playSong(listView.Items[index].SubItems[6].Text.ToString(), listView.Items[index].SubItems[1].Text.ToString(), listView.Items[index].SubItems[4].Text.ToString(), listView.Items[index].SubItems[7].Text.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "");
                throw new Exception();
            }
            
        }

        public void btnNext_Again()
        {

            Main form = (Main)Application.OpenForms["Main"];
            foreach (ListViewItem item in listView.Items)

            {
                // get the song is playing in form main
                if (item.SubItems[1].Text.Equals(form.lblNameSong.Text))
                {
                    int indexGet = Int32.Parse(item.SubItems[0].Text);
                    //listView.Items[indexGet].Selected = true;

                }

            }

            try
            {
                // get current row in listview
                int indexCurrent = listView.SelectedIndices[0];
                //listView.Items[indexCurrent].Selected = false;
                // next one row in list view
                int index;
                if (indexCurrent == countSongs - 2)
                {
                    index = 0;
                }
                else
                {
                    // prev one row in list view
                    index = indexCurrent ;
                }
                //In case we're in the last row
                if (index >= listView.Items.Count)
                    return;

                // row current after next set selected is true ( color in row) 
                listView.Items[index].Selected = true;
                // play next song after click next song button
                playSong(listView.Items[index].SubItems[6].Text.ToString(), listView.Items[index].SubItems[1].Text.ToString(), listView.Items[index].SubItems[4].Text.ToString(), listView.Items[index].SubItems[7].Text.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "");
                throw new Exception();
            }

        }



        private void playSong(string fileLocation, string titleSong, string durationSongEnd, string durationSeconds)
        {
            Main form = (Main)Application.OpenForms["Main"];
            form.SongSlider.Value = 0;
            form.SetTimeSongStart(0);
            
       
            form.lblNameSong.MaximumSize = new Size(100, 0);
            form.lblNameSong.AutoSize = true;
            form.lblNameSong.Text = titleSong;

            int durationSong = Int32.Parse(durationSeconds);

            form.SetDurationSong(durationSong);

            form.lblDurationEnd.Text = durationSongEnd;
            form.SongSlider.MaximumValue = durationSong;

            form.PlaySongClick(fileLocation.Trim());
            form.SetForm(1);
            form.SetUpView();

            form.pictureBox3.Visible = false;
            form.pictureBox4.Visible = true;
        }

        private void SetHeight(ListView listView, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            listView.SmallImageList = imgList;
        }


        int countSongs = 1;
       

        public void SetLoad(bool loadPass)
        {
            load = loadPass;
        }

        public void Songs_Load(object sender, EventArgs e)
        {        
                loadSong();               
        }

        public void loadSong()
        {
            DataTable dt = (new BUSSong()).loadSongs();
            loadSongInListView(dt);
            loadMenuSub();
            load = false;
        }

       
        public void loadSongInListView(DataTable dt)
        {
            listView.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item1 = new ListViewItem(countSongs.ToString());
                item1.SubItems.Add(dt.Rows[i]["title"].ToString());
                item1.SubItems.Add(dt.Rows[i]["author"].ToString());
                item1.SubItems.Add(dt.Rows[i]["genre"].ToString());
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
                item1.SubItems.Add("Not yet");
                item1.SubItems.Add(dt.Rows[i]["file"].ToString());
                item1.SubItems.Add(dt.Rows[i]["duration"].ToString());
                item1.SubItems.Add(dt.Rows[i]["urlDownload"].ToString());
                countSongs += 1;

                listView.Items.Add(item1);

                SetHeight(listView, 26);

            }
        }


        public void loadSongInListViewSearch(DataTable dt)
        {
            listView.Items.Clear();
            MessageBox.Show(dt.Rows.Count + "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item1 = new ListViewItem(countSongs.ToString());
                item1.SubItems.Add(dt.Rows[i]["title"].ToString());
                item1.SubItems.Add(dt.Rows[i]["author"].ToString());
                item1.SubItems.Add(dt.Rows[i]["genre"].ToString());
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
                item1.SubItems.Add("Not yet");
                item1.SubItems.Add(dt.Rows[i]["file"].ToString());
                item1.SubItems.Add(dt.Rows[i]["duration"].ToString());
                item1.SubItems.Add(dt.Rows[i]["urlDownload"].ToString());
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
                    playSong(item.SubItems[6].Text.ToString(), item.SubItems[1].Text.ToString(), item.SubItems[4].Text.ToString(), item.SubItems[7].Text.ToString());
                }
            }
        }

        public void btnRandom_click()

        {

            if (listView.SelectedItems.Count >= 1)
            {
                int indexCurrent = listView.SelectedIndices[0];
                listView.Items[indexCurrent].Selected = false;
            }

            Random r = new Random();
            Main form = (Main)Application.OpenForms["Main"];
            int rdNum = 0;
            rdNum = r.Next(listView.Items.Count);
            MessageBox.Show(rdNum + "");
            listView.Items[rdNum].Selected = true;


            try
            {

                playSong(listView.Items[rdNum].SubItems[6].Text.ToString(), listView.Items[rdNum].SubItems[1].Text.ToString(), listView.Items[rdNum].SubItems[4].Text.ToString(), listView.Items[rdNum].SubItems[7].Text.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "");
                throw new Exception();
            }

        }

        public Boolean checkselexted()
        {
            if (listView.SelectedItems.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        private void Menu_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {
            int indexCurrent = listView.SelectedIndices[0];
            if (e.ClickedItem.ToString().Equals("Download"))
            {
                string file = listView.Items[indexCurrent].SubItems[8].Text.ToString();
                string name = listView.Items[indexCurrent].SubItems[1].Text.ToString();
                //Create a WebClient to use as our download proxy for the program.
                WebClient webClient = new WebClient();
                System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);

                //Attach the DownloadFileCompleted event to your new AsyncCompletedEventHandler Completed
                //so when the event occurs the method is called.
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(downloader_DownloadFileCompleted);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(downloader_DownloadProgressChanged);

                //Attempt to actually download the file, this is where the error that you
                //won't see is probably occurring, this is because it checks the url in 
                //the blocking function internally and won't execute the download itself 
                //until this clears.
                webClient.DownloadFileAsync(new Uri(file), "C:\\Users\\LongBody\\Downloads\\" + name + ".mp3");

            }

            else if (e.ClickedItem.ToString().Equals("Favourite"))
            {
                string name = listView.Items[indexCurrent].SubItems[1].Text.ToString();
                DataTable dt = new BUSSong().findIdSong(name);
                // get id song is playing
                int id = Int32.Parse(dt.Rows[0]["id"].ToString());
                Main form = (Main)Application.OpenForms["Main"];
                if (!form.button2.Text.Equals("User")){
                    DataTable dt_1 = (new BUSUser()).findIdUserByName("select id from [user] where username = N'" + form.button2.Text + "'");
                    if (dt_1.Rows.Count > 0)
                    {
                        int id_user = Int32.Parse(dt_1.Rows[0]["id"].ToString());
                        DataTable dt_2 = new BUSFavourite().findSongFavourite(id, id_user);
                        if (dt_2.Rows.Count ==  0)
                        {
                            new BUSFavourite().addFavourite(id, id_user);
                            MessageBox.Show("Add success!!!");
                        }
                        else
                        {
                            MessageBox.Show("This song is already in favourite list");
                        }
                    }                  
                }
                else
                {
                    MessageBox.Show("You need login to use this feature");
                }

            }                    
        }

        void downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            int indexCurrent = listView.SelectedIndices[0];
            listView.Items[indexCurrent].SubItems[5].ForeColor = Color.Green;
            listView.Items[indexCurrent].SubItems[5].Text =  e.ProgressPercentage + "%";
        }
        void downloader_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            int indexCurrent = listView.SelectedIndices[0];
            if (e.Error != null)
                MessageBox.Show(e.Error.Message);
            else
            {

                string name = listView.Items[indexCurrent].SubItems[1].Text.ToString();
                DataTable dt_1 = new BUSSong().findIdSong(name);
                // get id song is playing
                int id_song = Int32.Parse(dt_1.Rows[0]["id"].ToString());
                string nameFile = "C:\\Users\\LongBody\\Downloads\\" + name + ".mp3";
                string query = "update song set [file] = N'" + nameFile + "' where id = " + id_song;
                new BUSSong().updateLink(query);
                DataTable dt = (new BUSSong()).loadSongs();
                loadSongInListView(dt);
                MessageBox.Show("Download Completed!!!");
            }

                
        }
    }
}
