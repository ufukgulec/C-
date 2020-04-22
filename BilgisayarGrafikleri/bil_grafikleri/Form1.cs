using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace bil_grafikleri
{
    public partial class Form1 : Form
    {
        private bool invert = false;

        private int list;
        private float alfa = 0;
        private float beta = 0;
        private float gamma = 0;
        public Form1()
        {
            InitializeComponent();

            simpleOpenGlControl1.InitializeContexts();

            int height = simpleOpenGlControl1.Height;

            int width = simpleOpenGlControl1.Width;

            Gl.glEnable(Gl.GL_LIGHTING);

            Gl.glEnable(Gl.GL_LIGHT0);

            float[] light_pos = new float[3] { 1, 0.5F, 1 };

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light_pos);

            Gl.glEnable(Gl.GL_DEPTH_TEST);

            Gl.glClearColor(1,0,0,1);



            Gl.glViewport(0, 0, width, height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);

            Gl.glLoadIdentity();

            Glu.gluPerspective(45.0f, (double)width / (double)height, 0.01f, 5000.0f);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            create();
        }
        public void create()
        {

            Glu.GLUquadric quadratic = Glu.gluNewQuadric();

            Glu.gluQuadricNormals(quadratic, Glu.GLU_SMOOTH);

            Glu.gluQuadricDrawStyle(quadratic, Glu.GLU_LINE);

            Glu.gluQuadricOrientation(quadratic,
                 Glu.GLU_OUTSIDE);



            list = Gl.glGenLists(1);

            Gl.glNewList(list, Gl.GL_COMPILE);

            Glu.gluSphere(quadratic, 3, 32, 32);

            Gl.glEndList();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void myPaint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT |
                 Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glLoadIdentity();

            Glu.gluLookAt(5, 5, 5, 0, 0, 0, 0, 1, 0);



            Gl.glRotatef(alfa, 1, 0, 0);

            Gl.glRotatef(beta, 0, 1, 0);

            Gl.glRotatef(gamma, 0, 0, 1);

            Gl.glCallList(list);
        }

        private void buttonX_MouseClick(object sender, MouseEventArgs e)
        {
            if (invert) // Shift basılı ise ters döndür

                alfa -= 5;

            else

                alfa += 5;

            alfa = (alfa + 360) % 360; // Mod işlemi: 0-355

            labelX.Text = alfa.ToString();

            simpleOpenGlControl1.Refresh();
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                if (invert) // Shift basılı ise ters döndür

                    alfa -= 5;

                else

                    alfa += 5;

                alfa = (alfa + 360) % 360; // Mod işlemi: 0-355

                labelX.Text = alfa.ToString();

                simpleOpenGlControl1.Refresh();
            }
        }

        private void buttonY_MouseClick(object sender, MouseEventArgs e)
        {
            if (invert)

                beta -= 5;

            else

                beta += 5;
            
            beta = (beta + 360) % 360; // Mod işlemi: 0-355

            labelY.Text = beta.ToString();

            simpleOpenGlControl1.Refresh();
        }

        private void buttonZ_MouseClick(object sender, MouseEventArgs e)
        {
            if (invert)

                gamma -= 5;

            else

                gamma += 5;

            gamma = (gamma + 360) % 360; // Mod işlemi: 0-355

            labelZ.Text = gamma.ToString();

            simpleOpenGlControl1.Refresh();
        }

        private void buttonKeyDown(object sender, KeyEventArgs e)
        {
            invert = false;

            if (e.KeyCode == Keys.ShiftKey)

                invert = true;
        }

        private void buttonKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)

                invert = false;
        }
        private void myKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32)
                alfa += 5;
            if (alfa == 360)
                alfa = 0;
            labelAlfa.Text = alfa.ToString();
            Form1.ActiveForm.Refresh();
            simpleOpenGlControl1.Refresh();
        }
        


    }
}