using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BUS
{
   public class BUSPlaylist
    {
        public DataTable loadPlaylist(string query)
        {
            return (new DataProvider()).executeNonQuery(query);
        }

        public void addToPlayList(int song , int user_id , string title)
        {
            (new DataProvider()).Excute("Insert into playlist values(" + song + " ," + user_id + " , N'" + title + "')");
        }

        public void RemoveSongFromPlayList(int song, int user_id, string title)
        {
            (new DataProvider()).Excute("delete from playlist where song_id = " + song + " and user_id =  " + user_id + " and title = N'" + title + "'" );
        }

        public void Remove(string query)
        {
            (new DataProvider()).Excute(query);
        }

        public DataTable checkSongExistPlaylist(int song, int user_id, string title)
        {
            return (new DataProvider()).executeNonQuery("select * from playlist where song_id = " + song + " and user_id = " + user_id + " and title = N'"  + title + "'");
        }
    }
}
