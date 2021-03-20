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
using System.Data.SqlClient;

namespace ProductsApp.PL
{

    public partial class FRM_ORDER : Form
    {
        BL.CLS_ORDER order = new BL.CLS_ORDER();
        DataTable dt = new DataTable();
        void createDathatable()
        {
            dt.Columns.Add("معرف المنتج");
            dt.Columns.Add("اسم المنتج");
            dt.Columns.Add("ثمن المنتج");
            dt.Columns.Add("الكميه ");
            dt.Columns.Add("المبلغ");
            dt.Columns.Add("نسبه الخصم");
            dt.Columns.Add("المبلغ الجمالى ");
            dgproducts.DataSource = dt;
        }
        void resizedvg()
        {
            this.dgproducts.RowHeadersWidth = 54;


            dgproducts.Columns[0].Width = textBox10.Width;


            this.dgproducts.Columns[1].Width = textBox13.Width;
            this.dgproducts.Columns[2].Width = textBoxprice.Width;
            this.dgproducts.Columns[3].Width = textBoxqut.Width;
            this.dgproducts.Columns[4].Width = textBoxAmount.Width;
            this.dgproducts.ReadOnly = true;
            this.dgproducts.MultiSelect = false;
        }
        void clearboxs()
        {
            textBox10.Clear();
            textBox13.Clear();
            textBoxprice.Clear();
            textBoxqut.Clear();
            textBoxtotal.Clear();
            textBoxdis.Clear();
            textBoxAmount.Clear();
            button2.Focus();
       
        }
       
