using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemTray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
        }

        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(notifyIcon1, null);
            }
        }

        private void показатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            скрытьToolStripMenuItem.Enabled = true;
            показатьToolStripMenuItem.Enabled = false;
        }

        private void скрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            скрытьToolStripMenuItem.Enabled = false;
            показатьToolStripMenuItem.Enabled = true;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
        }
    }
}
