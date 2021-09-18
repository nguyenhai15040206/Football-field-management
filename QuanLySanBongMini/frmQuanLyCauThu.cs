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
    public partial class frmQuanLyCauThu : Form
    {
        public int maCauThu = 0;
        public int maDoiBong = 0;
        public frmQuanLyCauThu()
        {
            InitializeComponent();
        }

        private void frmQuanLyCauThu_Load(object sender, EventArgs e)
        {
            SuKienBUS.Instance.loadDoiBongBoiSuKien_Look(gridLookUpEdit1, 3);
        }

        private void btnThemCauThu_Click(object sender, EventArgs e)
        {
            if(gridLookUpEdit1.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn đội bóng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int maDoiBong = int.Parse(gridLookUpEdit1.EditValue.ToString());
                if(txtTenCauThu.Text.Trim().Length > 0 && txtSDT.Text.Trim().Length > 0 && txtCMND.Text.Trim().Length > 0)
                {
                    if (KiemTraDuLieu.KtraSoDienThoai(txtSDT.Text.Trim()))
                    {
                        if(txtCMND.Text.Trim().Length <10 && KiemTraDuLieu.ktraChiNhapSo(txtCMND.Text.Trim()))
                        {
                            if(SuKienBUS.Instance.soLuongCauThu_suKien(3) <= gridView1.RowCount)
                            {
                                XtraMessageBox.Show("Số lượng cầu thử vượt quá mức quy định!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if(SuKienBUS.Instance.themCauThu(txtTenCauThu.Text,txtSDT.Text,dateNgaySinh.Value.Date, txtHinh.Text, txtCMND.Text, maDoiBong))
                            {
                                XtraMessageBox.Show("Thêm cầu thủ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SuKienBUS.Instance.loadCauThu(gvCauThu, maDoiBong, true);
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("CMND không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtSDT.Focus();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSDT.Focus();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                maDoiBong = int.Parse(gridLookUpEdit1.EditValue.ToString());
                SuKienBUS.Instance.loadCauThu(gvCauThu, maDoiBong, true);
                lbThongTinDB.Text = "Thông tin đội bóng -> Tên đội bóng: " + SuKienBUS.Instance.tenDoiBong(maDoiBong)
                    + " - Tên người đại diện: "+ SuKienBUS.Instance.tenNguoiDaiDien(maDoiBong) + 
                    " - SĐT Người đại diện: "+ SuKienBUS.Instance.soDienThoaiNguoiDaiDien(maDoiBong);
            }
            catch
            {
                return;
            }
        }

        public void reset()
        {
            txtCMND.Text = "";
            txtHinh.Text = "";
            txtSDT.Text = "";
            txtTenCauThu.Text = "";
            dateNgaySinh.Value = DateTime.Now;
            maCauThu = 0;
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            reset();
            txtTenCauThu.Focus();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                maCauThu = int.Parse(gridView1.GetRowCellValue(e.RowHandle, gridColumnMaCauThu).ToString());
                txtCMND.Text = gridView1.GetRowCellValue(e.RowHandle, gridColumnCMND).ToString();
                txtSDT.Text = gridView1.GetRowCellValue(e.RowHandle, gridColumnSDT).ToString();
                txtTenCauThu.Text = gridView1.GetRowCellValue(e.RowHandle, gridColumnTenSK).ToString();
                dateNgaySinh.Text = gridView1.GetRowCellValue(e.RowHandle, gridColumnNgaySinh).ToString();
            }
            catch
            {
                return;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (maCauThu <= 0)
            {
                XtraMessageBox.Show("Vui lòng chọn cầu thủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int maDoiBong = int.Parse(gridLookUpEdit1.EditValue.ToString());
                if (txtTenCauThu.Text.Trim().Length > 0 && txtSDT.Text.Trim().Length > 0 && txtCMND.Text.Trim().Length > 0)
                {
                    if (KiemTraDuLieu.KtraSoDienThoai(txtSDT.Text.Trim()))
                    {
                        if (txtCMND.Text.Trim().Length < 10 && KiemTraDuLieu.ktraChiNhapSo(txtCMND.Text.Trim()))
                        {
                            if (SuKienBUS.Instance.capNhatCauThu(maCauThu,txtTenCauThu.Text, txtSDT.Text, dateNgaySinh.Value.Date, txtHinh.Text, txtCMND.Text))
                            {
                                XtraMessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SuKienBUS.Instance.loadCauThu(gvCauThu, maDoiBong, true);
                                reset();
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("CMND không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtSDT.Focus();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSDT.Focus();
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maCauThu <= 0)
            {
                XtraMessageBox.Show("Vui lòng chọn cầu thủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int maDoiBong = int.Parse(gridLookUpEdit1.EditValue.ToString());
                DialogResult rs = XtraMessageBox.Show("Bạn có chắc muốn xóa cầu thủ này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(rs == DialogResult.Yes)
                {
                    if (SuKienBUS.Instance.xoaCauThu(maCauThu))
                    {
                        XtraMessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SuKienBUS.Instance.loadCauThu(gvCauThu, maDoiBong, true);
                        reset();
                    }
                }   
            }
        }

        private void btnTaoBangDau_Click(object sender, EventArgs e)
        {
            cbbBangDau.Items.Clear();
            txtSoDoi.Text = Convert.ToString(SuKienBUS.Instance.soDoiThamGia_suKien(3) / SuKienBUS.Instance.soBangDau_suKien(3));
            txtSoBang.Text = Convert.ToString(SuKienBUS.Instance.soBangDau_suKien(3));
            txtSoDoiKnock.Text = Convert.ToString(SuKienBUS.Instance.soDoiTGiaKnockout_suKien(3));

            char[] alphabet = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();
            for (int i = 0; i < int.Parse(txtSoBang.Text.Trim()); i++)
            {
                cbbBangDau.Items.Add("Bảng " + alphabet[i]);
            }
        }

        private void btnThemDoi_Click(object sender, EventArgs e)
        {
            if(cbbBangDau.SelectedItem == null)
            {
                XtraMessageBox.Show("Vui lòng chọn bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if(maDoiBong == 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn đội bóng cần thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if(dataGridView1.RowCount > int.Parse(txtSoDoi.Text.Trim()))
                    {
                        
                        XtraMessageBox.Show("Đã đủ số lượng cho bảng đấu này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        bool check = true;
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            if(dataGridView1.Rows[i].Cells["ma"].Value != null &&
                                int.Parse(dataGridView1.Rows[i].Cells["ma"].Value.ToString()) == maDoiBong)
                            {

                                check = false;
                                XtraMessageBox.Show("Đội bóng này đã có trong bảng đấu rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                check = true;
                                continue;
                            }
                        }
                        if (check)
                        {
                            int rowId = dataGridView1.Rows.Add();
                            DataGridViewRow row = dataGridView1.Rows[rowId];
                            row.Cells["ma"].Value = maDoiBong;
                            row.Cells["ten"].Value = SuKienBUS.Instance.tenDoiBong(maDoiBong);
                            row.Cells["hoten"].Value = SuKienBUS.Instance.tenNguoiDaiDien(maDoiBong);
                            row.Cells["sdt"].Value = SuKienBUS.Instance.soDienThoaiNguoiDaiDien(maDoiBong);
                        }
                        if((dataGridView1.RowCount - 1)  == int.Parse(txtSoDoi.Text.Trim()))
                        {
                            btnLuuBangDau.Enabled = true;
                            return;
                        }


                    }
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnXoaDoi_Click(object sender, EventArgs e)
        {

        }

        private void btnLuuBangDau_Click(object sender, EventArgs e)
        {
            DialogResult rs = XtraMessageBox.Show("Bảng có chắc muốn lưu " + cbbBangDau.SelectedItem.ToString() + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                if (SuKienBUS.Instance.themBangThiDau(cbbBangDau.SelectedItem.ToString(), 3, true))
                {
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        SuKienBUS.Instance.themChiTietBangDau(int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()), "");
                    }

                    XtraMessageBox.Show("Lưu bảng thi đấu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.Clear();
                    btnLuuBangDau.Enabled = false;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Selected)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null)
                {
                    return;
                }
                else
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                }
            }
        }
    }
}
