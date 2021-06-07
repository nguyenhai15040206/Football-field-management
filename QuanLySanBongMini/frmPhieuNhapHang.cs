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
using DevExpress.XtraExport.Implementation;
using DevExpress.XtraReports.UI;
using DevExpress.XtraBars.MessageFilter;
using DevExpress.XtraEditors;

namespace QuanLySanBongMini
{
    public partial class frmPhieuNhapHang : Form
    {
        private int dongChon = 0;
        double tongTien = 0;
        int maPhieuNhap = 0, maThucUong = 0, soLuong=0;
        double giaNhap = 0, thanhTien=0;
        bool tinhTrang = true;
        public frmPhieuNhapHang()
        {
            InitializeComponent();
        }

        private void frmQuanLySanBong_Load(object sender, EventArgs e)
        {
            // load nhà cung cấp
            NhaCungCapBUS.Instance.loadNCC_LookUpEdit(lookUpEdit1);

            // load Thức uống
            ThucUongBUS.Instance.loadThucUong_looUpEdit(repositoryItemLookUpEditThucUong);
            // load tất cả các phiếu nhập
            PhieuNhapBUS.Instance.loadTatCaPhieuNhap(gridContrrolPN);
            ChiTietPhieuNhapBUS.Instance.loadCTPN_maPhieuNhap(gridControlCTPN, 0);

        }

        public void tinhTienTong()
        {
            double pTienNuoc = 0;
            int soDong = int.Parse(gridColumnMaThucUong.SummaryItem.SummaryValue.ToString());
            for (int i = 0; i < gridViewCTPN.RowCount - 1; i++)
            {
                pTienNuoc += double.Parse(gridViewCTPN.GetRowCellValue(i, gridColumnThanhTien).ToString());
            }
            tongTien = pTienNuoc;
            txtTongTien.Text = string.Format("{0:0,0} vnđ", tongTien);
        }

        public void lamMoiDuLieu()
        {
            maPhieuNhap = 0;
            tongTien = 0;
            txtNguoiNhap.Text = "";
            txtTongTien.Text = "";
            lookUpEdit1.EditValue = null;
            
            PhieuNhapBUS.Instance.loadTatCaPhieuNhap(gridContrrolPN);
        }

        private void toolStripButtonLamMoi_Click(object sender, EventArgs e)
        {
            gridViewCTPN.OptionsBehavior.Editable = true;
            toolStripButtonInPhieu.Enabled = false;
            toolStripButtonLuuPN.Enabled = true;
            ChiTietPhieuNhapBUS.Instance.loadCTPN_maPhieuNhap(gridControlCTPN, 0);
            lamMoiDuLieu();
        }


