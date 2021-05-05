using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimatedWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

		public enum AnimateWindowFlags : int
		{
			AW_HOR_POSITIVE = 1,
			AW_HOR_NEGATIVE = 2,
			AW_VER_POSITIVE = 4,
			AW_VER_NEGATIVE = 8,
			AW_CENTER = 16,
			AW_HIDE = 65536,
			AW_ACTIVATE = 131072,
			AW_SLIDE = 262144,
			AW_BLEND = 524288
		};

		[DllImportAttribute("user32.dll", EntryPoint = "AnimateWindow", SetLastError = true)]
		public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

		public static bool AnimateWindow(Control ctrl, int dwTime, AnimateWindowFlags Flags)
		{
			return AnimateWindow(ctrl.Handle, dwTime, (int)Flags);
		}

		private void button1_Click(object sender, EventArgs e)
        {
			this.Visible = false;
			AnimateWindow(this, 2000, AnimateWindowFlags.AW_ACTIVATE | AnimateWindowFlags.AW_BLEND);
		}

		private void button2_Click(object sender, EventArgs e)
        {
			this.Visible = false;
			AnimateWindow(this, 2000,AnimateWindowFlags.AW_ACTIVATE| AnimateWindowFlags.AW_SLIDE|AnimateWindowFlags.AW_HOR_POSITIVE);
		}

        private void button3_Click(object sender, EventArgs e)
        {
			this.Visible = false;
			AnimateWindow(this, 2000, AnimateWindowFlags.AW_ACTIVATE | AnimateWindowFlags.AW_CENTER);
		}
    }
}
