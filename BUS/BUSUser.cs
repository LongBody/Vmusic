using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BUS
{
  public class BUSUser
    {
        public DataTable findIdUserByName(string query)
        {
            return (new DataProvider()).executeNonQuery(query);
        }

        public void addNewUser(string query)
        {
            (new DataProvider()).Excute(query);
        }
    }
}
