using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace ProductsApp.PL
{
    public partial class FRM_CUSTOMER1 : Form
    {
        BL.CLS_CUSTOMER cust = new BL.CLS_CUSTOMER();
        int ID,position;

        public FRM_CUSTOMER1()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = cust.Get_All_Customers();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            position = 0;
        }

        private void pBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "ملفات الصور |*.JPG; *.PNG; *.GIF *.BMP";
            if (of.ShowDialog() == DialogResult.OK)
            {
                pBox.Image = Image.FromFile(of.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                byte[] pict;
                if (pBox == null)
                {
                    pict = new byte[0];
                    cust.ADD_Customer(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, pict, "withoutImage");
                    this.dataGridView1.DataSource = cust.Get_All_Customers();
                } else
                {

                    MemoryStream ms = new MemoryStream();
                    pBox.Image.Save(ms, pBox.Image.RawFormat);
                    pict = ms.ToArray();
                    cust.ADD_Customer(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, pict, "withImage"); }
                    this.dataGridView1.DataSource = cust.Get_All_Customers();
            }
            catch
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            pBox.Image = null;
            textBox1.Focus();
            button2.Enabled = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                pBox.Image = null;
                this.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                this.textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                this.textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                ID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                /* DataTable dtt = new DataTable();*/
                /*       dtt.Rows.Add(this.dataGridView1.CurrentRow.Cells[5].Value);
                       byte[] ima = (byte[])dtt.Rows[0][0];*/
                byte[] ima = (byte[])this.dataGridView1.CurrentRow.Cells[5].Value;
             //   MemoryStream ms = new MemoryStream(ima);
                pBox.Image = ByteToImage(ima);
            }
            catch
            {
                return;
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] pict;
                if (pBox.Image == null)
                {
                    pict = new byte[0];
                    cust.EDIT_Customer(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, pict, "withoutImage",ID);
                    this.dataGridView1.DataSource = cust.Get_All_Customers();
                }
                else
                {

                    MemoryStream ms = new MemoryStream();
                    pBox.Image.Save(ms, pBox.Image.RawFormat);
                    pict = ms.ToArray();
                    cust.EDIT_Customer(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, pict, "withImage",ID);
                }
                this.dataGridView1.DataSource = cust.Get_All_Customers();
            }
            catch
            {
                return;
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                MessageBox.Show("هذا العميل موجود");
                return;
            }

            if (MessageBox.Show("هل انت تريد الحذف حقا ", "الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==
                    DialogResult.Yes)
            {
                cust.DELETE_Customer(ID);
                MessageBox.Show("deleted successfully", "delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dataGridView1.DataSource = cust.Get_All_Customers();
            }
            else
            {
                MessageBox.Show("لم يتم الحذف ", "الحذف", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information);
                   
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
        

            dataGridView1.DataSource = cust.SEARCH_Customer(textBox5.Text);
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button10_Click(sender, e);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Navigate(0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            position = cust.Get_All_Customers().Rows.Count - 1;
            Navigate(position);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
           if(position == 0)
            {
                MessageBox.Show("هذا اول عنصر");
                return;
            }
            position -= 1;
            Navigate(position);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (position == cust.Get_All_Customers().Rows.Count - 1)
            {
                MessageBox.Show("هذا اخر عنصر");
                return;
            }
            position += 1;
            Navigate(position);
        }

        void Navigate(int index)
        {
            try
            {

                pBox.Image = null;
                DataTable dtt = cust.Get_All_Customers();
                textBox1.Text = dtt.Rows[index][1].ToString();
                textBox2.Text = dtt.Rows[index][2].ToString();
                textBox3.Text = dtt.Rows[index][3].ToString();
                textBox4.Text = dtt.Rows[index][4].ToString();
                byte[] ima2 = (byte[])dtt.Rows[index][5];
                // byte[] ima = (byte[])this.dataGridView1.CurrentRow.Cells[5].Value;
                //   MemoryStream ms = new MemoryStream(ima);
                pBox.Image = ByteToImage(ima2);
            }
            catch
            {
                return;
            }
        }
    }
}
