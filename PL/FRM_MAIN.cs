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
    public partial class FRM_MAIN : Form
    {
        private static FRM_MAIN frm;
        static void frm_formclosed(object sender,FormClosedEventArgs e) {
            frm=null;
            }
        public static FRM_MAIN get_main_form
        {
            get{
                if (frm == null)
                {
                    frm = new FRM_MAIN();
                    frm.FormClosed+= new FormClosedEventHandler(frm_formclosed);
                }
                return frm;
            }
        }
        public FRM_MAIN()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
///*            this.ملفToolStripMenuItem.Enabled = false;*/

            this.استعادهنسخهمحفوظهToolStripMenuItem.Enabled = false;
            this.انشاءنسخهاحتياطيهToolStripMenuItem.Enabled = false;

            this.المنتجاتToolStripMenuItem.Enabled = false;
            this.المستخدمونToolStripMenuItem.Enabled = false;
            this.العملاءToolStripMenuItem.Enabled = false;
        }

        private void تسجيلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOG_FRM frm = new LOG_FRM();
            frm.ShowDialog();
        }

        private void FRM_MAIN_Load(object sender, EventArgs e)
        {

        }

        private void اضافهمنتجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT frm = new FRM_ADD_PRODUCT();
            frm.ShowDialog();
        }

        private void ادارهالمنتجاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_PRODUCTS frm = new FRM_PRODUCTS();
            frm.ShowDialog();
        }

        private void ادارهالاضافهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CATEGORY frm = new FRM_CATEGORY();
            frm.ShowDialog();
        }

        private void ادارهالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMER1 frm = new FRM_CUSTOMER1();
            frm.ShowDialog();
        }

        private void ادارهالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ORDER frm = new FRM_ORDER();
            frm.ShowDialog();
        }

        private void اضافهمستخدمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_User frm = new Add_User();
            frm.ShowDialog();
        }

        private void ادارهالمستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_USERS_LIST frm = new FRM_USERS_LIST();
            frm.ShowDialog();
        }

        private void انشاءنسخهاحتياطيهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_BACKUP frm = new FRM_BACKUP();
            frm.ShowDialog();

        }

        private void استعادهنسخهمحفوظهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_BACKUP frm = new FRM_BACKUP();
            frm.Text = "استعاده نسخه محفوظه";
            frm.button3.Text = "استعاده نسخه محفوظه";
            frm.ShowDialog();
        }
    }
}
