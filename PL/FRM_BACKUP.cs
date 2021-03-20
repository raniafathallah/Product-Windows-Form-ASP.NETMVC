using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProductsApp.PL
{
    public partial class FRM_BACKUP : Form
    {
        SqlConnection sqlConnection =
            new SqlConnection(@"Data Source=rania;Initial Catalog=Products_db;Integrated Security=true;");
        SqlCommand cmd;

        public FRM_BACKUP()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button3.Text == "انشاء نسخه احتياطيه")
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = folderBrowserDialog1.SelectedPath;

                }
            }
            else
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = openFileDialog1.FileName;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "انشاء نسخه احتياطيه")
            {
 //               +DateTime.Now.ToShortDateString().Replace("/", "-") +
 //DateTime.Now.ToLongDateString().Replace(":", "-")
                string filename = textBox1.Text + DateTime.Now.ToShortDateString().Replace("/", "-") +
                DateTime.Now.ToLongDateString().Replace(":", "-") ;
                string strQuery = "Backup database master to disk = 'E:/backupProduct_db/test.bak'";
                cmd = new SqlCommand(strQuery, sqlConnection);
                sqlConnection.Open(); cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("تم اخذ النسخه الاحتياطيه ", "النسخه الاحتياطيه ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                //                ALTER DATABASE Products_db SET OFFLINE  WITH NO_WAIT
                //               ALTER DATABASE Products_db SET ONLINE 
                //Alter Database Products_db set Offline With Rollback Immediate;

                string strQuery = " Alter Database Products_db set Offline With Rollback Immediate " +
                    " Restore Database Products_db From Disk='" + textBox1.Text + "'";
                
                SqlConnection sqlConnection =
                new SqlConnection(@"Data Source=rania;Initial Catalog=master;Integrated Security=true;");
            
                cmd = new SqlCommand(strQuery, sqlConnection);
                sqlConnection.Open(); cmd.ExecuteNonQuery();
                MessageBox.Show("تم اخذ النسخه الاحتياطيه ", "النسخه الاحتياطيه ", MessageBoxButtons.OK, MessageBoxIcon.Information);


      
                sqlConnection.Close();
           
            }

        }
    }
}
