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
    public partial class fmdoimk : Form
    {
        public fmdoimk()
        {
            InitializeComponent();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Bước 1: Khởi tạo kết nối
                string con_str = @"Initial Catalog=QLMT; User ID=sa; Password=123456;"; // 
                SqlConnection conn = new SqlConnection(con_str);
                // Bước 2: Khởi tạo truy vấn
                string query = "Select * from Nguoidung where Taikhoan=@Taikhoan ";
                string tk = txttimkiem.Text;
                // Bước 3: Tạo sqlDataAdapter
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.Add(new SqlParameter("@Taikhoan", tk));
                // Bước 4: Đổ dữ liệu lên DataSet
                DataSet ds = new DataSet();
                da.Fill(ds, "Nguoidung");

                // Hiển thị dữ liệu lên GridView
                dgvtkmk.DataSource = ds.Tables["Nguoidung"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            
        }
        private void clear()
        {
            txttimkiem.Text = "";
            txttk.Text = "";
            txtmk.Text = "";
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void dgvtkmk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvtkmk.CurrentRow.Index;
            txttk.Text = dgvtkmk.Rows[i].Cells[0].Value.ToString();
            txtmk.Text = dgvtkmk.Rows[i].Cells[1].Value.ToString();
        }

        private void btndmk_Click(object sender, EventArgs e)
        {
            try
            {
                // Bước 1: Khởi tạo kết nối
                string con_str = @"Initial Catalog=QLMT; User ID=sa; Password=123456;";
                SqlConnection conn = new SqlConnection(con_str);
                // Bước 2: Mở kết nối
                conn.Open();
                // Bước 3: Khởi tạo truy vấn
                string query = "update Nguoidung set Taikhoan=@Taikhoan , Matkhau=@Matkhau where Taikhoan=@Taikhoan";
                // Bước 4: Thực thi truy vấn
                SqlCommand cmd = new SqlCommand(query, conn);

                
                cmd.Parameters.Add(new SqlParameter("@Taikhoan", txttk.Text));
                cmd.Parameters.Add(new SqlParameter("@Matkhau", txtmk.Text));
                
                cmd.ExecuteNonQuery();
                // Bước 5: Đóng kết nối
                conn.Close();

                MessageBox.Show("Đổi mật Khẩu thành công!");
                // Hiển thị dữ liệu mới lên GridView


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {

                string con_str = @"Initial Catalog=QLMT; User ID=sa; Password=123456;";
                SqlConnection conn = new SqlConnection(con_str);
                // Bước 2: Mở kết nối
                conn.Open();
                // Bước 3: Khởi tạo truy vấn
                string query = "Delete from Nguoidung where Taikhoan = @Taikhoan";
                // Bước 4: Thực thi truy vấn
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@Taikhoan", txttk.Text));
                // -- Chọn phương thức thực thi phù hợp với truy vấn
                cmd.ExecuteNonQuery();
                // Bước 5: Đóng kết nối
                conn.Close();

                MessageBox.Show("Xóa Tài khoản thành công!");
                // Hiển thị dữ liệu mới lên GridView

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
