using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintSimple
{
    public partial class Form1 : Form
    {
        Boolean b = false;
        Pen pen;
        ArrayList points = new ArrayList();
        int penwidth = 1;
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(this.ForeColor);
            try
            {
                this.Cursor = new Cursor("PENCIL.CUR");
            } catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int getPenWidth()
        {
            return Convert.ToInt32(penwidth);
        }

        public void setPenWidth(int w)
        {
            penwidth = w;
        }
        public Color getColor()
        {
            return pen.Color;
        }
        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog(this)==DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                b = true;
                points.Clear();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            b = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (b)
            {
                Point pt = new Point(e.X, e.Y);
                points.Add(pt);

                if (points.Count <= 1)
                {
                    return;
                }

                Point[] pts = new Point[points.Count];
                points.CopyTo(pts, 0);

                Graphics graphics = this.CreateGraphics();
                graphics.DrawCurve(pen, pts);
            }
        }

        private void толщинаЛинииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(this);
            form.Owner = this;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                pen.Width = penwidth;
            };
            
        }
    }
}
