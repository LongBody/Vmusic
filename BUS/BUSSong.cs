using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAO;

namespace BUS
{
   public class BUSSong
    {
        public DataTable loadSongs()
        {
            return (new DataProvider()).executeNonQuery("select * from song join artist on song.artist_id = artist.id join genre on song.genre_id = genre.id");
        }

        public DataTable loadLyrics(string query)
        {
            return (new DataProvider()).executeNonQuery(query);
        }

        public DataTable loadSongWithArtist(string author)
        {
            return (new DataProvider()).executeNonQuery("select * from song join artist on song.artist_id = artist.id join genre on song.genre_id = genre.id where artist.author = N'" +author +"'");
        }

        public DataTable loadSongWithGenre(string gen)
        {
            return (new DataProvider()).executeNonQuery("select * from song join artist on song.artist_id = artist.id join genre on song.genre_id = genre.id where genre.genre = N'" + gen + "'");
        }

        public void updateViewSongs(int id)
        {
            new DataProvider().Excute("UPDATE song SET viewed = viewed + 1 WHERE id = " + id);
        }

        public void updateLink(string query)
        {
            new DataProvider().Excute(query);
        }


        public DataTable findIdSong(string name)
        {
            return (new DataProvider()).executeNonQuery("select id from song where title = N'" +  name +"'");
        }

        public DataTable loadSongsMostListen()
        {
            return (new DataProvider()).executeNonQuery("select * from song join artist on song.artist_id = artist.id join genre on song.genre_id = genre.id order by song.viewed desc");
        }

        public DataTable searchSongs(string txt)
        {
            string query = "select * from song join artist on song.artist_id = artist.id join genre on song.genre_id = genre.id where song.title like N'%" + txt + "%' or song.keySearch like N'%" + txt + "%'";
            return (new DataProvider()).executeNonQuery(query);
        }
    }
}
