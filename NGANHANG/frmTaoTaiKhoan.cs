using NGANHANG.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGANHANG
{
    public partial class frmTaoTaiKhoan : Form
    {
        public frmTaoTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.dS.NhanVien);

            // dS.Nhanvien empty case
            if (dS.NhanVien.Count == 0)
            {
                MessageBox.Show("Không tìm thấy bất kì nhân viên nào");
                Close();
                return;
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.nhanVienBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void btLuu_ClickAsync(object sender, EventArgs e)
        {
            if (lueNhanVien.GetSelectedDataRow() == null)
            {
                MessageBox.Show("Xin hãy chọn mã nhân viên");
                lueNhanVien.Focus();
                return;
            }

            if (txtLoginName.Text.Trim() == "")
            {
                MessageBox.Show("Tên đăng nhập không thể để trắng");
                txtLoginName.Focus();
                return;
            }

            if (txtPass.Text == "")
            {
                MessageBox.Show("Mật khẩu không thể trống");
                txtPass.Focus();
                return;
            }

            if (txtPassConfir.Text != txtPass.Text)
            {
                MessageBox.Show("Mật khẩu và mật khẩu nhập lại không khớp nhau");
                txtPassConfir.Focus();
                return;
            }

            string cmdText = "sp_create_account";
            SqlParameter parameterUsername = new SqlParameter("@username", (lueNhanVien.GetSelectedDataRow() as DataRowView)["MANV"]);
            SqlParameter parameterLoginname = new SqlParameter("@loginname", txtLoginName.Text.Trim());
            SqlParameter parameterPassword = new SqlParameter("@password", txtPass.Text);

            try
            {
                DbConnection.ExecuteNonQuery(cmdText, CommandType.StoredProcedure,
                    parameterUsername, parameterLoginname, parameterPassword);
                MessageBox.Show("Tạo tài khoản thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tên đăng nhập đã có hoặc nhân viên đã có tài khoản\nChi tiết: {ex.Message}");
            }
        }
    }
}
