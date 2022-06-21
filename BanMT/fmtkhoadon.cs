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
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace BanMT
{
    public partial class fmtkhoadon : Form
    {
        public fmtkhoadon()
        {
            InitializeComponent();
        }
        private void load()
        {
            SqlConnection cnn = new SqlConnection(@"Initial Catalog=QLMT; User ID=sa; Password=123456;");
            cnn.Open();
            var cmdd = new SqlCommand("Select Mahd from Hoadon", cnn);
            var apd = new SqlDataAdapter(cmdd);
            var dsd = new DataSet();
            apd.Fill(dsd, "Hoadon");
            cbomahd.DataSource = dsd.Tables[0];
            cbomahd.DisplayMember = "Mahd";
            cbomahd.ValueMember = "Mahd";

        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Bước 1: Khởi tạo kết nối
                string con_str = @"Initial Catalog=QLMT; User ID=sa; Password=123456;"; // 
                SqlConnection conn = new SqlConnection(con_str);
                // Bước 2: Khởi tạo truy vấn
                string query = "Select * from Hoadon where Mahd=@Mahd ";
                string tk = cbomahd.Text;
                // Bước 3: Tạo sqlDataAdapter
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.Add(new SqlParameter("@Mahd", tk));
                // Bước 4: Đổ dữ liệu lên DataSet
                DataSet ds = new DataSet();
                da.Fill(ds, "Hoadon");

                // Hiển thị dữ liệu lên GridView
                dgvtchoadon.DataSource = ds.Tables["Hoadon"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void fmtkhoadon_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            Close();
            Hethong frm = new Hethong();
            frm.Show();
        }
        private void export2Excel(DataGridView g, string duongDan, string tenTap)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int i = 1; i < g.Columns.Count + 1; i++)
            { 
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText; 
            }
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null) { obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString(); }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongDan + tenTap + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }


        private void btnin_Click(object sender, EventArgs e)
        {

            export2Excel(dgvtchoadon, @"D:\", "ExportExcel1");
            MessageBox.Show("Export thành công!");
        }

        private void cbomahd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvtchoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
