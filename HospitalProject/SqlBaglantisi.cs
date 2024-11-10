using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HospitalProject
{
    internal class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-83L42UFV\\SQLEXPRESS;Initial Catalog=HastaneProjeDb;Integrated Security=True;Encrypt=False");
            baglan.Open();
            return baglan;
        }

    }
}
