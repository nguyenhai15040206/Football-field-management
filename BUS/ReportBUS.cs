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


    }
}
