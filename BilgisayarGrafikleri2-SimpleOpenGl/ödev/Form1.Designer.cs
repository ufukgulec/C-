namespace ödev
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.simpleOpenGlControl1 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.buttonX = new System.Windows.Forms.Button();
            this.buttonY = new System.Windows.Forms.Button();
            this.buttonZ = new System.Windows.Forms.Button();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // simpleOpenGlControl1
            // 
            this.simpleOpenGlControl1.AccumBits = ((byte)(0));
            this.simpleOpenGlControl1.AutoCheckErrors = false;
            this.simpleOpenGlControl1.AutoFinish = false;
            this.simpleOpenGlControl1.AutoMakeCurrent = true;
            this.simpleOpenGlControl1.AutoSwapBuffers = true;
            this.simpleOpenGlControl1.BackColor = System.Drawing.Color.Black;
            this.simpleOpenGlControl1.ColorBits = ((byte)(32));
            this.simpleOpenGlControl1.DepthBits = ((byte)(16));
            this.simpleOpenGlControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simpleOpenGlControl1.Location = new System.Drawing.Point(0, 0);
            this.simpleOpenGlControl1.Name = "simpleOpenGlControl1";
            this.simpleOpenGlControl1.Size = new System.Drawing.Size(674, 266);
            this.simpleOpenGlControl1.StencilBits = ((byte)(0));
            this.simpleOpenGlControl1.TabIndex = 0;
            this.simpleOpenGlControl1.Click += new System.EventHandler(this.simpleOpenGlControl1_Click);
            this.simpleOpenGlControl1.DoubleClick += new System.EventHandler(this.simpleOpenGlControl1_DoubleClick);
            // 
            // buttonX
            // 
            this.buttonX.Location = new System.Drawing.Point(532, 12);
            this.buttonX.Name = "buttonX";
            this.buttonX.Size = new System.Drawing.Size(75, 23);
            this.buttonX.TabIndex = 1;
            this.buttonX.Text = "buttonX";
            this.buttonX.UseVisualStyleBackColor = true;
            this.buttonX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonKeyDown);
            this.buttonX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonKeyUp);
            this.buttonX.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonX_MouseClick);
            // 
            // buttonY
            // 
            this.buttonY.Location = new System.Drawing.Point(532, 41);
            this.buttonY.Name = "buttonY";
            this.buttonY.Size = new System.Drawing.Size(75, 23);
            this.buttonY.TabIndex = 2;
            this.buttonY.Text = "buttonY";
            this.buttonY.UseVisualStyleBackColor = true;
            this.buttonY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonKeyDown);
            this.buttonY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonKeyUp);
            this.buttonY.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonY_MouseClick);
            // 
            // buttonZ
            // 
            this.buttonZ.BackColor = System.Drawing.SystemColors.Control;
            this.buttonZ.Location = new System.Drawing.Point(532, 70);
            this.buttonZ.Name = "buttonZ";
            this.buttonZ.Size = new System.Drawing.Size(75, 23);
            this.buttonZ.TabIndex = 3;
            this.buttonZ.Text = "buttonZ";
            this.buttonZ.UseVisualStyleBackColor = false;
            this.buttonZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonKeyDown);
            this.buttonZ.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonKeyUp);
            this.buttonZ.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonZ_MouseClick);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(613, 17);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(13, 13);
            this.labelX.TabIndex = 4;
            this.labelX.Text = "0";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(613, 46);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(13, 13);
            this.labelY.TabIndex = 5;
            this.labelY.Text = "0";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(613, 75);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(13, 13);
            this.labelZ.TabIndex = 6;
            this.labelZ.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(532, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Obje değiştir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 266);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelZ);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.buttonZ);
            this.Controls.Add(this.buttonY);
            this.Controls.Add(this.buttonX);
            this.Controls.Add(this.simpleOpenGlControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.myPaint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl1;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Button buttonY;
        private System.Windows.Forms.Button buttonZ;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}

