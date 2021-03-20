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
    public partial class LOG_FRM : Form
    {
        public LOG_FRM()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        BL.Cl_LOGIN log = new BL.Cl_LOGIN();
        private void button1_Click(object sender, EventArgs e)
        { 
            DataTable dt = log.LOGIN(textBox1.Text,textBox2.Text);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][2].ToString() == "manager")
                {

                    FRM_MAIN.get_main_form.المنتجاتToolStripMenuItem.Enabled = true;
                    FRM_MAIN.get_main_form.استعادهنسخهمحفوظهToolStripMenuItem.Enabled = true;
                    FRM_MAIN.get_main_form.انشاءنسخهاحتياطيهToolStripMenuItem.Enabled = true;

                    FRM_MAIN.get_main_form.المنتجاتToolStripMenuItem.Enabled = true;
                    FRM_MAIN.get_main_form.المستخدمونToolStripMenuItem.Enabled = true;
                    FRM_MAIN.get_main_form.العملاءToolStripMenuItem.Enabled = true;
                }
                else
                {
                    FRM_MAIN.get_main_form.المنتجاتToolStripMenuItem.Enabled = true;
                    FRM_MAIN.get_main_form.استعادهنسخهمحفوظهToolStripMenuItem.Enabled = true;
                    FRM_MAIN.get_main_form.انشاءنسخهاحتياطيهToolStripMenuItem.Enabled = true;

                    FRM_MAIN.get_main_form.المنتجاتToolStripMenuItem.Enabled = true;
                    FRM_MAIN.get_main_form.المستخدمونToolStripMenuItem.Visible = false;
                    FRM_MAIN.get_main_form.العملاءToolStripMenuItem.Enabled = true;
                }
             /*   MessageBox.Show("login success");*/
         
                this.Close();
            }
            else
            {
                MessageBox.Show("login failed");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
