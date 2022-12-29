using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Graphics g = this.panel1.CreateGraphics();
            Pen p = new Pen(Color.Blue, 3);

            Rectangle rec = new Rectangle(10, 10, 100, 20);
            g.DrawRectangle(p, rec);

        }
    }
}
