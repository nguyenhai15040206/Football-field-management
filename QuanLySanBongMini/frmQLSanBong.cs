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
    public partial class frmQLSanBong : Form
    {
        public frmQLSanBong()
        {
            InitializeComponent();
        }
        bool tinhTrang;

        private void toolStripButtonLamMoi_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    control.Text = string.Empty;
                }
            }
        }

        private void toolStripButtonThemSan_Click(object sender, EventArgs e)
        {
            if (txtTenSan.Text.Trim().Length > 0)
            {
                if (SanBongBUS.Instance.KtraTrungTenSan(txtTenSan.Text))
                {
                    if (SanBongBUS.Instance.themSan(txtTenSan.Text, tinhTrang, int.Parse(cboLoaiSanBong.SelectedValue.ToString())))
                    {
                        MessageBox.Show("Thêm sân thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm sân thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Sân đã tồn tại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
        }

        private void toolStripButtonDSSanDabaoTri_Click(object sender, EventArgs e)
        {
            SanBongBUS.Instance.LoadSanDaBaoTri(gridContrrolDatSan);
        }

        private void toolStripButtonDSSanBaoTri_Click(object sender, EventArgs e)
        {
            SanBongBUS.Instance.LoadSanBaoTri(gridContrrolDatSan);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tinhTrang = false;
            if (checkBox1.Checked)
                tinhTrang = true;
        }

        private void frmQLSanBong_Load(object sender, EventArgs e)
        {
            LoaiSanBUS.Instance.loadLoaiSan_com(cboLoaiSanBong);
        }
    }
}
