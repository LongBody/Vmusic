using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BUS
{
   public class BUSMusicLocal
    {
        public DataTable loadMusicLocal(string query)
        {
            return (new DataProvider()).executeNonQuery(query);
        }

        public void Excute(string query)
        {
            (new DataProvider()).Excute(query);
        }

    }
}
