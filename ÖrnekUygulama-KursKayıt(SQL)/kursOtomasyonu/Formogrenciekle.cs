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
    public partial class Formogrenciekle : Form
    {
        public Formogrenciekle()
        {
            InitializeComponent();
        }
        SqlCommand komut = new SqlCommand();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP;Initial Catalog=KursDB;Integrated Security=True");
        string isim = "", soyisim = "";
        int veliID;
        string veliAdi = "", veliSoyadi = "";
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut;
            baglanti.Open();
            komut = new SqlCommand("select ogrenciID,ogrenciAdi,ogrenciSoyadi from ogrenciler where ogrenciAdi='"+textBox1.Text.ToString()+"' and ogrenciSoyadi='"+textBox2.Text.ToString()+"'",baglanti);
            komut.ExecuteNonQuery();
            DataTable dt = new DataTable();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView1.DataSource = dt;

            baglanti.Open();
            komut = new SqlCommand("select veliID,veliAdi,veliSoyadi from veliler where veliAdi='"+textBox7.Text.ToString()+"' and veliSoyadi='"+textBox6.Text.ToString()+"'", baglanti);
            komut.ExecuteNonQuery();
            dt = new DataTable();
            dt.Load(komut.ExecuteReader());
            baglanti.Close();
            dataGridView2.DataSource = dt;
            if (textBox1.Text.ToString()==isim.ToString()&&textBox2.Text.ToString()==soyisim.ToString())
            {
                
                MessageBox.Show("eklemeye çalıştıgınız ogrenci zaten var");
            }
            else
            {
                if (textBox7.Text.ToString() == veliAdi.ToString() && textBox6.Text.ToString() == veliSoyadi.ToString())
                {
                    baglanti.Open();
                    komut = new SqlCommand("insert into ogrenciler(ogrenciAdi,ogrenciSoyadi,ogrenciEposta,ogrenciTel,dogumTarihi,veliID) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + DateTime.Parse(textBox5.Text.ToString()) + "','"+veliID + "')", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Var olan veli, öğrenci kayıdı yapılmıştır.");
                    this.Close();
                }
                else
                {
                    baglanti.Open();
                    komut = new SqlCommand("insert into veliler(veliAdi,veliSoyadi,veliTel)values('" + textBox7.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox8.Text.ToString() + "')", baglanti);
                    komut.ExecuteNonQuery();
                    komut = new SqlCommand("select veliID,veliAdi,veliSoyadi from veliler where veliAdi='" + textBox7.Text.ToString() + "' and veliSoyadi='" + textBox6.Text.ToString() + "'", baglanti);
                    komut.ExecuteNonQuery();
                    dt = new DataTable();
                    dt.Load(komut.ExecuteReader());
                    baglanti.Close();
                    dataGridView2.DataSource = dt;

                    
                    baglanti.Open();
                    komut = new SqlCommand("insert into ogrenciler(ogrenciAdi,ogrenciSoyadi,ogrenciEposta,ogrenciTel,dogumTarihi,veliID) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + DateTime.Parse(textBox5.Text.ToString()) + "','" + veliID + "')", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kayıt İşlemi Tamamlanmıştır.");
                    this.Close();
                }
            }
        }
      
      private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
      {
          isim = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value.ToString());
          soyisim = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value.ToString());
      }
      
      private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
      {
          veliID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
          veliAdi = Convert.ToString(dataGridView2.CurrentRow.Cells[1].Value.ToString());
          veliSoyadi = Convert.ToString(dataGridView2.CurrentRow.Cells[2].Value.ToString());
      }    
    }
}
