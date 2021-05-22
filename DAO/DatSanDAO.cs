using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DatSanDAO
    {
        private static DatSanDAO instance;

        public static DatSanDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new DatSanDAO();
                }
                return instance;
            }
        }

        QuanLySanBongDataContext db = new QuanLySanBongDataContext();


        // load đặt danh sách đặt sân
        public List<NewDatSan> loadDatSan()
        {
            var datSan = (from ds in db.DatSans
                          join nd in db.NguoiDungs on ds.maNguoiDung equals nd.maNguoiDung
                          join kh in db.KhachHangs on ds.maKhachHang equals kh.maKhachHang
                          join san in db.sanBongs on ds.maSan equals san.maSan
                          select new NewDatSan
                          {
                              TenSan = san.tenSan,
                              TenKhachhang = kh.tenKhachHang,
                              TenNguoiDung = nd.tenNguoiDung,
                              NgayDat = ds.NgayDat,
                              GioVao = ds.GioRa,
                                GioRa = ds.GioRa,
                              TienSan = ds.tienSan,
                              TienCoc = ds.tienCoc,
                              GhiChu = ds.ghiChu,

                          }).ToList();
            return datSan;
        }

        // thêm đặt sân
        public bool datSan(int maSan, int maKhachHang, int maNguoiDung, DateTime ngayDat, TimeSpan gioVao, TimeSpan gioRa, double tienSan, 
            double tienCoc, bool tinhTrang, string ghiChu)
        {
            try
            {
                DatSan ds = new DatSan();
                ds.maSan = maSan;
                ds.maKhachHang = maKhachHang;
                ds.maNguoiDung = maNguoiDung;
                ds.NgayDat = ngayDat;
                ds.GioVao = gioVao;
                ds.GioRa = gioRa;
                ds.tienSan = (decimal)tienSan;
                ds.tienCoc = (decimal)tienCoc;
                ds.tinhTrang = tinhTrang;
                ds.ghiChu = ghiChu;
                db.DatSans.InsertOnSubmit(ds);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
