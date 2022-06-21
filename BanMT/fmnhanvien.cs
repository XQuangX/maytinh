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
    public partial class fmnhanvien : Form
    {
        public fmnhanvien()
        {
            InitializeComponent();
        }
        private void ketnoicsdl()
        {
            try
            {
                SqlConnection cnn = new SqlConnection(@"Initial Catalog=QLMT; User ID=sa; Password=123456;");
                cnn.Open();
                string sql = "select * from Nhanvien";  // lay het du lieu trong bang sinh vien
                SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dt);  // đổ dữ liệu vào kho
                cnn.Close();  // đóng kết nối
                dgvnhanvien.DataSource = dt; //đổ dữ liệu vào datagridview
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
                string query = "insert into Nhanvien(Manv,Tennv,GT,Diachi,SDT,Ngaysinh)VALUES(@Manv,@Tennv,@GT,@Diachi,@SDT,@Ngaysinh)";
                // Bước 4: Thực thi truy vấn
                SqlCommand cmd = new SqlCommand(query, conn);

                //int SDT = int.Parse(txtsdt.Text);
                cmd.Parameters.Add(new SqlParameter("@Manv", txtmanv.Text));
                cmd.Parameters.Add(new SqlParameter("@Tennv", txttennv.Text));
                cmd.Parameters.Add(new SqlParameter("@GT", cbogt.SelectedItem));
                cmd.Parameters.Add(new SqlParameter("@Diachi", txtdiachi.Text));

                cmd.Parameters.Add(new SqlParameter("@SDT", mtbsdt.Text));
                cmd.Parameters.Add(new SqlParameter("@Ngaysinh", mtbNS.Text));

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
            txtmanv.Text = "";
            txttennv.Text = "";
            cbogt.Text = "";
            txtdiachi.Text = "";
            mtbsdt.Text = "";
            mtbNS.Text = "";

        }


        private void dgvnhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnthem.Enabled = false;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            int i = dgvnhanvien.CurrentRow.Index;
            txtmanv.Text = dgvnhanvien.Rows[i].Cells[0].Value.ToString();
            txttennv.Text = dgvnhanvien.Rows[i].Cells[1].Value.ToString();
            cbogt.Text = dgvnhanvien.Rows[i].Cells[2].Value.ToString();
            txtdiachi.Text = dgvnhanvien.Rows[i].Cells[3].Value.ToString();
            mtbsdt.Text = dgvnhanvien.Rows[i].Cells[4].Value.ToString();
            mtbNS.Text = dgvnhanvien.Rows[i].Cells[5].Value.ToString();
        }

        private void fmnhanvien_Load(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            ketnoicsdl();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            Close();
            Hethong frm = new Hethong();
            frm.Show();
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
                string query = "update Nhanvien set Manv=@Manv,Tennv=@Tennv,GT=@GT,Diachi=@Diachi,SDT=@SDT,Ngaysinh=@Ngaysinh where Manv=@Manv";
                // Bước 4: Thực thi truy vấn
                SqlCommand cmd = new SqlCommand(query, conn);

                //int SDT = int.Parse(txtsdt.Text);
                cmd.Parameters.Add(new SqlParameter("@Manv", txtmanv.Text));
                cmd.Parameters.Add(new SqlParameter("@Tennv", txttennv.Text));
                cmd.Parameters.Add(new SqlParameter("@GT", cbogt.SelectedItem));
                cmd.Parameters.Add(new SqlParameter("@Diachi", txtdiachi.Text));

                cmd.Parameters.Add(new SqlParameter("@SDT", mtbsdt.Text));
                cmd.Parameters.Add(new SqlParameter("@Ngaysinh", mtbNS.Text));
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
                string query = "Delete from Nhanvien where Manv = @Manv";
                // Bước 4: Thực thi truy vấn
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@Manv", txtmanv.Text));
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
