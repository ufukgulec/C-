using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace VeriTabaninaResimEkleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti=new SqlConnection(@"Data Source=DESKTOP\;Initial Catalog=Dbo_kayit;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into kayitTablosu(adi, soyadi, resim) values (@p1,@p2,@p3)",baglanti);
            komut.Parameters.AddWithValue("@p1",text_ad.Text);
            komut.Parameters.AddWithValue("@p2", text_soyad.Text);
            komut.Parameters.AddWithValue("@p3", text_resim.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ekleme başarılı...");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            text_resim.Text = openFileDialog1.FileName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbo_kayitDataSet.kayitTablosu' table. You can move, or remove it, as needed.
            this.kayitTablosuTableAdapter.Fill(this.dbo_kayitDataSet.kayitTablosu);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adaptor = new SqlDataAdapter("Select * from kayitTablosu", baglanti);
            DataSet ds = new DataSet();
            adaptor.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = false;
            text_ad.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
            text_soyad.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
            text_resim.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            text_ad.Clear();
            text_soyad.Clear();
            text_resim.Clear();
        }
    }
}
