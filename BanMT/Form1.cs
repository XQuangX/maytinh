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
    public partial class fmlogin : Form
    {
        public fmlogin()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string con_str = "Initial Catalog = QLMT ;User ID=sa;Password=123456 ; ";
            SqlConnection conn = new SqlConnection(con_str);
            conn.Open();
            string tk = txttk.Text;
            string mk = txtmk.Text;
            string query = "select count(*) from NguoiDung where taikhoan ='" + tk + " 'and matkhau='" + mk + "'  ";
            SqlCommand cmd = new SqlCommand(query, conn);
            int soluong = (int)cmd.ExecuteScalar();
            conn.Close();
            if (soluong == 1)
            {
                MessageBox.Show("Đăng Nhập Thành Công !");
                this.DialogResult = DialogResult.OK;
                // this.Close();
                Hethong frm = new Hethong();
                frm.Show();

            }

            else
            {
                MessageBox.Show("Đăng Nhập Không Thành Công !");
            }
            clear();
            
            
        }
        private void clear()
        {
            txttk.Text = "";
            txtmk.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fmdangky frm = new fmdangky();
            frm.ShowDialog();
        }
    }
}
