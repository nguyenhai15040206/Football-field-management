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
using BUS;

namespace QuanLySanBongMini
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(txtMatKhau.Text.Trim().Length >0 && txtNhapLaiMK.Text.Trim().Length > 0 && txtTenDN.Text.Trim().Length >0)
            {
                if (NguoiDungBUS.Instance.KiemTraTenDangNhap(txtTenDN.Text))
                {
                    if (KiemTraDuLieu.kiemTraKhoanTrang(txtMatKhau.Text.Trim()) && KiemTraDuLieu.kiemTraKhoanTrang(txtNhapLaiMK.Text.Trim()))
                    {
                        if (txtMatKhau.Text.Trim() == txtNhapLaiMK.Text.Trim())
                        {
                            if (NguoiDungBUS.Instance.doiMatKhau(txtTenDN.Text, KiemTraDuLieu.MD5Hash(txtMatKhau.Text)))
                            {
                                XtraMessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Program.frm = null;
                                if (Program.frm == null || Program.frm.IsDisposed)
                                {
                                    Program.frm = new frmDangNhap();
                                }
                                this.Visible = false;
                                Program.frm.Show();
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Mật khẩu không khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNhapLaiMK.Focus();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Mật khẩu không có khoản trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMatKhau.Focus();
                    }    
                }
                else
                {
                    XtraMessageBox.Show("Tên đăng nhập sai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTenDN.Focus();
                }
            }   
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTenDN.Focus();
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

        private void frmDoiMatKhau_FormClosing(object sender, FormClosingEventArgs e)
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
