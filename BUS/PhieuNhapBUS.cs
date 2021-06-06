using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using DevExpress.XtraGrid;

namespace BUS
{
    public class PhieuNhapBUS
    {
        QuanLySanBongDataContext db = new QuanLySanBongDataContext();
        private static PhieuNhapBUS instance;

        public static PhieuNhapBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new PhieuNhapBUS();
                }
                return instance;
            }
        }

        public void loadTatCaPhieuNhap(GridControl dgv)
        {
            dgv.DataSource = PhieuNhapDAO.Instance.loadTatCaPhieuNhap();
        }

        public void loadTatCaPhieuNhap_TinhTrangHuy(GridControl dgv)
        {
            dgv.DataSource = PhieuNhapDAO.Instance.loadTatCaPhieuNhap_Huy();
        }

        // thêm phiếu nhập
        public bool themPhieuNhap(double tongTien, int maNCC, int maNguoiDung)
        {
            return PhieuNhapDAO.Instance.themPhieuNhap(tongTien, maNCC, maNguoiDung);
        }

        // xóa phiếu nhập
        public bool xoaPhieuNhap(int maPhieu)
        {
            return PhieuNhapDAO.Instance.xoaPhieuNhap(maPhieu);
        }

        // cập nhật phiếu nhập
        public bool capNhatPhieuNhap(int maPhieuNhap, double tongTien, int maNhaCungCap, int maNguoiDung)
        {
            return PhieuNhapDAO.Instance.capNhatPhieuNhap(maPhieuNhap, tongTien, maNhaCungCap, maNguoiDung);
        }

        // mã phiếu nhập mới nhất
        public int maPhieuNhapMoiNhat()
        {
            return PhieuNhapDAO.Instance.maPhieuNhap_top1();
        }

        // tổng tiền với mã phiếu
        public decimal tongTien_MaPhieu(int maPhieu)
        {
            return (decimal)PhieuNhapDAO.Instance.phieuNhap(maPhieu).tongTien;
        }    
    }
}
