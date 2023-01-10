using System;
using System.Collections;
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
    public partial class FormNhanVien : Form
    {
        public static string ConnectionString = @"Data Source =WIN-5M8L2E1IUSI\SQLEXPRESS; Initial Catalog = Bai4; User ID = sa; Password = 1";
        SqlConnection conn;
        SqlDataAdapter da;
        public static string Status = "";
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
            string Query = "select * from NhanSu";
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(Query, conn);
            da = new SqlDataAdapter(cmd);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataColumn colViewGTinh = new DataColumn();
                colViewGTinh.ColumnName = "View_GT";
                ds.Tables[0].Columns.Add(colViewGTinh);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["GioiTinh"].ToString().Trim() == "1")
                    {
                        dr["View_GT"] = "Nam";
                    }
                    else
                    {
                        dr["View_GT"] = "Nữ";
                    }
                }
                txtMaNS.Text = ds.Tables[0].Rows[0]["MaNV"].ToString();
                txtHoTen.Text = ds.Tables[0].Rows[0]["HoTen"].ToString();
                cboMaPB.Text = ds.Tables[0].Rows[0]["MaPB"].ToString();
                cboHSL.Text = ds.Tables[0].Rows[0]["ID_Luong"].ToString();
                txtQueQuan.Text = ds.Tables[0].Rows[0]["QueQuan"].ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["NgaySinh"].ToString());
                dtpNgay_BD.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["Ngay_BD"].ToString());
                if (ds.Tables[0].Rows[0]["GioiTinh"].ToString() == "1")
                    rdoNam.Checked = true;
                else
                    rdoNu.Checked = true;

            }
            lblTong.Text = "Tổng số " + ds.Tables[0].Rows.Count + " bản ghi";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
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
            string select = "select ID_Luong from Luong";
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd1 = new SqlCommand(select, conn);
            da = new SqlDataAdapter(cmd1);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                cboHSL.Items.Add(dr.GetInt32(0));
            }
            dr.Dispose();
            cmd1.Dispose();
        }
        public void LoadMaPB()
        {
            string select = "select MaPB from PhongBan";
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd1 = new SqlCommand(select, conn);
            da = new SqlDataAdapter(cmd1);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                cboMaPB.Items.Add(dr.GetInt32(0));
            }
            dr.Dispose();
            cmd1.Dispose();
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

                string QuerryCheck = "select * from NhanSu where MaNV='" + txtMaNS.Text.Trim() + "'";
                conn = new SqlConnection(ConnectionString);
                SqlCommand cmdCheck = new SqlCommand(QuerryCheck, conn);
                da = new SqlDataAdapter(cmdCheck);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblError.Text = "Đã tồn tại mã nhân viên" + txtMaNS.Text.Trim() + " trong hệ thống";
                    txtMaNS.Focus();
                    return;
                }
                var GioiTinh = -1;
                if (rdoNam.Checked == true)
                    GioiTinh = 1;
                else
                    GioiTinh = 0;
                string Query = "insert into NhanSu(MaNV, HoTen, NgaySinh,QueQuan, GioiTinh, Ngay_BD, MaPB,ID_Luong) values (N'" + txtMaNS.Text.Trim() + "',N'" + txtHoTen.Text.Trim() + "','" + Convert.ToDateTime(dtpNgaySinh.Value).ToString("yyyy-M-dd") + "',N'" + txtQueQuan.Text.Trim() + "','" + GioiTinh + "','" + Convert.ToDateTime(dtpNgay_BD.Value).ToString("yyyy-M-dd") + "',N'" + cboMaPB.Text.Trim() + "','" + cboHSL.Text.Trim() + "')";
                conn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand(Query, conn);

                da = new SqlDataAdapter(cmd);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                var bResult = cmd.ExecuteNonQuery();
                if (bResult > 0)
                {
                    GetData();
                    Status = "Reset";
                    SetControl(Status);
                    lblStatus.Text = "Ghi dữ liệu thành công";
                }
                else
                {
                    lblError.Text = "Lỗi";
                }
            }
            else
            {
                var GioiTinh = -1;
                if (rdoNam.Checked == true)
                    GioiTinh = 1;
                else
                    GioiTinh = 0;
                string Query = "update NhanSu set GioiTinh =N'" + GioiTinh + "',MaPB='" + cboMaPB.Text.Trim() + "', HoTen=N'" + txtHoTen.Text.Trim() + "', NgaySinh='" + Convert.ToDateTime(dtpNgaySinh.Value).ToString("yyyy-MM-dd") + "', QueQuan=N'" + txtQueQuan.Text.Trim() + "', ID_Luong=N'" + cboHSL.Text.Trim() + "'where MaNV='" + txtMaNS.Text.Trim() + "'";
                conn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand(Query, conn);

                da = new SqlDataAdapter(cmd);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                var bResult = cmd.ExecuteNonQuery();
                if (bResult > 0)
                {
                    GetData();
                    Status = "Reset";
                    SetControl(Status);
                    lblStatus.Text = "Cập nhật dữ liệu thành công";
                }
                else
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
            var GioiTinh = -1;
            if (rdoNam.Checked == true)
                GioiTinh = 1;
            else
                GioiTinh = 0;
            string Query = "delete from NhanSu where MaNV='" + txtMaNS.Text + "'";
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(Query, conn);

            da = new SqlDataAdapter(cmd);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            var bResult = cmd.ExecuteNonQuery();
            if (bResult > 0)
            {
                GetData();
                Status = "Reset";
                SetControl(Status);
                lblStatus.Text = "Xóa dữ liệu thành công";
            }
            else
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
            cboMaPB.Text = selectedRow.Cells["MaPB"].Value.ToString();
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
            string sql = "Select * from NhanSu where MANV LIKE '%" + txtTimKiem.Text + "%' or  HoTen LIKE '%" + txtTimKiem.Text + "%'";
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataColumn colViewGTinh = new DataColumn();
                colViewGTinh.ColumnName = "View_GT";
                ds.Tables[0].Columns.Add(colViewGTinh);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["GioiTinh"].ToString().Trim() == "1")
                    {
                        dr["View_GT"] = "Nam";
                    }
                    else
                    {
                        dr["View_GT"] = "Nữ";
                    }
                }
                txtMaNS.Text = ds.Tables[0].Rows[0]["MaNV"].ToString();
                txtHoTen.Text = ds.Tables[0].Rows[0]["HoTen"].ToString();
                cboMaPB.Text = ds.Tables[0].Rows[0]["MaPB"].ToString();
                cboHSL.Text = ds.Tables[0].Rows[0]["ID_Luong"].ToString();
                txtQueQuan.Text = ds.Tables[0].Rows[0]["QueQuan"].ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["NgaySinh"].ToString());
                dtpNgay_BD.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["Ngay_BD"].ToString());
                if (ds.Tables[0].Rows[0]["GioiTinh"].ToString() == "1")
                    rdoNam.Checked = true;
                else
                    rdoNu.Checked = true;

            }
            lblTong.Text = "Tổng số " + ds.Tables[0].Rows.Count + " bản ghi";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Refresh();

        }
    }
}
