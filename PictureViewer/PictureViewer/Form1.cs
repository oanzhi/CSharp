using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            подогнатьРазмерToolStripMenuItem1 = подогнатьРазмерToolStripMenuItem;
            истинныйРазмерToolStripMenuItem1 = истинныйРазмерToolStripMenuItem;
            поЦентруToolStripMenuItem1 = поЦентруToolStripMenuItem;
            автоматическийРазмерToolStripMenuItem1 = автоматическийРазмерToolStripMenuItem;
            pictureBox1.ContextMenuStrip = contextMenuStrip1;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.OpenFile());
                toolStripStatusLabel1.Text = "Изображение: "+openFileDialog1.FileName;
                toolStripStatusLabel2.Text = String.Format("{0:#} x {1:#}", pictureBox1.Image.Width, pictureBox1.Image.Height);
                сохранитьToolStripMenuItem.Enabled = true;
                printToolStripMenuItem.Enabled = true;
                printPreToolStripMenuItem.Enabled = true;
                pageSetupToolStripMenuItem.Enabled=true;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "*.jpg|*.png";
            saveFileDialog1.Filter = "JPEG|*.jpg|PNG|*.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.ReadWrite);
                if (saveFileDialog1.Filter.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                {
                    Console.WriteLine(saveFileDialog1.Filter);
                }
                else
                {
                    pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);

                }

            }
        }

        private void printPreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(pictureBox1.Image, 50, 50,pictureBox1.Image.Width,pictureBox1.Image.Height);
            g.DrawString("Размер изображения: "+ String.Format("Width - {0:#}, Height - {1:#}\n", 
                pictureBox1.Image.Width, pictureBox1.Image.Height) + toolStripStatusLabel1.Text,
                this.Font,Brushes.Black,100,pictureBox1.Image.Width+100);
        }

        private void подогнатьРазмерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            истинныйРазмерToolStripMenuItem.Checked = false;
            поЦентруToolStripMenuItem.Checked= false;
            автоматическийРазмерToolStripMenuItem.Checked= false;
        }

        private void истинныйРазмерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            подогнатьРазмерToolStripMenuItem.Checked = false;
            поЦентруToolStripMenuItem.Checked = false;
            автоматическийРазмерToolStripMenuItem.Checked = false;
        }

        private void поЦентруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            подогнатьРазмерToolStripMenuItem.Checked = false;
            автоматическийРазмерToolStripMenuItem.Checked = false;
            истинныйРазмерToolStripMenuItem.Checked = false;
        }

        private void автоматическийРазмерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            подогнатьРазмерToolStripMenuItem.Checked = false;
            поЦентруToolStripMenuItem.Checked = false;
            истинныйРазмерToolStripMenuItem.Checked = false;
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.PageSettings= new PageSettings();
            this.pageSetupDialog1.PrinterSettings = this.printDocument1.PrinterSettings;
            if (pageSetupDialog1.ShowDialog(this) == DialogResult.OK)
            {
                printDocument1.PrinterSettings = pageSetupDialog1.PrinterSettings;
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog(this) == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void подогнатьРазмерToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            подогнатьРазмерToolStripMenuItem.Checked = true;
            подогнатьРазмерToolStripMenuItem_Click(sender, e);
        }

        private void истинныйРазмерToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            истинныйРазмерToolStripMenuItem.Checked = true;
            истинныйРазмерToolStripMenuItem_Click(sender, e);
        }

        private void поЦентруToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            поЦентруToolStripMenuItem.Checked = true;
            поЦентруToolStripMenuItem_Click(sender, e);
        }

        private void автоматическийРазмерToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            автоматическийРазмерToolStripMenuItem.Checked = true;
            автоматическийРазмерToolStripMenuItem_Click(sender, e);
        }
    }
}
