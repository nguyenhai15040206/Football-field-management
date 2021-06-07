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

                           }).OrderBy(m=>m.MaloaiSan).ToList();
            return listDGG;
        }



        // load tất cả các đơn giá giờ với ngày cập nhật mới nhất
        public List<NewDonGiaGio> loadDonGiaGio_NgayCNMoiNhat_TenLoaiMaLoaiSan(int maLoaiSan)
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
                             a.maloaiSan == ls.maLoaiSan &&
                             ls.maLoaiSan == maLoaiSan
                           select new NewDonGiaGio
                           {
                               MaloaiSan = a.maloaiSan,
                               TuKhungGio = a.tuKhungGio,
                               DenKhungGio = a.denKhungGio,
                               NgayCapNhat = a.ngayCapNhat,
                               TenLoaiSan = ls.tenLoai,
                               DonGia = a.donGia

                           }).OrderBy(m => m.MaloaiSan).ToList();
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


        // thêm đơn giá giờ mới
        public bool themDonGiaGio(int maLoai, double tuGK, double denKG, DateTime ngayCN, decimal donGia)
        {
            try
            {
                DonGiaGio dgg = new DonGiaGio();
                dgg.maloaiSan = maLoai;
                dgg.tuKhungGio = tuGK;
                dgg.denKhungGio = denKG;
                dgg.ngayCapNhat = ngayCN;
                dgg.donGia = donGia;
                db.DonGiaGios.InsertOnSubmit(dgg);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // cập nhật đơn giá của đơn giá giờ
        public bool capNhatDonGiaGio(int maLoai, double tuKhungGio, double denKhungGio,DateTime ngayCN ,double donGia)
        {
            try
            {
                var donGiaGio = db.DonGiaGios.SingleOrDefault(m => m.maloaiSan == maLoai && m.tuKhungGio == tuKhungGio
                && m.denKhungGio == denKhungGio && m.ngayCapNhat == ngayCN);
                if (donGiaGio != null)
                {
                    db.DonGiaGios.DeleteOnSubmit(donGiaGio);
                    db.SubmitChanges();
                    DonGiaGio dggMoi = new DonGiaGio();
                    dggMoi.maloaiSan = maLoai;
                    dggMoi.tuKhungGio = tuKhungGio;
                    dggMoi.denKhungGio = denKhungGio;
                    dggMoi.donGia = (decimal)donGia;
                    dggMoi.ngayCapNhat = DateTime.Now.Date;
                    db.DonGiaGios.InsertOnSubmit(dggMoi);
                    db.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        // xóa tất cả các đơn giá giờ với maxLoaij sân sau đó thêm mới lại
        public bool xoaDonGiaGioVoiMa(int maLoaiSan)
        {
            try
            {
                List<DonGiaGio> dgg = db.DonGiaGios.Where(m => m.maloaiSan == maLoaiSan).ToList();
                db.DonGiaGios.DeleteAllOnSubmit(dgg);
                db.SubmitChanges();
                return true;
            }catch
            {
                return false;
            }
        }    


    }
}
