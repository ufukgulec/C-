﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Projem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel5.Height = button1.Height;
            panel5.Top = button1.Top;
            ilkGiris1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel5.Height = button1.Height;
            panel5.Top = button1.Top;
            ilkGiris1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel5.Height = button2.Height;
            panel5.Top = button2.Top;
            menü1.BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
