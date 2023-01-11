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
    public partial class FormPhongBan : Form
    {
        public static string ConnectionString = @"Data Source =WIN-5M8L2E1IUSI\SQLEXPRESS; Initial Catalog = Bai4; User ID = sa; Password = 1";
        SqlConnection conn;
        SqlDataAdapter da;
        public static string Status = "";
        Bai4Entities2 _context = new Bai4Entities2();
        public FormPhongBan()
        {
            InitializeComponent();
            this.LoadParent_ID();
            Status = "Reset";
            SetControl(Status);
            GetData();
        }
        public void GetData()
        {
            var list = _context.PhongBans.ToList();

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = list.Select(x => new
            {
                MaPB = x.MaPB,
                TenPB = x.TenPB,
                STT_PB = x.STT_PB,
                MoTa = x.MoTa,
                Parent_ID = x.Parent_ID,
            }).ToList();

            lblTong.Text = "Tổng số : " + list.Count();

        }
        public void LoadParent_ID()
        {
            var phongban = _context.PhongBans.ToArray();

            cboParent_ID.ValueMember = "Parent_ID";
            cboParent_ID.DisplayMember = "Parent_ID";
            cboParent_ID.DataSource = phongban;
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

                    txtMaPB.Enabled = true;
                    txtTenPB.Enabled = true;
                    txtSTT_PB.Enabled = true;
                    txtMoTa.Enabled = true;
                    cboParent_ID.Enabled = true;

                    break;

                case "Insert":
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhi.Enabled = true;
                    btnHuyBo.Enabled = true;

                    txtMaPB.Enabled = true;
                    txtTenPB.Enabled = true;
                    txtSTT_PB.Enabled = true;
                    txtMoTa.Enabled = true;
                    cboParent_ID.Enabled = true;

                    txtMaPB.Text = "";
                    txtTenPB.Text = "";
                    txtSTT_PB.Text = "";
                    txtMoTa.Text = "";

                    txtMaPB.Focus();

                    break;

                case "Update":
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhi.Enabled = true;
                    btnHuyBo.Enabled = true;

                    txtMaPB.Enabled = false;
                    txtTenPB.Enabled = true;
                    txtSTT_PB.Enabled = true;
                    txtMoTa.Enabled = true;
                    cboParent_ID.Enabled = true;

                    txtTenPB.Focus();

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
                if (txtMaPB.Text != null && txtMaPB.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin mã phòng ban";
                    txtMaPB.Focus();
                    return;
                }
                if (txtTenPB != null && txtTenPB.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin tên phòng ban";
                    txtTenPB.Focus();
                    return;
                }
                if (txtSTT_PB != null && txtSTT_PB.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin số thứ tự phòng ban";
                    txtSTT_PB.Focus();
                    return;
                }

                var exist = _context.PhongBans.Find(Convert.ToInt32(txtMaPB.Text));

                if (exist != null)
                {
                    lblError.Text = "Trùng mã nhân viên";
                    txtMaPB.Focus();
                    return;
                }

                PhongBan a = new PhongBan();

                a.MaPB = Convert.ToInt32(txtMaPB.Text);
                a.TenPB = txtTenPB.Text;
                a.MoTa = txtMoTa.Text;
                a.STT_PB = Convert.ToInt32(txtSTT_PB.Text);
                a.Parent_ID = Convert.ToInt32(cboParent_ID.SelectedValue);

                try
                {
                    _context.PhongBans.Add(a);
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
                if (txtTenPB != null && txtTenPB.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin tên phòng ban";
                    txtTenPB.Focus();
                    return;
                }
                if (txtSTT_PB != null && txtSTT_PB.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin số thứ tự phòng ban";
                    txtSTT_PB.Focus();
                    return;
                }

                var a = _context.PhongBans.Find(Convert.ToInt32(txtMaPB.Text));

                a.TenPB = txtTenPB.Text;
                a.MoTa = txtMoTa.Text;
                a.STT_PB = Convert.ToInt32(txtSTT_PB.Text);
                a.Parent_ID = Convert.ToInt32(cboParent_ID.SelectedValue);

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
            var count = _context.PhongBans.Find(Convert.ToInt32(txtMaPB.Text)).NhanSus.Count;

            if (count > 0)
            {
                MessageBox.Show("không thể xoá dữ liệu?", "Thông báo");
                return;
            }

            var find = _context.PhongBans.Find(Convert.ToInt32(txtMaPB.Text));

            try
            {
                _context.PhongBans.Remove(find);
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

            txtMaPB.Text = "";
            txtTenPB.Text = "";
            txtSTT_PB.Text = "";
            txtMoTa.Text = "";
            cboParent_ID.Text = "";
            

            txtMaPB.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblError.Text = "";
            lblStatus.Text = "";

            int RowIndex = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[RowIndex];
            txtMaPB.Text = selectedRow.Cells["MaPB"].Value.ToString();
            txtTenPB.Text = selectedRow.Cells["TenPB"].Value.ToString();
            txtSTT_PB.Text = selectedRow.Cells["STT_PB"].Value.ToString();
            txtMoTa.Text = selectedRow.Cells["MoTa"].Value.ToString();
            cboParent_ID.Text = selectedRow.Cells["Parent_ID"].Value.ToString();

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int MaPB = Convert.ToInt32(txtTimKiem.Text);
            var list = _context.PhongBans.Where(x => x.MaPB == MaPB);
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = list.Select(x => new
            {
                MaPB = x.MaPB,
                MoTa = x.MoTa,
                STT_PB = x.STT_PB,
                Parent_ID = x.Parent_ID,
            }).ToList();
            lblTong.Text = "Tổng số : "+list.Count();
        }
    }
}
