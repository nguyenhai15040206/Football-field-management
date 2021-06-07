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
                          orderby ds.NgayDat descending
                          select new NewDatSan
                          {
                              TenSan = san.tenSan,
                              TenKhachhang = kh.tenKhachHang,
                              SoDienThoai = kh.soDienThoai,
                              TenNguoiDung = nd.tenNguoiDung,
                              NgayDat = ds.NgayDat,
                              GioVao = new DateTime(ds.GioVao.Ticks).ToString("HH:mm"),
                              GioRa = new DateTime(ds.GioRa.Ticks).ToString("HH:mm"),
                              TienSan = ds.tienSan,
                              TienCoc = ds.tienCoc,
                              GhiChu = ds.ghiChu,

                          }).ToList();
            return datSan;
        }

        // load đặt danh sách đặt sân
        public List<NewDatSan> loadDatSan_ChuaThanhToan()
        {
            var datSan = (from ds in db.DatSans
                          join nd in db.NguoiDungs on ds.maNguoiDung equals nd.maNguoiDung
                          join kh in db.KhachHangs on ds.maKhachHang equals kh.maKhachHang
                          join san in db.sanBongs on ds.maSan equals san.maSan
                          where ds.tinhTrang == false
                          orderby ds.NgayDat descending
                          select new NewDatSan
                          {
                              TenSan = san.tenSan,
                              TenKhachhang = kh.tenKhachHang,
                              SoDienThoai = kh.soDienThoai,
                              TenNguoiDung = nd.tenNguoiDung,
                              NgayDat = ds.NgayDat,
                              GioVao = new DateTime(ds.GioVao.Ticks).ToString("HH:mm"),
                              GioRa = new DateTime(ds.GioRa.Ticks).ToString("HH:mm"),
                              TienSan = ds.tienSan,
                              TienCoc = ds.tienCoc,
                              GhiChu = ds.ghiChu,

                          }).ToList();
            return datSan;
        }

        // thêm đặt sân
        public bool datSan(int maSan, int maKhachHang, int maNguoiDung, DateTime ngayDat, TimeSpan gioVao, TimeSpan gioRa, double tienSan, 
            double tienCoc, string ghiChu)
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
                ds.ghiChu = ghiChu;
                ds.tinhTrang = false;
                db.DatSans.InsertOnSubmit(ds);
                db.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("" + e);
                return false;
            }
        }

        // xóa đặt sân
        public bool xoaDatSan(int maSan, int maKhachHang, DateTime ngayDat, TimeSpan gioVao, TimeSpan gioRa)
        {
            try
            {
                var queryDatSan =
                    (from DatSan in db.DatSans
                     where
                       DatSan.maSan == maSan &&
                       DatSan.maKhachHang == maKhachHang &&
                       DatSan.NgayDat == ngayDat &&
                       DatSan.GioVao == gioVao &&
                       DatSan.GioRa == gioRa
                     select DatSan).SingleOrDefault();
                db.DatSans.DeleteOnSubmit(queryDatSan);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool capNhatDatSan(int maSan, int maKhachHang, DateTime ngayDat, TimeSpan gioVao, TimeSpan gioRa, bool tinhTrang)
        {
            try
            {
                var queryDatSan =
                    (from DatSan in db.DatSans
                     where
                       DatSan.maSan == maSan &&
                       DatSan.maKhachHang == maKhachHang &&
                       DatSan.NgayDat == ngayDat &&
                       DatSan.GioVao == gioVao &&
                       DatSan.GioRa == gioRa
                     select DatSan).SingleOrDefault();
                queryDatSan.tinhTrang = tinhTrang;
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
