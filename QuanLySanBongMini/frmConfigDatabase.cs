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
                this.Hide();
                Program.frm = null;
                if (Program.frm == null || Program.frm.IsDisposed)
                {
                    Program.frm = new frmDangNhap();
                }
                this.Visible = false;
                Program.frm.Show();
                
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

        private void frmConfigDatabase_FormClosing(object sender, FormClosingEventArgs e)
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
