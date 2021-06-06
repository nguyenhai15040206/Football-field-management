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
using DAO;
using DevExpress.XtraEditors;
using DTO;

namespace QuanLySanBongMini
{
    public partial class frmDatSan : Form
    {
        int row = -1;
        public UserControlSanBong[] sanBong;
        public static string ptenSan = string.Empty;
        public static string pMaSan = string.Empty;
        int maSan=0;
        int maKhachHang = 0;
        int maLoaiSan = 0;
        double tienSan = 0, datCoc=0;
        // 
        double ptuKhungGio;
        double pdenKhungGio;
        double tien = 0;
        double gioDu = 0;
        double gioVao, soGio, gioRa;

        // truyền dữ liệu
        public static string tenKhachHang_LayDL = string.Empty;
        public static string soDienThoai_LayDL = string.Empty;
        public static string maKhachHang_LayDL = string.Empty;
        public frmDatSan()
        {
            InitializeComponent();
        }



        private void Panel1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(pMaSan))
            {
                maSan = int.Parse(pMaSan);
            }
            if(!string.IsNullOrEmpty(ptenSan))
            {
                lblChonSanBong.Text = "SÂN ĐANG CHỌN: " + ptenSan.ToUpper();
            }    
        }

        private void frmDatSan_Load(object sender, EventArgs e)
        {
            KhachHangBUS.Instance.loadKhachhang_Cbo(cboKhachHang);
            //this.userControlSanBong1.lblTenSan.Text = "Sân C1";

            //
            DatSanBUS.Instance.loadDatSan(gridContrrolDatSan);

        }

        public void resetDuLieu()
        {
            DatSanBUS.Instance.loadDatSan(gridContrrolDatSan);
            flowLayoutPanel1.Controls.Clear();
            numericUpDownGioThue.Value = 1;
            cboKhachHang.SelectedIndex = 0;
            maLoaiSan = 0;
            maSan = 0;
            maKhachHang = 0;
            row = -1;
            ckb11Nguoi.Checked = ckb5Nguoi.Checked = ckb7Nguoi.Checked = false;
            dateTimePickerGioVao.Value = DateTime.Now;
            dateTimePickerGioRa.Value = DateTime.Now;
            lblChonSanBong.Text = "CHƯA CHỌN SÂN BÓNG";
            dateTimePickerNgayDat.MinDate = DateTime.Now;
            foreach (Control item in groupBox1.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    item.Text = string.Empty;
                }
            }
        }

        private void toolStripButtonLamMoi_Click(object sender, EventArgs e)
        {
            resetDuLieu();
            toolStripButtonLuuDatSan.Enabled = true;
            toolStripButtonHuyLich.Enabled = false;
        }

        private void toolStripButtonLuuDatSan_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text.Trim().Length > 0 && txtSoDT.Text.Trim().Length > 0 && txtTienSan.Text.Trim().Length > 0)
            {
                if (maKhachHang != 0)
                {
                    if (maSan != 0)
                    {
                        if (txtDatCoc.Text.Trim().Length > 0 && double.Parse(txtDatCoc.Text.Trim())>= datCoc)
                        {
                            if (DatSanBUS.Instance.datSan(maSan, maKhachHang, 1, dateTimePickerNgayDat.Value.Date, TimeSpan.Parse(new DateTime(dateTimePickerGioVao.Value.TimeOfDay.Ticks).ToString("HH:mm")),
                                TimeSpan.Parse(new DateTime(dateTimePickerGioRa.Value.TimeOfDay.Ticks).ToString("HH:mm")), tienSan, int.Parse(txtDatCoc.Text.Trim()), txtGhiChu.Text.Trim()))
                            {
                                XtraMessageBox.Show("Thêm lịch đặt sân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loadLaiSanBongConTrong();
                                maKhachHang = 0;
                                maSan = 0;
                                tienSan = 0;
                                datCoc = 0;
                                resetDuLieu();
                            }
                            else
                            {
                                XtraMessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Vui lòng nhập số tiền đặt cọc (50% trở lên)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDatCoc.Focus();
                        }    
                    }
                    else
                    {
                        XtraMessageBox.Show("Vui lòng tìm và chọn sân bóng cần đặt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            else
            {
                XtraMessageBox.Show("Vui lòng kiểm tra lại thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }  
        }

        public void tinhTienSan()
        {
            if (maLoaiSan != 0)
            {
                dateTimePickerGioRa.Value = dateTimePickerGioVao.Value.AddHours(double.Parse(numericUpDownGioThue.Value.ToString()));

                // Tham lam
                List<DonGiaGio> dgg = DonGiaGioBUS.Instance.loadDonGiaGio_maLoaiSan(maLoaiSan);
                if (dgg.Count == 0)
                {
                    XtraMessageBox.Show("Chưa cập nhập đơn giá cho loại sân này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                for (int i = 0; i < dgg.Count - 1; i++)
                {
                    if (gioVao >= dgg[i].tuKhungGio && gioVao < dgg[i].denKhungGio)
                    {
                        ptuKhungGio = dgg[i].tuKhungGio;
                        pdenKhungGio = dgg[i].denKhungGio;
                        if (pdenKhungGio - gioVao < soGio)
                        {
                            gioDu = soGio - (pdenKhungGio - gioVao);
                            tien += (pdenKhungGio - gioVao) * (double)dgg[i].donGia;
                            if (gioDu != 0)
                            {
                                double m = gioDu;
                                for (int j = i + 1; j < dgg.Count; j++)
                                {
                                    if (dgg[j].denKhungGio - (dgg[j - 1].denKhungGio + m) >= 0)
                                    {
                                        tien += m * (double)dgg[j].donGia;
                                        break;
                                    }
                                    else
                                    {
                                        m = (dgg[j - 1].denKhungGio + m) - dgg[j].denKhungGio;
                                        tien += (dgg[j].denKhungGio - dgg[j].tuKhungGio) * (double)dgg[j].donGia;
                                        if (m != 0)
                                        {
                                            continue;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            tien = soGio * (double)dgg[i].donGia;
                            break;
                        }
                        break;
                    }
                    continue;
                }
                if (tien == 0)
                {
                    XtraMessageBox.Show("Giờ này chưa cập nhập đon giá! Vui lòng chọn giờ khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    tien = Math.Round(tien);
                    txtTienSan.Text = string.Format("{0:0,0} vnđ",tien);
                    tienSan = tien;
                    datCoc = Math.Round(tienSan * 50 / 100);
                    tien = 0;
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn sân bóng");
            }
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            gioVao = (double)dateTimePickerGioVao.Value.Hour + (double)((double)dateTimePickerGioVao.Value.Minute / 60);
            soGio = (double)numericUpDownGioThue.Value;
            gioRa = gioVao + soGio;
            if (dateTimePickerNgayDat.Value.Date == DateTime.Now.Date)
            {
                if(dateTimePickerGioVao.Value.AddMinutes(17).TimeOfDay < DateTime.Now.TimeOfDay)
                {
                    XtraMessageBox.Show("Vui lòng chọn giờ vào hợp lệ");
                    toolTip1.SetToolTip(dateTimePickerGioVao, "Giờ vào phải lớn hơn hoặc bằng giờ hiện tại (được trễ 15p)");
                    dateTimePickerGioVao.Focus();
                    return;
                    
                }
                else
                {
                    tinhTienSan();
                }
            }
            else
            {
                tinhTienSan();
            }    

        }


        private void btnTimSan_Click(object sender, EventArgs e)
        {
            if (maLoaiSan != 0)
            {
                loadLaiSanBongConTrong();
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn loại sân bóng!");
            }    
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
                    sanBong[i].panel1.Click += Panel1_Click;
                    flowLayoutPanel1.Controls.Add(sanBong[i]);
                }
            }
        }

        private void toolStripButtonHuySan_Click(object sender, EventArgs e)
        {
            if (row !=-1)
            {
                DialogResult rs = XtraMessageBox.Show("Bạn có chắc muốn hủy lịch đặt này không?", "Thông báo hủy sân", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    if (DatSanBUS.Instance.xoaDatSan(maSan, int.Parse(cboKhachHang.SelectedValue.ToString()), dateTimePickerNgayDat.Value.Date,
                        TimeSpan.Parse(new DateTime(dateTimePickerGioVao.Value.TimeOfDay.Ticks).ToString("HH:mm")),
                                        TimeSpan.Parse(new DateTime(dateTimePickerGioRa.Value.TimeOfDay.Ticks).ToString("HH:mm"))))
                    {
                        XtraMessageBox.Show("Xóa lịch đặt sân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        resetDuLieu();
                    }
                    else
                    {
                        XtraMessageBox.Show("Xóa thất bại, vui lòng kiểm tra lại thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn lịch đặt sân cần xóa", "Thông báo hủy sân", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch
            {
                return;
            }
        }

        private void txtDatCoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                toolTip1.SetToolTip(txtDatCoc, "Vui lòng nhập số tiền hợp lệ");
            }    
        }

        private void txtDatCoc_TextChanged(object sender, EventArgs e)
        {
            
        }


        #region sự kiện cho checkBox
        private void ckb5Nguoi_CheckedChanged(object sender, EventArgs e)
        {
            if(ckb5Nguoi.Checked== true)
            {
                maLoaiSan = 1;
            }    
            if(ckb7Nguoi.Checked==true)
            {
                ckb7Nguoi.Checked = false;
            }  
            if(ckb11Nguoi.Checked == true)
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
        #endregion


        // databiding
        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            toolStripButtonLuuDatSan.Enabled = false;
            try
            {
                row = e.RowHandle;
                dateTimePickerNgayDat.MinDate = DateTime.Parse("31/12/2020");
                lblChonSanBong.Text = "SÂN ĐANG CHỌN: " + (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTenSan).ToString().ToUpper());
                txtGhiChu.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnGhiChu).ToString();
                txtTenKH.Text = (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTenKh).ToString());
                txtSoDT.Text = (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnSoDT).ToString());
                txtTienSan.Text = string.Format("{0:0,0} vnđ", double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTienSan).ToString()));
                txtDatCoc.Text = string.Format("{0:0,0} vnđ", double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTienCoc).ToString()));
                maSan = SanBongBUS.Instance.maSan_voiTenSan(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTenSan).ToString());
                dateTimePickerNgayDat.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnNgayDat).ToString();
                dateTimePickerGioVao.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnGioVao).ToString();
                dateTimePickerGioRa.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnGioRa).ToString();
                maKhachHang = KhachHangBUS.Instance.maKhachHang_soDienThoai(txtSoDT.Text.Trim());
                cboKhachHang.SelectedValue = maKhachHang;
                toolStripButtonHuyLich.Enabled = true;
            }
            catch
            {
                return;
            }

        }

        private void cboKhachHang_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                maKhachHang = int.Parse(cboKhachHang.SelectedValue.ToString());
                txtTenKH.Text = KhachHangBUS.Instance.hotenKhachHang(maKhachHang);
                txtSoDT.Text = KhachHangBUS.Instance.soDienThoai(maKhachHang);
            }
            catch
            {
                maKhachHang = int.Parse(cboKhachHang.SelectedValue.ToString());
                txtTenKH.Text = KhachHangBUS.Instance.hotenKhachHang(maKhachHang);
                txtSoDT.Text = KhachHangBUS.Instance.soDienThoai(maKhachHang);
            }
        }

        private void txtSoDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
        }

        private void simpleButtonThemKH_Click(object sender, EventArgs e)
        {
            int maKH = 0;
            frmQLKhachHang frm = new frmQLKhachHang();
            frm.ShowDialog();
            if (!string.IsNullOrEmpty(tenKhachHang_LayDL))
            {
                this.txtTenKH.Text = tenKhachHang_LayDL;
            }
            if (!string.IsNullOrEmpty(soDienThoai_LayDL))
            {
                this.txtSoDT.Text = soDienThoai_LayDL;
            }

            if(!string.IsNullOrEmpty(maKhachHang_LayDL))
            {
                maKH = int.Parse(maKhachHang_LayDL);
            }    
            KhachHangBUS.Instance.loadKhachhang_Cbo(cboKhachHang);
            cboKhachHang.SelectedValue = maKH;

        }
    }
}
