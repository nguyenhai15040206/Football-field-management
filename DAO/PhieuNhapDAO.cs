using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class PhieuNhapDAO
    {
        QuanLySanBongDataContext db = new QuanLySanBongDataContext();
        private static PhieuNhapDAO instance;

        public static PhieuNhapDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new PhieuNhapDAO();
                }
                return instance;
            }
        }

        // lấy Phiếu nhập với mã phiếu mới nhất
        // lấy mã hóa đơn mới nhất
        public int maPhieuNhap_top1()
        {
            int maPN = (int)(from pn in db.PhieuNhaps
                             orderby pn.maPhieuNhap descending
                             select pn.maPhieuNhap).Take(1).Single();
            return maPN;
        }

        // lất Phiếu nhập với mã 
        public PhieuNhap phieuNhap(int maPhieu)
        {
            return db.PhieuNhaps.SingleOrDefault(m => m.maPhieuNhap == maPhieu);
        }

        // load tất cả các phiếu nhập
        public List<NewPhieuNhap> loadTatCaPhieuNhap()
        {
            var phieuNhap = (from pn in db.PhieuNhaps
                             join ncc in db.NhaCungCaps on pn.maNhaCungCap equals ncc.maNhaCungCap
                             join nd in db.NguoiDungs on pn.maNguoiDung equals nd.maNguoiDung
                             select new NewPhieuNhap { 
                                    MaPhieuNhap = pn.maPhieuNhap,
                                    TenNguoiDung = nd.tenNguoiDung,
                                    TenNhaCungCap = ncc.tenNhaCungCap,
                                    TongTien = pn.tongTien,
                                    NgayLap = pn.NgayLap,
                                    SoDienThoai = ncc.SoDienThoai,
                                    TinhTrang = pn.tinhTrang
                             }).ToList() ;
            return phieuNhap;
        }

        // thêm phiếu nhập
        public bool themPhieuNhap(double tongTien, int maNCC, int maNguoiDung)
        {
            try
            {
                PhieuNhap pn = new PhieuNhap();
                pn.NgayLap = DateTime.Parse(DateTime.Now.Date.ToString("MM/dd/yyy"));
                pn.tongTien = (decimal?)tongTien;
                pn.maNhaCungCap = maNCC;
                pn.maNguoiDung = maNguoiDung;
                pn.tinhTrang = true;
                db.PhieuNhaps.InsertOnSubmit(pn);
                db.SubmitChanges();
                return true;
            }   
            catch
            {
                return false;
            }
        }

        // xóa phiếu nhập (làm cho phiếu nhập hàng đó không còn hiệu lực)
        public bool xoaPhieuNhap(int maPhieuNhap)
        {
            try
            {
                PhieuNhap pn = db.PhieuNhaps.SingleOrDefault(m => m.maPhieuNhap==maPhieuNhap);
                pn.tinhTrang = false;
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
