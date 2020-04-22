using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace kutuphane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlCommand komut = new SqlCommand();
        SqlConnection baglanti=new SqlConnection("Data Source=DESKTOP;Initial Catalog=kutuphane;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            komut.CommandText = "select kitap.id as No, kitap.ad as KitapAdı,yazarad as Yazarınadı, yazarsoyad as YazarınSoyadı, adi as KitabınTürü from kitap inner join türler t on kitap.turID=t.id inner join yazar y on kitap.yazarID=y.id";
            komut.Connection=baglanti;
            DataTable dt=new DataTable();
            baglanti.Open();
            dt.Load(komut.ExecuteReader());
            dataGridView1.DataSource=dt;
            //baglanti.Close();
            komut.CommandText = "select id, yazarad, yazarsoyad,kayitTarihi from yazar";
            komut.Connection = baglanti;
            DataTable d = new DataTable();
            d.Load(komut.ExecuteReader());
            //baglanti.Open();
            dataGridView2.DataSource = d;
            baglanti.Close();
        }
        int yazarID;
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            yazarID=Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            komut.CommandText="select ad, adi from kitap inner join türler t on kitap.turID=t.id where yazarID="+yazarID;
            komut.Connection = baglanti;
            DataTable dt = new DataTable();
            baglanti.Open();
            dt.Load(komut.ExecuteReader());
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
    }
}
