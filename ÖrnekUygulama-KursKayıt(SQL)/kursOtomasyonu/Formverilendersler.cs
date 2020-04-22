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
    public partial class Formverilendersler : Form
    {
        public Formverilendersler()
        {
            InitializeComponent();
        }
        SqlCommand komut = new SqlCommand();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP;Initial Catalog=KursDB;Integrated Security=True");
        private void Formverilendersler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new SqlCommand("select o.ogrenciID, ogrenciAdi,ogrenciSoyadi,d.dersID,dersAdi as AldığıDers from dersSecimleri ds inner join ogrenciler o on o.ogrenciID=ds.ogrenciID inner join dersler d on d.dersID=ds.dersID",baglanti);
            DataTable dt = new DataTable();
            dt.Load(komut.ExecuteReader());
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
    }
}
