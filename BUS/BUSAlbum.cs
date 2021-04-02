using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BUS
{
  public class BUSAlbum
    {
        public DataTable loadAlbum(string query)
        {
            return (new DataProvider()).executeNonQuery(query);
        }
    }
}
