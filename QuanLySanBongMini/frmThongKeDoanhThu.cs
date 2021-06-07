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
    }
}
