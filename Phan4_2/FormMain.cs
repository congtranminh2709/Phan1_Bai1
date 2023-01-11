using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan4_2
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }

        private void NhanSu_Click(object sender, EventArgs e)
        {
            FormNhanVien _formNhanVien = new FormNhanVien();
            _formNhanVien.MdiParent = this;
            _formNhanVien.Dock = DockStyle.Fill;
            _formNhanVien.WindowState = FormWindowState.Maximized;
            _formNhanVien.Show();
        }

        private void PhongBan_Click(object sender, EventArgs e)
        {
            FormPhongBan _formPhongBan = new FormPhongBan();
            _formPhongBan.MdiParent = this;
            _formPhongBan.Dock = DockStyle.Fill;
            _formPhongBan.WindowState = FormWindowState.Maximized;
            _formPhongBan.Show();
        }

        private void Luong_Click(object sender, EventArgs e)
        {
            FormLuong _formLuong = new FormLuong();
            _formLuong.MdiParent = this;
            _formLuong.Dock = DockStyle.Fill;
            _formLuong.WindowState = FormWindowState.Maximized;
            _formLuong.Show();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMain a = new FormMain();
            a.Show();
        }
    }
}
