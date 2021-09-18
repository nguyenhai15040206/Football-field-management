using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SuKienDAO
    {
        QuanLySanBongDataContext db = new QuanLySanBongDataContext();
        private static SuKienDAO instance;

        public static SuKienDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new SuKienDAO();
                }
                return instance;
            }
        }

        public List<SuKien> loadTatCaSuKien()
        {
            var suKien = db.SuKiens.Where(m=>m.tinhTrang== true).ToList();
            if(suKien ==null || suKien.Count == 0)
            {
                return null;
            }
            return suKien;
        }

        public SuKien thongTinSuKien(int maSuKien)
        {
            return db.SuKiens.SingleOrDefault(m => m.maSuKien == maSuKien);
        }

        public bool themSuKien(string tenSuKien, DateTime ngayBatDau, int soDoiThamGia, int soBangDau,
            int soDoiVongKnockOut, int soLuongNguoiMoiDoi, int maND,double lePhiThamGia,bool tinhTrang)
        {
            try
            {
                SuKien suKien = new SuKien();
                suKien.tenSuKien = tenSuKien;
                suKien.ngayBatDau = ngayBatDau;
                suKien.soDoiThamGia = soDoiThamGia;
                suKien.soBangDau = soBangDau;
                suKien.soDoiVongKnockout = soDoiVongKnockOut;
                suKien.soLuongNguoiMoiDoi = soLuongNguoiMoiDoi;
                suKien.maNguoiDung = maND;
                suKien.lePhiThamGia = (decimal)lePhiThamGia;
                suKien.tinhTrang = tinhTrang;
                db.SuKiens.InsertOnSubmit(suKien);
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("" + ex);
                return false;
            }
        }

        public bool xoaSuKien(int maSuKien)
        {
            try
            {
                var suKien = db.SuKiens.SingleOrDefault(m => m.maSuKien == maSuKien);
                suKien.tinhTrang = false;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        // Đội bóng cho sự kiện
        public List<DoiBong> loadDoiBongBoiSuKien(int maSuKien)
        {
            var dsDoiBong = db.DoiBongs.Where(m => m.maSuKien == maSuKien).ToList();
            if(dsDoiBong  == null || dsDoiBong.Count == 0)
            {
                return null;
            }
            else
            {
                return dsDoiBong;
            }
        }

        public DoiBong thongTinDoiBOng(int maDoiBong)
        {
            return db.DoiBongs.SingleOrDefault(m => m.maDoiBong == maDoiBong);
        }

        public int soLuongDoiBongCuaSK(int maSuKien)
        {
            int count = db.DoiBongs.Count(m => m.maSuKien == maSuKien);
            return count;
        }

        public bool themDoiBong(int maDoiBong, int maSuKien, string tenDoiBong, string tenNguoiDD, string sdt, 
            string email, string hinhDoiBong, bool tinhTrang)
        {
            try
            {
                DoiBong doi = new DoiBong();
                doi.maDoiBong = maDoiBong;
                doi.maSuKien = maSuKien;
                doi.tenDoiBong = tenDoiBong;
                doi.tenNguoiDaiDien = tenNguoiDD;
                doi.SDTDoiDaiDien = sdt;
                doi.emailNguoiDaiDien = email;
                doi.hinhDoiBong = hinhDoiBong;
                doi.tinhTrang = tinhTrang;
                db.DoiBongs.InsertOnSubmit(doi);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool capNhatDoiBong(string tenDoiBong, string tenNguoiDD, string sdt,
            string email, string hinhDoiBong, bool tinhTrang, int maDoiBong)
        {
            try
            {
                var doi = db.DoiBongs.SingleOrDefault(m => m.maDoiBong == maDoiBong);
                if(doi == null)
                {
                    return false;
                }
                doi.tenDoiBong = tenDoiBong;
                doi.tenNguoiDaiDien = tenNguoiDD;
                doi.SDTDoiDaiDien = sdt;
                doi.emailNguoiDaiDien = email;
                doi.hinhDoiBong = hinhDoiBong;
                doi.tinhTrang = tinhTrang;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaDoiBong(int maDoiBong)
        {
            try
            {
                var doi = db.DoiBongs.SingleOrDefault(m => m.maDoiBong == maDoiBong);
                if(doi== null)
                {
                    return false;
                }
                db.DoiBongs.DeleteOnSubmit(doi);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        // Cầu thủ
        public List<CauThu> loadDanhSachCauThuTheoDoiBong(int maDoiBong, bool tinhTrang)
        {
            var dsDOiBong = db.CauThus.Where(m => m.maDoiBong == maDoiBong && tinhTrang == tinhTrang).ToList();
            if(dsDOiBong==null || dsDOiBong.Count == 0)
            {
                return null;
            }
            return dsDOiBong;
        }

        public bool themCauThu(string hoten, string sdt, DateTime ngaySinh, string hinhMinhHoa, string cmnd, int maDoiBong)
        {
            try
            {
                CauThu ct = new CauThu();
                ct.hoTen = hoten;
                ct.soDienThoai = sdt;
                ct.ngaySinh = ngaySinh;
                ct.hinhMinhHoa = hinhMinhHoa;
                ct.CMND = cmnd;
                ct.maDoiBong = maDoiBong;
                db.CauThus.InsertOnSubmit(ct);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool capNhatCauThu(int maCauThu,string hoten, string sdt, DateTime ngaySinh, string hinhMinhHoa, string cmnd)
        {
            try
            {
                CauThu ct = db.CauThus.SingleOrDefault(m => m.maCauThu == maCauThu);
                ct.hoTen = hoten;
                ct.soDienThoai = sdt;
                ct.ngaySinh = ngaySinh;
                ct.hinhMinhHoa = hinhMinhHoa;
                ct.CMND = cmnd;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaCauThu(int maCauThu)
        {
            try
            {
                CauThu ct = db.CauThus.SingleOrDefault(m => m.maCauThu == maCauThu);
                db.CauThus.DeleteOnSubmit(ct);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // bảng thi đấu
        public bool themBangThiDau(string tenBangDau, int maSuKien, bool tinhTrang)
        {
            try
            {
                BangThiDau bd = new BangThiDau();
                bd.tenBangDau = tenBangDau;
                bd.maSuKien = maSuKien;
                bd.tinhTrang = tinhTrang;
                db.BangThiDaus.InsertOnSubmit(bd);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public int bangDauMoiNhat()
        {
            int maBangDau = (int)(from bd in db.BangThiDaus
                                  orderby bd.maBangDau descending
                                  select bd.maBangDau).Take(1).Single();
            return maBangDau;
        }

        public bool themChiTietBangDau(int maDoiBong,string ghiChu)
        {
            try
            {
                ChiTietBangDau ctbd = new ChiTietBangDau();
                ctbd.maBangDau = bangDauMoiNhat();
                ctbd.maDoiBong = maDoiBong;
                ctbd.ghiChu = ghiChu;
                db.ChiTietBangDaus.InsertOnSubmit(ctbd);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        // trọng tài
        public bool themTrongTai(string tenTrongTai, string soDienThoai, bool tinhTrang)
        {
            try
            {
                TrongTai tt = new TrongTai();
                tt.tenTrongTai = tenTrongTai;
                tt.soDienThoai = soDienThoai;
                tt.tinhTrang = tinhTrang;
                db.TrongTais.InsertOnSubmit(tt);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool capNhatTrongTai(int maTrongTai, string tenTrongTai, string soDienThoai, bool tinhTrang)
        {
            try
            {
                TrongTai tt = db.TrongTais.SingleOrDefault(m => m.maTrongTai == maTrongTai);
                tt.tenTrongTai = tenTrongTai;
                tt.soDienThoai = soDienThoai;
                tt.tinhTrang = tinhTrang;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaTrongTai(int maTrongTai, bool tinhTrang)
        {
            try
            {
                TrongTai tt = db.TrongTais.SingleOrDefault(m => m.maTrongTai == maTrongTai);
                tt.tinhTrang = tinhTrang;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        // tại lịch đấu
        public bool themTranDau(int maSan, int maTrongTai, DateTime ngayThiDau, TimeSpan gioThiDau,
            int maDoiBong1, int maDoiBong2, int banThangDoi1, int bangThangDoi2)
        {
            try
            {
                TranDau td = new TranDau();
                td.maSan = maSan;
                td.maTrongTai = maTrongTai;
                td.ngayThiDau = ngayThiDau;
                td.gioThiDau = gioThiDau;
                td.maDoiBong1 = maDoiBong1;
                td.maDoiBong2 = maDoiBong2;
                td.banThangDoi1 = banThangDoi1;
                td.banThangDoi2 = bangThangDoi2;
                db.TranDaus.InsertOnSubmit(td);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaTranDau(int maTranDau)
        {
            try
            {
                TranDau td = db.TranDaus.SingleOrDefault(m => m.maTranDau == maTranDau);
                db.TranDaus.DeleteOnSubmit(td);
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
