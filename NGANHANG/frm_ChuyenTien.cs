using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGANHANG
{
    public partial class frm_ChuyenTien : Form
    {
        int check = 2;  //biến để kiểm tra giá trị trả về, nếu thực hiện thành công thì trả ra một MessageBox thông báo Success.
        public frm_ChuyenTien()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtSTKC.Text.Trim() == "" || txtTien.Text.Trim() == "" || txtSTKN.Text.Trim() == "")
            {    // hàm Trim để xóa khoảng trắng 2 bên.
                MessageBox.Show("Số tài khoản, số tiền không được bỏ trống", "", MessageBoxButtons.OK);
                return;
            }
            string strLenh = "EXEC SP_CHUYENTIEN '" + txtSTKC.Text + "','" + txtSTKN.Text + "','" + txtTien.Text + "','" + Program.username + "'";
            //Debug.WriteLine(strLenh);
            check = Program.ExecSqlNonQuery(strLenh);
            if (check == 0) MessageBox.Show("Giao dịch thành công!!!", "", MessageBoxButtons.OK);
        }
    }
}
