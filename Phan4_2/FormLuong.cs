using Phan4_2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan4_2
{
    public partial class FormLuong : Form
    {
        public static string ConnectionString = @"Data Source =WIN-5M8L2E1IUSI\SQLEXPRESS; Initial Catalog = Bai4; User ID = sa; Password = 1";
        SqlConnection conn;
        SqlDataAdapter da;
        public static string Status = "";
        Bai4Entities2 _context = new Bai4Entities2();
        public FormLuong()
        {
            InitializeComponent();
            Status = "Reset";
            SetControl(Status);
            GetData();
        }
        public void GetData()
        {
            var list = _context.Luongs.ToList();

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = list.Select(x => new
            {
                ID_Luong = x.ID_Luong,
                Ten = x.Ten,
                Bac_Luong = x.Bac_Luong
            }).ToList();
            lblTong.Text = "Tổng số : " + list.Count();
        }
        public void SetControl(string Status)
        {
            lblError.Text = "";
            lblStatus.Text = "";
            switch (Status)
            {
                case "Reset":
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnGhi.Enabled = true;
                    btnHuyBo.Enabled = true;

                    txtID_L.Enabled = true;
                    txtTenL.Enabled = true;
                    txtBL.Enabled = true;

                    break;

                case "Insert":
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhi.Enabled = true;
                    btnHuyBo.Enabled = true;

                    txtID_L.Enabled = true;
                    txtTenL.Enabled = true;
                    txtBL.Enabled = true;
                   
                    txtTenL.Text = "";
                    txtBL.Text = "";
                    txtID_L.Text = "";

                    txtID_L.Focus();

                    break;

                case "Update":
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhi.Enabled = true;
                    btnHuyBo.Enabled = true;

                    txtID_L.Enabled = false;
                    txtTenL.Enabled = true;
                    txtBL.Enabled = true;

                    txtTenL.Focus();

                    break;

                default:
                    break;
            }
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (Status == "Insert")
            {
                // kiểm tra xem có nhập đủ thông tin không
                if (txtID_L.Text != null && txtID_L.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin mã lương";
                    txtID_L.Focus();
                    return;
                }
                if (txtTenL != null && txtTenL.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin tên lương";
                    txtTenL.Focus();
                    return;
                }
                if (txtBL != null && txtBL.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin bậc lương";
                    txtBL.Focus();
                    return;
                }

                var exist = _context.Luongs.Find(Convert.ToInt32(txtID_L.Text));

                if (exist != null)
                {
                    lblError.Text = "Trùng mã nhân viên";
                    txtID_L.Focus();
                    return;
                }

                Luong a = new Luong();

                a.ID_Luong = Convert.ToInt32(txtID_L.Text);
                a.Bac_Luong = Convert.ToInt32(txtBL.Text);
                a.Ten = txtTenL.Text;

                try
                {
                    _context.Luongs.Add(a);
                    _context.SaveChanges();

                    GetData();
                    Status = "Reset";
                    SetControl(Status);
                    lblStatus.Text = "Ghi dữ liệu thành công";

                }
                catch
                {
                    lblError.Text = "Lỗi";
                }
            }
            else
            {
                if (txtID_L.Text != null && txtID_L.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin mã lương";
                    txtID_L.Focus();
                    return;
                }
                if (txtTenL != null && txtTenL.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin tên lương";
                    txtTenL.Focus();
                    return;
                }
                if (txtBL != null && txtBL.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin bậc lương";
                    txtBL.Focus();
                    return;
                } 

                var a = _context.Luongs.Find(Convert.ToInt32(txtID_L.Text));

                a.Bac_Luong = Convert.ToDecimal(txtBL.Text);
                a.Ten = txtTenL.Text;

                try
                {
                    _context.SaveChanges();

                    GetData();
                    Status = "Reset";
                    SetControl(Status);
                    lblStatus.Text = "Ghi dữ liệu thành công";

                }
                catch
                {
                    lblError.Text = "Lỗi";
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Status = "Insert";
            SetControl(Status);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Status = "Update";
            SetControl(Status);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var Result = MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo);
            if (Result == DialogResult.No)
                return;
       
            var find = _context.Luongs.Find(Convert.ToInt32(txtID_L.Text));

            try
            {
                _context.Luongs.Remove(find);
                _context.SaveChanges();

                GetData();
                Status = "Reset";
                SetControl(Status);
                lblStatus.Text = "Xóa dữ liệu thành công";
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {

            txtID_L.Text = "";
            txtTenL.Text = "";
            txtBL.Text = "";

            txtID_L.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblError.Text = "";
            lblStatus.Text = "";

            int RowIndex = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[RowIndex];
            txtID_L.Text = selectedRow.Cells["ID_Luong"].Value.ToString();
            txtTenL.Text = selectedRow.Cells["Ten"].Value.ToString();
            txtBL.Text = selectedRow.Cells["Bac_Luong"].Value.ToString();
           
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int ID_Luong = Convert.ToInt32(txtTimKiem.Text);
            var list = _context.Luongs.Where(x => x.ID_Luong == ID_Luong);
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = list.Select(x => new
            {
                ID_Luong = x.ID_Luong,
                Ten = x.Ten,
                Bac_Luong = x.Bac_Luong
            }).ToList();
            lblTong.Text = "Tổng số : " + list.Count();
            dataGridView1.Refresh();
        }
    }
}
