using System;
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
    public partial class Form2 : Form
    {
        Form1 form1;
        int penwidth;
        Boolean updown = false;
        public Form2(Form1 fp)
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
            form1 = fp;
            penwidth = form1.getPenWidth();
            numericUpDown1.Value = penwidth;
            trackBar1.Value = penwidth;
            label2.Height = penwidth;
            label2.BackColor = form1.getColor();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = Convert.ToInt32(numericUpDown1.Value);
            label2.Height = Convert.ToInt32(numericUpDown1.Value);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = Convert.ToInt32(trackBar1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.setPenWidth( Convert.ToInt32(numericUpDown1.Value)) ;
        }

        private void label2_ClientSizeChanged(object sender, EventArgs e)
        {
            label2.Top = 60 - label2.Height / 2;
        }
    }
}
