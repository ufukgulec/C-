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
    public partial class dersler : Form
    {
        public dersler()
        {
            InitializeComponent();
        }
        SqlCommand komut = new SqlCommand();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP;Initial Catalog=KursDB;Integrated Security=True");
        private void dersler_Load(object sender, EventArgs e)
        {
            komut.CommandText = "select dersID as DersID, dersAdi as DersAdı, dersler.alanID as DersAlanID,alanAdi as Kategori, ücret as DersÜcreti from dersler inner join alanlar a on a.alanID=dersler.alanID";
            komut.Connection = baglanti;
            DataTable dt = new DataTable();
            baglanti.Open();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView1.DataSource = dt;
        }
    }
}
