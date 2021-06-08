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
using DevExpress.XtraReports.UI;

namespace QuanLySanBongMini
{
    public partial class frmThongKeDoanhThu : Form
    {
        public frmThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            DataTable table = HoaDonBUS.Instance.thongKeDoanhThuTheoThang();
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Tháng";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Tổng tiền";
            //chart1.ChartAreas["ChartArea1"].AxisX.Title = "Tổng";
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chart1.Series.Add(" ");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                chart1.Series["Series1"].Points.AddXY(table.Rows[i]["thang"], table.Rows[i]["tong"]);
                chart1.Series[" "].Points.AddXY(table.Rows[i]["thang"], table.Rows[i]["tong"]);
            }
        }

        private void btnINHangNgay_Click(object sender, EventArgs e)
        {
            XtraReportThongKeDoanhThu rpt = new XtraReportThongKeDoanhThu();
            XRLabel xRLabel = rpt.lbTongCong;
            decimal tongTien = (decimal)ReportBUS.Instance.tongTien_theoNgay(dateTimePickerNgay.Value.Date);
            rpt.lbTongCong.Text = string.Format("{0:0,0} vnđ", tongTien);
            rpt.lbBangChu.Text = KiemTraDuLieu.chuyenTienThanhChu((double)tongTien);
            rpt.lbNgayThongKe.Text = DateTime.Now.Date.ToString("MM/dd/yyy");
            rpt.DataSource = ReportBUS.Instance.ThongKeDoanhThuTheoNgay(dateTimePickerNgay.Value.Date);
            rpt.ShowPreviewDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XtraReportThongKeDoanhThu rpt = new XtraReportThongKeDoanhThu();
            XRLabel xRLabel = rpt.lbTongCong;
            decimal tongTien = (decimal)ReportBUS.Instance.tongTien_theoThang(pkThang.Value.Month, pkThang.Value.Year);
            rpt.lbTongCong.Text = string.Format("{0:0,0} vnđ", tongTien);
            rpt.lbBangChu.Text = KiemTraDuLieu.chuyenTienThanhChu((double)tongTien);
            rpt.lbNgayThongKe.Text = DateTime.Now.Date.ToString("MM/dd/yyy");
            rpt.DataSource = ReportBUS.Instance.ThongKeDoanhThuTheoThang(pkThang.Value.Month, pkThang.Value.Year);
            rpt.ShowPreviewDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XtraReportThongKeDoanhThu rpt = new XtraReportThongKeDoanhThu();
            XRLabel xRLabel = rpt.lbTongCong;
            decimal tongTien = (decimal)ReportBUS.Instance.tongTien_theoNam(dateTimePickerNam.Value.Year);
            rpt.lbTongCong.Text = string.Format("{0:0,0} vnđ", tongTien);
            rpt.lbBangChu.Text = KiemTraDuLieu.chuyenTienThanhChu((double)tongTien);
            rpt.lbNgayThongKe.Text = DateTime.Now.Date.ToString("MM/dd/yyy");
            rpt.DataSource = ReportBUS.Instance.ThongKeDoanhThuTheoNam(dateTimePickerNam.Value.Year);
            rpt.ShowPreviewDialog();
        }
    }
}
