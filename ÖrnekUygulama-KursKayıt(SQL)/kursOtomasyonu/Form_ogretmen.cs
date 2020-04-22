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
    public partial class Form_ogretmen : Form
    {
        public Form_ogretmen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlCommand komut = new SqlCommand();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP;Initial Catalog=KursDB;Integrated Security=True");
        private void Form_ogretmen_Load(object sender, EventArgs e)
        {
            komut.CommandText = "select ogretmenID,ogretmenAdi,ogretmenSoyadi,dersAdi,kayitTarihi from ogretmenler inner join dersler d on d.dersID=ogretmenler.dersID";
            komut.Connection = baglanti;
            DataTable dt = new DataTable();
            baglanti.Open();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Formogretmenekle ogretmenekle = new Formogretmenekle();
            ogretmenekle.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            komut.CommandText = "select ogretmenID,ogretmenAdi,ogretmenSoyadi,dersAdi,kayitTarihi from ogretmenler inner join dersler d on d.dersID=ogretmenler.dersID";
            komut.Connection = baglanti;
            DataTable dt = new DataTable();
            baglanti.Open();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from ogretmenler where ogretmenID=" + ogid, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğretmen Silindi");
        }
        int ogid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ogid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Formogretmenguncelleme og = new Formogretmenguncelleme();
            og.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string ara = textBox1.Text.ToString();
            komut = new SqlCommand("select ogretmenID,ogretmenAdi,ogretmenSoyadi,dersAdi,kayitTarihi from ogretmenler inner join dersler d on d.dersID=ogretmenler.dersID where ogretmenAdi='" + textBox1.Text.ToString() + "'", baglanti);
            DataTable dt = new DataTable();
            baglanti.Open();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView1.DataSource = dt;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
