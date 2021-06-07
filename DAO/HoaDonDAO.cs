using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;
        public static HoaDonDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new HoaDonDAO();
                }
                return instance;
            }
        }

        QuanLySanBongDataContext db = new QuanLySanBongDataContext();

        // load hoas ddown
        public List<NewHoaDon> loadHoaDon(bool tinhTrang)
        {
            var hoaDon = (from hd in db.HoaDons
                          from ds in db.DatSans
                          from kh in db.KhachHangs
                          from san in db.sanBongs
                          where hd.maSan == ds.maSan &&
                          hd.ngayDat == ds.NgayDat &&
                          hd.gioVao == ds.GioVao &&
                          hd.gioRa == ds.GioRa &&
                          hd.maSan == san.maSan &&
                          hd.maKhachHang == kh.maKhachHang && 
                          hd.tinhTrang == tinhTrang
                          select new NewHoaDon
                          {     
                              MaHoaDon = hd.maHoaDon,
                              DatCoc = (double)ds.tienCoc,
                              GiamGia = (double)hd.giamGia,
                              GioRa = (TimeSpan)hd.gioRa,
                              GioVao = (TimeSpan) hd.gioVao,
                              MaNguoiDung = (int)hd.maNguoiDung,
                              NgayDat = (DateTime)hd.ngayDat,
                              NgayLap = (DateTime)hd.ngayLap,
                              SoDienThoai = kh.soDienThoai,
                              TenKhachHang = kh.tenKhachHang,
                              TenSan = san.tenSan,
                              TienNuoc = (double)hd.tienNuoc,
                              TienSan = (double) hd.tienSan,
                              TongTien= (double) hd.tongTien,
                              TinhTrang = (bool)hd.tinhTrang,
                          }).ToList();
            return hoaDon;

        }

        // lấy mã hóa đơn mới nhất
        public int maHoaDon_top1()
        {
            int maHD = (int)(from hd in db.HoaDons
                        orderby hd.maHoaDon descending
                        select  hd.maHoaDon ).Take(1).Single();
            return maHD;
        }

        // thêm hóa đơn(thêm mới vào csdl)
        public bool themHoaDon(double tienSan,double giamGia, double tienNuoc, double tongTien,int maSan, int maKhachHang, DateTime ngayDat, TimeSpan gioVao, TimeSpan gioRa, int maNguoiDung)
        {
            // mặt định trình trạng hóa đơn có hiệu lực (true)
            // hóa đơn có ngày lập là ngày hiện tại
            try
            {
                HoaDon hd = new HoaDon();
                hd.ngayLap = DateTime.Parse(DateTime.Now.Date.ToString("MM-dd-yyy"));
                hd.tienSan = (decimal?)tienSan;
                hd.giamGia = (decimal?)giamGia;
                hd.tienNuoc = (decimal?)tienNuoc;
                hd.tongTien = (decimal?)tongTien;
                hd.maKhachHang = maKhachHang;
                hd.maNguoiDung = maNguoiDung;
                hd.ngayDat = ngayDat;
                hd.gioVao = gioVao;
                hd.gioRa = gioRa;
                hd.maSan = maSan;
                hd.tinhTrang = true;
                db.HoaDons.InsertOnSubmit(hd);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // hủy hóa đơn(có nghĩa hóa đơn này không có giá trị)
        public bool huyHoaDon(int maHoaDon)
        {
            try
            {
                var hoaDon = db.HoaDons.SingleOrDefault(m => m.maHoaDon == maHoaDon);
                hoaDon.tinhTrang = false;
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