        void clearData()
        {
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear();
            textBox6.Clear(); textBox7.Clear(); textBox8.Clear(); textBox9.Clear(); textBox10.Clear();
            datetime3.Value = DateTime.Now;
            pictureBox1.Image = null;
            clearboxs();
            dt.Clear();
            dgproducts.Refresh();
            button4.Enabled = true;
            button5.Enabled = false;

        }
        public FRM_ORDER()
        {
            InitializeComponent();
            createDathatable();
            resizedvg();
            textBox4.Text = Program.SalesMan;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try { 
            order.ADD_ORDER(int.Parse(textBox1.Text), datetime3.Value, int.Parse(textBox5.Text), textBox2.Text.ToString(), textBox4.Text.ToString());
            MessageBox.Show("العمليه نجحت ", "عمليه الاضافه", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {

            }
            try
            {
                for (int i = 0; i < dgproducts.Rows.Count ; i++)
                {
                    order.ADD_ORDER_DETAILS(dgproducts.Rows[i].Cells[0].Value.ToString(),
                        int.Parse(textBox1.Text.ToString()),
                         int.Parse(dgproducts.Rows[i].Cells[3].Value.ToString()),
                        dgproducts.Rows[i].Cells[2].Value.ToString(),
                       float.Parse(dgproducts.Rows[i].Cells[5].Value.ToString()),
                       dgproducts.Rows[i].Cells[4].Value.ToString(),
                       dgproducts.Rows[i].Cells[6].Value.ToString());
                }
            }
            catch
            {
                return;
            }
            clearData();

        /*       public void ADD_ORDER(int order_id, DateTime order_date, int customer_id, string description_order, string salesman)
               {
               }*/

    }

        private void button4_Click(object sender, EventArgs e)
        {
            //جديد
            textBox1.Text = order.GET_LAST_ORDER_ID().Rows[0][0].ToString();
            button5.Enabled = true;
            button6.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMER_LIST frm = new FRM_CUSTOMER_LIST();
            frm.ShowDialog();
            textBox5.Text = frm.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox6.Text = frm.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox7.Text = frm.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox8.Text = frm.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox9.Text = frm.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            if (frm.dataGridView1.CurrentRow.Cells[5].Value == null)
            {
                MessageBox.Show("هذا العميل لا يحتوى على صوره ");
                return;
            }
            else
            {
                pictureBox1.Image = null;
                byte[] ima = (byte[])frm.dataGridView1.CurrentRow.Cells[5].Value;

                pictureBox1.Image = ByteToImage(ima);

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

        private void button2_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMER_LIST frm = new FRM_CUSTOMER_LIST("pro");
            frm.ShowDialog();
            textBox10.Text = frm.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox13.Text = frm.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxprice.Text = frm.dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }

        void calculateAmount()
        {
            if (textBoxprice.Text != string.Empty && textBoxqut.Text != string.Empty)
            {
                double amount = double.Parse(textBoxprice.Text) * double.Parse(textBoxqut.Text);
                textBoxAmount.Text = amount.ToString();
            }

        }

       public void calculateAmounttotal()
        {
            if (textBoxdis.Text != string.Empty && textBoxAmount.Text != string.Empty)
            {
                double amount = double.Parse(textBoxprice.Text) * double.Parse(textBoxqut.Text);
                double discount = amount - (amount * (double.Parse(textBoxdis.Text) / 100));
                textBox17.Text = discount.ToString();
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (textBoxprice.Text != string.Empty && textBoxqut.Text != string.Empty)
            {
                double amount = double.Parse(textBoxprice.Text) * double.Parse(textBoxqut.Text);
                textBoxAmount.Text = amount.ToString();
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char s = char.Parse(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != s)
            {
                e.Handled = true;
            }
            calculateAmount();
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter && textBoxprice.Text != string.Empty)
            {
                textBoxqut.Focus();
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBoxprice.Text != string.Empty)
            {
                textBoxdis.Focus();
            }
        }


        private void textBoxdis_MouseUp(object sender, MouseEventArgs e)
        {
           //calculateAmounttotal();
        }

        private void textBoxdis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (order.verifyQty(textBox10.Text, int.Parse(textBoxqut.Text)).Rows.Count < 1)
                {
                    MessageBox.Show("الكميه غير متاحه ", "خطا", MessageBoxButtons.OK);
                    return;
                }
                for (int i = 0; i < dgproducts.Rows.Count-1; i++)
                {
                    if (dgproducts.Rows[i].Cells[0].Value.ToString() == textBox10.Text)
                    {
                        MessageBox.Show("هذا المنتج تم ادخاله ");clearboxs();
                        return;
                    }
                }
      
                DataRow data = dt.NewRow();
                data[0] = textBox10.Text;
                data[1] = textBox13.Text;
                data[2] = textBoxprice.Text;
                data[3] = textBoxqut.Text;
                data[4] = textBoxAmount.Text;
                data[5] = textBoxdis.Text;
                data[6] = textBoxtotal.Text;
                dt.Rows.Add(data);
                dgproducts.DataSource = dt;
                clearboxs();
                int y=0;
                //  textBoxtotal.Text=(from datagrid viewRow row in dgproducts Where row.cells[6].formattedvalue)).sum().tostring();
                try
                {

                    for (int i = 0; i < dgproducts.Rows.Count - 1; i++)
                    {
                        y = y + int.Parse(dgproducts.Rows[i].Cells[6].Value.ToString());
                    }
                    textBox17.Text = y.ToString();
                }
                catch
                {
                    return;
                }
            
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxdis_TextChanged(object sender, EventArgs e)
        {
            if(textBoxAmount.Text!=string.Empty&& textBoxdis.Text != string.Empty)
            {
                double t =int.Parse(textBoxAmount.Text)-(int.Parse(textBoxAmount.Text) * int.Parse(textBoxdis.Text)) / 100;
                textBoxtotal.Text = t.ToString();
            }

        }

        private void dgproducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgproducts_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox10.Text = this.dgproducts.CurrentRow.Cells[0].Value.ToString();
                textBox13.Text = this.dgproducts.CurrentRow.Cells[1].Value.ToString();
                textBoxprice.Text = this.dgproducts.CurrentRow.Cells[2].Value.ToString();
                textBoxqut.Text = this.dgproducts.CurrentRow.Cells[3].Value.ToString();
                textBoxAmount.Text = this.dgproducts.CurrentRow.Cells[4].Value.ToString();
                textBoxtotal.Text = this.dgproducts.CurrentRow.Cells[6].Value.ToString();
                textBoxdis.Text = this.dgproducts.CurrentRow.Cells[5].Value.ToString();
                dgproducts.Rows.RemoveAt(dgproducts.CurrentRow.Index);
                textBoxqut.Focus();
            }
            catch
            {
                return;
            }
        }

        private void تعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgproducts_DoubleClick(sender, e);

        }

        private void حذفالسطرالحالىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgproducts.Rows.RemoveAt(dgproducts.CurrentRow.Index);
        }

        private void حذفالكلToolStripMenuItem_Click(object sender, EventArgs e)
        {
//     /*       for (int i = 0; i < dgproducts.Rows.Count-1; i++)
//            {

//                dgproducts.Rows.RemoveAt(dgproducts.Rows[i].Index);
//            }
//*/
            dt.Clear();
            dgproducts.Refresh();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*  order_details_report*/
            /*GET_LAST_ORDER_ID_print*/

            int order_id =int.Parse(order.GET_LAST_ORDER_ID_print().Rows[0][0].ToString());
            Reporting.Order_rpt rpt = new Reporting.Order_rpt();
            rpt.SetParameterValue("@ORD_ID", order_id);
            Reporting.FRM_RPT_PRODUCT myfrm = new Reporting.FRM_RPT_PRODUCT();
            rpt.SetDataSource(order.GET_order_details_report(order_id));
            myfrm.crystalReportViewer1.ReportSource = rpt;
            myfrm.ShowDialog();

        }
    }
}