using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DevExpress.XtraGrid;

namespace BUS
{
    public class DatSanBUS
    {
        private static DatSanBUS instance;

        public static DatSanBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new DatSanBUS();
                }
                return instance;
            }
        }


        //load tất các các đặt sân lên GridControl
        public void loadDatSan(GridControl gv)
        {
            gv.DataSource = DatSanDAO.Instance.loadDatSan();
        }
        // đặt sân
        public bool datSan(int maSan, int maKhachHang, int maNguoiDung, DateTime ngayDat, TimeSpan gioVao, TimeSpan gioRa, double tienSan,
            double tienCoc,  string ghiChu)
        {
            return DatSanDAO.Instance.datSan(maSan, maKhachHang, maNguoiDung, ngayDat, gioVao, gioRa, tienSan, tienCoc, ghiChu);
        }

        // hủy lịch
        public bool xoaDatSan(int maSan, int maKhachHang, DateTime ngayDat, TimeSpan gioVao, TimeSpan gioRa)
        {
            return DatSanDAO.Instance.xoaDatSan(maSan, maKhachHang, ngayDat, gioVao, gioRa);
        }
    }
}
