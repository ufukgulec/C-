using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace kursOtomasyonu
{
    public partial class ogretmenler : Form
    {
        public ogretmenler()
        {
            InitializeComponent();
        }
        SqlCommand komut = new SqlCommand();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP;Initial Catalog=KursDB;Integrated Security=True");
        private void ogretmenler_Load(object sender, EventArgs e)
        {
            komut.CommandText = "select ogretmenID,ogretmenAdi,ogretmenSoyadi,dersAdi from ogretmenler inner join dersler d on d.dersID=ogretmenler.dersID";
            komut.Connection = baglanti;
            DataTable dt = new DataTable();
            baglanti.Open();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView1.DataSource = dt;
        }
    }
}
