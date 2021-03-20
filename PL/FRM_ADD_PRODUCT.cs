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
    public partial class FRM_ADD_PRODUCT : Form
    {
        public string state = "add";
        BL.cls_products prd = new BL.cls_products();
        public FRM_ADD_PRODUCT()
        {
            InitializeComponent();
     
          
       
            combo_cat.DataSource = prd.Get_All_Categories();
            combo_cat.DisplayMember = "cat_description";
            combo_cat.ValueMember = "cat_id";
            combo_cat.SelectedIndexChanged += Combo_cat_SelectedIndexChanged;
            /*   
             ;
                combo_cat.DisplayMember("cat_description");
                combo_cat.DisplayMember("cat_description",);
                combo_cat.ValueMember("cat_id");*/

        }
        public int h;
        public void Combo_cat_SelectedIndexChanged(object sender, EventArgs e)
        {
       /*     h = int.Parse();*/
        }

        private void FRM_ADD_PRODUCT_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //download image 
            OpenFileDialog ofd = new OpenFileDialog();
         ///*   ofd.Filter = "ملفات  \*.jpg;*.png;*.gif;*.bmp;";*/
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                img_product.Image = Image.FromFile(ofd.FileName);
            }
        }
     

        private void button2_Click(object sender, EventArgs e)
        {
            
         /*   ADD EVENT*/
            if (state == "add")
            {
                MemoryStream ms = new MemoryStream();
                img_product.Image.Save(ms, img_product.Image.RawFormat);
                byte[] byteimage = ms.ToArray();
                prd.Add_Product(combo_cat.SelectedIndex + 1, des_prod.Text, id_product.Text, int.Parse(quant_prod.Text),
                    price_product.Text, byteimage);
                MessageBox.Show("العمليه نجحت ", "عمليه الاضافه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                img_product.Image.Save(ms, img_product.Image.RawFormat);
                byte[] byteimage = ms.ToArray();
                prd.Update_Product(combo_cat.SelectedIndex + 1, des_prod.Text, id_product.Text, int.Parse(quant_prod.Text),
                    price_product.Text, byteimage);
                MessageBox.Show("تم التعديل  ", "عمليه التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            FRM_PRODUCTS.get_main_form.dataGridView1.DataSource = prd.Get_All_Products();

        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void combo_cat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void id_product_Validated(object sender, EventArgs e)
        {
            if (state == "add")
            {
                DataTable DT = new DataTable();
                DT = prd.verifyProductID(id_product.Text);
                if (DT.Rows.Count > 0)
                {
                    MessageBox.Show("هذا المعرف موجود مسبقا  ", "تنبيه ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    id_product.Focus();
                    id_product.SelectionStart = 0;
                    id_product.SelectionLength = id_product.TextLength;

                }
            }
        }
    }
}
