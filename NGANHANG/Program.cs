using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace NGANHANG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static SqlConnection conn = new SqlConnection(); //SqlConnection class thuộc namespace System.Data.SqlClient và được sử dụng để kết nối mở đến CSDL SQL Server.
        public static String connstr;
        public static String connstr_publisher = "Data Source=SERA;Initial Catalog=NGANHANG;Integrated Security=True";
        //public static String connstr_publisher = "Data Source=DESKTOP-P1FGHF2;Initial Catalog=NGANHANG; User ID=sa;Password=123";

        public static SqlDataReader myReader;
        public static String servername = "";
        public static String username = "";
        public static String mlogin = "";
        public static String password = "";

        public static String database = "NGANHANG";
        public static String remotelogin = "HTKN";
        public static String remotepassword = "123";
        public static String mloginDN = "";
        public static String passwordDN = "";
        public static String mGroup = "";
        public static String mHoten = "";
        public static int mChinhanh = 0;

        public static BindingSource bds_dspm = new BindingSource(); //giữ bds phân mảnh khi đăng nhập -> chứa TENCN và TENSEVER của V_Get_Subscribes. Từ lúc đăng nhập thành công đến lúc kết thúc.

        public static frmMain frmChinh; // con trỏ frmChinh.

        public static int KetNoi()
        {
            if (Program.conn != null && Program.conn.State == System.Data.ConnectionState.Open) 
                Program.conn.Close();
            try
            {
                Program.connstr = "Data Source=" + Program.servername + ";Initial Catalog=" + Program.database + ";User ID=" +
                      Program.mlogin + ";password=" + Program.password;
                Program.conn.ConnectionString = Program.connstr;
                Program.conn.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        public static SqlDataReader ExecSqlDataReader(String strLenh) { // thực thi câu lệnh và trả về dưới dạng DataReader.
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, Program.conn);
            sqlcmd.CommandType = CommandType.Text;
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            try { 
                myreader=sqlcmd.ExecuteReader(); 
                return myreader;
            }
            catch (SqlException ex) { 
                Program.conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static DataTable ExecsqlDataTable(String cmd) { 
            DataTable dt = new DataTable();
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();  //Khởi tạo một instance mới của class SqlDataAdapter bằng một lệnh và một chuỗi kết nối.đây là kho lưu trữ dữ liệu trong bộ nhớ. Có thể lưu trữ các bảng giống như một cơ sở dữ liệu.
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);  //SqlDataAdapter trong C# hoạt động như một cầu nối giữa DataSet và CSDL SQL Server để truy xuất dữ liệu. 
            da.Fill(dt);    // Giống với DataReader nhưng khác một chỗ là ta tải về bằng Fill.
            conn.Close();   // Nó cung cấp phương thức Fill(Dataset) được sử dụng để thêm các hàng trong DataSet sao cho khớp với các hàng trong CSDL.
            return dt;
        }

        public static int ExecSqlNonQuery(String strLenh) {

            SqlCommand Sqlcmd = new SqlCommand(strLenh, conn);
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 600;// 10 phut  -- Những câu lệnh thực thi mà không truy vấn có khả năng làm tự động hàng loạt ở bên CSDL(backup,restore) có thể nó sẽ quá thời gian mặc định 60s.
            if (conn.State == ConnectionState.Closed) conn.Open();
            try {
                Sqlcmd.ExecuteNonQuery(); conn.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return ex.State;// trang thai lỗi gói từ RAISERROR trong SQL Server qua -> Message.
            }
        }
    [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmChinh = new frmMain();   // frmChinh là một đối tượng của frmMain
            Application.Run(frmChinh);
            //Application.Run(new frmMain());
            //Tại sao không chạy thẳng frmMain mà phải tạo ra frm chính?
            //-> Vì giữa frmDangNhap và frmMain sẽ có sự trao đổi data với nhau. Ở frmDangNhap khi ta lấy về MANV,HOTEN,NHOM thì ta phải
            //gửi số liệu đó về frmMain để nó hiển thị -> ta phải có tên đối tượng để ta gọi -> tạo ra frmChinh. 
        }
    }
}
