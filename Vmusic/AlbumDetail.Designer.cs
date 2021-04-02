
namespace Vmusic
{
    partial class AlbumDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddToPlayList = new System.Windows.Forms.ToolStripMenuItem();
            this.Favourite = new System.Windows.Forms.ToolStripMenuItem();
            this.Download = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listView = new System.Windows.Forms.ListView();
            this.Play = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Song = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Genre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.URL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Menu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToPlayList,
            this.Favourite,
            this.Download});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(178, 76);
            this.Menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Menu_ItemClicked);
            // 
            // AddToPlayList
            // 
            this.AddToPlayList.Name = "AddToPlayList";
            this.AddToPlayList.Size = new System.Drawing.Size(177, 24);
            this.AddToPlayList.Text = "Add to PlayList";
            // 
            // Favourite
            // 
            this.Favourite.Name = "Favourite";
            this.Favourite.Size = new System.Drawing.Size(177, 24);
            this.Favourite.Text = "Favourite";
            // 
            // Download
            // 
            this.Download.Name = "Download";
            this.Download.Size = new System.Drawing.Size(177, 24);
            this.Download.Text = "Download";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 542);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Author";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(25, 32);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 150);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // listView
            // 
            this.listView.BackColor = System.Drawing.Color.Black;
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Play,
            this.Song,
            this.Genre,
            this.Time,
            this.columnHeader1,
            this.File,
            this.URL});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.ForeColor = System.Drawing.Color.Silver;
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(279, 0);
            this.listView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(933, 542);
            this.listView.TabIndex = 6;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView_MouseUp_1);
            // 
            // Play
            // 
            this.Play.Text = "Play";
            this.Play.Width = 50;
            // 
            // Song
            // 
            this.Song.Text = "Song";
            this.Song.Width = 199;
            // 
            // Genre
            // 
            this.Genre.Text = "Genre";
            this.Genre.Width = 237;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 87;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 6;
            this.columnHeader1.Text = "Download";
            this.columnHeader1.Width = 140;
            // 
            // File
            // 
            this.File.DisplayIndex = 4;
            this.File.Text = "File";
            this.File.Width = 0;
            // 
            // URL
            // 
            this.URL.DisplayIndex = 5;
            this.URL.Width = 0;
            // 
            // AlbumDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 542);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AlbumDetail";
            this.Text = "AlbumDetail";
            this.Load += new System.EventHandler(this.AlbumDetail_Load);
            this.Menu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem AddToPlayList;
        private System.Windows.Forms.ToolStripMenuItem Favourite;
        private System.Windows.Forms.ToolStripMenuItem Download;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ListView listView;
        public System.Windows.Forms.ColumnHeader Play;
        public System.Windows.Forms.ColumnHeader Song;
        public System.Windows.Forms.ColumnHeader Genre;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader File;
        private System.Windows.Forms.ColumnHeader URL;
    }
}