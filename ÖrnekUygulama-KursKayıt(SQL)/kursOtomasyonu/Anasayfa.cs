using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursOtomasyonu
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void button_ogrenci_Click(object sender, EventArgs e)
        {
            Form_ogrenci formogrenci = new Form_ogrenci();
            formogrenci.ShowDialog();

        }

        private void button_ogretmen_Click(object sender, EventArgs e)
        {
            Form_ogretmen formogretmen = new Form_ogretmen();
            formogretmen.ShowDialog();
        }

        private void button_ders_Click(object sender, EventArgs e)
        {
            Form_ders formders = new Form_ders();
            formders.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormDersSecim dersSecim = new FormDersSecim();
            dersSecim.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ogretmenler ogretmenler = new ogretmenler();
            ogretmenler.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dersler dersler = new dersler();
            dersler.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Formveliler veli = new Formveliler();
            veli.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }

       
    }
}
