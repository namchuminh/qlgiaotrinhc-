using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hanam
{
    public partial class GiaoTrinh : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        string query;
        public GiaoTrinh()
        {
            InitializeComponent();
            Connect connect = new Connect();
            conn = connect.ConnectDB();
            getData();
        }

        void getData()
        {
            try
            {
                List<tblGiaoTrinh> lstGiaoTrinh = new List<tblGiaoTrinh>();
                conn.Open();
                query = "SELECT * FROM GiaoTrinh";
                cmd = new SqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tblGiaoTrinh objGiaoTrinh = new tblGiaoTrinh();
                    objGiaoTrinh.MaGiaoTrinh = (string)reader["MaGiaoTrinh"];
                    objGiaoTrinh.TenGiaoTrinh = (string)reader["TenGiaoTrinh"];
                    objGiaoTrinh.MaLoai = (string)reader["MaLoai"];
                    objGiaoTrinh.TenTacGia = (string)reader["TenTacGia"];
                    objGiaoTrinh.NhaXuatBan = (string)reader["NhaXuatBan"];
                    lstGiaoTrinh.Add(objGiaoTrinh);
                }
                dgvGiaoTrinh.DataSource = lstGiaoTrinh;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvGiaoTrinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgvGiaoTrinh.CurrentCell.RowIndex;
            txtMaGiaoTrinh.Text = dgvGiaoTrinh.Rows[row].Cells["MaGiaoTrinh"].Value.ToString();
            txtTenGiaoTrinh.Text = dgvGiaoTrinh.Rows[row].Cells["TenGiaoTrinh"].Value.ToString();
            txtMaLoai.Text = dgvGiaoTrinh.Rows[row].Cells["MaLoai"].Value.ToString();
            txtTenTacGia.Text = dgvGiaoTrinh.Rows[row].Cells["TenTacGia"].Value.ToString();
            txtNhaXuatBan.Text = dgvGiaoTrinh.Rows[row].Cells["NhaXuatBan"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MaGiaoTrinh = txtMaGiaoTrinh.Text;
            string TenGiaoTrinh = txtTenGiaoTrinh.Text;
            string MaLoai = txtMaLoai.Text;
            string TenTacGia = txtTenTacGia.Text;
            string NhaXuatBan = txtNhaXuatBan.Text;
            try
            {
                conn.Open();
                query = $"INSERT INTO GiaoTrinh(MaGiaoTrinh, TenGiaoTrinh, MaLoai, TenTacGia, NhaXuatBan) VALUES('{MaGiaoTrinh}','{TenGiaoTrinh}', '{MaLoai}', '{TenTacGia}', '{NhaXuatBan}')";
                cmd = new SqlCommand(query, conn);
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                if (result > 0)
                {
                    MessageBox.Show("Thêm thành công!", "Thông Báo!");
                    getData();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công!", "Thông Báo!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtMaGiaoTrinh.Text = "";
            txtTenGiaoTrinh.Text = "";
            txtMaLoai.Text = "";
            txtTenTacGia.Text = "";
            txtNhaXuatBan.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string MaGiaoTrinh = txtMaGiaoTrinh.Text;
            string TenGiaoTrinh = txtTenGiaoTrinh.Text;
            string MaLoai = txtMaLoai.Text;
            string TenTacGia = txtTenTacGia.Text;
            string NhaXuatBan = txtNhaXuatBan.Text;
            try
            {
                conn.Open();
                query = $"UPDATE GiaoTrinh SET TenGiaoTrinh = '{TenGiaoTrinh}', MaLoai = '{MaLoai}', TenTacGia = '{TenTacGia}', NhaXuatBan = '{NhaXuatBan}' WHERE MaGiaoTrinh = '{MaGiaoTrinh}'";
                cmd = new SqlCommand(query, conn);
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                if (result > 0)
                {
                    MessageBox.Show("Sửa thành công!", "Thông Báo!");
                    getData();
                }
                else
                {
                    MessageBox.Show("Sửa không thành công!", "Thông Báo!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string MaGiaoTrinh = txtMaGiaoTrinh.Text;
            try
            {
                conn.Open();
                query = $"DELETE FROM GiaoTrinh WHERE MaGiaoTrinh = '{MaGiaoTrinh}'";
                cmd = new SqlCommand(query, conn);
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                if (result > 0)
                {
                    MessageBox.Show("Xóa thành công!", "Thông Báo!");
                    getData();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công!", "Thông Báo!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string TimKiem = txtTimKiem.Text;
            Search(TimKiem);
        }

        void Search(string TimKiem)
        {
            try
            {
                List<tblGiaoTrinh> lstGiaoTrinh = new List<tblGiaoTrinh>();
                conn.Open();
                query = $"SELECT * FROM GiaoTrinh WHERE TenGiaoTrinh LIKE '%{TimKiem}%'";
                cmd = new SqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tblGiaoTrinh objGiaoTrinh = new tblGiaoTrinh();
                    objGiaoTrinh.MaGiaoTrinh = (string)reader["MaGiaoTrinh"];
                    objGiaoTrinh.TenGiaoTrinh = (string)reader["TenGiaoTrinh"];
                    objGiaoTrinh.MaLoai = (string)reader["MaLoai"];
                    objGiaoTrinh.TenTacGia = (string)reader["TenTacGia"];
                    objGiaoTrinh.NhaXuatBan = (string)reader["NhaXuatBan"];
                    lstGiaoTrinh.Add(objGiaoTrinh);
                }
                dgvGiaoTrinh.DataSource = lstGiaoTrinh;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string NguoiMuon = txtNguoiMuon.Text;
            ThongKe(NguoiMuon);
        }

        void ThongKe(string NguoiMuon)
        {
            try
            {
                List<tblGiaoTrinh> lstGiaoTrinh = new List<tblGiaoTrinh>();
                conn.Open();
                query = $"SELECT GiaoTrinh.MaGiaoTrinh, GiaoTrinh.TenGiaoTrinh, GiaoTrinh.MaLoai, GiaoTrinh.TenTacGia, GiaoTrinh.NhaXuatBan FROM GiaoTrinh, PhieuMuon, CTPhieuMuon WHERE CTPhieuMuon.MaPhieuMuon = PhieuMuon.MaPhieuMuon AND CTPhieuMuon.MaGiaoTrinh = GiaoTrinh.MaGiaoTrinh AND PhieuMuon.NguoiMuon = '{NguoiMuon}'";
                cmd = new SqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tblGiaoTrinh objGiaoTrinh = new tblGiaoTrinh();
                    objGiaoTrinh.MaGiaoTrinh = (string)reader["MaGiaoTrinh"];
                    objGiaoTrinh.TenGiaoTrinh = (string)reader["TenGiaoTrinh"];
                    objGiaoTrinh.MaLoai = (string)reader["MaLoai"];
                    objGiaoTrinh.TenTacGia = (string)reader["TenTacGia"];
                    objGiaoTrinh.NhaXuatBan = (string)reader["NhaXuatBan"];
                    lstGiaoTrinh.Add(objGiaoTrinh);
                }
                dgvGiaoTrinh.DataSource = lstGiaoTrinh;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
