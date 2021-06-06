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
using DevExpress.XtraEditors;

namespace QuanLySanBongMini
{
    public partial class frmQLKhachHang : Form
    {
        int maKH;
        public frmQLKhachHang()
        {
            InitializeComponent();
        }

        
        private void frmQLKhachHang_Load(object sender, EventArgs e)
        {
            LoaiKhachHangBUS.Instance.LoadLoaiKhachHang(cboLoaiKhachHang);
            KhachHangBUS.Instance.loadKhachHang_Grid(gridContrrolKhachHang);
        }

        public void lamMoiDuLieu()
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    control.Text = string.Empty;
                }
            }
            toolStripButtonCapNhat.Enabled = false;
            toolStripButtonLuuKhachHang.Enabled = false;
            toolStripButtonChonH.Enabled = false;
        }
        private void toolStripButtonLamMoi_Click(object sender, EventArgs e)
        {
            lamMoiDuLieu();
            toolStripButtonCapNhat.Enabled = false;
            toolStripButtonLuuKhachHang.Enabled = true;

        }



        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtTenKH.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn3).ToString();
                txtSDT.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn4).ToString();
                numericUpDownDiemTL.Value = decimal.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn5).ToString());
                maKH = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn2).ToString());
                toolStripButtonCapNhat.Enabled = true;
                toolStripButtonLuuKhachHang.Enabled = false;
                toolStripButtonChonH.Enabled = true;
            }
            catch
            {
                return;
            }

        }

        private void toolStripButtonCapNhat_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text.Trim().Length > 0 && txtSDT.Text.Trim().Length > 0)
            {
                if (KiemTraDuLieu.KtraSoDienThoai(txtSDT.Text))
                {
                    if (KhachHangBUS.Instance.CapNhatThongTin(maKH, txtTenKH.Text, txtSDT.Text, (double)numericUpDownDiemTL.Value, int.Parse(cboLoaiKhachHang.SelectedValue.ToString())))
                    {
                        XtraMessageBox.Show("Cập nhật thành công");
                        KhachHangBUS.Instance.loadKhachHang_Grid(gridContrrolKhachHang);
                    }
                    else
                    {
                        XtraMessageBox.Show("Số điện thoại đã tồn tại");
                    }

                }
                else
                {
                    XtraMessageBox.Show("Sai định dạng! Nhập lại số điện thoại");
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
        }

        private void toolStripButtonLuuKhachHang_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text.Trim().Length > 0 && txtSDT.Text.Trim().Length > 0)
            {
                if (KiemTraDuLieu.KtraSoDienThoai(txtSDT.Text))
                {
                    if(KhachHangBUS.Instance.KtraTrungSDTKhachHang(txtSDT.Text.Trim()))
                    {
                        if(KhachHangBUS.Instance.ThemKhachHang(txtTenKH.Text.Trim(),txtSDT.Text.Trim()))
                        {
                            XtraMessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            KhachHangBUS.Instance.loadKhachHang_Grid(gridContrrolKhachHang);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Số điện thoại đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if(e.Column.Name== "gridColumn1")
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa khách hàng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (KhachHangBUS.Instance.xoaKhachHang(maKH))
                    {
                        XtraMessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lamMoiDuLieu();
                        frmQLKhachHang_Load(sender, e);
                    }
                    else
                    {
                        XtraMessageBox.Show("Khách hàng này đã có lịch đặt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }   

        }

        private void toolStripButtonChonH_Click(object sender, EventArgs e)
        {
            if(txtSDT.Text.Trim().Length >0)
            {
                frmDatSan.soDienThoai_LayDL = txtSDT.Text;
                frmDatSan.tenKhachHang_LayDL = txtTenKH.Text;
                frmDatSan.maKhachHang_LayDL = maKH.ToString();
                this.Close();
            }  
            else
            {
                XtraMessageBox.Show("Vui lòng chọn khách hàng có sẵn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }
    }
}
