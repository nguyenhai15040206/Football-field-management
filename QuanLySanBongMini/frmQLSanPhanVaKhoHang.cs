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
    public partial class frmQLSanPhanVaKhoHang : Form
    {
        private bool tinhTrang = true;
        int maThucUong = 0;
        public frmQLSanPhanVaKhoHang()
        {
            InitializeComponent();
        }

        public void lamMoiDuLieu()
        {
            numericUpDownSL.Value = 0;
            toolStripButtonLuu.Enabled = true;
            toolStripButtonCapNhat.Enabled = false;
            foreach (Control item in groupBox1.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    item.Text = string.Empty;
                }
            }
        }

        private void frmQLSanPhanVaKhoHang_Load(object sender, EventArgs e)
        {
            bunifuckkbTinhTrang.Checked = true;
            ThucUongBUS.Instance.loadThucUong_GridControl(gridContrrolThucUong, tinhTrang);
        }

        private void ckbTinhTrang_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtTenThucUong.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn4).ToString();
            cboDonViTinh.Text = (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn5).ToString());
            numericUpDownSL.Value = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn6).ToString());
            txtDonGia.Text = string.Format("{0:0,0} vnđ", double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn7).ToString()));
            txtDonGiaNhap.Text = string.Format("{0:0,0} vnđ", double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn2).ToString()));
            bunifuckkbTinhTrang.Checked = bool.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn8).ToString());
            toolStripButtonCapNhat.Enabled = true;
            toolStripButtonLuu.Enabled = false;
            maThucUong = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn3).ToString());
        }

        private void toolStripButtonLamMoi_Click(object sender, EventArgs e)
        {
            lamMoiDuLieu();
        }


        private void btnThemPhieuNhap_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaThucUong_Click(object sender, EventArgs e)
        {
              
        }

        private void toolStripButtonNhapHang_Click(object sender, EventArgs e)
        {
            frmPhieuNhapHang frm = new frmPhieuNhapHang();
            frm.ShowDialog();
        }

        private void toolStripButtonLuu_Click(object sender, EventArgs e)
        {
            if(txtTenThucUong.Text.Trim().Length >0 && txtDonGia.Text.Trim().Length >0 && cboDonViTinh.SelectedItem !=null)
            {
                string DVT = "";
                if(cboDonViTinh.SelectedIndex==0)
                {
                    DVT = "Chai";
                }
                if (cboDonViTinh.SelectedIndex == 1)
                {
                    DVT = "Lon";
                }
                if (KiemTraDuLieu.ktraChiNhapSo_double(txtDonGia.Text.Trim()))
                {
                    if (KiemTraDuLieu.ktraChiNhapSo_double(txtDonGiaNhap.Text.Trim()))
                    {
                        if(numericUpDownSL.Value == 0)
                        {
                            tinhTrang = false;
                        }    
                        else
                        {
                            tinhTrang = true;
                        }
                        if (ThucUongBUS.Instance.themThucUong(txtTenThucUong.Text.Trim(), DVT, double.Parse(txtDonGia.Text.Trim()),
                            double.Parse(txtDonGiaNhap.Text.Trim()), int.Parse(numericUpDownSL.Value.ToString()), tinhTrang))
                        {
                            XtraMessageBox.Show("Thêm thức uống mới thành công! Vui lòng nhập hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lamMoiDuLieu();
                            ThucUongBUS.Instance.loadThucUong_GridControl(gridContrrolThucUong, true);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Nhập dữ liệu sai! vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDonGiaNhap.Focus();
                    }    
                }
                else
                {
                    XtraMessageBox.Show("Nhập dữ liệu sai! vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDonGia.Focus();
                }    
            }   
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (string.IsNullOrEmpty(txtTenThucUong.Text.Trim()))
            {
                txtTenThucUong.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDonGia.Text.Trim()))
            {
                txtDonGia.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDonGiaNhap.Text.Trim()))
            {
                txtDonGiaNhap.Focus();
                return;
            }
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "gridColumn1") 
            {
                int maThucUong = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn3).ToString());
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa thức uống này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (ThucUongBUS.Instance.xoaThucUong(maThucUong))
                    {
                        XtraMessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ThucUongBUS.Instance.loadThucUong_GridControl(gridContrrolThucUong, tinhTrang);
                    }
                }
            }    
        }

        private void bunifuckkbTinhTrang_OnChange(object sender, EventArgs e)
        {
            if (bunifuckkbTinhTrang.Checked == true)
            {
                tinhTrang = true;
                blTinhTrang.Text = "Còn hàng";
            }
            else
            {
                tinhTrang = false;
                blTinhTrang.Text = "Hết hàng";
            }
            ThucUongBUS.Instance.loadThucUong_GridControl(gridContrrolThucUong, tinhTrang);
        }

        private void toolStripButtonCapNhat_Click(object sender, EventArgs e)
        {
            if (txtTenThucUong.Text.Trim().Length > 0 && txtDonGia.Text.Trim().Length > 0 && cboDonViTinh.SelectedItem != null)
            {
                string DVT = "";
                if (cboDonViTinh.SelectedIndex == 0)
                {
                    DVT = "Chai";
                }
                if (cboDonViTinh.SelectedIndex == 1)
                {
                    DVT = "Lon";
                }
                if (KiemTraDuLieu.ktraChiNhapSo_double(txtDonGia.Text.Trim()))
                {
                    if (KiemTraDuLieu.ktraChiNhapSo_double(txtDonGiaNhap.Text.Trim()))
                    {
                        if (numericUpDownSL.Value == 0)
                        {
                            tinhTrang = false;
                        }
                        else
                        {
                            tinhTrang = true;
                        }
                        if (ThucUongBUS.Instance.capNhatThucUong(maThucUong,txtTenThucUong.Text.Trim(), DVT, double.Parse(txtDonGia.Text.Trim()),
                            double.Parse(txtDonGiaNhap.Text.Trim()), int.Parse(numericUpDownSL.Value.ToString()), tinhTrang))
                        {
                            XtraMessageBox.Show("Cập nhật thức uống thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lamMoiDuLieu();
                            ThucUongBUS.Instance.loadThucUong_GridControl(gridContrrolThucUong, true);
                            toolStripButtonLuu.Enabled = false;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Nhập dữ liệu sai! vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDonGiaNhap.Focus();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Nhập dữ liệu sai! vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDonGia.Focus();
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (string.IsNullOrEmpty(txtTenThucUong.Text.Trim()))
            {
                txtTenThucUong.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDonGia.Text.Trim()))
            {
                txtDonGia.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDonGiaNhap.Text.Trim()))
            {
                txtDonGiaNhap.Focus();
                return;
            }
        }
    }
}
