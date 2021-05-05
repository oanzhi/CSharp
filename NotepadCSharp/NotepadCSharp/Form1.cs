using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadCSharp
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr handle, string text, string title, uint type);
        public enum MessageBoxType : int
        {
            /// <summary>
            /// Три кнопки - Abort, Retry, Ignore
            /// </summary>
            MB_ABORTRETRYIGNORE = 2,
            /// <summary>
            /// Три кнопки - Cancel, Try, Continue
            /// </summary>
            MB_CANCELTRYCONTINUE = 6,
            /// <summary>
            /// Одна кнопка - Ok.
            /// </summary>
            MB_OK = 0,
            /// <summary>
            /// Две кнопки - Ok, Cancel.
            /// </summary>
            MB_OKCANCEL = 1,
            /// <summary>
            /// Две кнопки - Retry, Cancel
            /// </summary>
            MB_RETRYCANCEL = 5,
            /// <summary>
            /// Две кнопки - Yes, No
            /// </summary>
            MB_YESNO = 4,
            /// <summary>
            ///  Три кнопки - Yes, No, Cancel
            /// </summary>
            MB_YESNOCANCEL = 3,
            /// <summary>
            /// Иконка - восклицание
            /// </summary>
            MB_ICONEXCLAMATION = 0x30,
            /// <summary>
            /// Иконка - предупреждение
            /// </summary>
            MB_ICONWARNING = 0x30,
            /// <summary>
            /// Иконка - информация
            /// </summary>
            MB_ICONINFORMATION = 0x40,
            /// <summary>
            /// Иконка - вопрос
            /// </summary>
            MB_ICONQUESTION = 0x20,
            /// <summary>
            /// Иконка - стоп
            /// </summary>
            MB_ICONSTOP = 0x10,
            /// <summary>
            /// Иконка - ошибка
            /// </summary>
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
        
        int itemscount=0;
        Form4 f4 ;
        public Form1()
        {
            InitializeComponent();
            this.MdiChildActivate += new System.EventHandler(this.Form2_Activated);
        }

        private void Form2_Closed(object sender, EventArgs e)
        {
            Form2 f2 = sender as Form2;
            if(!f2.Text.Substring(0,9).Equals("Untitled "))
            {
                int res = MessageBox(this.Handle, "Do you want to save changes in "+f2.Text+"?", "Message", (int)MessageBoxType.MB_YESNO | (int)MessageBoxType.MB_ICONQUESTION);
                if (res == (int)MessageBoxReturnType.IDYES)
                {
                    saveToolStripMenuItem_Click(sender,e);
                }
            }
            foreach (ToolStripMenuItem tool in arrangeIconsToolStripMenuItem.DropDownItems)
            {
                if (tool.Text.Equals(f2.Text))
                {
                    tool.Dispose();
                    break;
                }
            }
            if (this.MdiChildren.Length == 1)
            {
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                pasteToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                selectAllToolStripMenuItem.Enabled = false;
                findToolStripMenuItem.Enabled = false;
                fontToolStripMenuItem.Enabled = false;
                colorToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                toolStripButton3.Enabled = false;
                toolStripButton4.Enabled = false;
                toolStripButton5.Enabled = false;
                toolStripButton6.Enabled = false;
            }
        }
        private Form2 create_Form2(String str)
        {
            itemscount++;
            Form2 f2 = new Form2();
            f2.Text = str;
            f2.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_Closed);
            f2.MdiParent = this;
            f2.Show();
            f2.WindowState = FormWindowState.Maximized;
            ToolStripMenuItem tool = new ToolStripMenuItem(str);
            tool.Checked = true; 
            tool.Click += new EventHandler(this.ToolStripMenuItem_Checked);
            arrangeIconsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tool });
            cutToolStripMenuItem.Enabled=true;
            copyToolStripMenuItem.Enabled = true;
            pasteToolStripMenuItem.Enabled = true;
            deleteToolStripMenuItem.Enabled = true;
            selectAllToolStripMenuItem.Enabled = true;
            findToolStripMenuItem.Enabled = true;
            fontToolStripMenuItem.Enabled = true;
            colorToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            toolStripButton4.Enabled = true;
            toolStripButton5.Enabled = true;
            toolStripButton6.Enabled = true;
            return f2;
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
                foreach (ToolStripMenuItem tool in arrangeIconsToolStripMenuItem.DropDownItems)
                {
                    if (tool.Text.Equals(this.ActiveMdiChild.Text))
                    {
                        tool.Checked = true;
                    }
                    else
                    {
                        tool.Checked = false;
                    }
                }
        }
        private void ToolStripMenuItem_Checked(object sender, EventArgs e)
        {
                ToolStripMenuItem t = (ToolStripMenuItem)sender;
                t.Checked = true;
                foreach (Form2 f2 in this.MdiChildren)
                {
                    if (t.Text.Equals(f2.Text)) f2.Activate();
                }

        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String str = "Untitled "+(itemscount+1);
            create_Form2(str);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = this.ActiveMdiChild as Form2;
            if (!f2.Text.Substring(0,9).Equals("Untitled ")) {
                int a = f2.Text.Length - 4;
                if (f2.Text.Substring(a, 4).Equals(".txt"))
                {
                    String content = f2.richTextBox1.Text;
                    UTF8Encoding utf8 = new UTF8Encoding();
                    StreamWriter sw = new StreamWriter(f2.Text, false, utf8);
                    sw.Write(content);
                    sw.Close();
                }
                else
                {
                    f2.richTextBox1.SaveFile(f2.Text);
                }
            };
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                Form2 f2 = this.ActiveMdiChild as Form2;
                String first = f2.Text;
                Console.WriteLine(saveFileDialog1.FileName);
                Console.WriteLine(saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 4, 4));
                if (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length-4,4).Equals(".rtf"))
                {
                    Console.WriteLine("Hiiiiii");
                    f2.richTextBox1.SaveFile(saveFileDialog1.FileName);
                }
                else
                {
                    String content = f2.richTextBox1.Text;
                    UTF8Encoding utf8 = new UTF8Encoding();
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, utf8);
                    sw.Write(content);
                    sw.Close();
                }
                f2.Text = saveFileDialog1.FileName;
                foreach(ToolStripMenuItem tool in arrangeIconsToolStripMenuItem.DropDownItems)
                {
                    if (tool.Text.Equals(first))
                    {
                        tool.Text = saveFileDialog1.FileName;
                    }
                }
                saveToolStripMenuItem.Enabled = true;
                toolStripButton3.Enabled = true;
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool present = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (Form2 f2 in this.MdiChildren)
                {
                    if (f2.Text.Equals(openFileDialog1.FileName))
                    {
                        f2.Activate();
                        present = true;
                        break;
                    }
                }
                if(!present)   if (openFileDialog1.FileName.Substring(openFileDialog1.FileName.Length - 4, 4).Equals(".txt"))
                {
                    String line;
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    String str = openFileDialog1.FileName;
                    Form2 f2 = create_Form2(str);
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        f2.richTextBox1.Text += line;
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
                else
                {
                    String str = openFileDialog1.FileName;
                    Form2 f2 = create_Form2(str);
                    f2.richTextBox1.LoadFile(openFileDialog1.FileName);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = this.ActiveMdiChild as Form2;
            f2.richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = this.ActiveMdiChild as Form2;
            f2.richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = this.ActiveMdiChild as Form2;
            f2.richTextBox1.Paste();
        }

        private void aboutProgrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.MdiParent = this;
            f3.Show();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Form2 f2 = this.ActiveMdiChild as Form2;
                f2.richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Form2 f2 = this.ActiveMdiChild as Form2;
                f2.richTextBox1.SelectionColor=colorDialog1.Color;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = this.ActiveMdiChild as Form2;
            f2.richTextBox1.SelectedText="";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = this.ActiveMdiChild as Form2;
            f2.richTextBox1.SelectAll();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int wordstart, startpos;
            Form2 f2 = this.ActiveMdiChild as Form2;
            startpos = f2.richTextBox1.SelectionStart;
            if(f4.checkBox1.Checked && f4.checkBox2.Checked)
            {
                wordstart = f2.richTextBox1.Find(f4.textBox1.Text,startpos, System.Windows.Forms.RichTextBoxFinds.MatchCase | System.Windows.Forms.RichTextBoxFinds.WholeWord);
                if(wordstart>-1) f2.richTextBox1.Select(wordstart,f4.textBox1.Text.Length);
            }
            else if(f4.checkBox1.Checked && !f4.checkBox2.Checked)
            {
                wordstart = f2.richTextBox1.Find(f4.textBox1.Text, startpos, System.Windows.Forms.RichTextBoxFinds.MatchCase);
                if (wordstart > -1) f2.richTextBox1.Select(wordstart, f4.textBox1.Text.Length);
            }
            else if (!f4.checkBox1.Checked && f4.checkBox2.Checked)
            {
                wordstart = f2.richTextBox1.Find(f4.textBox1.Text, startpos, System.Windows.Forms.RichTextBoxFinds.WholeWord);
                if (wordstart > -1) f2.richTextBox1.Select(wordstart, f4.textBox1.Text.Length);
            }
            else if (!f4.checkBox1.Checked && !f4.checkBox2.Checked)
            {
                wordstart = f2.richTextBox1.Find(f4.textBox1.Text, startpos, System.Windows.Forms.RichTextBoxFinds.None);
                if (wordstart > -1) f2.richTextBox1.Select(wordstart, f4.textBox1.Text.Length);
            }
            f4.Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            f4.Close();
        }
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f4 = new Form4();
            f4.Show();
            f4.button1.Click += new EventHandler(this.button1_Click);
            f4.button2.Click += new EventHandler(this.button2_Click);
        }
    }
}
