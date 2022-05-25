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
using System.Diagnostics;
using NGANHANG.Lib;

namespace NGANHANG
{
    public partial class frmDangNhap : Form
    {
        private static SqlConnection conn_publisher = new SqlConnection();

        public frmDangNhap()
        {
            InitializeComponent();
        }
        public static int KetNoi_CSDLGOC()
        {
            if (conn_publisher != null && conn_publisher.State == System.Data.ConnectionState.Open)
                conn_publisher.Close();   // Khi ta mở sever và tải dữ liệu về thì trong vòng từ 5-10s nó sẽ tự đóng -> trong trường hợp ta kiểm tra mà sever vẫn mở nhưng khi tải dữ liệu về thì nó sẽ tự động đóng gây ra lỗi. 
            try
            {
                conn_publisher.ConnectionString = Program.connstr_publisher;   // gán Tên sever + tên DB từ connstr_publisher vào ConnectionString.
                conn_publisher.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối về cơ sở dữ liệu gốc.\nBạn xem lại Tên sever của publisher và tên CSDL trong chuỗi kết nối.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        private void LayDSPM(String cmd)
        {
            DataTable dt = new DataTable(); //trả về một data table.
            if (conn_publisher.State == ConnectionState.Closed) conn_publisher.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn_publisher); // Tạo ra một đối tượng thuộc lớp SqlDataAdapter có 2 tham số là chuỗi lệnh và đối tượng SqlConnection.
            da.Fill(dt);    // Muốn tải số liệu từ View,Table từ DataAdapter vào DataTable thì ta dùng Fill -> dt sẽ chứa các danh sách phân mảnh.
            conn_publisher.Close();

            Program.bds_dspm = new BindingSource();
            Program.bds_dspm.DataSource = dt;   // ta gán dspm đó cho bds_dspm ở Program.    // Liên kết số liệu bds_dspm với cmd

            cmbChiNhanh.DataSource = Program.bds_dspm;  // gán bds_dspm ở Program cho DataSource ở cmbChiNhanh. //
            cmbChiNhanh.DisplayMember = "TENCN"; cmbChiNhanh.ValueMember = "TENSERVER";
        }
        

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            if (KetNoi_CSDLGOC() == 0) return; // nếu hàm KetNoi_CSDLGOC() == 0 -> đăng nhập thất bại
            LayDSPM("SELECT * FROM V_Get_Subscribes");  // Lấy ra danh sách các phân mảnh từ V_Get_Subscribles.
            cmbChiNhanh.SelectedIndex = 1;cmbChiNhanh.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e){}

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)   //sự kiện này xảy ra khi cmb được chọn giá trị mới.
        {
            try
            {
                Program.servername = cmbChiNhanh.SelectedValue.ToString();   // Lấy Value Member gán vào severname của Program.
                // Trong Value Member thuộc tính chứa giá trị trên đó -> SelectedValue
                // Trong Display Member thuộc tính chứa giá trị trên đó -> Text
            }
            catch (Exception) { }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim() == "" || txtPass. Text. Trim() == "") {    // hàm Trim để xóa khoảng trắng 2 bên.
                MessageBox.Show("Login name và mật mā không được trống", "", MessageBoxButtons.OK);
                return;
            }
            Program.mlogin = txtLogin.Text; Program.password = txtPass.Text;
            if (Program.KetNoi() == 0) return;
            Program.mChinhanh = cmbChiNhanh.SelectedIndex;  //Nếu đăng nhập thành công thì ta sẽ giữ lại thông tin vừa đăng nhập như chi nhánh nào.
            Program.mloginDN = Program.mlogin;              //tài khoản đăng nhập thành công.   -> sẽ còn dùng cho những form sau này.
            Program.passwordDN = Program.password;          //mật khẩu đăng nhập thành công.

            // Setup DbConnection
            DbConnection.SetDefaultConnectionString($"Data Source={Program.servername};Initial Catalog={Program.database};User ID={Program.mlogin};password={Program.password}");

            /*Debug.WriteLine(Program.mlogin);
            Debug.WriteLine(Program.password);*/
            string strLenh = "EXEC SP_Lay_Thong_Tin_NV_Tu_Login '" + Program.mlogin + "'";
            //Debug.WriteLine(strLenh);
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null || !Program.myReader.HasRows) {
                MessageBox.Show("Bạn không có quyền truy cập!", "", MessageBoxButtons.OK);
                return;   //nếu bằng null có nghĩa là không lấy được thông tin nhân viên -> kết thúc.  
            } 
            Program.myReader.Read();    // Khi thực thi xong SP_Lay_Thong... thì nó chỉ trả ra 1 hàng nên ta chỉ cần Read() 1 lần. Nếu nhiều hàng thì ta phải tạo ra một vòng lặp và lặp cho đến khi Read()==null để lấy ra.

            Program.username = Program.myReader.GetString(0); // Lay user name      //GetString(0) là cột đầu tiên chứa MANV.
            Debug.WriteLine("");
            if (Convert.IsDBNull(Program.username)) {
                MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn xem lại username, password", "", MessageBoxButtons.OK);
                return;
            }
            Program.mHoten = Program.myReader.GetString(1); //GetString(1) chứa HOTEN
            Program.mGroup = Program.myReader.GetString(2); //GetString(2) chứa NHOM
            Program.myReader.Close();
            Program.conn.Close();
            Program.frmChinh.MANV.Text = "Mã NV = " +Program.username;
            Program.frmChinh.HOTEN.Text = "Họ tên = " + Program.mHoten;
            Program.frmChinh.NHOM.Text = "Nhóm = "+Program.mGroup;
            Program.frmChinh.HienThiMenu();

            Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
