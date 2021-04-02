using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;

namespace Vmusic
{
    public partial class Genre : Form
    {
        public Genre()
        {
            InitializeComponent();
        }

        private void Genre_Load(object sender, EventArgs e)
        {
            DataTable dt = (new BUSArtist()).loadArtist("select genre, image from genre");
            Main form = (Main)Application.OpenForms["Main"];
            int x = 0;
            int y = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var picture = new PictureBox();
                picture.Size = new Size(150, 200);
                picture.BackgroundImageLayout = ImageLayout.Stretch;
                picture.ImageLocation = dt.Rows[i]["image"].ToString();
                picture.Name = dt.Rows[i][0].ToString();
                picture.Location = new Point(x, y);
                picture.MouseClick += new MouseEventHandler((o, a) =>
                {
                    PictureBox pic = o as PictureBox;
                    GenreDetail formDetail = new GenreDetail();
                    formDetail.pictureBox1.ImageLocation = pic.ImageLocation;
                    formDetail.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                    formDetail.label1.Text = pic.Name;
                    DataTable dtLoadWithAuthor = (new BUSSong()).loadSongWithGenre(pic.Name);
                    form.openChildForm(formDetail);
                    formDetail.loadSongInListView(dtLoadWithAuthor);
                }

                );

                var label1 = new Label();
                label1.AutoSize = true;
                label1.ForeColor = Color.White;
                label1.Parent = picture;
                flowLayoutPanel1.AutoScroll = true;
                label1.Text = dt.Rows[i][0].ToString();
                label1.Name = dt.Rows[i]["image"].ToString();
                label1.MouseClick += new MouseEventHandler((o, a) => {
                    ArtistDetail formDetail = new ArtistDetail();
                    Label l = o as Label;
                    formDetail.label1.Text = l.Text;
                    formDetail.pictureBox1.ImageLocation = l.Name;
                    formDetail.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                    DataTable dtLoadWithAuthor = (new BUSSong()).loadSongWithGenre(l.Text);
                    form.openChildForm(formDetail);
                    formDetail.loadSongInListView(dtLoadWithAuthor);

                }
                );


                label1.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                label1.TextAlign = ContentAlignment.MiddleCenter;
                label1.Top = 150;
                flowLayoutPanel1.Controls.Add(picture);
                picture.Controls.Add(label1);


            }
            }
        }
    
}
