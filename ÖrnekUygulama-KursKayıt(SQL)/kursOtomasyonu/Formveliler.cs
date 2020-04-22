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
    public partial class Formveliler : Form
    {
        public Formveliler()
        {
            InitializeComponent();
        }
        SqlCommand komut = new SqlCommand();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP;Initial Catalog=KursDB;Integrated Security=True");
        private void Formveliler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new SqlCommand("select * from veliler",baglanti);
            DataTable dt = new DataTable();
            dt.Load(komut.ExecuteReader());
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
    }
}
