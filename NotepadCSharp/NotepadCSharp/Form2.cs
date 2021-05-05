using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadCSharp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text= "Amount of symbols " + richTextBox1.Text.Length.ToString(CultureInfo.InvariantCulture);
            toolStripStatusLabel2.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text="Amount of symbols "+ richTextBox1.Text.Length.ToString(CultureInfo.InvariantCulture); 
        }

    }
}
