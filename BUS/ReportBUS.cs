using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class ReportBUS
    {
        private static ReportBUS instance;

        public static ReportBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new ReportBUS();
                }
                return instance;
            }
        }

        public DataTable thanhToanSan(int maPhieu)
        {
            return ReportDAO.Instance.phieuThanhToan(maPhieu);
        }



        public DataTable inPhieuNhap(int maPhieuNhap)
        {
            return ReportDAO.Instance.phieuNhapHang(maPhieuNhap);
        }


        public DataTable ThongKeDoanhThuTheoNgay(DateTime ngay)
        {
            return ReportDAO.Instance.ThongKeDoanhThuTheoNgay(ngay);
        }
        public double tongTien_theoNgay(DateTime ngay)
        {
            return ReportDAO.Instance.tongTien_theoNgay(ngay);
        }


        public DataTable ThongKeDoanhThuTheoThang(int thang, int nam)
        {
            return ReportDAO.Instance.ThongKeDoanhThuTheoThang(thang, nam);
        }

        public double tongTien_theoThang(int thang, int nam)
        {
            return ReportDAO.Instance.tongTien_theoTTnag(thang,nam);
        }

        public DataTable ThongKeDoanhThuTheoNam(int nam)
        {
            return ReportDAO.Instance.ThongKeDoanhThuTheoNam(nam);
        }

        public double tongTien_theoNam( int nam)
        {
            return ReportDAO.Instance.tongTien_theoNam(nam);
        }


    }
}
