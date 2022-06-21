using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanMT
{
    public partial class Hethong : Form
    {
        public Hethong()
        {
            InitializeComponent();
        }

        private void mnsdangxuat_Click(object sender, EventArgs e)
        {
            Close();
            //fmlogin frm = new fmlogin();
            //frm.ShowDialog();
        }

        private void mnunhanvien_Click(object sender, EventArgs e)
        {
            Close();
            fmnhanvien frm = new fmnhanvien();
            frm.Show();
        }

        private void mnukhachhang_Click(object sender, EventArgs e)
        {
            Close();
            fmkhachhang frm = new fmkhachhang();
            frm.Show();
        }

        private void mnuhanghoa_Click(object sender, EventArgs e)
        {
            Close();
            fmhanghoa frm = new fmhanghoa();
            frm.Show();
        }

        private void mnuhoadon_Click(object sender, EventArgs e)
        {
            Close();
            frmhoadon frm = new frmhoadon();
            frm.Show();
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            fmdangky frm = new fmdangky();
            frm.Show();
        }

        private void mnudmk_Click(object sender, EventArgs e)
        {
            fmdoimk frm = new fmdoimk();
            frm.Show();
        }

        private void hóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Close();
            fmtkhoadon frm = new fmtkhoadon();
            frm.Show();
        }

        private void mnulienhe_Click(object sender, EventArgs e)
        {
            Close();
            fmThongtin frm = new fmThongtin();
            frm.Show();
        }

        private void tKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            fmtknhanvien frm = new fmtknhanvien();
            frm.Show();
        }

        private void tKKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            tkkhachhang frm = new tkkhachhang();
            frm.Show();
        }

        private void tKMáyTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            fmtkmaytinh frm = new fmtkmaytinh();
            frm.Show();
        }
    }
}
