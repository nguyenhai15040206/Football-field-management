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
using DevExpress.XtraReports.UI;

namespace QuanLySanBongMini
{
    public partial class frmQLHoaDon : Form
    {
        private bool tinhTrang=true;
        int maHoaDon = 0;

        // 
        private int maSan=0, maKhachHang=0;
        private TimeSpan gioVao = TimeSpan.Parse(new DateTime(DateTime.Now.Ticks).ToString("HH:mm"));
        private TimeSpan gioRa = TimeSpan.Parse(new DateTime(DateTime.Now.Ticks).ToString("HH:mm"));
        private DateTime ngayDat = DateTime.Now.Date;
        public frmQLHoaDon()
        {
            InitializeComponent();
        }

        private void frmQLHoaDon_Load(object sender, EventArgs e)
        {
            // load hóa đơn với tình trạng khả dụng
            HoaDonBUS.Instance.loadHoaDon_GridControl(gridControlHD, tinhTrang);

            // load thức uống lên lookUpEdit trong gridControl
            ThucUongBUS.Instance.loadThucUong_looUpEdit(repositoryItemLookUpEditThucUong);
        }

        public void lamMoiDuLieu()
        {
            dateTimePickerNgayDat.Value = DateTime.Now;
            foreach(Control item in panel5.Controls)
            {
                if(item.GetType() == typeof(TextBox))
                {
                    item.Text = string.Empty;
                }    
            }
            toolStripButtonInPhieu.Enabled = false;
        }


        private void bunifuCkbTinhTrang_OnChange(object sender, EventArgs e)
        {
            if(bunifuCkbTinhTrang.Checked == true)
            {
                tinhTrang = true;
                lbTinhTrang.Text = "Khả dụng";
                HoaDonBUS.Instance.loadHoaDon_GridControl(gridControlHD, tinhTrang);
                lamMoiDuLieu();
            }   
            else
            {
                tinhTrang = false;
                lbTinhTrang.Text = "Không khả dụng";
                HoaDonBUS.Instance.loadHoaDon_GridControl(gridControlHD, tinhTrang);
                lamMoiDuLieu();
            }    
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                maHoaDon = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnMaHD).ToString().Trim());
                ChiTietHoaDonBUS.Instance.loadCTHD_maHD(gridControlCTHD, maHoaDon);
                txtTenKhachHang.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTenKH).ToString();
                txtSDT.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnSDT).ToString();
                dateTimePickerNgayDat.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnNgayDat).ToString();
                txtKhungGioDa.Text = "Từ:  "+gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnGioVao).ToString()+ "  đến:  "+
                    gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnGioRa).ToString();
                txtTienNuoc.Text = string.Format("{0:0,0} vnđ", double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTienNuoc).ToString()));
                txtTongTien.Text = string.Format("{0:0,0} vnđ", double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTongTien).ToString()));
                tinhTrang = bool.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTinhTrang).ToString());
                bunifuCkbTinhTrang.Checked = tinhTrang;
                //
                maSan = SanBongBUS.Instance.maSan_voiTenSan(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTenSan).ToString());
                maKhachHang = KhachHangBUS.Instance.maKhachHang_soDienThoai(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnSDT).ToString());
                ngayDat = DateTime.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnNgayDat).ToString());
                gioVao = TimeSpan.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnGioVao).ToString());
                gioRa = TimeSpan.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnGioRa).ToString());
                if (tinhTrang== true)
                {
                    toolStripButtonInPhieu.Enabled = true;
                }    

            }
            catch
            {
                return;
            }
        }

        private void toolStripButtonInPhieu_Click(object sender, EventArgs e)
        {
            XtraReportXuatHoaDon rpt = new XtraReportXuatHoaDon();
            rpt.DataSource = ReportBUS.Instance.thanhToanSan(maHoaDon);
            rpt.ShowPreviewDialog();
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "gridColumn1")
            {
                maHoaDon = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnMaHD).ToString().Trim());
                if (tinhTrang == true)
                {
                    if (XtraMessageBox.Show("Bạn có chắc muốn hủy hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (HoaDonBUS.Instance.huyHoaDon(maHoaDon))
                        {
                            
                            XtraMessageBox.Show("Hóa đơn này đã được hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DatSanBUS.Instance.capNhatDatSan_ChuaThanhToan(maSan, maKhachHang, ngayDat, gioVao, gioRa, false);
                            for(int i=0; i < gridViewCTHD.RowCount;i++)
                            {
                                int maSP = int.Parse(gridViewCTHD.GetRowCellValue(i, gridColumnMaThucUong).ToString());
                                int soLuong = int.Parse(gridViewCTHD.GetRowCellValue(i, gridColumnSL).ToString());
                                ThucUongBUS.Instance.capNhatSoLuongKhiHuy(maSP, soLuong);
                            }
                            KhachHangBUS.Instance.capNhatDienTichLuy_khiHuy(maKhachHang);
                            lamMoiDuLieu();
                            HoaDonBUS.Instance.loadHoaDon_GridControl(gridControlHD, true);
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Hóa đơn này không khả dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

    }
}
