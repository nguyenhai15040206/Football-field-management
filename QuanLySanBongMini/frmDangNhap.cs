using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySanBongMini
{
    public partial class frmDangNhap : Form
    {
        public string thongTinND = "";
        public int maNguoiDung = 0;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtTenDN.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Tên đăng nhập không được bỏ trống");
                this.txtTenDN.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu không được bỏ trống");
                this.txtMatKhau.Focus();
                return;
            }
            int kq = NguoiDungBUS.Instance.checkConfig();
            if (kq == 0) // chuỗi cấu hình phù hợp
            {
                ProcessLogin(); // cấu hình phù hợp xử lý đăng nhập
            }
            if (kq == 1)
            {
                // chuổi cấu hình không phù hợp
                // xử lý cấu hình
                MessageBox.Show("Chuỗi cấu hình không tồn tại");
                ProcessConfig();


            }
            if (kq == 2)
            {
                // xử lý cấu hình
                MessageBox.Show("Chuỗi cấu hình không phù hợp");
                ProcessConfig();
            }
        }

        public void ProcessConfig()
        {
            frmConfigDatabase frm = new frmConfigDatabase();
            frm.ShowDialog();
            this.Hide();
        }
        public void ProcessLogin()
        {
            try
            {
                if (NguoiDungBUS.Instance.dangNhapHeThong(txtTenDN.Text.Trim(), txtMatKhau.Text.Trim()) == 300)
                {
                    maNguoiDung = NguoiDungBUS.Instance.maNguoiDung(txtTenDN.Text.Trim());
                    thongTinND = NguoiDungBUS.Instance.thongTinNguoiDung(txtTenDN.Text.Trim());
                    this.DialogResult = DialogResult.OK;
                }
                if (NguoiDungBUS.Instance.dangNhapHeThong(txtTenDN.Text.Trim(), txtMatKhau.Text.Trim()) == 200)
                {
                    MessageBox.Show("Tài khoản không khả dụng");
                }
                if (NguoiDungBUS.Instance.dangNhapHeThong(txtTenDN.Text.Trim(), txtMatKhau.Text.Trim()) == 100)
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                }
            }
            catch
            {

            }
        }
    }
}
