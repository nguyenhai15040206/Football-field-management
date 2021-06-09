using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new KhachHangDAO();
                }
                return instance;
            }
        }
        QuanLySanBongDataContext db = new QuanLySanBongDataContext();


        // load tất cả các khách hàng
        public List<NewKhachHangLoaiKH> loadTatCaKhachHang()
        {
            var listKH = (from kh in db.KhachHangs
                          join lkh in db.LoaiKhachHangs on kh.maLoaiKhachHang equals lkh.maLoaiKhachHang
                          select new NewKhachHangLoaiKH
                          {
                              MaKhachHang = kh.maKhachHang,
                              TenKhachHang = kh.tenKhachHang,
                              TenLoai = lkh.tenLoai,
                              SoDienThoai = kh.soDienThoai,
                              DiemTichLuy = kh.diemTichLuy

                          }).ToList();
            if (listKH.Count == 0)
            {
                return null;
            }
            return listKH;
        }

        // lấy tt khách hàng với mã khách hàng
        public KhachHang thongTinKhachHang_maKH(int maKH)
        {
            var kh = db.KhachHangs.SingleOrDefault(m => m.maKhachHang == maKH);
            if(kh==null)
            {
                return null;
            }
            return kh;

        }

        // lấy thông tin khách hàng với số điện thoại
        public KhachHang thongTinKhachHang_soDienThoai(string soDienThoai)
        {
            var kh = db.KhachHangs.SingleOrDefault(m => m.soDienThoai == soDienThoai);
            if (kh == null)
            {
                return null;
            }
            return kh;
        }



        ///Thêm khách hàng
        ///
        public bool themKhachHang(string tenKH, string sdt)
        {
            try
            {
                KhachHang kh = new KhachHang();
                kh.tenKhachHang = tenKH;
                kh.soDienThoai = sdt;
                kh.diemTichLuy = 0;
                kh.maLoaiKhachHang = 1;
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // xóa khách hàng
        public bool xoaKhachHang(int maKhachHang)
        {
            try
            {
                KhachHang kh = db.KhachHangs.SingleOrDefault(m => m.maKhachHang == maKhachHang);
                db.KhachHangs.DeleteOnSubmit(kh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }    


        //kiểm tra trùng số điện thoại
        public bool KtraTrungSoDienThoai(string input)
        {
            try
            {
                var txt = db.KhachHangs.Where(m => m.soDienThoai == input).ToList();
                if (txt.Count() > 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Cập nhật thông tin khách hàng
        public bool CapNhatThongtinKH(int makh, string tenKH, string sdt, double diemTL, int maloai)
        {
            try
            {
                var kh = db.KhachHangs.SingleOrDefault(ma => ma.maKhachHang == makh);
                if (kh == null)
                {
                    return false;
                }

                if (sdt == kh.soDienThoai)
                {
                    kh.tenKhachHang = tenKH;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    if (KtraTrungSoDienThoai(sdt))
                    {
                        kh.tenKhachHang = tenKH;
                        kh.soDienThoai = sdt;
                        db.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch
            {

                return false;
            }
        }

        public int soLuongKhachHangDatSan(int maKhachHang)
        {
            var soLuong = db.HoaDons.Where(m => m.maKhachHang == maKhachHang && m.tinhTrang == true).Count();
            return soLuong;
        }

        public bool capNhatDienTichLuy_khiDat(int maKhachHang)
        {
            try
            {
                var khachhang = db.KhachHangs.SingleOrDefault(m => m.maKhachHang == maKhachHang);
                int soLuongDat = soLuongKhachHangDatSan(maKhachHang);
                khachhang.diemTichLuy = soLuongDat + 1;
                if(khachhang.diemTichLuy>=10)
                {
                    khachhang.maLoaiKhachHang = 2;
                }    
                if(khachhang.diemTichLuy >=20)
                {
                    khachhang.maLoaiKhachHang = 3;
                }
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool capNhatDienTichLuy_khiHuy(int maKhachHang)
        {
            try
            {
                var khachhang = db.KhachHangs.SingleOrDefault(m => m.maKhachHang == maKhachHang);
                int soLuongDat = soLuongKhachHangDatSan(maKhachHang);
                khachhang.diemTichLuy = (soLuongDat - 1) <=0? 0: (soLuongDat - 1);
                if (khachhang.diemTichLuy < 10)
                {
                    khachhang.maLoaiKhachHang = 1;
                }
                else
                {

                    if (khachhang.diemTichLuy >= 10)
                        khachhang.maLoaiKhachHang = 2;
                    else
                        khachhang.maLoaiKhachHang = 3;
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
                return false;
            }
        }
    }
}
