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
    public partial class frmKH : Form
    {
        int vitri = 0;
        string macn = "";
        int check_Luu_HieuChinh = 0;    // Nếu chọn btnThem thì ta gán = 1, nếu btnHieuChinh thì ta gán = 2. Mục đích là để biết ta chọn btnThem hay không để chạy SP kiểm tra mã nv bị trùng.
        private SqlDataReader checkCMND;

        public frmKH()
        {
            InitializeComponent();
        }

        private void frmKH_Load(object sender, EventArgs e)
        {
            DS1.EnforceConstraints = false; // bỏ kiểm tra khóa ngoại MACN.
            // TODO: This line of code loads data into the 'dS1.KhachHang' table. You can move, or remove it, as needed.
            this.KHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr; // gán thông tin đăng nhập vào các Adapter tương ứng để fill lấy thông tin đúng với thông tin đăng nhập.
            this.KHACHHANGTableAdapter.Fill(this.DS1.KhachHang);
            // TODO: This line of code loads data into the 'DS1.TaiKhoan' table. You can move, or remove it, as needed.
            this.TAIKHOANTableAdapter.Connection.ConnectionString = Program.connstr;
            this.TAIKHOANTableAdapter.Fill(this.DS1.TaiKhoan);

            macn = ((DataRowView)bdsKH[0])["MACN"].ToString();
            cmbChiNhanh.DataSource = Program.bds_dspm;  //sao chép dspm đã load ở form đăng nhập.
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChinhanh;
            if (Program.mGroup == "NGANHANG")
            {
                cmbChiNhanh.Enabled = true;
                btnThem.Enabled = btnHieuChinh.Enabled = btnLuu.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = false;
            }
            else
            {
                cmbChiNhanh.Enabled = false;
                btnThem.Enabled = btnHieuChinh.Enabled = btnLuu.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = true;
            }
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsKH.Position;
            txtCMND.Enabled = false;    //ta không cho phép sửa CMND.
            panelControl2.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = false;
            btnLuu.Enabled = btnPhucHoi.Enabled = true;
            gcKH.Enabled = false;
            check_Luu_HieuChinh = 2;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtCMND.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                txtCMND.Focus();
                return;
            }
            if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                txtHo.Focus();
                return;
            }
            if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                txtTen.Focus();
                return;
            }
            if (txtPhai.Text.Trim() == "")
            {
                MessageBox.Show("Phái nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                txtPhai.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return;
            }
            if (dtpNgayCap.Text.Trim() == "")
            {
                MessageBox.Show("Ngày cấp không được thiếu!", "", MessageBoxButtons.OK);
                dtpNgayCap.Focus();
                return;
            }

            // Số điện thoại cho phép null.

            if (check_Luu_HieuChinh == 1)    // Nếu chọn btn thêm thì ta chạy SP kiểm tra có trùng CMND hay không.
            {
                string strLenh = "EXEC SP_TimKH_tu_CMND '" + txtCMND.Text + "'";
                try { 
                    checkCMND = Program.ExecSqlDataReader(strLenh);
                    checkCMND.Read();

                    if (checkCMND.GetBoolean(0))   //đã tồn tại cmnd trùng.
                    {
                        MessageBox.Show("Chứng minh nhân dân bị trùng.", "", MessageBoxButtons.OK);
                        txtCMND.Focus();
                        checkCMND.Close();
                        return;
                    }
                    else
                    {
                        bdsKH.EndEdit();    // kết thúc quá trình tạo. -> Ghi vào trong bds.
                        bdsKH.ResetCurrentItem();   //Đưa những thông tin đó lên lưới.
                        this.KHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.KHACHHANGTableAdapter.Update(this.DS1.KhachHang); // Update trên adapter có 3 nghĩa: vừa là insert, update, delete. Nó tùy vào tình huống cụ thể để đưa lệnh tương ứng.
                        MessageBox.Show("Thêm thành công!", "", MessageBoxButtons.OK);
                        checkCMND.Close();
                    } 
                }
                catch (Exception ex){
                    checkCMND.Close();
                    MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                try
                {   //dùng cho hiệu chỉnh
                    bdsKH.EndEdit();    // kết thúc quá trình hiệu chỉnh. -> Ghi vào trong bds.
                    bdsKH.ResetCurrentItem();   //Đưa những thông tin đó lên lưới.
                    this.KHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.KHACHHANGTableAdapter.Update(this.DS1.KhachHang); // Update trên adapter có 3 nghĩa: vừa là insert, update, delete. Nó tùy vào tình huống cụ thể để đưa lệnh tương ứng.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi khách hàng.\n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }    

            gcKH.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = true;
            btnLuu.Enabled = btnPhucHoi.Enabled = false;

            panelControl2.Enabled = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Int32 cmnd = 0;
            if (bdsTK.Count > 0)
            {
                MessageBox.Show("Không thể xóa khách hàng này vì đã có tài khoản!!!", "",
                    MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa khách hàng này ??", "Xác nhận",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    cmnd = int.Parse(((DataRowView)bdsKH[bdsKH.Position])["CMND"].ToString());  // Giữ lại cmnd hiện tại đang đứng để nếu xóa ở máy hiện tại thành công mà xóa ở CSDL thất bại thì ta sẽ fill data về lại máy và nhờ cmnd đó thì con trỏ nó sẽ nhảy đến cmnd vừa xóa.
                    bdsKH.RemoveCurrent();  // Xóa trên máy hiện tại trước, sau đó mới xóa trên CSDL sau.
                    this.KHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.KHACHHANGTableAdapter.Update(this.DS1.KhachHang); // xóa dữ liệu đó ở CSDL.
                }
                catch (Exception ex)    // Trong thực tế sẽ có lỗi phát sinh mà thầy Thư cũng không biết.
                {
                    MessageBox.Show("Lỗi xóa nhân viên. Bạn hãy xóa lại\n" + ex.Message, "",
                        MessageBoxButtons.OK);
                    this.KHACHHANGTableAdapter.Fill(this.DS1.KhachHang);   // Trường hợp xóa ở máy hiện tạo thành công nhưng xóa trên CSDL bị lỗi thì ta phải tải về lại máy hiện tại.
                    bdsKH.Position = bdsKH.Find("CMND", cmnd);  // đưa con trỏ nhảy đến vị trí manv đã xóa thất bại trước đó.
                    return;
                }
            }
            if (bdsKH.Count == 0) btnXoa.Enabled = false;   // trường hợp ta xóa hết khách hàng hoặc trong Grid không có ai thì ta làm mờ nút xóa đi. Nếu không nó sẽ báo lỗi ở dòng code 92 là khi ta lấy cmnd trước khi xóa ra thì bdsKH.Position không tìm thấy vị trí nào thì nó báo lỗi.
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsKH.CancelEdit();
            this.KHACHHANGTableAdapter.Fill(this.DS1.KhachHang);    // ta tải lại vì khi chọn thêm, sau đó phục hồi thì trên grild vẫn xuất hiện 1 ô trắng do ta chưa load lên lại vào grild.
            if (btnThem.Enabled == false) bdsKH.Position = vitri;   //nếu trường hợp đã bấm nút Thêm thì ta sẽ nhảy về lại vị trí trước đó.
            gcKH.Enabled = true;
            panelControl2.Enabled = false;
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = true;
            btnLuu.Enabled = btnPhucHoi.Enabled = false;
        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.KHACHHANGTableAdapter.Fill(this.DS1.KhachHang);   // tải lại Khách hàng.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Tải lại danh sách nhân viên: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;  //Kiểm tra cmb này đã có số liệu hay chưa.Trong thực tế có trường hợp mới mở form lên thì nó tự chạy rồi.Nhưng khi nó chạy mã mình vẫn chưa chọn gì thì sẽ báo lỗi.
            Program.servername = cmbChiNhanh.SelectedValue.ToString();

            if (cmbChiNhanh.SelectedIndex != Program.mChinhanh)  //nếu ta chọn chi nhánh khác với chi nhánh ở thời điểm đăng nhập thì ta sẽ dùng tk HTKN;
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if (Program.KetNoi() == 0)
                MessageBox.Show("Lỗi kết nối về chi nhánh mới!", "", MessageBoxButtons.OK);
            else
            {
                this.KHACHHANGTableAdapter.Connection.ConnectionString = Program.connstr;    // gán thông tin đăng nhập vào các Adapter tương ứng để fill lấy thông tin đúng với thông tin đăng nhập.
                this.KHACHHANGTableAdapter.Fill(this.DS1.KhachHang);
                this.TAIKHOANTableAdapter.Connection.ConnectionString = Program.connstr;
                this.TAIKHOANTableAdapter.Fill(this.DS1.TaiKhoan);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtCMND.Enabled = true; // Vì khi ta hiệu chỉnh thì không cho phép sửa CMND -> nên ta khóa bên Hiệu Chỉnh -> Qua Thêm thì ta phải mở ra lại.
            vitri = bdsKH.Position; //Giữ lại vị trí khách hàng mà chúng ta đang đứng -> dùng trong phục hồi và thêm.
            panelControl2.Enabled = true;
            bdsKH.AddNew();
            txtMaCN.Text = macn;
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = false;
            btnLuu.Enabled = btnPhucHoi.Enabled = true;
            gcKH.Enabled = false;
            check_Luu_HieuChinh = 1;
        }

        private void khachHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS1);

        }
    }
}
