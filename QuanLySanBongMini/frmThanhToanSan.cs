using BUS;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace QuanLySanBongMini
{
    public partial class frmThanhToanSan : Form
    {
        int dongChon = 0;
        double tienSan = 0, datCoc = 0, giamGia = 0;
        double tienNuoc = 0, tongTien = 0;
        int maKhachHang = 0,maSan=0;
        DateTime ngayDat;
        TimeSpan gioVao, gioRa;
        public frmThanhToanSan()
        {
            InitializeComponent();
        }

        public void resetDuLieu()
        {
            dongChon = 0;
            tienNuoc = tienSan =datCoc = giamGia =tongTien= maKhachHang= maSan=0;
            foreach (Control item in groupBox1.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    item.Text = string.Empty;
                }
            }
        }

        private void frmThanhToanSan_Load(object sender, EventArgs e)
        {
            // load danh sách đặt sân chưa thanh toán
            DatSanBUS.Instance.loadDatSanChuaThanhToan(lookUpEdit1);

            // load danh sách thức uống lên treeList
            ThucUongBUS.Instance.loadThucUong_TreeList(treeListThucUong);

            // load thức uống lên comBobox
            ThucUongBUS.Instance.loadThucUong_cbo(cbbThucUong);



        }


        private void txtKhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }   
        }

        private void txtKhachHang_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtKhachDua, "Nhập số tiền lớn hơn hoặc bằng tổng tiền!");
            double khachDua = 0;
            khachDua = txtKhachDua.Text.Trim() == "" ? 0 : double.Parse(txtKhachDua.Text.Trim());
            txtTienThua.Text = string.Format("{0:0,0} vnđ", (khachDua - tongTien));
            if (txtKhachDua.Text.Trim().Length >0 && khachDua >= tongTien)
            {
                toolStripButtonThanhToan.Enabled = true;
            }
            else
            {
                toolStripButtonThanhToan.Enabled = false;
            }    
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvChiTietHD.Rows[e.RowIndex].Cells[0].Selected)
            {
                if (dgvChiTietHD.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    dgvChiTietHD.Rows.Remove(dgvChiTietHD.Rows[e.RowIndex]);
                    tinhTienTong();
                }
            }

        }

        public void tinhTienTong()
        {
            double pTienNuoc = 0;
            for (int i = 0; i < dgvChiTietHD.Rows.Count - 1; i++)
            {
                pTienNuoc += double.Parse(dgvChiTietHD.Rows[i].Cells[5].Value.ToString());
            }
            tienNuoc = pTienNuoc;
            txtTienNuoc.Text = string.Format("{0:0,0} vnđ", tienNuoc);
            tongTien = Math.Round(tienSan - datCoc - giamGia + tienNuoc);
            txtTongTien.Text = string.Format("{0:0,0} vnđ", tongTien);
        }

        private void toolStripButtonLamMoi_Click(object sender, EventArgs e)
        {
            resetDuLieu();
        }

        private void toolStripButtonThanhToanNhieuSan_Click(object sender, EventArgs e)
        {
            XtraReportXuatHoaDon rpt = new XtraReportXuatHoaDon();
            rpt.DataSource = ReportBUS.Instance.thanhToanSan(5);
            rpt.ShowPreviewDialog();
        }

        private void dgvChiTietHD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            if(dgvChiTietHD.CurrentRow !=null)
            {
                try
                {
                    dgvChiTietHD.Rows[dongChon].Cells[2].Value = ThucUongBUS.Instance.DVT(int.Parse(dgvChiTietHD.Rows[dongChon].Cells[1].Value.ToString()));
                    dgvChiTietHD.Rows[dongChon].Cells[4].Value = ThucUongBUS.Instance.donGia(int.Parse(dgvChiTietHD.Rows[dongChon].Cells[1].Value.ToString()));
                    if (dgvChiTietHD.Rows[dongChon].Cells[3].Value != null)
                    {
                        if (KiemTraDuLieu.ktraChiNhapSo(dgvChiTietHD.Rows[dongChon].Cells[3].Value.ToString()))
                        {
                            dgvChiTietHD.Rows[dongChon].Cells[5].Value = ThucUongBUS.Instance.donGia(int.Parse(dgvChiTietHD.Rows[dongChon].Cells[1].Value.ToString())) *
                                    int.Parse(dgvChiTietHD.Rows[dongChon].Cells[3].Value.ToString());
                            tinhTienTong();

                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập số lượng chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        dgvChiTietHD.Rows[dongChon].Cells[3].Value = 1;
                        dgvChiTietHD.Rows[dongChon].Cells[5].Value = ThucUongBUS.Instance.donGia(int.Parse(dgvChiTietHD.Rows[dongChon].Cells[1].Value.ToString())) * 1;
                        tinhTienTong();
                    }    
                }
                catch
                {
                    return;
                }
            }    
        }

        private void toolStripButtonThanhToan_Click(object sender, EventArgs e)
        {
            
            if (txtSDT.Text.Trim().Length > 0)
            {
                if (HoaDonBUS.Instance.themHoaDon(tienSan, giamGia, tienNuoc, tongTien,maSan, maKhachHang,ngayDat,gioVao,gioRa, 1))
                {
                    int maHoaDon = HoaDonBUS.Instance.maHoaDon_top1();
                    for (int i = 0; i < dgvChiTietHD.Rows.Count - 1; i++)
                    {

                        int maThucUong = int.Parse(dgvChiTietHD.Rows[i].Cells[1].Value.ToString());
                        int soLuong = int.Parse(dgvChiTietHD.Rows[i].Cells[3].Value.ToString());
                        double donGia = double.Parse(dgvChiTietHD.Rows[i].Cells[4].Value.ToString());
                        double thanhTien = soLuong * donGia;
                        ChiTietHoaDonBUS.Instance.themCTHoaDon(maHoaDon, maThucUong, soLuong, donGia, thanhTien);
                    }
                    toolStripButtonThanhToan.Enabled = false;
                    if (MessageBox.Show("Thêm thành công! Bạn có muốn in hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        XtraReportXuatHoaDon rpt = new XtraReportXuatHoaDon();
                        rpt.DataSource = ReportBUS.Instance.thanhToanSan(maHoaDon);
                        rpt.ShowPreviewDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng sân cần thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongChon = e.RowIndex;
            
        }



        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtKhachDua.ReadOnly = false;
                tienSan = double.Parse(lookUpEdit1.GetColumnValue("TienSan").ToString());
                datCoc = double.Parse(lookUpEdit1.GetColumnValue("TienCoc").ToString());
                txtTenKhachHang.Text = lookUpEdit1.GetColumnValue("TenKhachhang").ToString();
                txtSDT.Text = lookUpEdit1.GetColumnValue("SoDienThoai").ToString();
                maKhachHang = KhachHangBUS.Instance.maKhachHang_soDienThoai(txtSDT.Text.Trim());
                dateTimePickerNgayDat.Text = lookUpEdit1.GetColumnValue("NgayDat").ToString();
                ngayDat = dateTimePickerNgayDat.Value.Date;
                maSan = SanBongBUS.Instance.maSan_voiTenSan(lookUpEdit1.GetColumnValue("TenSan").ToString().Trim());
                gioVao = TimeSpan.Parse(lookUpEdit1.GetColumnValue("GioVao").ToString());
                gioRa = TimeSpan.Parse(lookUpEdit1.GetColumnValue("GioRa").ToString());
                txtKhungGioDa.Text = "Từ: " +lookUpEdit1.GetColumnValue("GioVao").ToString()+" đến: " + lookUpEdit1.GetColumnValue("GioRa").ToString();
                txtTienSan.Text = string.Format("{0:0,0} vnđ", double.Parse(lookUpEdit1.GetColumnValue("TienSan").ToString()));
                txtDatCoc.Text = string.Format("{0:0,0} vnđ", double.Parse(lookUpEdit1.GetColumnValue("TienCoc").ToString()));
                numericUpDownGiamGia.Value = (decimal)LoaiKhachHangBUS.Instance.giamGia(txtSDT.Text.Trim());

                txtKhachDua.Text = "";
                txtTienThua.Text = "";
                txtKhachDua.Focus();
                
            }
            catch
            {
                return;
            }
            
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            
            giamGia = Math.Round(tienSan * (double)numericUpDownGiamGia.Value / 100);
            txtGiamGia.Text = string.Format("{0:0,0} vnđ", giamGia);
            tongTien = Math.Round(tienSan - datCoc - giamGia + tienNuoc);
            txtTongTien.Text = string.Format("{0:0,0} vnđ", tongTien);
            


        }
    }
}
