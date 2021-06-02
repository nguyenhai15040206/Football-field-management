using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
   public class DonGiaGioDAO
    {
        private static DonGiaGioDAO instance;

        public static DonGiaGioDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new DonGiaGioDAO();
                }
                return instance;
            }
        }
        QuanLySanBongDataContext db = new QuanLySanBongDataContext();

        // load tất cả các đơn giá giờ với ngày cập nhật mới nhất
        public List<DonGiaGio> loadDonGiaGio_NgayCNMoiNhat()
        {
            var listDGG = (from a in db.DonGiaGios
                           from b in (
                               (from DonGiaGio in db.DonGiaGios
                                group DonGiaGio by new
                                {
                                    DonGiaGio.tuKhungGio,
                                    DonGiaGio.denKhungGio
                                } into g
                                select new
                                {
                                    date = (DateTime?)g.Max(p => p.ngayCapNhat),
                                    g.Key.tuKhungGio,
                                    g.Key.denKhungGio
                                }))
                           where
                             a.ngayCapNhat == b.date &&
                             a.tuKhungGio == b.tuKhungGio &&
                             a.denKhungGio == b.denKhungGio
                           select a).ToList();
            return listDGG;
        }

        //
        // load tất cả các đơn giá giờ với ngày cập nhật mới nhất
        public List<NewDonGiaGio> loadDonGiaGio_NgayCNMoiNhat_tenLoaiSan()
        {
            var listDGG = (from a in db.DonGiaGios
                           from ls in db.LoaiSans
                           from b in (
                               (from DonGiaGio in db.DonGiaGios
                                group DonGiaGio by new
                                {
                                    DonGiaGio.tuKhungGio,
                                    DonGiaGio.denKhungGio
                                } into g
                                select new
                                {
                                    date = (DateTime?)g.Max(p => p.ngayCapNhat),
                                    g.Key.tuKhungGio,
                                    g.Key.denKhungGio
                                }))

                           where
                             a.ngayCapNhat == b.date &&
                             a.tuKhungGio == b.tuKhungGio &&
                             a.denKhungGio == b.denKhungGio &&
                             a.maloaiSan == ls.maLoaiSan
                           select new NewDonGiaGio {
                               MaloaiSan = a.maloaiSan,
                               TuKhungGio = a.tuKhungGio,
                               DenKhungGio = a.denKhungGio,
                               NgayCapNhat = a.ngayCapNhat,
                               TenLoaiSan = ls.tenLoai,
                               DonGia = a.donGia

                           }).ToList();
            return listDGG;
        }



        // load tất cả các đơn giá giờ với ngày cập nhật mới nhất và với maxLoaiSan 
        public List<DonGiaGio> loadDonGiaGio_NgayCNMoiNhat_MaLoaiSan(int maLoaiSan)
        {
            var listDGG = (from a in db.DonGiaGios
                           from b in (
                               (from DonGiaGio in db.DonGiaGios
                                group DonGiaGio by new
                                {
                                    DonGiaGio.tuKhungGio,
                                    DonGiaGio.denKhungGio
                                } into g
                                select new
                                {
                                    date = (DateTime?)g.Max(p => p.ngayCapNhat),
                                    g.Key.tuKhungGio,
                                    g.Key.denKhungGio
                                }))
                           where
                             a.ngayCapNhat == b.date &&
                             a.tuKhungGio == b.tuKhungGio &&
                             a.denKhungGio == b.denKhungGio &&
                             a.maloaiSan == maLoaiSan
                           select a).OrderBy(m=>m.tuKhungGio). ToList();
            return listDGG;
        }

    }
}
