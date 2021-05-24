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
    public partial class frmQLKhachHang : Form
    {
        public frmQLKhachHang()
        {
            InitializeComponent();
        }

        int maKH;
        private void frmQLKhachHang_Load(object sender, EventArgs e)
        {
            LoaiKhachHangBUS.Instance.LoadLoaiKhachHang(cboLoaiKhachHang);
            KhachHangBUS.Instance.loadKhachHang_Grid(gridContrrolKhachHang);
        }


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



        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtTenKH.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn3).ToString();
            txtSDT.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn4).ToString();
            numericUpDownDiemTL.Value = decimal.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn5).ToString());

            maKH = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn2).ToString());

        }

        private void toolStripButtonCapNhat_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text.Trim().Length > 0 && txtSDT.Text.Trim().Length > 0)
            {
                if (KiemTraDuLieu.KtraSoDienThoai(txtSDT.Text))
                {
                    if (KhachHangBUS.Instance.CapNhatThongTin(maKH, txtTenKH.Text, txtSDT.Text, (double)numericUpDownDiemTL.Value, int.Parse(cboLoaiKhachHang.SelectedValue.ToString())))
                    {
                        MessageBox.Show("Cập nhật thành công");
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại");
                    }

                }
                else
                {
                    MessageBox.Show("Sai định dạng! Nhập lại số điện thoại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
        }

        private void toolStripButtonLuuDatSan_Click_1(object sender, EventArgs e)
        {
            if (txtTenKH.Text.Trim().Length > 0 && txtSDT.Text.Trim().Length > 0)
            {
                if (KiemTraDuLieu.KtraSoDienThoai(txtSDT.Text))
                {
                    if (KhachHangBUS.Instance.KtraTrungSDTKhachHang(txtSDT.Text))
                    {
                        if (KhachHangBUS.Instance.ThemKhachHang(txtTenKH.Text, txtSDT.Text))
                        {
                            MessageBox.Show("Thêm thành công");
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại");
                    }
                }
                else
                {
                    MessageBox.Show("Sai định dạng! Nhập lại số điện thoại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
        }
    }
}
