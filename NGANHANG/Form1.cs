using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGANHANG
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;   //nếu frmMain đã tồn tại thì trả về f, không thì trả về null.
            return null;
        }
        private void btn_DangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDangNhap));
            if (frm != null) frm.Activate();
            else
            {
                frmDangNhap f = new frmDangNhap();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void btn_GuiRut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frm_GuiRut));
            if (frm != null) frm.Activate();
            else
            {
                frm_GuiRut f = new frm_GuiRut();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btn_ChuyenTien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frm_ChuyenTien));
            if (frm != null) frm.Activate();
            else
            {
                frm_ChuyenTien f = new frm_ChuyenTien();
                f.MdiParent = this;
                f.Show();
            }
        }
        public void HienThiMenu()
        {
            MANV.Text = "Mã NV: " + Program.username;
            HOTEN.Text = "; Họ tên: " + Program.mHoten;
            NHOM.Text = "; Nhóm: " + Program.mGroup;
            // Phân quyền
            rib_BaoCao.Visible = rib_DanhMuc.Visible = rib_NghiepVu.Visible = true;
            // tiếp tục if trên Program.mGroup để bật/tắt các nút lệnh trên menu chính
            if(Program.mGroup == "NGANHANG")
            {
                btn_GuiRut.Enabled = false;
                btn_ChuyenTien.Enabled = false;
            }
            if(Program.mGroup == "CHINHANH")
            {
                btn_SaoKe.Enabled = false;
                btn_LietKeTK.Enabled = false;
                btn_LietKeKH.Enabled = false;
            }
        }
            private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btn_NhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmNV));
            if (frm != null) frm.Activate();
            else
            {
                frmNV f = new frmNV();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btn_TaoTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Program.mlogin == "")
            {
                MessageBox.Show("Bạn phải đăng nhập trước khi tạo tài khoản!", "", MessageBoxButtons.OK);
                return;
            }
            return;
        }

        private void btn_DangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mlogin == "")
            {
                MessageBox.Show("Bạn phải đăng nhập trước khi đăng xuất!", "", MessageBoxButtons.OK);
                return;
            }
            return;
        }
    }
}
