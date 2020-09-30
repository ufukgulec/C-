using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ConnectionStringClass
{
    class SqlBaglantisi
    {
        public SqlConnection baglanti() {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP;Initial Catalog=kutuphane;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}