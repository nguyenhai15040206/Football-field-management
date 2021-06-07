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
                    if (txtMatKhau.Text.Trim() == txtNhapLaiMK.Text.Trim())
                    {
                        if (NguoiDungBUS.Instance.doiMatKhau(txtTenDN.Text, KiemTraDuLieu.MD5Hash(txtMatKhau.Text)))
                        {
                            XtraMessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Mật khẩu không khớp");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Tên đăng nhập sai!");
                }
            }   
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin");
                txtTenDN.Focus();
            }    
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
