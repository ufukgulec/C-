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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            renkDegisim(textBox1, panel1);
        }
        private void textBox2_Click(object sender, EventArgs e)
        {
            renkDegisim(textBox2, panel2);
        }
        private void renkDegisim(TextBox txt, Panel pnl)
        {
            textBox1.ForeColor = Color.White;
            panel1.BackColor = Color.White;
            textBox2.ForeColor = Color.White;
            panel2.BackColor = Color.White;
            txt.Clear();
            txt.ForeColor = Color.FromArgb(142, 223, 218);
            pnl.BackColor = Color.FromArgb(142, 223, 218);


        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Left += 10;
            if (this.Left >= 810)
            {
                timer1.Stop();
                timer2.Start();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Left -= 10;
            if (this.Left <= 760)
            {
                this.SendToBack();
                timer2.Stop();
            }
        }
    }
}
