using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ThucUongDAO
    {
        private static ThucUongDAO instance;
        public static ThucUongDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new ThucUongDAO();
                }
                return instance;
            }
        }
        QuanLySanBongDataContext db = new QuanLySanBongDataContext();


        // load tất cả thức uống
        public List<ThucUong> loadTaCaThucUong()
        {
            var lisThucUong = db.ThucUongs.ToList();
            return lisThucUong;
        }
        // load tất cả các thức uống còn hàng

        public List<ThucUong> loadTaCaThucUong_HetHang()
        {
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ThucUongs);
            var lisThucUong = (from tu in db.ThucUongs
                               where tu.tinhTrang== false
                               select tu).ToList();
            return lisThucUong;
        }

        // load tất cả thức uống với tình trạng còn hàng
        public List<ThucUong> loadTaCaThucUong_ConHang()
        {
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ThucUongs);
            var lisThucUong = db.ThucUongs.Where(m => m.tinhTrang == true).OrderByDescending(m=>m.soLuong).ToList();
            return lisThucUong;
        }

        public ThucUong timThucUongVoi_Ma(int maThucUong)
        {
            var tu = db.ThucUongs.SingleOrDefault(m => m.maThucUong == maThucUong);
            if (tu == null)
            {
                return null;
            }
            return tu;
        }

        // thêm thức uống
        public bool themThucUong(string tenThucUong, string DVT, double giaBan,double giaNhap ,int soLuong, bool tinhTrang)
        {
            try
            {
                ThucUong tu = new ThucUong();
                tu.tenThucUong = tenThucUong;
                tu.DVT = DVT;
                tu.giaBan = (decimal?)giaBan;
                tu.giaNhap = (decimal?)giaNhap;
                tu.soLuong = soLuong;
                tu.tinhTrang = tinhTrang;
                db.ThucUongs.InsertOnSubmit(tu);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // xóa thức uống 
        public bool xoaThucUong(int maThucUong)
        {
            try
            {
                var thucUong = db.ThucUongs.SingleOrDefault(m => m.maThucUong == maThucUong);
                db.ThucUongs.DeleteOnSubmit(thucUong);
                db.SubmitChanges();
                return true;
            }   
            catch
            {
                return false;
            }
        }

        // cập nhật thức uống
        public bool capNhatThucUong(int maTU,string tenThucUong, string DVT, double giaBan, double giaNhap, int soLuong, bool tinhTrang)
        {
            try
            {
                ThucUong tu = db.ThucUongs.SingleOrDefault(m => m.maThucUong == maTU);
                tu.tenThucUong = tenThucUong;
                tu.DVT = DVT;
                tu.giaBan = (decimal?)giaBan;
                tu.giaNhap = (decimal?)giaNhap;
                tu.soLuong = soLuong;
                tu.tinhTrang = tinhTrang;
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
