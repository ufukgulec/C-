using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        double D_benzin = 0, D_dizel = 0, D_lpg = 0;
        double E_benzin = 0, E_dizel = 0, E_lpg = 0;
        double F_benzin = 0, F_dizel = 0, F_lpg = 0;
        double S_benzin = 0, S_dizel = 0, S_lpg = 0;
        string[] depo, fiyat;
        private void txt_depo_oku() 
        {
            depo = System.IO.File.ReadAllLines(Application.StartupPath + "\\depo.txt");
            D_benzin = Convert.ToDouble(depo[0]);
            D_dizel = Convert.ToDouble(depo[1]);
            D_lpg = Convert.ToDouble(depo[2]);
        }
        private void txt_depo_yaz() 
        {
            label4.Text = D_benzin.ToString("N")+" Litre";
            label5.Text = D_dizel.ToString("N") + " Litre";
            label6.Text = D_lpg.ToString("N") + " Litre";
        }
        private void txt_fiyat_oku()
        {
            fiyat = System.IO.File.ReadAllLines(Application.StartupPath + "\\fiyat.txt");
            F_benzin = Convert.ToDouble(fiyat[0]);
            F_dizel = Convert.ToDouble(fiyat[1]);
            F_lpg = Convert.ToDouble(fiyat[2]);
        }
        private void txt_fiyat_yaz()
        {
            label9.Text = F_benzin.ToString("N")+" ₺";
            label8.Text = F_dizel.ToString("N") + " ₺";
            label7.Text = F_lpg.ToString("N") + " ₺";
        }
        private void progressBar() {
            progressBar1.Maximum = 1000;
            progressBar1.Value = Convert.ToInt16(D_benzin);
            progressBar2.Maximum = 1000;
            progressBar2.Value = Convert.ToInt16(D_dizel);
            progressBar3.Maximum = 1000;
            progressBar3.Value = Convert.ToInt16(D_lpg);
        }
        private void numericUpDown() { 
        numericUpDown1.Maximum=decimal.Parse(D_benzin.ToString());
        numericUpDown1.DecimalPlaces = 2;
        numericUpDown2.Maximum = decimal.Parse(D_dizel.ToString());
        numericUpDown2.DecimalPlaces = 2;
        numericUpDown3.Maximum = decimal.Parse(D_lpg.ToString());
        numericUpDown3.DecimalPlaces = 2;

            numericUpDown1.Increment=0.1M;
            numericUpDown1.ReadOnly = true;
            numericUpDown2.Increment = 0.1M;
            numericUpDown2.ReadOnly = true;
            numericUpDown3.Increment = 0.1M;
            numericUpDown3.ReadOnly = true;
        }
        private void comboBox() 
        {
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            string[] yakitTür = { "Benzin", "Dizel", "Lpg" };
            comboBox1.Items.AddRange(yakitTür);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txt_depo_oku();
            txt_depo_yaz();
            txt_fiyat_oku();
            txt_fiyat_yaz();
            progressBar();
            numericUpDown();
            comboBox();
        }
        private void kontrol(double E_yakit,double D_yakit,TextBox t,int a) 
        {
            try
            {
                E_yakit = Convert.ToDouble(t.Text);
                if (1000 < D_yakit+ E_yakit|| E_yakit<= 0)
                    t.Text = "Hata!";
                else
                    depo[a] = Convert.ToString(D_yakit+ E_yakit);
            }
            catch (Exception)
            {
                t.Text = "Hata!";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            kontrol(E_benzin,D_benzin,textBox1,0);
            kontrol(E_dizel, D_dizel,textBox2,1);
            kontrol(E_lpg, D_lpg,textBox3,2);

            System.IO.File.WriteAllLines(Application.StartupPath + "\\depo.txt", depo); 
            txt_depo_oku();
            txt_depo_yaz();
            progressBar();
            numericUpDown();
        }
        private void zamYap(double F_yakit,int a, TextBox t)
        {
            try
            {
                F_yakit = F_yakit + (F_yakit * Convert.ToDouble(t.Text) / 100);
                fiyat[a] = Convert.ToString(F_yakit);
                t.Clear();
            }
            catch (Exception)
            {
                t.Text = "Hata";
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            zamYap(F_benzin,0,textBox6);
            zamYap(F_dizel, 1, textBox5);
            zamYap(F_lpg, 2, textBox4);
            System.IO.File.WriteAllLines(Application.StartupPath + "\\fiyat.txt", fiyat);
            txt_fiyat_oku();
            txt_fiyat_yaz();
        }
        private void numericAyar(NumericUpDown nm) 
        {
            numericUpDown1.Enabled = false;
            numericUpDown1.Value = 0;
            numericUpDown2.Enabled = false;
            numericUpDown2.Value = 0;
            numericUpDown3.Enabled = false;
            numericUpDown3.Value = 0;
            nm.Enabled = true;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                numericAyar(numericUpDown1);
            }
            else if (comboBox1.SelectedIndex == 1)
                numericAyar(numericUpDown2);
            else if (comboBox1.SelectedIndex == 2)
                numericAyar(numericUpDown3);
        }
        private void satisYap(double S_yakit,NumericUpDown nm,double D_yakit,double F_yakit,int a) {
            S_yakit = double.Parse(nm.Value.ToString());
            if (nm.Enabled == true) {
                D_yakit = D_yakit - S_yakit;
                label13.Text = "Ödeyeceğiniz tutar: " + (S_yakit * F_yakit)+" ₺";
                depo[a] = Convert.ToString(D_yakit);
                nm.Value = 0;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            satisYap(S_benzin,numericUpDown1,D_benzin,F_benzin,0);
            satisYap(S_dizel, numericUpDown2,D_dizel,F_dizel,1);
            satisYap(S_lpg, numericUpDown3, D_lpg, F_lpg,2);
            System.IO.File.WriteAllLines(Application.StartupPath + "\\depo.txt", depo);
            txt_depo_oku();
            txt_depo_yaz();
            progressBar();
            numericUpDown();
        }
    }
}
