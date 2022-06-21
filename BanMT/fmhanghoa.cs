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
    public partial class fmhanghoa : Form
    {
        public fmhanghoa()
        {
            InitializeComponent();
        }
        
        private void ketnoicsdl()
        {
            try
            {
                SqlConnection cnn = new SqlConnection(@"Initial Catalog=QLMT; User ID=sa; Password=123456;");
                cnn.Open();
                string sql = "select * from Hang";  // lay het du lieu trong bang sinh vien
                SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
                SqlCommand cmd = new SqlCommand("Nhacungcap", cnn);
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dt);  // đổ dữ liệu vào kho
                
                cnn.Close();  // đóng kết nối
                dgvhanghoa.DataSource = dt; //đổ dữ liệu vào datagridview
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
         void loadcombox()
        {
            SqlConnection cnn = new SqlConnection(@"Initial Catalog=QLMT; User ID=sa; Password=123456;");
            cnn.Open();
            var cmd = new SqlCommand("Select Tenncc from Nhacungcap", cnn);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cboncc.DisplayMember = "Tenncc";
            cboncc.DataSource = dt;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                // Bước 1: Khởi tạo kết nối
                string con_str = @"Initial Catalog=QLMT; User ID=sa; Password=123456;";
                SqlConnection conn = new SqlConnection(con_str);
                // Bước 2: Mở kết nối
                conn.Open();
                // Bước 3: Khởi tạo truy vấn
                string query = "insert into Hang(Mahang,Tenhang,Soluong,Gianhap,Giaban,NCC)VALUES(@Mahang,@Tenhang,@Soluong,@Gianhap,@Giaban,@NCC)";
                // Bước 4: Thực thi truy vấn
                SqlCommand cmd = new SqlCommand(query, conn);

                //int SDT = int.Parse(txtsdt.Text);
                cmd.Parameters.Add(new SqlParameter("@Mahang", txtmah.Text));
                cmd.Parameters.Add(new SqlParameter("@Tenhang", txttenh.Text));
                cmd.Parameters.Add(new SqlParameter("@Soluong", txtsl.Text));
                cmd.Parameters.Add(new SqlParameter("@Gianhap", txtnhap.Text));

                cmd.Parameters.Add(new SqlParameter("@Giaban", txtban.Text));
                cmd.Parameters.Add(new SqlParameter("@NCC", cboncc.Text));

                cmd.ExecuteNonQuery();
                // Bước 5: Đóng kết nối
                conn.Close();

                MessageBox.Show("Thêm mới thành công!");
                // Hiển thị dữ liệu mới lên GridView


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            ketnoicsdl();
            clearText();
        }
        private void clearText()
        {
            txtmah.Text = "";
            txttenh.Text = "";
            txtsl.Text = "";
            txtnhap.Text = "";
            txtban.Text = "";
            cboncc.Text = "";
        }

        private void fmhanghoa_Load(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            ketnoicsdl();
            loadcombox();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                // Bước 1: Khởi tạo kết nối
                string con_str = @"Initial Catalog=QLMT; User ID=sa; Password=123456;";
                SqlConnection conn = new SqlConnection(con_str);
                // Bước 2: Mở kết nối
                conn.Open();
                // Bước 3: Khởi tạo truy vấn
                string query = "update Hang set Mahang=@Mahang,Tenhang=@Tenhang,Soluong=@Soluong,Gianhap=@Gianhap,Giaban=@Giaban,NCC=@NCC where Mahang=@Mahang";
                // Bước 4: Thực thi truy vấn
                SqlCommand cmd = new SqlCommand(query, conn);

                //int SDT = int.Parse(txtsdt.Text);
                cmd.Parameters.Add(new SqlParameter("@Mahang", txtmah.Text));
                cmd.Parameters.Add(new SqlParameter("@Tenhang", txttenh.Text));
                cmd.Parameters.Add(new SqlParameter("@Soluong", txtsl.Text));
                cmd.Parameters.Add(new SqlParameter("@Gianhap", txtnhap.Text));

                cmd.Parameters.Add(new SqlParameter("@Giaban", txtban.Text));
                cmd.Parameters.Add(new SqlParameter("@NCC", cboncc.Text));
                cmd.ExecuteNonQuery();
                // Bước 5: Đóng kết nối
                conn.Close();

                MessageBox.Show("Sửa thành công!");
                // Hiển thị dữ liệu mới lên GridView


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            ketnoicsdl();
            clearText();
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
                string query = "Delete from Hang where Mahang = @Mahang";
                // Bước 4: Thực thi truy vấn
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@Mahang", txtmah.Text));
                // -- Chọn phương thức thực thi phù hợp với truy vấn
                cmd.ExecuteNonQuery();
                // Bước 5: Đóng kết nối
                conn.Close();

                MessageBox.Show("Xóa thành công!");
                // Hiển thị dữ liệu mới lên GridView

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            ketnoicsdl();
            clearText();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            Close();
            Hethong frm = new Hethong();
            frm.Show();
        }

        private void dgvhanghoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnthem.Enabled = false;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            int i = dgvhanghoa.CurrentRow.Index;
            txtmah.Text = dgvhanghoa.Rows[i].Cells[0].Value.ToString();
            txttenh.Text = dgvhanghoa.Rows[i].Cells[1].Value.ToString();
            txtsl.Text = dgvhanghoa.Rows[i].Cells[2].Value.ToString();
            txtnhap.Text = dgvhanghoa.Rows[i].Cells[3].Value.ToString();
            txtban.Text = dgvhanghoa.Rows[i].Cells[4].Value.ToString();
            cboncc.Text = dgvhanghoa.Rows[i].Cells[5].Value.ToString();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            clearText();
            btnthem.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
        }
    }
}
