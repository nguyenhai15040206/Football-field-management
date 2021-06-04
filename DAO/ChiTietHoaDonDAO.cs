using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ChiTietHoaDonDAO
    {
        private static ChiTietHoaDonDAO instance;
        public static ChiTietHoaDonDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new ChiTietHoaDonDAO();
                }
                return instance;
            }
        }
        QuanLySanBongDataContext db = new QuanLySanBongDataContext();

        // thêm chi tiết hóa đơn
        public bool themCTHoaDon(int maHoaDon, int maThucUong, int soLuong, double giaBan, double thanhTien )
        {
            try
            {
                ChiTietHD cthd = new ChiTietHD();
                cthd.maHoaDon = maHoaDon;
                cthd.maThucUong = maThucUong;
                cthd.soLuong = soLuong;
                cthd.giaBan = (decimal?)giaBan;
                cthd.thanhTien = (decimal?)thanhTien;
                db.ChiTietHDs.InsertOnSubmit(cthd);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        // xóa chi tiết hóa đơn
        public bool xoaCTHoaDon(int maHoaDon, int maThucUong)
        {
            try
            {
                var cthd= db.ChiTietHDs.SingleOrDefault(m => m.maHoaDon == maHoaDon && m.maThucUong == maThucUong);
                db.ChiTietHDs.DeleteOnSubmit(cthd);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        // cập nhật chi tiết hóa đơn
        public bool capNhatCTHoaDon(int maHoaDon, int maThucUong, int soLuong, double giaBan, double thanhTien)
        {
            try
            {
                ChiTietHD cthd = db.ChiTietHDs.SingleOrDefault(m => m.maThucUong == maThucUong && m.maHoaDon == maHoaDon);
                cthd.soLuong = soLuong;
                cthd.giaBan = (decimal?)giaBan;
                cthd.thanhTien = (decimal?)thanhTien;
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
