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
            string Query = "select * from PhongBan";
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

                txtMaPB.Text = ds.Tables[0].Rows[0]["MaPB"].ToString();
                txtTenPB.Text = ds.Tables[0].Rows[0]["TenPB"].ToString();
                txtSTT_PB.Text = ds.Tables[0].Rows[0]["STT_PB"].ToString();
                txtMoTa.Text = ds.Tables[0].Rows[0]["Mota"].ToString();
                cboParent_ID.Text = ds.Tables[0].Rows[0]["Parent_ID"].ToString();
            }
            lblTong.Text = "Tổng số " + ds.Tables[0].Rows.Count + " bản ghi";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
        public void LoadParent_ID()
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
                cboParent_ID.Items.Add(dr.GetInt32(0));
            }
            dr.Dispose();
            cmd1.Dispose();
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

                string QuerryCheck = "select * from PhongBan where MaPB='" + txtMaPB.Text.Trim() + "'";
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
                    lblError.Text = "Đã tồn tại Mã Phòng Ban" + txtMaPB.Text.Trim() + " trong hệ thống";
                    txtMaPB.Focus();
                    return;
                }

                string Query = "insert into PhongBan(MaPB, TenPB, MoTa,STT_PB, Parent_ID) values " +
                    "(N'" + txtMaPB.Text.Trim() + "',N'" + txtTenPB.Text.Trim() + "',N'" + txtMoTa.Text.Trim() + "',N'" + txtSTT_PB.Text.Trim() + "',N'" + cboParent_ID.Text.Trim() + "')";
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

                string Query = "update PhongBan set TenPB=N'" + txtTenPB.Text.Trim() + "', STT_PB=N'" + txtSTT_PB.Text.Trim() + "', MoTa=N'" + txtMoTa.Text.Trim() + "' , Parent_ID=N'" + cboParent_ID.Text.Trim() + "'where MaPB='" + txtMaPB.Text.Trim() + "'";
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
            string QuerryCheck = "select COUNT(NhanSu.MaNV) as a from NhanSu where NhanSu.MaPB ='" + txtMaPB.Text.Trim() + "'";
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmdCheck = new SqlCommand(QuerryCheck, conn);
            da = new SqlDataAdapter(cmdCheck);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (Convert.ToUInt32(ds.Tables[0].Rows[0][0]) > 0)
            {
                MessageBox.Show("không thể xoá dữ liệu?", "Thông báo");
                return;
            }

            string Query = "delete from PhongBan where MaPB='" + txtMaPB.Text + "'";
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
            string sql = "Select * from PhongBan where MaPB LIKE '%" + txtTimKiem.Text + "%'";
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                txtMaPB.Text = ds.Tables[0].Rows[0]["MaPB"].ToString();
                txtTenPB.Text = ds.Tables[0].Rows[0]["TenPB"].ToString();
                txtSTT_PB.Text = ds.Tables[0].Rows[0]["STT_PB"].ToString();
                txtMoTa.Text = ds.Tables[0].Rows[0]["Mota"].ToString();
                cboParent_ID.Text = ds.Tables[0].Rows[0]["Parent_ID"].ToString();
            }
            lblTong.Text = "Tổng số " + ds.Tables[0].Rows.Count + " bản ghi";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Refresh();
        }
    }
}
