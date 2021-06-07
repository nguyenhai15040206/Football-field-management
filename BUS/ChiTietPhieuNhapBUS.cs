using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid;
using System.ComponentModel;

namespace BUS
{
    public class ChiTietPhieuNhapBUS
    {
        QuanLySanBongDataContext db = new QuanLySanBongDataContext();
        private static ChiTietPhieuNhapBUS instance;

        public static ChiTietPhieuNhapBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new ChiTietPhieuNhapBUS();
                }
                return instance;
            }
        }

        // load chi tiết phiếu nhập theo mã phiếu
        public void loadCTPN_maPhieuNhap(GridControl dgv,int maPhieu)
        { 
            List<NewChiTietPN> ctpn = ChiTietPhieuNhapDAO.Instance.loadChiTietPN_maPhieuNhap(maPhieu);
            dgv.DataSource = new BindingList<NewChiTietPN>(ctpn);
        }

        // thêm chi tiết phiếu nhập
        public bool themCTPhieuNhap(int maPhieuNhap, int maThucUong, int soLuong, double giaBan, double thanhTien)
        {
            return ChiTietPhieuNhapDAO.Instance.themCTPhieuNhap(maPhieuNhap, maThucUong, soLuong, giaBan, thanhTien);
        }

        // xóa từng chi tiết phiếu nhập
        public bool xoaChiTietPN(int maPhieu, int maThucUong)
        {
            return ChiTietPhieuNhapDAO.Instance.xoaCTPhieuNhap(maPhieu, maThucUong);
        }

        // xóa tất cả chi tiết phiếu nhập khi Phiếu nhập này được hủy
        public bool xoaCTPN_PhieuNhapHuy(int maPhieu)
        {
            return ChiTietPhieuNhapDAO.Instance.xoaCTPhieuNhap_phieuNhapHuy(maPhieu);
        }

        // cập nhật thức uống
        public bool capNhatCTPhieuNhap(int maPhieu, int maThucUong, int soLuong, double giaBan, double thanhTien)
        {
            return ChiTietPhieuNhapDAO.Instance.capNhatCTPhieuNhap(maPhieu, maThucUong, soLuong, giaBan, thanhTien);
        }

        // trả về tìm thấy hay không tìm thaays CTPN
        public bool CTPhieuNhap(int maPhieu, int maSP)
        {
            var ctpn = ChiTietPhieuNhapDAO.Instance.timPhieuNhap_maPNMaTU(maPhieu, maSP);
            if(ctpn == null)
            {
                return false;
            }    
            else
            {
                return true;
            }    
        }



    }
}
