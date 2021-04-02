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
    public partial class CreateNewPlaylist : Form
    {
        int song;
        int userId;
        int form;

        public void SetSongId(int songId)
        {
            song = songId;
        }

        public void SetForm(int formInt)
        {
            form = formInt;
        }

        public void SetUserId(int id)
        {
            userId = id;
        }

        public CreateNewPlaylist()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string playlist = textBox1.Text.Trim();
            if (!playlist.Equals(""))
            {
                new BUSPlaylist().addToPlayList(song, userId, playlist);
               
                Songs formSongs = (Songs)Application.OpenForms["Songs"];
                ArtistDetail formArtist = (ArtistDetail)Application.OpenForms["ArtistDetail"];
                GenreDetail genArtist = (GenreDetail)Application.OpenForms["GenreDetail"];
                Favourite favourite = (Favourite)Application.OpenForms["Favourite"];
                MostListened most = (MostListened)Application.OpenForms["MostListened"];       
                AlbumDetail album = (AlbumDetail)Application.OpenForms["AlbumDetail"];


                if (form == 1)
                {
                    formSongs.loadMenuSub();
                }

                else if (form == 2)
                {
                    formArtist.loadMenuSub();
                }
                else if (form == 3)
                {
                    most.loadMenuSub();
                }
                else if (form == 4)
                {
                    favourite.loadMenuSub();
                }
                else if (form == 5)
                {
                    genArtist.loadMenuSub();
                }
                else if (form == 6)
                {
                    album.loadMenuSub();
                }
                this.Hide();
                MessageBox.Show("Add song in new playlist success!");

            }
            else
            {
                MessageBox.Show("Enter a playlist name");
            }
           
        }

        private void CreateNewPlaylist_Load(object sender, EventArgs e)
        {

        }
    }
}
