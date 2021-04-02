using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BUS
{
    public class BUSFavourite
    {

        public DataTable findSongFavourite(int id, int userID)
        {
            return (new DataProvider()).executeNonQuery("Select * from Favourite where id = " + id +"and user_id = " + userID);
        }

        public DataTable findAllSongFavouriteByIdUser(int userID)
        {
            return (new DataProvider()).executeNonQuery("select * from song join artist on song.artist_id = artist.id join genre on song.genre_id = genre.id join favourite on favourite.id = song.id where favourite.user_id = " + userID) ;
        }

        public void removeSongFromFavourite(int id , int user_id)
        {
           (new DataProvider()).Excute("delete from favourite where id =  " + id + " and user_id = " +  user_id);
        }

        public DataTable findDetailSongWithID(int id)
        {
            return (new DataProvider()).executeNonQuery("select * from song join artist on song.artist_id = artist.id join genre on song.genre_id = genre.id where song.id = " + id) ;
        }

        public DataTable loadSongs(int user_id)
        {
            return (new DataProvider()).executeNonQuery("Select * from Favourite where user_id = " + user_id);
        }
        public void addFavourite(int id, int userID)
        {
           (new DataProvider()).Excute("Insert into Favourite values(" + id + " ," + userID + ")");
        }
    }
}
