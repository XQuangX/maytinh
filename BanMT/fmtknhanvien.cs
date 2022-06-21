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
    public partial class fmtknhanvien : Form
    {
        public fmtknhanvien()
        {
            InitializeComponent();
        }

        private void load()
        {
            SqlConnection cnn = new SqlConnection(@"Initial Catalog=QLMT; User ID=sa; Password=123456;");
            cnn.Open();
            var cmdd = new SqlCommand("Select Manv from Nhanvien", cnn);
            var apd = new SqlDataAdapter(cmdd);
            var dsd = new DataSet();
            apd.Fill(dsd, "Nhanvien");
            cbomanv.DataSource = dsd.Tables[0];
            cbomanv.DisplayMember = "Manv";
            cbomanv.ValueMember = "Manv";

        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Bước 1: Khởi tạo kết nối
                string con_str = @"Initial Catalog=QLMT; User ID=sa; Password=123456;"; // 
                SqlConnection conn = new SqlConnection(con_str);
                // Bước 2: Khởi tạo truy vấn
                string query = "Select * from Nhanvien where Manv=@Manv ";
                string tk = cbomanv.Text;
                // Bước 3: Tạo sqlDataAdapter
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.Add(new SqlParameter("@Manv", tk));
                // Bước 4: Đổ dữ liệu lên DataSet
                DataSet ds = new DataSet();
                da.Fill(ds, "Nhanvien");

                // Hiển thị dữ liệu lên GridView
                dgvtchoadon.DataSource = ds.Tables["Nhanvien"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

        private void btndong_Click(object sender, EventArgs e)
        {
            Close();
            Hethong frm = new Hethong();
            frm.Show();
        }

        private void fmtknhanvien_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
