using BUS;
using DevExpress.XtraEditors;
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
                XtraMessageBox.Show("Tên đăng nhập không được bỏ trống","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                this.txtTenDN.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                XtraMessageBox.Show("Mật khẩu không được bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                XtraMessageBox.Show("Chuỗi cấu hình không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ProcessConfig();


            }
            if (kq == 2)
            {
                // xử lý cấu hình
                XtraMessageBox.Show("Chuỗi cấu hình không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ProcessConfig();
            }
        }

        public void ProcessConfig()
        {
            Program.frmConfigDatabase = null;
            if (Program.frmConfigDatabase == null || Program.frmConfigDatabase.IsDisposed)
            {
                Program.frmConfigDatabase = new frmConfigDatabase();
            }
            this.Visible = false;
            Program.frmConfigDatabase.Show();
        }
        public void ProcessLogin()
        {
            try
            {
                if (NguoiDungBUS.Instance.KiemTraTenDangNhap(txtTenDN.Text.Trim()))
                {
                    if (NguoiDungBUS.Instance.dangNhapHeThong(txtTenDN.Text.Trim(), txtMatKhau.Text.Trim()) == 300)
                    {
                        maNguoiDung = NguoiDungBUS.Instance.maNguoiDung(txtTenDN.Text.Trim());
                        thongTinND = NguoiDungBUS.Instance.thongTinNguoiDung(txtTenDN.Text.Trim());
                        Program.mainForm = null;
                        if (Program.mainForm == null || Program.mainForm.IsDisposed)
                        {
                            Program.mainForm = new frmMain();
                            Program.mainForm.thongTinNguoiDung(Program.frm.thongTinND);
                            Program.mainForm.maNguoiDung(Convert.ToString(Program.frm.maNguoiDung));
                        }
                        Program.frm.Visible= false;
                        Program.mainForm.Show();
                    }
                    if (NguoiDungBUS.Instance.dangNhapHeThong(txtTenDN.Text.Trim(), txtMatKhau.Text.Trim()) == 200)
                    {
                        XtraMessageBox.Show("Tài khoản không khả dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (NguoiDungBUS.Instance.dangNhapHeThong(txtTenDN.Text.Trim(), txtMatKhau.Text.Trim()) == 100)
                    {
                        XtraMessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtTenDN.Focus();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDN.Focus();
                }    
            }
            catch
            {

            }
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            Program.frm = null;
            if (Program.frm == null || Program.frm.IsDisposed)
            {
                Program.frmDoiMatKhau = new frmDoiMatKhau();
            }
            this.Visible = false;
            Program.frmDoiMatKhau.Show();
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }
    }
}
