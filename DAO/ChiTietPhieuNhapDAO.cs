using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ChiTietPhieuNhapDAO
    {
        QuanLySanBongDataContext db = new QuanLySanBongDataContext();
        private static ChiTietPhieuNhapDAO instance;

        public static ChiTietPhieuNhapDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new ChiTietPhieuNhapDAO();
                }
                return instance;
            }
        }

        public List<NewChiTietPN> loadChiTietPN_maPhieuNhap(int maPhieu)
        {
            var ctpnList = (from pn in db.PhieuNhaps
                            join ctpn in db.ChiTietPNs on pn.maPhieuNhap equals ctpn.maPhieuNhap
                            join sp in db.ThucUongs on ctpn.maThucUong equals sp.maThucUong
                            join tu in db.ThucUongs on ctpn.maThucUong equals tu.maThucUong
                            where pn.maPhieuNhap == maPhieu
                            select new NewChiTietPN
                            {
                                MaThucUong = tu.maThucUong,
                                DVT = sp.DVT,
                                SoLuong = (int)ctpn.soLuong / 24,
                                DonGia = (double)ctpn.donGia,
                                ThanhTien =(double) ctpn.thanhTien
                            }).ToList();
            
            return ctpnList;
        }

        public bool themCTPhieuNhap(int maPhieuNhap, int maThucUong, int soLuong, double giaBan, double thanhTien)
        {
            try
            {
                ChiTietPN ctpn = new ChiTietPN();
                ctpn.maPhieuNhap = maPhieuNhap;
                ctpn.maThucUong = maThucUong;
                ctpn.soLuong = soLuong;
                ctpn.donGia = (decimal?)giaBan;
                ctpn.thanhTien = (decimal?)thanhTien;
                db.ChiTietPNs.InsertOnSubmit(ctpn);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        // xóa chi tiết hóa đơn
        public bool xoaCTPhieuNhap(int maPhieuNhap, int maThucUong)
        {
            try
            {
                var ctpn = db.ChiTietPNs.SingleOrDefault(m => m.maPhieuNhap == maPhieuNhap && m.maThucUong == maThucUong);
                db.ChiTietPNs.DeleteOnSubmit(ctpn);
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
