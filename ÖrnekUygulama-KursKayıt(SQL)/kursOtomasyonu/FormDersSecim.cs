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
    
    public partial class FormDersSecim : Form
    {
        SqlCommand komut=new SqlCommand();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP;Initial Catalog=KursDB;Integrated Security=True");
        int ogrenciID, dersID;
        public FormDersSecim()
        {
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void FormDersSecim_Load(object sender, EventArgs e)
        {
            komut.CommandText = "select ogrenciID,ogrenciAdi,ogrenciSoyadi from ogrenciler";
            komut.Connection = baglanti;
            DataTable dt = new DataTable();
            baglanti.Open();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView1.DataSource = dt;
           
            komut.CommandText = "select dersler.dersID,dersAdi,ogretmenAdi from dersler inner join ogretmenler o on o.dersID=dersler.dersID";
            komut.Connection = baglanti;
            dt = new DataTable();
            baglanti.Open();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView2.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string ara = textBox1.Text.ToString();
            komut = new SqlCommand("select ogrenciID, ogrenciAdi, ogrenciSoyadi from ogrenciler where ogrenciAdi='" + textBox1.Text.ToString() + "'", baglanti);
            DataTable dt = new DataTable();
            baglanti.Open();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ara = textBox1.Text.ToString();
            komut = new SqlCommand("select dersler.dersID,dersAdi,ogretmenAdi from dersler inner join ogretmenler o on o.dersID=dersler.dersID where dersAdi='" + textBox2.Text.ToString() + "'", baglanti);
            DataTable dt = new DataTable();
            baglanti.Open();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView2.DataSource = dt;
        }

        private void textBox1_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Click_1(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new SqlCommand("insert into dersSecimleri (ogrenciID,dersID)values ('"+ogrenciID+"','"+dersID+"')",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarılı");
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ogrenciID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dersID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Formverilendersler verilen = new Formverilendersler();
            verilen.ShowDialog();
        }

      

       
    }
}
