using Phan4_2.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan4_2
{
    public partial class FormNhanVien : Form
    {
        public static string ConnectionString = @"Data Source =WIN-5M8L2E1IUSI\SQLEXPRESS; Initial Catalog = Bai4; User ID = sa; Password = 1";
        SqlConnection conn;
        SqlDataAdapter da;
        public static string Status = "";
        Bai4Entities2 _context = new Bai4Entities2();
        public FormNhanVien()
        {
            InitializeComponent();
            this.LoadHSL();
            this.LoadMaPB();
            Status = "Reset";
            SetControl(Status);
            GetData();
        }
        public void GetData()
        {
            var list = _context.NhanSus.ToList();

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = list.Select(x => new
            {
                MaNV = x.MaNV,
                HoTen = x.HoTen,
                NgaySinh = x.NgaySinh,
                QueQuan = x.QueQuan,
                View_GT = x.GioiTinh == 1 ? "Nam" : "Nữ",
                Ngay_BD = x.Ngay_BD,
                TenPB = x.PhongBan.TenPB,
                Luong = x.Luong.Ten,
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

                    txtMaNS.Enabled = true;
                    txtHoTen.Enabled = true;
                    cboMaPB.Enabled = true;
                    cboHSL.Enabled = true;
                    txtQueQuan.Enabled = true;
                    rdoNam.Enabled = true;
                    rdoNu.Enabled = true;
                    dtpNgaySinh.Enabled = true;
                    dtpNgay_BD.Enabled = true;

                    break;

                case "Insert":
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhi.Enabled = true;
                    btnHuyBo.Enabled = true;

                    txtMaNS.Enabled = true;
                    txtHoTen.Enabled = true;
                    cboMaPB.Enabled = true;
                    cboHSL.Enabled = true;
                    txtQueQuan.Enabled = true;
                    rdoNam.Enabled = true;
                    rdoNu.Enabled = true;
                    dtpNgaySinh.Enabled = true;
                    dtpNgay_BD.Enabled = true;

                    txtMaNS.Text = "";
                    txtHoTen.Text = "";
                    txtQueQuan.Text = "";

                    txtMaNS.Focus();

                    break;

                case "Update":
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhi.Enabled = true;
                    btnHuyBo.Enabled = true;

                    txtMaNS.Enabled = false;
                    txtHoTen.Enabled = true;
                    cboMaPB.Enabled = true;
                    cboHSL.Enabled = true;
                    txtQueQuan.Enabled = true;
                    rdoNam.Enabled = true;
                    rdoNu.Enabled = true;
                    dtpNgaySinh.Enabled = true;
                    dtpNgay_BD.Enabled = true;

                    txtHoTen.Focus();

                    break;

                default:
                    break;
            }

        }

        public void LoadHSL()
        {
            var luong = _context.Luongs.ToArray();

            cboHSL.ValueMember = "ID_Luong";
            cboHSL.DisplayMember = "ten";
            cboHSL.DataSource = luong;
        }
        public void LoadMaPB()
        {
            var phongban = _context.PhongBans.ToArray();

            cboMaPB.ValueMember = "MaPB";
            cboMaPB.DisplayMember = "TenPB";
            cboMaPB.DataSource = phongban;
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (Status == "Insert")
            {
                // kiểm tra xem có nhập đủ thông tin không
                if (txtMaNS.Text != null && txtMaNS.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin mã nhân viên";
                    txtMaNS.Focus();
                    return;
                }
                if (txtHoTen != null && txtHoTen.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin tên nhân viên";
                    txtHoTen.Focus();
                    return;
                }
                if (txtQueQuan != null && txtQueQuan.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin địa chỉ";
                    txtQueQuan.Focus();
                    return;
                }
                if (cboHSL != null && cboHSL.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin hệ số lương";
                    cboHSL.Focus();
                    return;
                }
                if (cboMaPB != null && cboMaPB.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin mã phòng ban";
                    cboMaPB.Focus();
                    return;
                }


                var exist = _context.NhanSus.Find(Convert.ToInt32(txtMaNS.Text));

                if (exist != null)
                {
                    lblError.Text = "Trùng mã nhân viên";
                    txtMaNS.Focus();
                    return;
                }

                NhanSu a = new NhanSu();

                a.MaNV = Convert.ToInt32(txtMaNS.Text);
                a.HoTen = txtHoTen.Text;
                a.QueQuan = txtQueQuan.Text;
                a.GioiTinh = rdoNam.Checked == true ? 1 : 0;
                a.NgaySinh = dtpNgaySinh.Value;
                a.Ngay_BD = dtpNgay_BD.Value;
                a.MaPB = Convert.ToInt32(cboMaPB.SelectedValue);
                a.ID_Luong = Convert.ToInt32(cboHSL.SelectedValue);

                try
                {
                    _context.NhanSus.Add(a);
                    _context.SaveChanges();

                    GetData();
                    Status = "Reset";
                    SetControl(Status);
                    lblStatus.Text = "Ghi dữ liệu thành công";

                } catch
                {
                    lblError.Text = "Lỗi";
                }
            }
            else
            {
                if (txtMaNS.Text != null && txtMaNS.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin mã nhân viên";
                    txtMaNS.Focus();
                    return;
                }
                if (txtHoTen != null && txtHoTen.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin tên nhân viên";
                    txtHoTen.Focus();
                    return;
                }
                if (txtQueQuan != null && txtQueQuan.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin địa chỉ";
                    txtQueQuan.Focus();
                    return;
                }
                if (cboHSL != null && cboHSL.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin hệ số lương";
                    cboHSL.Focus();
                    return;
                }
                if (cboMaPB != null && cboMaPB.Text.Trim() != "") { }
                else
                {
                    lblError.Text = "Chưa nhập đủ thông tin mã phòng ban";
                    cboMaPB.Focus();
                    return;
                }

                var a = _context.NhanSus.Find(Convert.ToInt32(txtMaNS.Text));

                a.HoTen = txtHoTen.Text;
                a.QueQuan = txtQueQuan.Text;
                a.GioiTinh = rdoNam.Checked == true ? 1 : 0;
                a.NgaySinh = dtpNgaySinh.Value;
                a.Ngay_BD = dtpNgay_BD.Value;
                a.MaPB = Convert.ToInt32(cboMaPB.SelectedValue);
                a.ID_Luong = Convert.ToInt32(cboHSL.SelectedValue);

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
            var find = _context.NhanSus.Find(Convert.ToInt32(txtMaNS.Text));

            try
            {
                _context.NhanSus.Remove(find);
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

            txtMaNS.Text = "";
            txtHoTen.Text = "";
            txtQueQuan.Text = "";
            rdoNam.Text = "";
            rdoNu.Text = "";
            dtpNgaySinh.Text = "";
            dtpNgay_BD.Text = "";
            cboMaPB.Text = "";
            cboHSL.Text = "";

            txtMaNS.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblError.Text = "";
            lblStatus.Text = "";

            int RowIndex = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[RowIndex];
            txtMaNS.Text = selectedRow.Cells["MaNV"].Value.ToString();
            txtHoTen.Text = selectedRow.Cells["HoTen"].Value.ToString();
            txtQueQuan.Text = selectedRow.Cells["QueQuan"].Value.ToString();
            cboMaPB.Text = selectedRow.Cells["TenPB"].Value.ToString();
            cboHSL.Text = selectedRow.Cells["ID_Luong"].Value.ToString();
            dtpNgaySinh.Value = Convert.ToDateTime(selectedRow.Cells["NgaySinh"].Value);
            dtpNgay_BD.Value = Convert.ToDateTime(selectedRow.Cells["Ngay_BD"].Value);
            if (selectedRow.Cells["GioiTinh"].Value.ToString() == "Nam")
                rdoNam.Checked = true;
            else
                rdoNu.Checked = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int MaNV = Convert.ToInt32(txtTimKiem.Text);
            var list = _context.NhanSus.Where(x => x.MaNV == MaNV);
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = list.Select(x => new
            {
                MaNV = x.MaNV,
                HoTen = x.HoTen,
                NgaySinh = x.NgaySinh,
                QueQuan = x.QueQuan,
                View_GT = x.GioiTinh == 1 ? "Nam" : "Nữ",
                Ngay_BD = x.Ngay_BD,
                TenPB = x.PhongBan.TenPB,
                Luong = x.Luong.Ten,
            }).ToList();

            lblTong.Text = "Tổng số : " + list.Count();
        }
    }
}
