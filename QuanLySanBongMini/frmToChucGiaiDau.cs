using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraEditors;

namespace QuanLySanBongMini
{
    public partial class frmToChucGiaiDau : Form
    {
        public static int maGiaiDau = 0;
        public int maDoiBong = 0;
        public frmToChucGiaiDau()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        public void resetData()
        {
            maGiaiDau = 0;
            txtTenSuKien.Text = "";
            numSoDoiKnockout.Value = numSoDoiKnockout.Minimum;
            dateNgayBD.Value = DateTime.Now.Date;
            numSoDoi.Value = numSoDoi.Minimum;
            numSoBangDau.Value = numSoBangDau.Minimum;
            numSLNguoiMoiDoi.Value = numSLNguoiMoiDoi.Minimum;
        }

        public void resetDataDoiBong()
        {
            maDoiBong = 0;
            txtTenDoiBong.Text = "";
            txtTenNguoiDaiDien.Text = "";
            txtSoDienThoai.Text = "";
            txtHinhDaiDien.Text = "";
            txtEMail.Text = "";
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            resetData();
            btnLuuGiaiDau.Enabled = true;
            btnHuyGiaiDau.Enabled = false;
        }

        private void btnLuuGiaiDau_Click(object sender, EventArgs e)
        {
            if (txtTenSuKien.Text.Trim().Length > 0)
            {
                if (dateNgayBD.Value.Date >= DateTime.Now.Date.AddDays(5))
                {
                    if(KiemTraDuLieu.ktraChiNhapSo_double(txtLePhiThamGia.Text.Trim()) && double.Parse(txtLePhiThamGia.Text.Trim())> 0)
                    {
                        if (SuKienBUS.Instance.themSuKien(txtTenSuKien.Text.Trim(), dateNgayBD.Value.Date, int.Parse(numSoDoi.Value.ToString()),
                        int.Parse(numSoBangDau.Value.ToString()), int.Parse(numSoDoiKnockout.Value.ToString()), int.Parse(numSLNguoiMoiDoi.Value.ToString()), 1, double.Parse(txtLePhiThamGia.Text.Trim()), true))
                        {
                            XtraMessageBox.Show("Thêm sự kiện mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SuKienBUS.Instance.loadSuKien(gvSuKien);
                            btnLuuGiaiDau.Enabled = false;
                            resetData();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Lệ phí tham gia không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtLePhiThamGia.Focus();
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Ngày diễn ra sự kiện không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng nhập tên sự kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmToChucGiaiDau_Load(object sender, EventArgs e)
        {
            btnHuyGiaiDau.Enabled = false;
            btnLuuGiaiDau.Enabled = false;
            btnThemDoiBong.Enabled = false;
            btnLamMoiDoiBong.Enabled = false;
            btnCapNhatDOiBong.Enabled = false;
            btnXoaDoiBong.Enabled = false;
            SuKienBUS.Instance.loadSuKien(gvSuKien);
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                maGiaiDau = int.Parse(gridView1.GetRowCellValue(e.RowHandle, gridColumnMaSuKien).ToString());
                txtTenSuKien.Text = gridView1.GetRowCellValue(e.RowHandle, gridColumnTenSK).ToString();
                dateNgayBD.Text = gridView1.GetRowCellValue(e.RowHandle, gridColumnNgayBD).ToString();
                numSLNguoiMoiDoi.Value = int.Parse(gridView1.GetRowCellValue(e.RowHandle, gridColumnSLNguoiMoiDoi).ToString());
                numSoBangDau.Value = int.Parse(gridView1.GetRowCellValue(e.RowHandle, gridColumnSoBangDau).ToString());
                numSoDoi.Value = int.Parse(gridView1.GetRowCellValue(e.RowHandle, gridColumnSoDoi).ToString());
                numSoDoiKnockout.Value = int.Parse(gridView1.GetRowCellValue(e.RowHandle, gridColumnSoDoiVongKnock).ToString());
                txtLePhiThamGia.Text = string.Format("{0:0,0}", double.Parse(gridView1.GetRowCellValue(e.RowHandle, gridColumnLePhi).ToString()));
                SuKienBUS.Instance.loadDoiBong(gvDoiBong, maGiaiDau);
                btnHuyGiaiDau.Enabled = true;
                btnLuuGiaiDau.Enabled = false;
                btnLamMoiDoiBong.Enabled = true;
                btnThemDoiBong.Enabled = false;
                btnCapNhatDOiBong.Enabled = false;
                btnXoaDoiBong.Enabled = false;
                resetDataDoiBong();
            }
            catch
            {
                return;
            }
        }

        private void btnHuyGiaiDau_Click(object sender, EventArgs e)
        {
            if(maGiaiDau > 0)
            {
                if(DateTime.Now.Date < dateNgayBD.Value.Date)
                {
                    DialogResult rs = XtraMessageBox.Show("Bạn có chắc muốn xóa sự kiện này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                    {
                        if (SuKienBUS.Instance.huySuKien(maGiaiDau))
                        {
                            XtraMessageBox.Show("Sự kiện này đã được xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SuKienBUS.Instance.loadSuKien(gvSuKien);
                            btnHuyGiaiDau.Enabled = false;
                            resetData();
                        }
                    }
                    
                }
                else
                {
                    XtraMessageBox.Show("Sự kiện này đang diễm ra không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn sự kiện cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThemDoiBong_Click(object sender, EventArgs e)
        {
            if(maGiaiDau > 0)
            {
                int soLuong = SuKienBUS.Instance.soLuongHienTaiCuaSK(maGiaiDau);
                if (txtTenDoiBong.Text.Trim().Length > 0 && txtTenNguoiDaiDien.Text.Trim().Trim().Length >0
                    && txtSoDienThoai.Text.Trim().Length > 0 && txtEMail.Text.Trim().Length > 0)
                {
                    if (!KiemTraDuLieu.KtraSoDienThoai(txtSoDienThoai.Text.Trim()))
                    {
                        XtraMessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSoDienThoai.Focus();
                        return;
                    }
                    if (!KiemTraDuLieu.KtraEmail(txtEMail.Text.Trim()))
                    {
                        XtraMessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEMail.Focus();
                        return;
                    }
                    if (soLuong >= int.Parse(numSoDoi.Value.ToString()))
                    {
                        XtraMessageBox.Show("Đã đủ số lượng đội! Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string hinhDoiBong = txtHinhDaiDien.Text.Trim().Length > 0 ? txtHinhDaiDien.Text.Trim() : null;
                    if (SuKienBUS.Instance.themDoiBong((soLuong + 1), maGiaiDau, txtTenDoiBong.Text.Trim(), txtTenNguoiDaiDien.Text.Trim(),
                        txtSoDienThoai.Text.Trim(), txtEMail.Text.Trim(), hinhDoiBong, true)){
                        XtraMessageBox.Show("Thêm đội bóng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SuKienBUS.Instance.loadDoiBong(gvDoiBong, maGiaiDau);
                        try { File.Copy(txtHinhDaiDien.Text.Trim(), Path.Combine(@"C:\Users\hp\Desktop\MonBaDinh\QuanLySanBongMini\Images\", Path.GetFileName(txtHinhDaiDien.Text)), true); }
                        catch (Exception ex) { Console.WriteLine("" + ex); return; }
                        //resetDataDoiBong();

                    }

                }
                else
                {
                    XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn sự kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoiDoiBong_Click(object sender, EventArgs e)
        {
            btnThemDoiBong.Enabled = true;
            btnCapNhatDOiBong.Enabled = false;
            btnXoaDoiBong.Enabled = false;
            resetDataDoiBong();
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                maDoiBong = int.Parse(gridView2.GetRowCellValue(e.RowHandle, gridColumnSTT).ToString());
                txtTenDoiBong.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnTenDB).ToString();
                txtTenNguoiDaiDien.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnNDD).ToString();
                txtSoDienThoai.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnSDTNDD).ToString();
                txtEMail.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnEMailNDD).ToString();
                btnCapNhatDOiBong.Enabled = true;
                btnXoaDoiBong.Enabled = true;
            }
            catch
            {
                return;
            }
        }

        private void btnCapNhatDOiBong_Click(object sender, EventArgs e)
        {
            if (maGiaiDau > 0)
            {
                if(maDoiBong > 0)
                {
                    if (txtTenDoiBong.Text.Trim().Length > 0 && txtTenNguoiDaiDien.Text.Trim().Trim().Length > 0
                        && txtSoDienThoai.Text.Trim().Length > 0 && txtEMail.Text.Trim().Length > 0)
                    {
                        if (!KiemTraDuLieu.KtraSoDienThoai(txtSoDienThoai.Text.Trim()))
                        {
                            XtraMessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtSoDienThoai.Focus();
                            return;
                        }
                        if (!KiemTraDuLieu.KtraEmail(txtEMail.Text.Trim()))
                        {
                            XtraMessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtEMail.Focus();
                            return;
                        }
                        string hinhDoiBong = txtHinhDaiDien.Text.Trim().Length > 0 ? txtHinhDaiDien.Text.Trim() : null;
                        if (SuKienBUS.Instance.capNhatDoiBong(txtTenDoiBong.Text.Trim(), txtTenNguoiDaiDien.Text.Trim(),
                            txtSoDienThoai.Text.Trim(), txtEMail.Text.Trim(), hinhDoiBong, true,maDoiBong))
                        {
                            XtraMessageBox.Show("Cập nhật đội bóng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SuKienBUS.Instance.loadDoiBong(gvDoiBong, maGiaiDau);
                            resetDataDoiBong();
                            btnCapNhatDOiBong.Enabled = false;
                            btnXoaDoiBong.Enabled = false;

                        }

                    }
                    else
                    {
                        XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng chọn đội bóng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn sự kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaDoiBong_Click(object sender, EventArgs e)
        {
            if(maGiaiDau > 0)
            {
                if (maDoiBong > 0)
                {
                    DialogResult rs = XtraMessageBox.Show("Bạn có chắc muốn xóa đội bóng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                    {
                        if (SuKienBUS.Instance.xoaDoiBong(maDoiBong))
                        {
                            XtraMessageBox.Show("Cập nhật đội bóng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SuKienBUS.Instance.loadDoiBong(gvDoiBong, maGiaiDau);
                            resetDataDoiBong();
                            btnCapNhatDOiBong.Enabled = false;
                            btnXoaDoiBong.Enabled = false;
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng chọn đội bóng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn sự kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog() { Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png" };
                if (open.ShowDialog() == DialogResult.OK)
                {
                    txtHinhDaiDien.Text = open.FileName;
                }
            }
            catch
            {
                return;
            }
        }
    }
}
