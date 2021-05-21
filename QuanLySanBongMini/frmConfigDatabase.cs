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
    public partial class frmConfigDatabase : Form
    {
        public frmConfigDatabase()
        {
            InitializeComponent();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (cboServername.Text.Trim() != "" && cboDatabase.Text.Trim() != "" && txtPass.Text.Trim() != ""
                && txtUsername.Text.Trim() != "")
            {
                NguoiDungBUS.Instance.saveConfig(cboServername.Text, txtUsername.Text, txtPass.Text, cboDatabase.Text);
                frmDangNhap frm = new frmDangNhap();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
        }

        private void cboServername_DropDown(object sender, EventArgs e)
        {
            NguoiDungBUS.Instance.getServerName(cboServername);
        }

        private void cboDatabase_DropDown(object sender, EventArgs e)
        {
            NguoiDungBUS.Instance.getDatabaseName(cboServername.Text, txtUsername.Text.Trim(), txtPass.Text.Trim(), cboDatabase);
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
