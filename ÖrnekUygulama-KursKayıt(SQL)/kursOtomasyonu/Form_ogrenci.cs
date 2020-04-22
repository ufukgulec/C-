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
    public partial class Form_ogrenci : Form
    {
        public Form_ogrenci()
        {
            InitializeComponent();
        }
        SqlCommand komut = new SqlCommand();
        SqlConnection baglanti=new SqlConnection("Data Source=DESKTOP;Initial Catalog=KursDB;Integrated Security=True");
        
        public void Form_ogrenci_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kursDBDataSet.ogrenciler' table. You can move, or remove it, as needed.
            komut.CommandText = "select ogrenciID,ogrenciAdi,ogrenciSoyadi,veliAdi,ogrenciEposta,ogrenciTel,dogumTarihi, kayitTarihi from ogrenciler inner join veliler v on v.veliID=ogrenciler.veliID";
            komut.Connection = baglanti;
            DataTable dt = new DataTable();
            baglanti.Open();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Formogrenciekle ogrenciEkle = new Formogrenciekle();
            ogrenciEkle.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int ogrenciID;
        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from ogrenciler where ogrenciID="+ogrenciID,baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Silindi");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Formogrenciguncelleme ogrencıguncelleme = new Formogrenciguncelleme();
            ogrencıguncelleme.Show();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            komut.CommandText = "select ogrenciID,ogrenciAdi,ogrenciSoyadi,veliAdi,ogrenciEposta,ogrenciTel,dogumTarihi, kayitTarihi from ogrenciler inner join veliler v on v.veliID=ogrenciler.veliID";
            komut.Connection = baglanti;
            DataTable dt = new DataTable();
            baglanti.Open();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ogrenciID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            string ara = textBox1.Text.ToString();
            komut = new SqlCommand("select ogrenciID,ogrenciAdi,ogrenciSoyadi,veliAdi,ogrenciEposta,ogrenciTel,dogumTarihi, kayitTarihi from ogrenciler inner join veliler v on v.veliID=ogrenciler.veliID where ogrenciAdi='" + textBox1.Text.ToString() + "'", baglanti);
            DataTable dt = new DataTable();
            baglanti.Open();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView1.DataSource = dt;
        }
    }
}
