namespace ProductsApp.PL
{
    partial class FRM_ADD_PRODUCT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_ADD_PRODUCT));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.close_btn = new System.Windows.Forms.Button();
            this.add_btn = new System.Windows.Forms.Button();
            this.img_download = new System.Windows.Forms.Button();
            this.img_product = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.price_product = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.quant_prod = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.des_prod = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.id_product = new System.Windows.Forms.TextBox();
            this.combo_cat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_product)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.close_btn);
            this.groupBox1.Controls.Add(this.add_btn);
            this.groupBox1.Controls.Add(this.img_download);
            this.groupBox1.Controls.Add(this.img_product);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.price_product);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.quant_prod);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.des_prod);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.id_product);
            this.groupBox1.Controls.Add(this.combo_cat);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(26, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(618, 430);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // close_btn
            // 
            this.close_btn.Location = new System.Drawing.Point(142, 385);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(75, 23);
            this.close_btn.TabIndex = 14;
            this.close_btn.Text = "الغاء";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(55, 385);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(75, 23);
            this.add_btn.TabIndex = 13;
            this.add_btn.Text = "موافق";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // img_download
            // 
            this.img_download.AccessibleName = "img_download";
            this.img_download.Location = new System.Drawing.Point(162, 330);
            this.img_download.Name = "img_download";
            this.img_download.Size = new System.Drawing.Size(256, 23);
            this.img_download.TabIndex = 5;
            this.img_download.Text = "تحميل الصوره";
            this.img_download.UseVisualStyleBackColor = true;
            this.img_download.Click += new System.EventHandler(this.button1_Click);
            // 
            // img_product
            // 
            this.img_product.AccessibleName = "img_product";
            this.img_product.Image = ((System.Drawing.Image)(resources.GetObject("img_product.Image")));
            this.img_product.Location = new System.Drawing.Point(162, 246);
            this.img_product.Name = "img_product";
            this.img_product.Size = new System.Drawing.Size(256, 77);
            this.img_product.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_product.TabIndex = 11;
            this.img_product.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(434, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "صوره المنتج";
            // 
            // price_product
            // 
            this.price_product.AccessibleName = "price_product";
            this.price_product.Location = new System.Drawing.Point(162, 213);
            this.price_product.Name = "price_product";
            this.price_product.Size = new System.Drawing.Size(256, 20);
            this.price_product.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(443, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "ثمن المنتج";
            // 
            // quant_prod
            // 
            this.quant_prod.AccessibleName = "quant_prod";
            this.quant_prod.Location = new System.Drawing.Point(162, 174);
            this.quant_prod.Name = "quant_prod";
            this.quant_prod.Size = new System.Drawing.Size(256, 20);
            this.quant_prod.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "كميه المخزنه";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // des_prod
            // 
            this.des_prod.AccessibleName = "des_prod";
            this.des_prod.Location = new System.Drawing.Point(162, 89);
            this.des_prod.Multiline = true;
            this.des_prod.Name = "des_prod";
            this.des_prod.Size = new System.Drawing.Size(256, 72);
            this.des_prod.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(434, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "وصف المنتج";
            // 
            // id_product
            // 
            this.id_product.AccessibleName = "id_product";
            this.id_product.Location = new System.Drawing.Point(162, 52);
            this.id_product.Name = "id_product";
            this.id_product.Size = new System.Drawing.Size(256, 20);
            this.id_product.TabIndex = 1;
            this.id_product.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.id_product.Validated += new System.EventHandler(this.id_product_Validated);
            // 
            // combo_cat
            // 
            this.combo_cat.AccessibleName = "id_cat";
            this.combo_cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_cat.FormattingEnabled = true;
            this.combo_cat.Location = new System.Drawing.Point(162, 19);
            this.combo_cat.Name = "combo_cat";
            this.combo_cat.Size = new System.Drawing.Size(256, 21);
            this.combo_cat.TabIndex = 2;
            this.combo_cat.SelectedIndexChanged += new System.EventHandler(this.combo_cat_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(434, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "معرف المنتج";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(434, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "صنف المنتج";
            // 
            // FRM_ADD_PRODUCT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 450);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_ADD_PRODUCT";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "اضافه منتج";
            this.Load += new System.EventHandler(this.FRM_ADD_PRODUCT_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_product)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox combo_cat;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox id_product;
        public System.Windows.Forms.TextBox price_product;
        public System.Windows.Forms.TextBox quant_prod;
        public System.Windows.Forms.TextBox des_prod;
        public System.Windows.Forms.Button close_btn;
        public System.Windows.Forms.Button add_btn;
        public System.Windows.Forms.Button img_download;
        public System.Windows.Forms.PictureBox img_product;
    }
}