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
    public partial class Formogretmenekle : Form
    {
        public Formogretmenekle()
        {
            InitializeComponent();
        }
        SqlCommand komut = new SqlCommand();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP;Initial Catalog=KursDB;Integrated Security=True");
        int did, aid;
        string isim = "", soyisim = "";
        private void Formogretmenekle_Load(object sender, EventArgs e)
        {   
            komut = new SqlCommand("select dersler.alanID,alanAdi,dersID,dersAdi from dersler inner join alanlar a on a.alanID=dersler.alanID",baglanti);
            baglanti.Open();
            DataTable dt = new DataTable();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView1.DataSource = dt;
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            aid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            did = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value);    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            komut = new SqlCommand("select ogretmenID, ogretmenAdi,ogretmenSoyadi from ogretmenler where ogretmenAdi='" + textBox1.Text.ToString() + "' and ogretmenSoyadi='" + textBox2.Text.ToString() + "'", baglanti);
            komut.ExecuteNonQuery();
            DataTable dt = new DataTable();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView2.DataSource = dt;

            if (textBox1.Text.ToString() == isim.ToString() && textBox2.Text.ToString() == soyisim.ToString())
            {
                MessageBox.Show("Eklemeye çalıştıgınız ogretmen zaten var");
            }
            else
            {
                baglanti.Open();
                komut = new SqlCommand("insert into ogretmenler (ogretmenAdi,ogretmenSoyadi,alanID,dersID) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + aid + "','" + did + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarılı");
                this.Close();
            }
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            isim = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            soyisim = dataGridView2.CurrentRow.Cells[2].Value.ToString();
        }

        
    }
}
