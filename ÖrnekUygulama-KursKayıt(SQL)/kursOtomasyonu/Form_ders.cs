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
    public partial class Form_ders : Form
    {
        public Form_ders()
        {
            InitializeComponent();
        }
        SqlCommand komut = new SqlCommand();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP;Initial Catalog=KursDB;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form_ders_Load(object sender, EventArgs e)
        {
            komut.CommandText = "select dersID as DersID, dersAdi as DersAdı, dersler.alanID as DersAlanı,alanAdi as Kategori, ücret as DersÜcreti from dersler inner join alanlar a on a.alanID=dersler.alanID";
            komut.Connection = baglanti;
            DataTable dt = new DataTable();
            baglanti.Open();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Formdersekle ders = new Formdersekle();
            ders.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            komut.CommandText = "select dersID as DersID, dersAdi as DersAdı, dersler.alanID as DersAlanı,alanAdi as Kategori, ücret as DersÜcreti from dersler inner join alanlar a on a.alanID=dersler.alanID";
            komut.Connection = baglanti;
            DataTable dt = new DataTable();
            baglanti.Open();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string ara = textBox1.Text.ToString();
            komut = new SqlCommand("select dersID as DersID, dersAdi as DersAdı, dersler.alanID as DersAlanı,alanAdi as Kategori, ücret as DersÜcreti from dersler inner join alanlar a on a.alanID=dersler.alanID where dersAdi='" + textBox1.Text.ToString() + "'", baglanti);
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

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from dersler where dersID=" + dersID, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ders Silindi");
        }
        int dersID;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dersID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        }
    }
}
