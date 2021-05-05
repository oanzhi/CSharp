using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm
{
   
    public partial class Form1 : Form
    {
        Boolean full = false;
        Boolean correct1 = true;
        Boolean correct2 = true;
        public Form1()
        {
            InitializeComponent();
            radioButton2.Checked = true;
            label4.Visible = false;
            textBox3.Visible = false;
            label5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals("") && correct1 == true && radioButton2.Checked == true || 
                !textBox1.Text.Equals("") && !textBox2.Text.Equals("") && !textBox3.Text.Equals("") && correct1 == true &&correct2==true && radioButton1.Checked == true)
            {
                const string message = "Регистрация успешно выполнена";
                const string caption = "Регистрация";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                const string message = "Проверьте корректность вводимых данных";
                const string caption = "Ошибка";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK);

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label4.Visible = true;
                textBox3.Visible = true;
                textBox3_TextChanged(sender, e);
            }
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label4.Visible = false;
                textBox3.Visible = false;
            }

        }

     
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                full = true;
            }
            else
            {
                full = false;
            }
            textBox2_TextChanged(sender,e);
            textBox3_TextChanged(sender, e);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!full)
            {
                try
                {
                    Convert.ToInt32(textBox2.Text);
                    correct1 = true;
                    errorProvider1.Clear();
                    label5.Visible = false;
                }
                catch (System.FormatException)
                {
                    correct1 = false;
                    errorProvider1.SetError(textBox2, "Must be number");
                    label5.Visible = true; ;
                }
                finally
                {
                    if(textBox2.Text.Equals(""))
                    {
                        correct1 = true;
                        errorProvider1.Clear();
                        label5.Visible = false;
                    }
                }
                }
            else
            {
                correct1 = true;
                errorProvider1.Clear();
                label5.Visible = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!full)
            {
                try
                {
                    Convert.ToInt32(textBox3.Text);
                    correct2 = true;
                    errorProvider2.Clear();
                    label5.Visible = false;
                }
                catch (System.FormatException)
                {
                    correct2 = false;
                    errorProvider2.SetError(textBox3, "Must be number");
                    label5.Visible = true; ;
                }
                finally
                {
                    if (textBox3.Text.Equals(""))
                    {
                        correct2 = true;
                        errorProvider2.Clear();
                        label5.Visible = false;
                    }
                }
            }
            else
            {
                correct2 = true;
                errorProvider2.Clear();
                label5.Visible = false;
            }
        }
    }
}
