using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductsApp.PL
{
    public partial class Add_User : Form
    {
        BL.Cl_LOGIN login = new BL.Cl_LOGIN();
        public Add_User()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==String.Empty|| textBox2.Text == String.Empty|| textBox3.Text == String.Empty
               || textBox4.Text == String.Empty|| textBox5.Text == String.Empty)
            {
              
                MessageBox.Show("يرجى كتابه جميع التفاصيل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Add_User frm = new Add_User();
            // frm.ShowDialog();
            if (button1.Text == "اضافه")
            {
                login.Add_User(textBox1.Text, textBox3.Text, textBox5.Text, textBox2.Text);
                MessageBox.Show("تم اضافه المستخدم", "اضافه", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                login.Edit_User(textBox1.Text, textBox3.Text, textBox5.Text, textBox2.Text);
                MessageBox.Show("تم تعديل المستخدم", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }




            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear(); textBox1.Focus();
        }

        private void textBox4_Validated(object sender, EventArgs e)
        {
            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("الكلمتان ليس متطابقتان", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
