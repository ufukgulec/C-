using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
namespace GazeteBasliklari_RSS_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        XmlTextReader XmlTextReader = new XmlTextReader("http://www.hurriyet.com.tr/rss/spor");
        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = button1.Text.ToString();
            while (XmlTextReader.Read())
            {
                if (XmlTextReader.Name == "title")
                {
                        listBox1.Items.Add(XmlTextReader.ReadString());
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
