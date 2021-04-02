using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAO;

namespace BUS
{
    public class BUSArtist
    {
        public DataTable loadArtist(string query)
        {
            return (new DataProvider()).executeNonQuery(query);
        }
    }
}
