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

namespace MessageBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr handle, string text, string title, uint type);

		public enum MessageBoxType : int
		{
			/// Три кнопки - Abort, Retry, Ignore
			MB_ABORTRETRYIGNORE = 2,
			/// Три кнопки - Cancel, Try, Continue
			MB_CANCELTRYCONTINUE = 6,
			/// Одна кнопка - Ok.
			MB_OK = 0,
			/// Две кнопки - Ok, Cancel.
			MB_OKCANCEL = 1,
			/// Две кнопки - Retry, Cancel
			MB_RETRYCANCEL = 5,
			/// Две кнопки - Yes, No
			MB_YESNO = 4,
			///  Три кнопки - Yes, No, Cancel
			MB_YESNOCANCEL = 3,
			/// Иконка - восклицание
			MB_ICONEXCLAMATION = 0x30,
			/// Иконка - предупреждение
			MB_ICONWARNING = 0x30,
			/// Иконка - информация
			MB_ICONINFORMATION = 0x40,
			/// Иконка - вопрос
			MB_ICONQUESTION = 0x20,
			/// Иконка - стоп
			MB_ICONSTOP = 0x10,
			/// Иконка - ошибка
			MB_ICONERROR = 0x10,
		}

		public enum MessageBoxReturnType : int
		{
			IDABORT = 3,
			IDCANCEL = 2,
			IDCONTINUE = 11,
			IDIGNORE = 5,
			IDNO = 7,
			IDOK = 1,
			IDRETRY = 4,
			IDTRYAGAIN = 10,
			IDYES = 6
		}
		private void button1_Click(object sender, EventArgs e)
        {
			MessageBox(this.Handle, "Hello world", "From WinApi", (int)MessageBoxType.MB_ICONQUESTION | (int)MessageBoxType.MB_ABORTRETRYIGNORE);
        }

        private void button2_Click(object sender, EventArgs e)
        {
			MessageBox(this.Handle,"Hello world","Form WinApi",(int)MessageBoxType.MB_YESNOCANCEL|(int)MessageBoxType.MB_ICONINFORMATION);
        }

        private void button3_Click(object sender, EventArgs e)
        {
			MessageBox(this.Handle, "Hello world", "Form WinApi", (int)MessageBoxType.MB_OK | (int)MessageBoxType.MB_ICONERROR);
		}

		private void button4_Click(object sender, EventArgs e)
        {
			MessageBox(this.Handle, "Hello world", "Form WinApi", (int)MessageBoxType.MB_YESNO | (int)MessageBoxType.MB_ICONWARNING);
		}
	}
}
