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
    public partial class FRM_USERS_LIST : Form
    {
        BL.Cl_LOGIN login = new BL.Cl_LOGIN();
        public FRM_USERS_LIST()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = login.Get_All_Users();
        }

        private void FRM_USERS_LIST_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = login.Search_User(textBox5.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = login.Search_User(textBox5.Text);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            login.Delete_User(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            this.dataGridView1.DataSource = login.Get_All_Users();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_User frm = new Add_User();
            frm.Text = "تعديل المستخدم";
            frm.button1.Text = "تعديل";
            frm.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.textBox5.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();


            frm.ShowDialog();


        }
    }
}
