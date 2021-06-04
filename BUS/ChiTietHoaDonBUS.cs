using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class ChiTietHoaDonBUS
    {
        private static ChiTietHoaDonBUS instance;
        public static ChiTietHoaDonBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new ChiTietHoaDonBUS();
                }
                return instance;
            }
        }

        public bool themCTHoaDon(int maHoaDon, int maThucUong, int soLuong, double giaBan, double thanhTien)
        {
            return ChiTietHoaDonDAO.Instance.themCTHoaDon(maHoaDon, maThucUong, soLuong, giaBan, thanhTien);
        }    
    }
}
