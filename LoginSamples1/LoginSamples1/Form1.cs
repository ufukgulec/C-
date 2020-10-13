using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginSamples1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            renkDegisim(textBox1, panel1);
        }
        private void textBox2_Click(object sender, EventArgs e)
        {
            renkDegisim(textBox2, panel2);
        }
        private void textBox3_Click(object sender, EventArgs e)
        {
            renkDegisim(textBox3, panel3);
        }
        private void renkDegisim(TextBox txt, Panel pnl) 
        {
            textBox1.ForeColor = Color.White;
            panel1.BackColor = Color.White;
            textBox2.ForeColor = Color.White;
            panel2.BackColor = Color.White;
            textBox3.ForeColor = Color.White;
            panel3.BackColor = Color.White;
            txt.Clear();
            txt.ForeColor = Color.FromArgb(142, 223, 218);
            pnl.BackColor = Color.FromArgb(142, 223, 218);
                

        }
        Form2 giris;
        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            giris = new Form2();
            giris.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            giris.Left += 10;
            if (giris.Left>=810)
            {
                timer1.Stop();
                this.TopMost = false;
                giris.TopMost = true;
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            giris.Left -= 10;
            if (giris.Left<=560)
            {
                timer2.Stop();
            }
        }
    }
}
