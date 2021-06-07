using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DevExpress.XtraGrid;

namespace BUS
{
    public class HoaDonBUS
    {
        private static HoaDonBUS instance;
        public static HoaDonBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new HoaDonBUS();
                }
                return instance;
            }
        }

        // load tất cả hóa đơn với tình trạng hóa đơn (hóa đơn có khả dụng hây không )
        public void loadHoaDon_GridControl(GridControl dgv, bool tinhTrang)
        {
            dgv.DataSource = HoaDonDAO.Instance.loadHoaDon(tinhTrang);
        }    

        // thêm hóa đơn mới
        public bool themHoaDon(double tienSan, double giamGia, double tienNuoc, double tongTien, int maSan, int maKhachHang,
            DateTime ngayDat, TimeSpan gioVao, TimeSpan gioRa, int maNguoiDung)
        {
            return HoaDonDAO.Instance.themHoaDon(tienSan,giamGia, tienNuoc, tongTien,maSan, maKhachHang,ngayDat,gioVao,gioRa, maNguoiDung);
        }

        // mã hóa đơn mới nhất
        public int maHoaDon_top1()
        {
            return HoaDonDAO.Instance.maHoaDon_top1();
        }   
        
        // hủy hóa đơn
        public bool huyHoaDon(int maHoaDon)
        {
            return HoaDonDAO.Instance.huyHoaDon(maHoaDon);
        }


        // thống kê doanh thu
        public DataTable thongKeDoanhThuTheoThang()
        {
            return HoaDonDAO.Instance.thongKeDoanhThuTheoThang();
        }
    }
}
