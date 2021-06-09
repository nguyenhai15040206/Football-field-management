using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using DevExpress.XtraGrid;
using System.ComponentModel;

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

        // load chi tiết hóa đơn theo mã phiếu
        public void loadCTHD_maHD(GridControl dgv, int maHD)
        {
            List<NewChiTietHD> ctpn = ChiTietHoaDonDAO.Instance.loadChiTietHD_maPhieuNhap(maHD);
            dgv.DataSource = new BindingList<NewChiTietHD>(ctpn);
        }

        public bool themCTHoaDon(int maHoaDon, int maThucUong, int soLuong, double giaBan, double thanhTien)
        {
            return ChiTietHoaDonDAO.Instance.themCTHoaDon(maHoaDon, maThucUong, soLuong, giaBan, thanhTien);
        }

        // xóa tất cả chi tiết phiếu nhập khi Phiếu nhập này được hủy
        public bool xoaCTHoaDon_HoaDonHuy(int maHoaDon)
        {
            return ChiTietHoaDonDAO.Instance.xoaCTHDieuNhap_HoaDonHuy(maHoaDon);
        }

        // xóa chi tiết hóa đơn
        public bool xoaCTHoaDon(int maHoaDon, int maThucUong)
        {
            return ChiTietHoaDonDAO.Instance.xoaCTHoaDon(maHoaDon, maThucUong);
        }   
        
        // đếm số luownjjg chi tiết hóa đơn
        public int soLuongCTHD_MaHD(int maHoaDon)
        {
            return ChiTietHoaDonDAO.Instance.soLuongCTHD_MaHD(maHoaDon);
        }
    }
}
