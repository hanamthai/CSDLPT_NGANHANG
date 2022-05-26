namespace NGANHANG
{
    partial class frmTaoTKNV
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
            this.components = new System.ComponentModel.Container();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lueNhanVien = new DevExpress.XtraEditors.GridLookUpEdit();
            this.nhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS = new NGANHANG.DS();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btLuu = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassConfir = new DevExpress.XtraEditors.TextEdit();
            this.txtPass = new DevExpress.XtraEditors.TextEdit();
            this.txtLoginName = new DevExpress.XtraEditors.TextEdit();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            this.nhanVienTableAdapter = new NGANHANG.DSTableAdapters.NhanVienTableAdapter();
            this.tableAdapterManager = new NGANHANG.DSTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueNhanVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassConfir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Mã nhân viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 189);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Nhập lại mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 154);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Mật Khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Tên tài khoản";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lueNhanVien);
            this.groupControl1.Controls.Add(this.btLuu);
            this.groupControl1.Controls.Add(this.txtPassConfir);
            this.groupControl1.Controls.Add(this.txtPass);
            this.groupControl1.Controls.Add(this.txtLoginName);
            this.groupControl1.Controls.Add(this.btThoat);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Location = new System.Drawing.Point(305, 152);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(696, 310);
            this.groupControl1.TabIndex = 28;
            this.groupControl1.Text = "Tạo tài khoản";
            // 
            // lueNhanVien
            // 
            this.lueNhanVien.EditValue = "Chọn nhân viên";
            this.lueNhanVien.Location = new System.Drawing.Point(215, 76);
            this.lueNhanVien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lueNhanVien.Name = "lueNhanVien";
            this.lueNhanVien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueNhanVien.Properties.DataSource = this.nhanVienBindingSource;
            this.lueNhanVien.Properties.DisplayMember = "MANV";
            this.lueNhanVien.Properties.PopupView = this.gridLookUpEdit1View;
            this.lueNhanVien.Properties.ValueMember = "MANV";
            this.lueNhanVien.Size = new System.Drawing.Size(406, 22);
            this.lueNhanVien.TabIndex = 37;
            // 
            // nhanVienBindingSource
            // 
            this.nhanVienBindingSource.DataMember = "NhanVien";
            this.nhanVienBindingSource.DataSource = this.dS;
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMANV,
            this.colHo,
            this.colTen});
            this.gridLookUpEdit1View.DetailHeight = 437;
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colMANV
            // 
            this.colMANV.Caption = "Mã";
            this.colMANV.FieldName = "MANV";
            this.colMANV.MinWidth = 25;
            this.colMANV.Name = "colMANV";
            this.colMANV.Visible = true;
            this.colMANV.VisibleIndex = 0;
            this.colMANV.Width = 94;
            // 
            // colHo
            // 
            this.colHo.Caption = "Họ";
            this.colHo.FieldName = "HO";
            this.colHo.MinWidth = 25;
            this.colHo.Name = "colHo";
            this.colHo.Visible = true;
            this.colHo.VisibleIndex = 1;
            this.colHo.Width = 94;
            // 
            // colTen
            // 
            this.colTen.Caption = "Tên";
            this.colTen.FieldName = "TEN";
            this.colTen.MinWidth = 25;
            this.colTen.Name = "colTen";
            this.colTen.Visible = true;
            this.colTen.VisibleIndex = 2;
            this.colTen.Width = 94;
            // 
            // btLuu
            // 
            this.btLuu.Location = new System.Drawing.Point(496, 218);
            this.btLuu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(125, 45);
            this.btLuu.TabIndex = 35;
            this.btLuu.Text = "Lưu";
            this.btLuu.Click += new System.EventHandler(this.btLuu_ClickAsync);
            // 
            // txtPassConfir
            // 
            this.txtPassConfir.Location = new System.Drawing.Point(215, 185);
            this.txtPassConfir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassConfir.Name = "txtPassConfir";
            this.txtPassConfir.Properties.UseSystemPasswordChar = true;
            this.txtPassConfir.Size = new System.Drawing.Size(406, 22);
            this.txtPassConfir.TabIndex = 34;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(215, 150);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPass.Name = "txtPass";
            this.txtPass.Properties.UseSystemPasswordChar = true;
            this.txtPass.Size = new System.Drawing.Size(406, 22);
            this.txtPass.TabIndex = 33;
            // 
            // txtLoginName
            // 
            this.txtLoginName.Location = new System.Drawing.Point(215, 115);
            this.txtLoginName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(406, 22);
            this.txtLoginName.TabIndex = 32;
            // 
            // btThoat
            // 
            this.btThoat.Location = new System.Drawing.Point(364, 218);
            this.btThoat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(125, 45);
            this.btThoat.TabIndex = 30;
            this.btThoat.Text = "Thoát";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // nhanVienTableAdapter
            // 
            this.nhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.GD_CHUYENTIENTableAdapter = null;
            this.tableAdapterManager.GD_GOIRUTTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = this.nhanVienTableAdapter;
            this.tableAdapterManager.UpdateOrder = NGANHANG.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // frmTaoTKNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 689);
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmTaoTKNV";
            this.Text = "Tạo tài khoản";
            this.Load += new System.EventHandler(this.frmTaoTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueNhanVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassConfir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btLuu;
        private DevExpress.XtraEditors.TextEdit txtPassConfir;
        private DevExpress.XtraEditors.TextEdit txtPass;
        private DevExpress.XtraEditors.TextEdit txtLoginName;
        private DevExpress.XtraEditors.SimpleButton btThoat;
        private DS dS;
        private System.Windows.Forms.BindingSource nhanVienBindingSource;
        private DSTableAdapters.NhanVienTableAdapter nhanVienTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraEditors.GridLookUpEdit lueNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private DevExpress.XtraGrid.Columns.GridColumn colHo;
        private DevExpress.XtraGrid.Columns.GridColumn colTen;
    }
}