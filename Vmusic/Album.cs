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
    public partial class Album : Form
    {
        public Album()
        {
            InitializeComponent();
        }

        private void Album_Load(object sender, EventArgs e)
        {
            DataTable dt = (new BUSAlbum()).loadAlbum("select id,  name , picture_url from album");
            Main form = (Main)Application.OpenForms["Main"];
            int x = 0;
            int y = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var picture = new PictureBox();
                picture.Size = new Size(150, 160);
                
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                picture.ImageLocation = dt.Rows[i]["picture_url"].ToString();
                picture.Name = dt.Rows[i][1].ToString();
                picture.Tag = dt.Rows[i][0].ToString();
                picture.Location = new Point(x, y);
                picture.MouseClick += new MouseEventHandler((o, a) =>
                {
                    PictureBox pic = o as PictureBox;
                    AlbumDetail formDetail = new AlbumDetail();
                    formDetail.pictureBox1.ImageLocation = pic.ImageLocation;
                    formDetail.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    formDetail.label1.Text = pic.Name;
                    string id = (string)pic.Tag;
                    DataTable dtLoadAlbum = (new BUSAlbum()).loadAlbum("select * from song join artist on song.artist_id = artist.id join genre on song.genre_id = genre.id where song.album_id = " + Int32.Parse(id));
                    form.openChildForm(formDetail);
                    formDetail.loadSongInListView(dtLoadAlbum);
                }

                );

                var label1 = new Label();
                label1.AutoSize = true;
                label1.ForeColor = Color.White;
                label1.Parent = picture;
                flowLayoutPanel1.AutoScroll = true;
                label1.Text = dt.Rows[i][1].ToString();
                label1.Name = dt.Rows[i]["picture_url"].ToString();
                label1.Tag = dt.Rows[i]["id"].ToString();
                label1.MouseClick += new MouseEventHandler((o, a) =>
                {
                    AlbumDetail formDetail = new AlbumDetail();
                    Label l = o as Label;
                    formDetail.label1.Text = l.Text;
                    formDetail.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    formDetail.pictureBox1.ImageLocation = l.Name;
                    string id = (string)l.Tag;
                    DataTable dtLoadAlbum = (new BUSAlbum()).loadAlbum("select * from song join artist on song.artist_id = artist.id join genre on song.genre_id = genre.id where song.album_id = " + Int32.Parse(id));
                    form.openChildForm(formDetail);
                    formDetail.loadSongInListView(dtLoadAlbum);

                }
                );


                label1.Font = new Font(Label.DefaultFont, FontStyle.Bold);
            
                label1.Top = 147;
                flowLayoutPanel1.Controls.Add(picture);
                picture.Controls.Add(label1);
            }
        }
    }
}
