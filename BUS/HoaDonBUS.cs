using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

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
    }
}
