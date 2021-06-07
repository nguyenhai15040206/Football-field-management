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
    public partial class frmQLSanBong : Form
    {
        bool tinhTrang = true;
        public frmQLSanBong()
        {
            InitializeComponent();
        }

        private void frmQLSanBong_Load(object sender, EventArgs e)
        {
            LoaiSanBUS.Instance.loadLoaiSam_LookUpEdit(lookUpEditLoaiSan);
            // load tất cả sân bóng
            SanBongBUS.Instance.LoadSanBong_TinhTrang(gridContrrolSanBong,tinhTrang);

        }

        private void bunifuCkbTinhTrang_OnChange(object sender, EventArgs e)
        {
            if (bunifuCkbTinhTrang.Checked)
            {
                tinhTrang = true;
                lbTinhTrang.Text = "Đang hoạt động";
                SanBongBUS.Instance.LoadSanBong_TinhTrang(gridContrrolSanBong,tinhTrang);
            }
            else
            {
                tinhTrang = false;
                lbTinhTrang.Text = "Sân bảo trì";
                SanBongBUS.Instance.LoadSanBong_TinhTrang(gridContrrolSanBong,tinhTrang);
            }    
        }

        private void toolStripButtonLamMoi_Click(object sender, EventArgs e)
        {
            txtTenSan.Text = "";
            toolStripButtonThemSan.Enabled = true;
            txtTenSan.Focus();
            bunifuTransition1.HideSync(panelShow);
        }

        private void toolStripButtonThemSan_Click(object sender, EventArgs e)
        {
            if (txtTenSan.Text.Trim().Length > 0)
            {
                if (SanBongBUS.Instance.KtraTrungTenSan(txtTenSan.Text))
                {
                    if (SanBongBUS.Instance.themSan(txtTenSan.Text, tinhTrang, int.Parse(1.ToString())))
                    {
                        XtraMessageBox.Show("Thêm sân bóng mới thành công!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SanBongBUS.Instance.LoadSanBong_TinhTrang(gridContrrolSanBong, tinhTrang);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Tên sân này đã bị trùng! Vui lòng nhập tên khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng điền tên sân bóng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSan.Focus();
            }
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int maSan = int.Parse(gridViewSanBong.GetRowCellValue(e.RowHandle, gridColumnMaSan).ToString());
            if (e.Column.Name == "gridColumnXoaSan")
            {
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa sân bóng này không?","Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    if (SanBongBUS.Instance.xoaSanBong(maSan))
                    {
                        XtraMessageBox.Show("Xóa sân bóng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }  
                    else
                    {
                        XtraMessageBox.Show("Sân bóng này đang được sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }    
                }    
            } 
            
            if(e.Column.Name == "gridColumnBaoTri")
            {
                var sanDangDuocSD = SanBongBUS.Instance.sanDangDuocSuDungHomNay();
                if (bunifuCkbTinhTrang.Checked == true)
                {
                    bool duocBaoTri = true;
                    for (int i=0;i< sanDangDuocSD.Count;i++)
                    {
                        if(maSan == sanDangDuocSD[i])
                        {
                            duocBaoTri = false;
                        }    
                    }
                    if (duocBaoTri == true)
                    {
                        if (SanBongBUS.Instance.baoTriSanBong(maSan, false))
                        {
                            XtraMessageBox.Show("Sân được bảo trì!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTenSan.Text = "";
                            toolStripButtonThemSan.Enabled = true;
                            txtTenSan.Focus();
                            SanBongBUS.Instance.LoadSanBong_TinhTrang(gridContrrolSanBong, tinhTrang);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Sân này đang được sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }    
                }
                else
                {
                    if (SanBongBUS.Instance.baoTriSanBong(maSan, true))
                    {
                        XtraMessageBox.Show("Bảo trì sân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTenSan.Text = "";
                        toolStripButtonThemSan.Enabled = true;
                        txtTenSan.Focus();
                        SanBongBUS.Instance.LoadSanBong_TinhTrang(gridContrrolSanBong, tinhTrang);
                    }
                }    
            }    
        }

        private void lookUpEditLoaiSan_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                // load tất cả đơn giá giờ theo mã loại sân
                DonGiaGioBUS.Instance.loadDonGia_NgayCNMoiNhat_Grid_MaLoaiSan(gridControl3, int.Parse(lookUpEditLoaiSan.EditValue.ToString()));
                txtTenLoaiSan.Text = lookUpEditLoaiSan.Text;
                if(gridViewDGG.RowCount !=0)
                {
                    toolStripButtonXoa.Enabled = true;
                }    
                else
                {
                    toolStripButtonXoa.Enabled = false;
                }    

            }
            catch
            {

            }
        }

        private void gridViewNguoiDungDaCoNhom_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                numericUpDownTuKKG.Value = (decimal)double.Parse(gridViewDGG.GetRowCellValue(e.RowHandle, gridColumnTuKG).ToString());
                numericUpDownDenKG.Value = (decimal)double.Parse(gridViewDGG.GetRowCellValue(e.RowHandle, gridColumnDenKG).ToString());
                dateTimePickerNgayCNDGG.Text = gridViewDGG.GetRowCellValue(e.RowHandle, gridColumnNgayCNDGG).ToString();
                txtDonGia.Text = double.Parse(gridViewDGG.GetRowCellValue(e.RowHandle, gridColumnDonGiaDGG).ToString()).ToString();
                toolStripButtonThemDGG.Visible = false;
                toolStripButtonCapNhatDGG.Visible = true;
                numericUpDownDenKG.Enabled = numericUpDownTuKKG.Enabled = false;
                txtDonGia.Focus();
            }
            catch
            {
                return;
            }
        }

        public void lamMoiDuLieu()
        {
            numericUpDownDenKG.Value = 1;
            numericUpDownTuKKG.Value = 1;
            txtDonGia.Text = "";
            dateTimePickerNgayCNDGG.Value = DateTime.Now.Date;
        }    
        private void toolStripButtonLamMoiDDG_Click(object sender, EventArgs e)
        {
            toolStripButtonThemDGG.Enabled = true;
            toolStripButtonThemDGG.Visible = true;
            toolStripButtonCapNhatDGG.Visible = false;
            toolStripButtonXoa.Visible = true;
            numericUpDownDenKG.Value = 1;
            numericUpDownTuKKG.Value = 1;
            numericUpDownDenKG.Enabled = numericUpDownTuKKG.Enabled = true;
            txtDonGia.Text = "";
            numericUpDownTuKKG.Focus();
            dateTimePickerNgayCNDGG.Value = DateTime.Now.Date;
        }

        private void toolStripButtonNhapGia_Click(object sender, EventArgs e)
        {
            bunifuTransition1.ShowSync(panelShow);
            //panelShow.Visible = true;
        }

        private void gridViewSanBong_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtTenSan.Text = gridViewSanBong.GetRowCellValue(e.RowHandle, gridColumnTenSan).ToString();
                lookUpEditLoaiSan.Text = gridViewSanBong.GetRowCellValue(e.RowHandle, gridColumnLoaiSan).ToString();
                txtTenSan.Focus();
                toolStripButtonThemSan.Enabled = false;
            }
            catch
            {
                return;
            }

        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                toolTip1.SetToolTip(txtDonGia, "Vui lòng nhập số tiền hợp lệ");
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbTinhTrang_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonThemDGG_Click(object sender, EventArgs e)
        {
            if(txtTenLoaiSan.Text.Trim().Length>0&&numericUpDownDenKG.Value>0&&numericUpDownDenKG.Value>0&&txtDonGia.Text.Trim().Length>0)
            {
                if(numericUpDownDenKG.Value - numericUpDownTuKKG.Value >= 1)
                {
                    if (DonGiaGioBUS.Instance.themDonGiaGio(int.Parse(lookUpEditLoaiSan.EditValue.ToString()),(double)numericUpDownTuKKG.Value,(double)numericUpDownDenKG.Value,dateTimePickerNgayCNDGG.Value.Date,decimal.Parse(txtDonGia.Text)))
                    {
                        XtraMessageBox.Show("Thêm đơn giá mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } 
                else
                {
                    XtraMessageBox.Show("Khung giờ không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }   
            else
            {
                XtraMessageBox.Show("Không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void toolStripButtonXoa_Click(object sender, EventArgs e)
        {
            if(XtraMessageBox.Show("Bạn có chắc muốn xóa đơn giá " + txtTenLoaiSan.Text + " này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==DialogResult.Yes)
            if (DonGiaGioBUS.Instance.xoaDonGiaGioVoiMa(int.Parse(lookUpEditLoaiSan.EditValue.ToString())))
            {
                XtraMessageBox.Show("Xóa đơn giá giờ của loại " + txtTenLoaiSan.Text+" thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DonGiaGioBUS.Instance.loadDonGia_NgayCNMoiNhat_Grid_MaLoaiSan(gridControl3, int.Parse(lookUpEditLoaiSan.EditValue.ToString()));
                    lamMoiDuLieu();
            }    
        }

        private void toolStripButtonCapNhatDGG_Click(object sender, EventArgs e)
        {
            if(txtDonGia.Text.Trim().Length >0)
            {
                if(DonGiaGioBUS.Instance.capNhatDonGiaGio(int.Parse(lookUpEditLoaiSan.EditValue.ToString()),
                    double.Parse(numericUpDownTuKKG.Value.ToString()), double.Parse(numericUpDownDenKG.Value.ToString()),
                    dateTimePickerNgayCNDGG.Value.Date, double.Parse(txtDonGia.Text.Trim())))
                {
                    XtraMessageBox.Show("ĐƠn giá đã được cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DonGiaGioBUS.Instance.loadDonGia_NgayCNMoiNhat_Grid_MaLoaiSan(gridControl3, int.Parse(lookUpEditLoaiSan.EditValue.ToString()));
                    lamMoiDuLieu();
                }
            }   
            else
            {
                XtraMessageBox.Show("Vui lòng nhập đơn giá cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }    
        }
    }
}
