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
        public FormLuong()
        {
            InitializeComponent();
            Status = "Reset";
            SetControl(Status);
            GetData();
        }
        public void GetData()
        {
            string Query = "select * from Luong";
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

                txtID_L.Text = ds.Tables[0].Rows[0]["ID_Luong"].ToString();
                txtTenL.Text = ds.Tables[0].Rows[0]["Ten"].ToString();
                txtBL.Text = ds.Tables[0].Rows[0]["Bac_Luong"].ToString();
               
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

                string QuerryCheck = "select * from Luong where ID_Luong='" + txtID_L.Text.Trim() + "'";
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
                    lblError.Text = "Đã tồn tại mã luong" + txtID_L.Text.Trim() + " trong hệ thống";
                    txtID_L.Focus();
                    return;
                }
                string Query = "insert into Luong(ID_Luong, Ten, Bac_Luong) values (N'" + txtID_L.Text.Trim() + "',N'" + txtTenL.Text.Trim() + "'," + Convert.ToDecimal(txtBL.Text) + ")";
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
               
                string Query = "update Luong set Bac_Luong=N'" + txtBL.Text.Trim() + "' Ten=N'" + txtTenL.Text.Trim() + "' where ID_Luong='" + txtID_L.Text.Trim() + "'";
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
            string QuerryCheck = "select COUNT(NhanSu.MaNV) as a from NhanSu where NhanSu.ID_Luong ='" + txtID_L.Text.Trim() + "'";
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
                string Query = "delete from Luong where ID_Luong='" + txtID_L.Text + "'";
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
            string sql = "Select * from Luong where ID_Luong LIKE '%" + txtTimKiem.Text + "%'";
            conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                txtID_L.Text = ds.Tables[0].Rows[0]["ID_Luong"].ToString();
                txtTenL.Text = ds.Tables[0].Rows[0]["Ten"].ToString();
                txtBL.Text = ds.Tables[0].Rows[0]["Bac_Luong"].ToString();

            }
            lblTong.Text = "Tổng số " + ds.Tables[0].Rows.Count + " bản ghi";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Refresh();
        }
    }
}
