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
    public partial class frmhoadon : Form
    {
        public frmhoadon()
        {
            InitializeComponent();
        }
        private void ketnoicsdl()
        {
            try
            {
                SqlConnection cnn = new SqlConnection(@"Initial Catalog=QLMT; User ID=sa; Password=123456;");
                cnn.Open();
                string sql = "select * from Hoadon";  // lay het du lieu trong bang sinh vien
                SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
                //SqlCommand cmd = new SqlCommand("Nhacungcap", cnn);
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dt);  // đổ dữ liệu vào kho

                cnn.Close();  // đóng kết nối
                dgvhoadon.DataSource = dt; //đổ dữ liệu vào datagridview

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void clearText()
        {
            txtmahd.Text = "";
            cbomanv.Text = "";
            txttennv.Text = "";
            mtbngayban.Text = "";
            cbomakh.Text = "";
            txttenkh.Text = "";
            cbomah.Text = "";
            txttenhang.Text = "";
            txtsl.Text = "";
            txtgiaban.Text = "";
            txttongtien.Text = "";

        }

        private void frmhoadon_Load(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            ketnoicsdl();
            load0();
            load1();
            load2();
            

        }

        private void dgvhoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnthem.Enabled = false;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            int i = dgvhoadon.CurrentRow.Index;
            txtmahd.Text = dgvhoadon.Rows[i].Cells[0].Value.ToString();
            cbomanv.Text = dgvhoadon.Rows[i].Cells[1].Value.ToString();
            mtbngayban.Text = dgvhoadon.Rows[i].Cells[2].Value.ToString();
            cbomakh.Text = dgvhoadon.Rows[i].Cells[3].Value.ToString();
            cbomah.Text = dgvhoadon.Rows[i].Cells[4].Value.ToString();
            txtsl.Text = dgvhoadon.Rows[i].Cells[5].Value.ToString();
            txtgiaban.Text = dgvhoadon.Rows[i].Cells[6].Value.ToString();
            txttongtien.Text = dgvhoadon.Rows[i].Cells[7].Value.ToString();
        }
        private void load0()
        {
            SqlConnection cnn = new SqlConnection(@"Initial Catalog=QLMT; User ID=sa; Password=123456;");
            cnn.Open();
            var cmd = new SqlCommand("Select Manv from Nhanvien", cnn);
            var ap = new SqlDataAdapter(cmd);
            var ds = new DataSet();
            ap.Fill(ds, "Nhanvien");
            cbomanv.DataSource = ds.Tables[0];
            cbomanv.DisplayMember = "Manv";
            cbomanv.ValueMember = "Manv";

        }
        private void load1()
        {
            SqlConnection cnn = new SqlConnection(@"Initial Catalog=QLMT; User ID=sa; Password=123456;");
            cnn.Open();
            var cmdr = new SqlCommand("Select Makh from Khachhang", cnn);
            var apr = new SqlDataAdapter(cmdr);
            var dsr = new DataSet();
            apr.Fill(dsr, "Khachhang");
            cbomakh.DataSource = dsr.Tables[0];
            cbomakh.DisplayMember = "Makh";
            cbomakh.ValueMember = "Makh";

        }
        private void load2()
        {
            SqlConnection cnn = new SqlConnection(@"Initial Catalog=QLMT; User ID=sa; Password=123456;");
            cnn.Open();
            var cmdt = new SqlCommand("Select Mahang from Hang", cnn);
            var apt = new SqlDataAdapter(cmdt);
            var dst = new DataSet();
            apt.Fill(dst, "Hang");
            cbomah.DataSource = dst.Tables[0];
            cbomah.DisplayMember = "Mahang";
            cbomah.ValueMember = "Mahang";

        }
        

        private void cbomanv_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection cnn = new SqlConnection(@"Initial Catalog=QLMT; User ID=sa; Password=123456;");
            cnn.Open();
            var cmd = new SqlCommand("Select Tennv from Nhanvien where Manv='" + cbomanv.SelectedValue.ToString() + "'", cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                txttennv.Text = dr.GetString(0).ToString();
                
            }
        }

        private void cbomakh_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(@"Initial Catalog=QLMT; User ID=sa; Password=123456;");
            cnn.Open();
            var cmdr = new SqlCommand("Select Tenkh from Khachhang where Makh='" + cbomakh.SelectedValue.ToString() + "'", cnn);
            SqlDataReader drr = cmdr.ExecuteReader();
            if (drr.HasRows)
            {
                drr.Read();
                txttenkh.Text = drr.GetString(0).ToString();

            }
        }

        private void cbomah_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(@"Initial Catalog=QLMT; User ID=sa; Password=123456;");
            cnn.Open();
            var cmdt = new SqlCommand("Select Tenhang , Giaban from Hang where Mahang='" + cbomah.SelectedValue.ToString() + "'", cnn);
            SqlDataReader drt = cmdt.ExecuteReader();
            if (drt.HasRows)
            {
                drt.Read();
                txttenhang.Text = drt.GetString(0).ToString();
                txtgiaban.Text = drt.GetInt32(1).ToString();

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
                string query = "insert into Hoadon(Mahd,Manv,Ngayban,Makh,Mahang,Soluong,Dongia,Tongtien)VALUES(@Mahd,@Manv,@Ngayban,@Makh,@Mahang,@Soluong,@Dongia,@Tongtien)";
                // Bước 4: Thực thi truy vấn
                SqlCommand cmd = new SqlCommand(query, conn);

                int Soluong = int.Parse(txtsl.Text);
                int Dongia = int.Parse(txtgiaban.Text);
                cmd.Parameters.Add(new SqlParameter("@Mahd", txtmahd.Text));
                cmd.Parameters.Add(new SqlParameter("@Manv", cbomanv.Text));              
                cmd.Parameters.Add(new SqlParameter("@Ngayban", mtbngayban.Text));              
                cmd.Parameters.Add(new SqlParameter("@Makh", cbomakh.Text));
                cmd.Parameters.Add(new SqlParameter("@Mahang", cbomah.Text));
                cmd.Parameters.Add(new SqlParameter("@Soluong", Soluong));
                cmd.Parameters.Add(new SqlParameter("@Dongia", Dongia));
                cmd.Parameters.Add(new SqlParameter("@Tongtien", txttongtien.Text));
                cmd.ExecuteNonQuery();
                // Bước 5: Đóng kết nối
                conn.Close();

                MessageBox.Show("Thanh toán thành công!");
                // Hiển thị dữ liệu mới lên GridView


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            ketnoicsdl();
            clearText();
        }

        private void btntongtien_Click(object sender, EventArgs e)
        {
            double soluong = double.Parse(txtsl.Text);
            double dongia = double.Parse(txtgiaban.Text);
            double tongtien = soluong * dongia;
            txttongtien.Text = tongtien.ToString();
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
                string query = "update Hoadon set Mahd=@Mahang,Manv=@Manv,Ngayban=@Ngayban,Makh=@Makh,Mahang=@Mahang,Soluong=@Soluong, Dongia=@Dongia,Tongtien=@Tongtien where Mahd=@Mahd";
                // Bước 4: Thực thi truy vấn
                SqlCommand cmd = new SqlCommand(query, conn);

                int Soluong = int.Parse(txtsl.Text);
                int Dongia = int.Parse(txtgiaban.Text);
                cmd.Parameters.Add(new SqlParameter("@Mahd", txtmahd.Text));
                cmd.Parameters.Add(new SqlParameter("@Manv", cbomanv.Text));
                cmd.Parameters.Add(new SqlParameter("@Ngayban", mtbngayban.Text));
                cmd.Parameters.Add(new SqlParameter("@Makh", cbomakh.Text));
                cmd.Parameters.Add(new SqlParameter("@Mahang", cbomah.Text));
                cmd.Parameters.Add(new SqlParameter("@Soluong", Soluong));
                cmd.Parameters.Add(new SqlParameter("@Dongia", Dongia));
                cmd.Parameters.Add(new SqlParameter("@Tongtien", txttongtien.Text));
                cmd.ExecuteNonQuery();
                // Bước 5: Đóng kết nối
                conn.Close();

                MessageBox.Show("Sửa  thành công!");
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

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {

                string con_str = @"Initial Catalog=QLMT; User ID=sa; Password=123456;";
                SqlConnection conn = new SqlConnection(con_str);
                // Bước 2: Mở kết nối
                conn.Open();
                // Bước 3: Khởi tạo truy vấn
                string query = "Delete from Hoadon where Mahd = @Mahd";
                // Bước 4: Thực thi truy vấn
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@Mahd", txtmahd.Text));
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
