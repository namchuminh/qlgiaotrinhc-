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

namespace Hanam
{
    public partial class DangNhap : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        string query;
        public DangNhap()
        {
            InitializeComponent();
            Connect connect = new Connect();
            conn = connect.ConnectDB();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string TaiKhoan = txtTaiKhoan.Text;
            string MatKhau = txtMatKhau.Text;
            try
            {
                conn.Open();
                query = $"SELECT COUNT(*) FROM NguoiDung WHERE TaiKhoan = '{TaiKhoan}' AND MatKhau = '{MatKhau}'";
                cmd = new SqlCommand(query,conn);
                int result = (int)cmd.ExecuteScalar();
                if(result == 1)
                {
                    MessageBox.Show("Đăng Nhập Thành Công!", "Thông Báo!");
                    GiaoTrinh giaoTrinh = new GiaoTrinh();  
                    giaoTrinh.Show();
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("Đăng Nhập Không Thành Công", "Thông Báo!");
                }
                conn.Close();
            }catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