        private void toolStripButtonLuuPN_Click(object sender, EventArgs e)
        {
            if (lookUpEdit1.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (tongTien != 0)
                {
                    if (PhieuNhapBUS.Instance.themPhieuNhap(tongTien, int.Parse(lookUpEdit1.EditValue.ToString()), 1))
                    {
                        maPhieuNhap = PhieuNhapBUS.Instance.maPhieuNhapMoiNhat();
                        for (int i = 0; i < gridViewCTPN.RowCount - 1; i++)
                        {
                            int maThucUong = int.Parse(gridViewCTPN.GetRowCellValue(i, gridColumnMaThucUong).ToString());
                            int soLuong = int.Parse(gridViewCTPN.GetRowCellValue(i, gridColumnSL).ToString());
                            double donGia = double.Parse(gridViewCTPN.GetRowCellValue(i, gridColumnDonGia).ToString());
                            double thanhTien = soLuong * 24 * donGia;
                            ChiTietPhieuNhapBUS.Instance.themCTPhieuNhap(maPhieuNhap, maThucUong, soLuong * 24, donGia, thanhTien);
                            ThucUongBUS.Instance.capNhatSoLuongKhiHuy(maThucUong,soLuong*24);
                        }
                        toolStripButtonLuuPN.Enabled = false;
                        if (MessageBox.Show("Thêm thành công! Bạn có muốn in phiếu nhập này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            XtraReportPhieuNhap rpt = new XtraReportPhieuNhap();
                            XRLabel xRLabel = rpt.xrLabelTienChu;
                            decimal tongTien = PhieuNhapBUS.Instance.tongTien_MaPhieu(maPhieuNhap);
                            xRLabel.Text = KiemTraDuLieu.chuyenTienThanhChu((double)tongTien);
                            rpt.xrLabel10.Text = string.Format("{0:0,0} vnđ", tongTien);
                            rpt.DataSource = ReportBUS.Instance.inPhieuNhap(maPhieuNhap);
                            rpt.ShowPreviewDialog();
                        }
                        lamMoiDuLieu();
                        ChiTietPhieuNhapBUS.Instance.loadCTPN_maPhieuNhap(gridControlCTPN, 0);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void toolStripButtonInPhieu_Click(object sender, EventArgs e)
        {

            XtraReportPhieuNhap rpt = new XtraReportPhieuNhap();
            XRLabel xRLabel = rpt.xrLabelTienChu;
            decimal tongTien = PhieuNhapBUS.Instance.tongTien_MaPhieu(maPhieuNhap);
            rpt.xrLabel10.Text = string.Format("{0:0,0} vnđ", tongTien);
            xRLabel.Text = KiemTraDuLieu.chuyenTienThanhChu((double)tongTien);
            rpt.DataSource = ReportBUS.Instance.inPhieuNhap(maPhieuNhap);
            rpt.ShowPreviewDialog();
        }

        private void gridViewCTPN_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "gridColumnMaThucUong")
            {

                var maTU = gridViewCTPN.GetRowCellValue(e.RowHandle, e.Column);
                gridViewCTPN.SetRowCellValue(e.RowHandle, "DVT", ThucUongBUS.Instance.DVT((int)maTU));
                gridViewCTPN.SetRowCellValue(e.RowHandle, "DonGia", ThucUongBUS.Instance.donGiaNhap((int)maTU));
                if (int.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnSL).ToString()) == 0 || gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnSL) == null)
                {
                    gridViewCTPN.SetRowCellValue(e.RowHandle, "SoLuong", 1);
                    gridViewCTPN.SetRowCellValue(e.RowHandle, "ThanhTien", 1 * 24 * (double.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnDonGia).ToString())));
                    tinhTienTong();
                }
                else
                {
                    gridViewCTPN.SetRowCellValue(e.RowHandle, "ThanhTien", int.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnSL).ToString()) * 24 *
                        (double.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnDonGia).ToString())));
                    tinhTienTong();
                }
            }
            if (e.Column.Name == "gridColumnSL")
            {
                gridViewCTPN.SetRowCellValue(e.RowHandle, "ThanhTien", int.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnSL).ToString()) * 24 *
                        (double.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnDonGia).ToString())));
                tinhTienTong();
            }

        }


        private void gridViewCTPN_Click(object sender, EventArgs e)
        {
            tinhTienTong();

        }


        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                maPhieuNhap = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn2).ToString().Trim());
                ChiTietPhieuNhapBUS.Instance.loadCTPN_maPhieuNhap(gridControlCTPN, maPhieuNhap);
                txtNguoiNhap.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnNguoiNhap).ToString();
                txtTongTien.Text = string.Format("{0:0,0} vnđ", double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTongTien).ToString()));
                toolStripButtonInPhieu.Enabled = true;
                toolStripButtonLuuPN.Enabled = false;
                int maNCC =  NhaCungCapBUS.Instance.maNCC_soDT((gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn4).ToString()));
                lookUpEdit1.EditValue = maNCC;
                tinhTrang = bool.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumnTinhTrang).ToString());
                bunifuCkbTinhTrang.Checked = tinhTrang;
                gridViewCTPN.OptionsBehavior.Editable = false;
            }
            catch
            {
                return;
            }
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "gridColumn1")
            {
                maPhieuNhap = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn2).ToString().Trim());
                if (tinhTrang == true)
                {
                    if (MessageBox.Show("Bạn có chắc muốn hủy có đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (PhieuNhapBUS.Instance.xoaPhieuNhap(maPhieuNhap))
                        {
                            MessageBox.Show("Phiếu nhập này đã được hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            for(int i= 0; i< gridViewCTPN.RowCount-1; i++)
                            {
                                int maThucUong = int.Parse(gridViewCTPN.GetRowCellValue(i, gridColumnMaThucUong).ToString());
                                int soLuong = int.Parse(gridViewCTPN.GetRowCellValue(i, gridColumnSL).ToString());
                                ThucUongBUS.Instance.capNhatSoLuongKhiMua(maThucUong,soLuong*24);
                            }    
                            lamMoiDuLieu();
                            ChiTietPhieuNhapBUS.Instance.loadCTPN_maPhieuNhap(gridControlCTPN, 0);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Phiếu nhập không khả dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void bunifuCkbTinhTrang_OnChange(object sender, EventArgs e)
        {
            if (bunifuCkbTinhTrang.Checked == true)
            {
                tinhTrang = true;
                blTinhTrang.Text = "Đơn đã nhập";
                lamMoiDuLieu();
                PhieuNhapBUS.Instance.loadTatCaPhieuNhap(gridContrrolPN);
                
            }
            else
            {
                tinhTrang = false;
                blTinhTrang.Text = "Đơn đã hủy";
                lamMoiDuLieu();
                PhieuNhapBUS.Instance.loadTatCaPhieuNhap_TinhTrangHuy(gridContrrolPN);
                
            }
        }

        private void gridViewCTPN_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            maThucUong = 0;
            if( gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnMaThucUong)!= null)
            {
                maThucUong = int.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnMaThucUong).ToString());
                soLuong = int.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnSL).ToString()) * 24;
                giaNhap = double.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnDonGia).ToString());
                thanhTien = soLuong * giaNhap;
                dongChon = e.RowHandle;
            }
            
        }

        private void gridViewCTPN_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if(e.Column.Name== "gridColumnXoa")
            {
                if (maThucUong > 0)
                {
                    if (gridViewCTPN.DataRowCount != 0)
                    {
                        if (ChiTietPhieuNhapBUS.Instance.CTPhieuNhap(maPhieuNhap, maThucUong) == false)
                        {
                            gridViewCTPN.DeleteRow(dongChon);
                            tinhTienTong();
                        }
                    }
                }
            } 
        }

        private void repositoryItemButtonEditXoaCTPN_Click(object sender, EventArgs e)
        {
            

        }
    }
}
