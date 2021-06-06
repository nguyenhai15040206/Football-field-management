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

        // thêm phiếu nhập
        public bool themPhieuNhap(double tongTien, int maNCC, int maNguoiDung)
        {
            return PhieuNhapDAO.Instance.themPhieuNhap(tongTien, maNCC, maNguoiDung);
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
