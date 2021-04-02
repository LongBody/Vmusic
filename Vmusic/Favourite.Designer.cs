
namespace Vmusic
{
    partial class Favourite
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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Download = new System.Windows.Forms.ToolStripMenuItem();
            this.listView = new System.Windows.Forms.ListView();
            this.Play = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Song = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Genre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.URL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToPlayList,
            this.toolStripMenuItem1,
            this.Download});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(154, 70);
            this.Menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Menu_ItemClicked_1);
            // 
            // AddToPlayList
            // 
            this.AddToPlayList.Name = "AddToPlayList";
            this.AddToPlayList.Size = new System.Drawing.Size(153, 22);
            this.AddToPlayList.Text = "Add to PlayList";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem1.Text = "Delete";
            // 
            // Download
            // 
            this.Download.Name = "Download";
            this.Download.Size = new System.Drawing.Size(153, 22);
            this.Download.Text = "Download";
            // 
            // listView
            // 
            this.listView.BackColor = System.Drawing.Color.Black;
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Play,
            this.Song,
            this.Author,
            this.Genre,
            this.Time,
            this.columnHeader1,
            this.File,
            this.URL});
            this.listView.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.ForeColor = System.Drawing.Color.Silver;
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(909, 479);
            this.listView.TabIndex = 4;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView_MouseUp);
            // 
            // Play
            // 
            this.Play.Text = "Play";
            this.Play.Width = 50;
            // 
            // Song
            // 
            this.Song.Text = "Song";
            this.Song.Width = 240;
            // 
            // Author
            // 
            this.Author.Text = "Author";
            this.Author.Width = 240;
            // 
            // Genre
            // 
            this.Genre.Text = "Genre";
            this.Genre.Width = 205;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 65;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Download";
            this.columnHeader1.Width = 105;
            // 
            // File
            // 
            this.File.Text = "File";
            this.File.Width = 0;
            // 
            // URL
            // 
            this.URL.Width = 0;
            // 
            // Favourite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 440);
            this.Controls.Add(this.listView);
            this.Name = "Favourite";
            this.Text = "Favourite";
            this.Load += new System.EventHandler(this.Favourite_Load);
            this.Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem AddToPlayList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Download;
        public System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader Play;
        private System.Windows.Forms.ColumnHeader Song;
        private System.Windows.Forms.ColumnHeader Author;
        private System.Windows.Forms.ColumnHeader Genre;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader File;
        private System.Windows.Forms.ColumnHeader URL;
    }
}