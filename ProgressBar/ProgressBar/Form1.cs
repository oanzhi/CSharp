using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Visible=false;
        }
        private IDataParameter input;

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (Convert.ToInt32(textBox1.Text) >= progressBar1.Minimum && Convert.ToInt32(textBox1.Text) <= progressBar1.Maximum)
                {
                    progressBar1.Value = Convert.ToInt32(textBox1.Text);
                    pictureBox1.Visible = false;
                } else
                {
                    const string message = "Проверьте корректность вводимых данных";
                    const string caption = "Ошибка";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                }
            } catch(System.FormatException)
            {
                const string message = "Проверьте корректность вводимых данных";
                const string caption = "Ошибка";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           for (int i = 0; i <= progressBar1.Step; i++)
            {
                if (backgroundWorker1.CancellationPending == false)
                {

                    backgroundWorker1.ReportProgress(i++ *progressBar1.Maximum/progressBar1.Step);
                    Thread.Sleep(100);
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = true;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progressBar1.Update();
        }
    }
}
