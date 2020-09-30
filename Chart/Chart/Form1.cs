using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Chart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP;Initial Catalog=Dbo_FilmArsiv;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Film_adi,Film_puan from tbl_filmler",baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while(oku.Read())
            {
                chart1.Series["Filmler"].Points.AddXY(oku[0].ToString(),oku[1]);
            }
            baglanti.Close();
        }
    }
}
