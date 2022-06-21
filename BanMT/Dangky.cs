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

namespace BanMT
{
    public partial class fmdangky : Form
    {
        public fmdangky()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

        }

        private void btndk_Click(object sender, EventArgs e)
        {
            try
            {
                // Bước 1: Khởi tạo kết nối
                string con_str = @"Initial Catalog=QLMT; User ID=sa; Password=123456;";
                SqlConnection conn = new SqlConnection(con_str);
                // Bước 2: Mở kết nối
                conn.Open();
                // Bước 3: Khởi tạo truy vấn
                string query = "insert into Nguoidung(Taikhoan,Matkhau)VALUES(@Taikhoan, @Matkhau)";
                // Bước 4: Thực thi truy vấn
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@Taikhoan", txttk.Text));
                cmd.Parameters.Add(new SqlParameter("@Matkhau", txtmk.Text));
                cmd.ExecuteNonQuery();
                // Bước 5: Đóng kết nối
                conn.Close();

                MessageBox.Show("Đăng Ký Thành Công :)");
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            clearTextdk();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Close();
           
        }
        public void clearTextdk()
        {
            

            txttk.Text = "";
            txtmk.Text = "";
            
        }
    }
}
