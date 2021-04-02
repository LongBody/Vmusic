using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using BUS;

namespace Vmusic
{
    public partial class Artist : Form
    {
        public Artist()
        {
            InitializeComponent();
        }

        private void Artist_Load(object sender, EventArgs e)
        {      
            DataTable dt = (new BUSArtist()).loadArtist("select author, image from artist");
            Main form = (Main)Application.OpenForms["Main"];
            int x = 0;
            int y = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var picture = new PictureBox();
                picture.Size = new Size(150, 250);
                picture.BackgroundImageLayout = ImageLayout.Stretch;
                picture.ImageLocation = dt.Rows[i]["image"].ToString();
                picture.Name = dt.Rows[i][0].ToString();
                picture.Location = new Point(x, y);
                picture.MouseClick += new MouseEventHandler((o, a) =>
                {
                    PictureBox pic = o as PictureBox;
                    ArtistDetail formDetail = new ArtistDetail();                
                    formDetail.pictureBox1.ImageLocation = pic.ImageLocation;
                    formDetail.label1.Text = pic.Name;
                    DataTable dtLoadWithAuthor = (new BUSSong()).loadSongWithArtist(pic.Name);
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
                label1.Name= dt.Rows[i]["image"].ToString();
                label1.MouseClick += new MouseEventHandler((o, a) => {
                    ArtistDetail formDetail = new ArtistDetail();                 
                    Label l = o as Label;
                    formDetail.label1.Text = l.Text;
                    formDetail.pictureBox1.ImageLocation = l.Name;
                    DataTable dtLoadWithAuthor = (new BUSSong()).loadSongWithArtist(l.Text);
                    form.openChildForm(formDetail);
                    formDetail.loadSongInListView(dtLoadWithAuthor);

                }
                );


                label1.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                label1.TextAlign = ContentAlignment.MiddleCenter;
                label1.Left = (140 - label1.Width) / 2;
                label1.Top = 145;
                flowLayoutPanel1.Controls.Add(picture);
                picture.Controls.Add(label1);


            }
        }
    }
}
