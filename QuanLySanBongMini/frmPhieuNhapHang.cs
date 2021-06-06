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

namespace QuanLySanBongMini
{
    public partial class frmPhieuNhapHang : Form
    {
        private int dongChon=0;
        double tongTien = 0;
        int maPhieuNhap = 0;
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

            ChiTietPhieuNhapBUS.Instance.loadCTPN_maPhieuNhap(gridControlCTPN,0);

        }

        public void tinhTienTong()
        {
            double pTienNuoc = 0;
            int soDong = int.Parse(gridColumnMaThucUong.SummaryItem.SummaryValue.ToString());
            for (int i = 0; i < gridViewCTPN.RowCount-1; i++)
            {
                pTienNuoc += double.Parse(gridViewCTPN.GetRowCellValue(i,gridColumnThanhTien).ToString());
            }
            tongTien = pTienNuoc;
            txtTongTien.Text = string.Format("{0:0,0} vnđ", tongTien);
        }

        private void toolStripButtonLamMoi_Click(object sender, EventArgs e)
        {
            maPhieuNhap = 0;
            toolStripButtonInPhieu.Enabled = false;
            toolStripButtonLuuPN.Enabled = true;
            txtNguoiNhap.Text = "";
            txtTongTien.Text ="";
            lookUpEdit1.EditValue= null;
            ChiTietPhieuNhapBUS.Instance.loadCTPN_maPhieuNhap(gridControlCTPN, 0);
        }


        private void toolStripButtonLuuPN_Click(object sender, EventArgs e)
        {
            if(lookUpEdit1.EditValue== null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
            else
            {
                if (tongTien != 0)
                {
                    if (PhieuNhapBUS.Instance.themPhieuNhap(tongTien, int.Parse(lookUpEdit1.EditValue.ToString()), 1))
                    {
                        maPhieuNhap = PhieuNhapBUS.Instance.maPhieuNhapMoiNhat();
                        for (int i = 0; i < gridViewCTPN.RowCount -1; i++)
                        {
                            int maThucUong = int.Parse(gridViewCTPN.GetRowCellValue(i,gridColumnMaThucUong).ToString());
                            int soLuong = int.Parse(gridViewCTPN.GetRowCellValue(i,gridColumnSL).ToString());
                            double donGia = double.Parse(gridViewCTPN.GetRowCellValue(i, gridColumnDonGia).ToString());
                            double thanhTien = soLuong * 24 * donGia;
                            ChiTietPhieuNhapBUS.Instance.themCTPhieuNhap(maPhieuNhap, maThucUong, soLuong * 24, donGia, thanhTien);
                        }
                        toolStripButtonLuuPN.Enabled = false;
                        if (MessageBox.Show("Thêm thành công! Bạn có muốn in phiếu nhập này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            XtraReportPhieuNhap rpt = new XtraReportPhieuNhap();
                            XRLabel xRLabel = rpt.xrLabelTienChu;
                            decimal tongTien = PhieuNhapBUS.Instance.tongTien_MaPhieu(maPhieuNhap);
                            xRLabel.Text = KiemTraDuLieu.chuyenTienThanhChu((double)tongTien);
                            rpt.xrLabel10.Text =  string.Format("{0:0,0} vnđ", tongTien);
                            rpt.DataSource = ReportBUS.Instance.inPhieuNhap(maPhieuNhap);
                            rpt.ShowPreviewDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }    
            }    
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch
            {
                return;
            }
        }

        

        

        private void dgvChiTietPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dongChon = e.RowIndex;
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

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                maPhieuNhap = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn2).ToString().Trim());
                ChiTietPhieuNhapBUS.Instance.loadCTPN_maPhieuNhap(gridControlCTPN, maPhieuNhap);
                toolStripButtonInPhieu.Enabled = true;
            }
            catch
            {
                return;
            }
        }

        private void dgvChiTietPN_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void repositoryItemLookUpEditThucUong_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //int 
            }
            catch
            {
                return;
            }
        }

        private void gridViewCTPN_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
            if (e.Column.FieldName == "MaThucUong")
            {
                var maTU = gridViewCTPN.GetRowCellValue(e.RowHandle, e.Column);
                gridViewCTPN.SetRowCellValue(e.RowHandle, "DVT", ThucUongBUS.Instance.DVT((int)maTU));
                gridViewCTPN.SetRowCellValue(e.RowHandle, "DonGia", ThucUongBUS.Instance.donGiaNhap((int)maTU));
                if (int.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnSL).ToString()) == 0 || gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnSL) == null)
                {
                    gridViewCTPN.SetRowCellValue(e.RowHandle, "SoLuong", 1);
                    gridViewCTPN.SetRowCellValue(e.RowHandle, "ThanhTien", 1 * 24 * (double.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnDonGia).ToString())));

                }
                else
                {
                    gridViewCTPN.SetRowCellValue(e.RowHandle, "ThanhTien", int.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnSL).ToString()) * 24 *
                        (double.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnDonGia).ToString())));
                }    
            } 
            if(e.Column.FieldName == "SoLuong")
            {
                gridViewCTPN.SetRowCellValue(e.RowHandle, "ThanhTien", int.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnSL).ToString()) * 24 *
                        (double.Parse(gridViewCTPN.GetRowCellValue(e.RowHandle, gridColumnDonGia).ToString())));
            }
        }


        private void gridViewCTPN_Click(object sender, EventArgs e)
        {
            tongTien = 0;
            tinhTienTong();
        }
    }
}
