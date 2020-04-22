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
    public partial class Formdersekle : Form
    {
        public Formdersekle()
        {
            InitializeComponent();
        }
        SqlCommand komut = new SqlCommand();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP;Initial Catalog=KursDB;Integrated Security=True");
        int aid;
        private void Formdersekle_Load(object sender, EventArgs e)
        {   
            baglanti.Open();
            komut = new SqlCommand("select alanID as ID, alanAdi as AlanAdı from alanlar",baglanti);
            DataTable dt = new DataTable();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView1.DataSource=dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            aid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        }
        string ders = "";
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new SqlCommand("select dersID, dersAdi from dersler where dersAdi='" + textBox1.Text.ToString() + "'", baglanti);
            komut.ExecuteNonQuery();
            DataTable dt = new DataTable();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView2.DataSource = dt;

            if (textBox1.Text.ToString() == ders.ToString())
            {
                MessageBox.Show("Eklemeye çalıştıgınız ders zaten var");
            }
            else {
                baglanti.Open();
                komut = new SqlCommand("insert into dersler (dersAdi,alanID,ücret) values ('" + textBox1.Text.ToString() + "','" + aid + "','" + Convert.ToInt32(textBox2.Text.ToString()) + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarılı");
                this.Close();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ders = Convert.ToString(dataGridView2.CurrentRow.Cells[1].Value.ToString());
        }
    }
}
