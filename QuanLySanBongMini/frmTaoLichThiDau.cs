using DAO;
using DevExpress.XtraEditors;
using DTO;
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
    public partial class frmTaoLichThiDau : Form
    {
        public UserControlSanBong[] sanBong;
        int maLoaiSan = 0;
        public frmTaoLichThiDau()
        {
            InitializeComponent();
        }

        public void loadLaiSanBongConTrong()
        {
            flowLayoutPanel1.Controls.Clear();
            List<sanBong> listSanBong = SanBongDAO.Instance.loadTatCaSanBongConTrong(dateTimePickerGioVao.Value.TimeOfDay, dateTimePickerGioRa.Value.TimeOfDay, dateTimePickerNgayDat.Value.Date, maLoaiSan);
            if (listSanBong == null)
            {
                XtraMessageBox.Show("Không có sân trống với loại sân này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                sanBong = new UserControlSanBong[listSanBong.Count];
                for (int i = 0; i < listSanBong.Count; i++)
                {
                    sanBong[i] = new UserControlSanBong();
                    sanBong[i].Top = 30 * i;

                    sanBong[i].lblTenSan.Text = listSanBong[i].tenSan;
                    sanBong[i].Tag = listSanBong[i].maSan.ToString();
                    //sanBong[i].panel1.Click += Panel1_Click;
                    flowLayoutPanel1.Controls.Add(sanBong[i]);
                }
            }
        }

        private void ckb5Nguoi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb5Nguoi.Checked == true)
            {
                maLoaiSan = 1;
            }
            if (ckb7Nguoi.Checked == true)
            {
                ckb7Nguoi.Checked = false;
            }
            if (ckb11Nguoi.Checked == true)
            {
                ckb11Nguoi.Checked = false;
            }
        }

        private void ckb7Nguoi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb7Nguoi.Checked == true)
            {
                maLoaiSan = 2;
            }
            if (ckb5Nguoi.Checked == true)
            {
                ckb5Nguoi.Checked = false;
            }
            if (ckb11Nguoi.Checked == true)
            {
                ckb11Nguoi.Checked = false;
            }
        }

        private void ckb11Nguoi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb11Nguoi.Checked == true)
            {
                maLoaiSan = 3;
            }
            if (ckb5Nguoi.Checked == true)
            {
                ckb5Nguoi.Checked = false;
            }
            if (ckb7Nguoi.Checked == true)
            {
                ckb7Nguoi.Checked = false;
            }
        }
    }
}
