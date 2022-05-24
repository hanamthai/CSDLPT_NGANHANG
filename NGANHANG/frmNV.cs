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
    public partial class frmNV : Form
    {
        int vitri = 0;
        string macn = "";
        int check_Luu_HieuChinh = 0;    // Nếu chọn btnThem thì ta gán = 1, nếu btnHieuChinh thì ta gán = 2. Mục đích là để biết ta chọn btnThem hay không để chạy SP kiểm tra mã nv bị trùng.
        private SqlDataReader checkMaNV;
        public frmNV()
        {
            InitializeComponent();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMaNV.Enabled = true; // Vì khi ta hiệu chỉnh thì không cho phép sửa mã -> nên ta khóa bên Hiệu Chỉnh -> Qua Thêm thì ta phải mở ra lại.
            vitri = bdsNV.Position; //Giữ lại vị trí nhân viên mà chúng ta đang đứng -> dùng trong phục hồi và thêm.
            panelControl2.Enabled = true;
            bdsNV.AddNew();
            txtMaCN.Text = macn;
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = btnInDSNV.Enabled = false;
            btnLuu.Enabled = btnPhucHoi.Enabled = true;
            gcNhanVien.Enabled = false;
            check_Luu_HieuChinh = 1;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)  // Có 2 trường hợp: Thêm, Sửa.
        {
            bdsNV.CancelEdit();
            if (btnThem.Enabled == false) bdsNV.Position = vitri;   //nếu trường hợp đã bấm nút Thêm thì ta sẽ nhảy về lại vị trí trước đó.
            gcNhanVien.Enabled = true;
            panelControl2.Enabled = false;
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = btnInDSNV.Enabled = true;
            btnLuu.Enabled = btnPhucHoi.Enabled = false;
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsNV.Position;
            txtMaNV.Enabled = false;    //ta không cho phép sửa mã nhân viên.
            panelControl2.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = btnInDSNV.Enabled = false;
            btnLuu.Enabled = btnPhucHoi.Enabled = true;
            gcNhanVien.Enabled = false;
            check_Luu_HieuChinh = 2;
        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.NHANVIENTableAdapter.Fill(this.DS.NhanVien);   // tải lại Nhân Viên.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Tải lại danh sách nhân viên: " + ex.Message,"",MessageBoxButtons.OK);
                return;
            }
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Int32 manv = 0;
            if(bdsChuyenTien.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập GIAO DỊCH CHUYỂN TIỀN","",
                    MessageBoxButtons.OK);
                return;
            }
            if (bdsGuiRut.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập GIAO DỊCH GỬI RÚT","",
                    MessageBoxButtons.OK);
                return;
            }
            if(MessageBox.Show("Bạn có thật sự muốn xóa nhân viên này ??","Xác nhận",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    manv = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString());  // Giữ lại mã nhân viên hiện tại đang đứng để nếu xóa ở máy hiện tại thành công mà xóa ở CSDL thất bại thì ta sẽ fill data về lại máy và nhờ manv đó thì con trỏ nó sẽ nhảy đến manv vừa xóa.
                    bdsNV.RemoveCurrent();  // Xóa trên máy hiện tại trước, sau đó mới xóa trên CSDL sau.
                    this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.NHANVIENTableAdapter.Update(this.DS.NhanVien); // xóa dữ liệu đó ở CSDL.

                    // Gọi sp xóa tài khoản login nếu có
                }
                catch (Exception ex)    // Trong thực tế sẽ có lỗi phát sinh mà thầy Thư cũng không biết.
                {
                    MessageBox.Show("Lỗi xóa nhân viên. Bạn hãy xóa lại\n" + ex.Message,"",
                        MessageBoxButtons.OK);
                    this.NHANVIENTableAdapter.Fill(this.DS.NhanVien);   // Trường hợp xóa ở máy hiện tạo thành công nhưng xóa trên CSDL bị lỗi thì ta phải tải về lại máy hiện tại.
                    bdsNV.Position = bdsNV.Find("MANV", manv);  // đưa con trỏ nhảy đến vị trí manv đã xóa thất bại trước đó.
                    return;
                }
            }
            if (bdsNV.Count == 0) btnXoa.Enabled = false;   // trường hợp ta xóa hết nhân viên hoặc trong Grid không có ai thì ta làm mờ nút xóa đi. Nếu không nó sẽ báo lỗi ở dòng code 93 là khi ta lấy manv trước khi xóa ra thì bdsNV.Position không tìm thấy vị trí nào thì nó báo lỗi.
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaNV.Text.Trim() == "")  
            {
                MessageBox.Show("Mã nhân viên không được thiếu!","",MessageBoxButtons.OK);
                txtMaNV.Focus();
                return;
            }
            if(txtHo.Text.Trim() == "")
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
            // Có thể thiếu SĐT vì nó cho phép null.
            // Gọi SP kiểm tra mã nhân viên có bị trùng trong CSDL hay không? (SP_TimNV_tu_MANV)

            /*string strLenh = "EXEC SP_TimNV_tu_MANV '" + txtMaNV.Text + "'";
            checkMaNV = Program.ExecSqlDataReader(strLenh);
            if (checkMaNV == null)   // Không tồn tại manv đó trong CSDL.
            {
                MessageBox.Show("Mã nhân viên đã bị trùng. Vui lòng nhập lại!", "", MessageBoxButtons.OK);
                txtMaNV.Focus();
                return;
            }*/

            // ERROR : Khi gọi SP để kiểm tra mã nhân viên có bị trùng hay không thì ta gặp một trường hợp là nút lưu này là lưu cả cho thêm và 
            //lưu cả cho hiệu chỉnh trong khi đó thì phần hiệu chỉnh có thể trùng mã nhân viên, còn thêm nv thì khi tạo không được trùng mã nv.
            // Vậy thì làm sao để ta biết khi nào thì tạo tài khoản khi nào thì hiệu chỉnh????
                if (check_Luu_HieuChinh == 1)    // Nếu chọn btn thêm thì ta chạy SP kiểm tra có trùng mã nv hay không.
                {
                    string strLenh = "EXEC SP_TimNV_tu_MANV '" + txtMaNV.Text + "'";
                    checkMaNV = Program.ExecSqlDataReader(strLenh);
                    if(checkMaNV != null)   //đã tồn tại mã nv trùng.
                    {
                        MessageBox.Show("Mã nhân viên bị trùng.", "", MessageBoxButtons.OK);
                        txtMaNV.Focus();
                        checkMaNV.Close();
                    return;
                    }
                }
            
            try
            {
                bdsNV.EndEdit();    // kết thúc quá trình hiệu chỉnh. -> Ghi vào trong bds.
                bdsNV.ResetCurrentItem();   //Đưa những thông tin đó lên lưới.
                this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.NHANVIENTableAdapter.Update(this.DS.NhanVien); // Update trên adapter có 3 nghĩa: vừa là insert, update, delete. Nó tùy vào tình huống cụ thể để đưa lệnh tương ứng.
            }
            catch (Exception ex)
            {
                /*if (ex.Message.Contains("PRIMARY")) {
                    MessageBox.Show("Mã nhân viên bị trùng.\n" + ex.Message, "", MessageBoxButtons.OK);  // ERROR: Nếu bị trùng mã nv ở site khác thì không báo lỗi. Suy nghĩ mãi nhưng chưa khắc phục được.
                    txtMaNV.Focus();
                } 
                else*/
                MessageBox.Show("Lỗi ghi nhân viên.\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            gcNhanVien.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = btnInDSNV.Enabled = true;
            btnLuu.Enabled = btnPhucHoi.Enabled = false;

            panelControl2.Enabled = false;
        }

        private void frmNV_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false; // bỏ kiểm tra khóa ngoại STK.
            // TODO: This line of code loads data into the 'dS.NhanVien' table. You can move, or remove it, as needed.
            this.NHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;    // gán thông tin đăng nhập vào các Adapter tương ứng để fill lấy thông tin đúng với thông tin đăng nhập.
            this.NHANVIENTableAdapter.Fill(this.DS.NhanVien);
            // TODO: This line of code loads data into the 'DS.GD_CHUYENTIEN' table. You can move, or remove it, as needed.
            this.gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_CHUYENTIENTableAdapter.Fill(this.DS.GD_CHUYENTIEN);
            // TODO: This line of code loads data into the 'DS.GD_GOIRUT' table. You can move, or remove it, as needed.
            this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_GOIRUTTableAdapter.Fill(this.DS.GD_GOIRUT);

            macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
            cmbChiNhanh.DataSource = Program.bds_dspm;  //sao chép dspm đã load ở form đăng nhập.
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChinhanh;
            if(Program.mGroup == "NGANHANG")
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

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        
    }
}
