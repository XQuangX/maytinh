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
    public partial class fmkhachhang : Form
    {
        public fmkhachhang()
        {
            InitializeComponent();
        }
        private void ketnoicsdl()
        {
            try
            {
                SqlConnection cnn = new SqlConnection(@"Initial Catalog=QLMT; User ID=sa; Password=123456;");
                cnn.Open();
                string sql = "select * from Khachhang";  // lay het du lieu trong bang sinh vien
                SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dt);  // đổ dữ liệu vào kho
                cnn.Close();  // đóng kết nối
                dgvkhachhang.DataSource = dt; //đổ dữ liệu vào datagridview
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
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
                string query = "insert into Khachhang(Makh,Tenkh,Diachi,SDT)VALUES(@Makh,@Tenkh,@Diachi,@SDT)";
                // Bước 4: Thực thi truy vấn
                SqlCommand cmd = new SqlCommand(query, conn);

                //int SDT = int.Parse(txtsdt.Text);
                cmd.Parameters.Add(new SqlParameter("@Makh", txtmakh.Text));
                cmd.Parameters.Add(new SqlParameter("@Tenkh", txttenkh.Text));
                
                cmd.Parameters.Add(new SqlParameter("@Diachi", txtdiachi.Text));

                cmd.Parameters.Add(new SqlParameter("@SDT", mtbsdt.Text));
                

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

        private void btndong_Click(object sender, EventArgs e)
        {
            Close();
            Hethong frm = new Hethong();
            frm.Show();
        }

        private void dgvkhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnthem.Enabled = false;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            int i = dgvkhachhang.CurrentRow.Index;
            txtmakh.Text = dgvkhachhang.Rows[i].Cells[0].Value.ToString();
            txttenkh.Text = dgvkhachhang.Rows[i].Cells[1].Value.ToString();
            txtdiachi.Text = dgvkhachhang.Rows[i].Cells[2].Value.ToString();
            mtbsdt.Text = dgvkhachhang.Rows[i].Cells[3].Value.ToString();
            
        }
        private void clearText()
        {
            txtmakh.Text = "";
            txttenkh.Text = "";
            txtdiachi.Text = "";
            mtbsdt.Text = "";

        }

        private void fmkhachhang_Load(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            ketnoicsdl();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            clearText();
            btnthem.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
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
                string query = "update Khachhang set Makh=@Makh,Tenkh=@Tenkh,Diachi=@Diachi,SDT=@SDT where Makh=@Makh";
                // Bước 4: Thực thi truy vấn
                SqlCommand cmd = new SqlCommand(query, conn);

                //int SDT = int.Parse(txtsdt.Text);
                cmd.Parameters.Add(new SqlParameter("@Makh", txtmakh.Text));
                cmd.Parameters.Add(new SqlParameter("@Tenkh", txttenkh.Text));
                cmd.Parameters.Add(new SqlParameter("@Diachi", txtdiachi.Text));

                cmd.Parameters.Add(new SqlParameter("@SDT", mtbsdt.Text));
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
                string query = "Delete from Khachhang where Makh = @Makh";
                // Bước 4: Thực thi truy vấn
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@Makh", txtmakh.Text));
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
    }
}
