
namespace NGANHANG
{
    partial class frm_GuiRut
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
            this.txtSTK = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.cmbGuiRut = new System.Windows.Forms.ComboBox();
            this.btnCheckTK = new System.Windows.Forms.Button();
            this.txtTenND = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSTK
            // 
            this.txtSTK.Location = new System.Drawing.Point(253, 109);
            this.txtSTK.Margin = new System.Windows.Forms.Padding(4);
            this.txtSTK.Name = "txtSTK";
            this.txtSTK.Size = new System.Drawing.Size(559, 28);
            this.txtSTK.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số Tài Khoản";
            // 
            // txtTien
            // 
            this.txtTien.Location = new System.Drawing.Point(253, 204);
            this.txtTien.Name = "txtTien";
            this.txtTien.Size = new System.Drawing.Size(559, 28);
            this.txtTien.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nhập Số Tiền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Loại Giao Dịch";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(326, 403);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(110, 46);
            this.btnXacNhan.TabIndex = 6;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(591, 399);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(97, 54);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // cmbGuiRut
            // 
            this.cmbGuiRut.FormattingEnabled = true;
            this.cmbGuiRut.Location = new System.Drawing.Point(253, 307);
            this.cmbGuiRut.Name = "cmbGuiRut";
            this.cmbGuiRut.Size = new System.Drawing.Size(559, 28);
            this.cmbGuiRut.TabIndex = 8;
            this.cmbGuiRut.SelectedIndexChanged += new System.EventHandler(this.cmbGuiRut_SelectedIndexChanged);
            // 
            // btnCheckTK
            // 
            this.btnCheckTK.Location = new System.Drawing.Point(839, 105);
            this.btnCheckTK.Name = "btnCheckTK";
            this.btnCheckTK.Size = new System.Drawing.Size(93, 35);
            this.btnCheckTK.TabIndex = 10;
            this.btnCheckTK.Text = "Kiểm Tra";
            this.btnCheckTK.UseVisualStyleBackColor = true;
            this.btnCheckTK.Click += new System.EventHandler(this.btnCheckTK_Click);
            // 
            // txtTenND
            // 
            this.txtTenND.AutoSize = true;
            this.txtTenND.Location = new System.Drawing.Point(971, 116);
            this.txtTenND.Name = "txtTenND";
            this.txtTenND.Size = new System.Drawing.Size(128, 21);
            this.txtTenND.TabIndex = 12;
            this.txtTenND.Text = "Tên người dùng";
            // 
            // frm_GuiRut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 543);
            this.Controls.Add(this.txtTenND);
            this.Controls.Add(this.btnCheckTK);
            this.Controls.Add(this.cmbGuiRut);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSTK);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_GuiRut";
            this.Text = "Rút tiền";
            this.Load += new System.EventHandler(this.frm_GuiRut_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSTK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ComboBox cmbGuiRut;
        private System.Windows.Forms.Button btnCheckTK;
        private System.Windows.Forms.Label txtTenND;
    }
}