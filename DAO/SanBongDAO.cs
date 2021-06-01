using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class SanBongDAO
    {
        QuanLySanBongDataContext db = new QuanLySanBongDataContext();
        private static SanBongDAO instance;

        public static SanBongDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new SanBongDAO();
                }
                return instance;
            }
        }


        // load tất cả sân bóng
        public List<NewSanBongLoaiSan> loadTatCaSanBong()
        {
            var listSanBong = (from san in db.sanBongs
                               join loai in db.LoaiSans on san.maLoaiSan equals loai.maLoaiSan
                               select new NewSanBongLoaiSan
                               {
                                   MaSan = san.maSan,
                                   TenLoai = loai.tenLoai,
                                   TenSan = san.tenSan
                               }).ToList();
            if (listSanBong.Count == 0)
                return null;
            return listSanBong;
        }



        // load ra tất cả các sân còn trống trong khung giờ vào và khung giờ ra
        public List<sanBong> loadTatCaSanBongConTrong(TimeSpan gioVao , TimeSpan gioRa, DateTime ngayDat, int maLoaiSan)
        {
            var listSanBong = new  List<sanBong>();
            listSanBong = (from SanBong in db.sanBongs
                           where
                             SanBong.LoaiSan.maLoaiSan == maLoaiSan && SanBong.tinhTrang== true && !
                               (from ds in db.DatSans
                                where
                                  ((ds.GioVao <= gioVao && ds.GioRa >= gioVao) || (ds.GioVao <=gioRa && ds.GioRa>= gioRa && ds.GioVao > gioVao) ||
                                  ds.GioVao >= gioVao && ds.GioRa <= gioRa)
                                  && ds.NgayDat == ngayDat
                                select new { ds.maSan }).Contains(new { maSan = SanBong.maSan })
                           select SanBong).ToList();
            if(listSanBong.Count == 0)
            {
                return null;
            }    
            return listSanBong;
        }



        // load sân bóng còn sử dụng được
        public List<NewSanBongLoaiSan> loadTatCaSanBongDaBaoTri()
        {
            var listSanBong = (from sb in db.sanBongs
                               join lsb in db.LoaiSans on sb.maLoaiSan equals lsb.maLoaiSan
                               where sb.tinhTrang == false
                               select new NewSanBongLoaiSan
                               {
                                   MaSan = sb.maSan,
                                   TenSan = sb.tenSan,
                                   TenLoai = lsb.tenLoai
                               }).ToList();
            if (listSanBong.Count == 0)
            {
                return null;
            }
            return listSanBong;
        }


        // load sân bóng còn bảo trì
        public List<NewSanBongLoaiSan> loadTatCaSanBongBaoTri()
        {
            var listSanBong = (from sb in db.sanBongs
                               join lsb in db.LoaiSans on sb.maLoaiSan equals lsb.maLoaiSan
                               where sb.tinhTrang == true
                               select new NewSanBongLoaiSan
                               {
                                   MaSan = sb.maSan,
                                   TenSan = sb.tenSan,
                                   TenLoai = lsb.tenLoai
                               }).ToList();
            if (listSanBong.Count == 0)
            {
                return null;
            }
            return listSanBong;
        }

        //thêm sân bóng
        public bool ThemSanBong(string tenSan, bool tinhTrang, int loai)
        {
            try
            {
                sanBong sb = new sanBong();
                sb.tenSan = tenSan;
                sb.tinhTrang = tinhTrang;
                sb.maLoaiSan = loai;
                db.sanBongs.InsertOnSubmit(sb);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //kiểm tra trùng tên sân
        public bool TrungTenSan(string input)
        {
            try
            {
                var txt = db.sanBongs.Where(s => s.tenSan == input).ToList();
                if (txt.Count > 0)
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

        // lấy được mã sân bóng với tên sân bóng
        public int maSan_voiTenSan(string tenSan)
        {
            int maSan = db.sanBongs.Where(m => m.tenSan == tenSan.Trim()).SingleOrDefault().maSan;  
            return maSan;
        }


    }
}
