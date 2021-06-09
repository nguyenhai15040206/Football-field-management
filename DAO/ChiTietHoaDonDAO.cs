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

        // load chi tiết hóa đơn với mã hóa đơn
        public List<NewChiTietHD> loadChiTietHD_maPhieuNhap(int maHoaDon)
        {
            var cthdList = (from hd in db.HoaDons
                            join cthd in db.ChiTietHDs on hd.maHoaDon equals cthd.maHoaDon
                            join tu in db.ThucUongs on cthd.maThucUong equals tu.maThucUong
                            where hd.maHoaDon == maHoaDon
                            select new NewChiTietHD
                            {
                                MaThucUong = tu.maThucUong,
                                DVT = tu.DVT,
                                SoLuong = (int)cthd.soLuong,
                                DonGia = (double)cthd.giaBan,
                                ThanhTien = (double)cthd.thanhTien
                            }).ToList();

            return cthdList;
        }

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

        // xóa chi tiết phiếu nhập khi phiếu nhập đó được hủy
        public bool xoaCTHDieuNhap_HoaDonHuy(int maHoaDon)
        {
            try
            {
                var cthd = db.ChiTietHDs.Where(m => m.maHoaDon == maHoaDon).ToList();
                if (cthd.Count == 0)
                {
                    return false;
                }
                else
                {
                    db.ChiTietHDs.DeleteAllOnSubmit(cthd);
                    db.SubmitChanges();
                    return true;
                }
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

        // đếm số lượng chi tiết hóa đơn với mã hóa đơn
        public int soLuongCTHD_MaHD(int maHoaDon)
        {
            return db.ChiTietHDs.Where(m => m.maHoaDon == maHoaDon).Count();
        }
    }
}
