using NGANHANG.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGANHANG
{
    public partial class frmTaoTKKH : Form
    {
        public frmTaoTKKH()
        {
            InitializeComponent();
        }

        private void frmTaoTKKH_Load(object sender, EventArgs e)
        {
            dS1.EnforceConstraints = false;
            this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khachHangTableAdapter.Fill(this.dS1.KhachHang);

            // dS.Nhanvien empty case
            if (dS1.KhachHang.Count == 0)
            {
                MessageBox.Show("Không tìm thấy bất kì khách hàng nào");
                Close();
                return;
            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (lueNguoiDung.GetSelectedDataRow() == null)
            {
                MessageBox.Show("Xin hãy chọn cmnd người dùng");
                lueNguoiDung.Focus();
                return;
            }

            if (txtStk.Text.Trim() == "")
            {
                MessageBox.Show("Số tài khoản không thể để trắng");
                txtStk.Focus();
                return;
            }

            string cmdText = "sp_tao_tai_khoan_khach_hang";
            SqlParameter parameterCMND = new SqlParameter("@cmnd", (lueNguoiDung.GetSelectedDataRow() as DataRowView)["CMND"]);
            SqlParameter parameterStk = new SqlParameter("@stk", txtStk.Text.Trim());

            try
            {
                DbConnection.ExecuteNonQuery(cmdText, CommandType.StoredProcedure,
                    parameterCMND, parameterStk);
                MessageBox.Show("Tạo tài khoản thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Số tài khoản đã tồn tạin\nChi tiết: {ex.Message}");
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
