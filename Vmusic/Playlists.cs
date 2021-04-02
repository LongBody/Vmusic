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
    public partial class Playlists : Form
    {
        public Playlists()
        {
            InitializeComponent();
        }

        private void Playlists_Load(object sender, EventArgs e)
        {
            Main form = (Main)Application.OpenForms["Main"];
            DataTable dt_user = (new BUSUser()).findIdUserByName("select id from [user] where username = N'" + form.button2.Text + "'");
            if (dt_user.Rows.Count > 0)
            {
            int id = Int32.Parse(dt_user.Rows[0]["id"].ToString());
            DataTable dt = (new BUSPlaylist()).loadPlaylist("select distinct(title)  from playlist where user_id = " + id);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var picture = new PictureBox();
                    picture.Size = new Size(150, 160);

                    picture.SizeMode = PictureBoxSizeMode.StretchImage;
                    picture.ImageLocation = "C:\\Users\\LongBody\\source\\repos\\Vmusic\\image\\playlist.png";
                    picture.Name = dt.Rows[i][0].ToString();
                    picture.MouseClick += new MouseEventHandler((o, a) =>
                    {
                        PictureBox pic = o as PictureBox;
                        PlaylistDetail formDetail = new PlaylistDetail();
                        formDetail.pictureBox1.ImageLocation = pic.ImageLocation;
                        formDetail.label1.Text = pic.Name;
                        string query = "select * from song join artist on song.artist_id = artist.id join genre on song.genre_id = genre.id Join playlist on song.id = playlist.song_id where playlist.title  = N'" + pic.Name + "' and playlist.user_id = " + id;
                        
                        DataTable dtLoad = (new BUSPlaylist()).loadPlaylist(query);
                        form.openChildForm(formDetail);
                        formDetail.loadSongInListView(dtLoad);
                        formDetail.loadMenuSub();
                    }

                    );


                    var label1 = new Label();
                    label1.AutoSize = true;
                    label1.ForeColor = Color.GreenYellow;
                    label1.BackColor = Color.Transparent;
                    flowLayoutPanel1.AutoScroll = true;
                    label1.Text = dt.Rows[i][0].ToString();
                    label1.Name = "C:\\Users\\LongBody\\source\\repos\\Vmusic\\image\\playlist.png";
                    label1.MouseClick += new MouseEventHandler((o, a) => {
                        PlaylistDetail formDetail = new PlaylistDetail();
                        Label l = o as Label;
                        formDetail.label1.Text = l.Text;
                        formDetail.pictureBox1.ImageLocation = l.Name;
                        string query = "select * from song join artist on song.artist_id = artist.id join genre on song.genre_id = genre.id Join playlist on song.id = playlist.song_id where playlist.title = N'" + l.Text + "' and playlist.user_id = " + id;
                        DataTable dtLoad = (new BUSPlaylist()).loadPlaylist(query);
                        form.openChildForm(formDetail);
                        formDetail.loadSongInListView(dtLoad);
                        formDetail.loadMenuSub();

                    }
                    );


                    label1.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                    //label1.TextAlign = ContentAlignment.MiddleCenter;
                    label1.Left = (100 - label1.Width) / 2;
                    label1.Top = 145;
                    flowLayoutPanel1.Controls.Add(picture);
                    picture.Controls.Add(label1);


                }
            }
          
        }
    }
}
