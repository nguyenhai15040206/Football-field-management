using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NhomNguoiDungDAO
    {
        private static NhomNguoiDungDAO instance;

        public static NhomNguoiDungDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new NhomNguoiDungDAO();
                }
                return instance;
            }
        }

        QuanLySanBongDataContext db = new QuanLySanBongDataContext();
        // load nhóm người dùng
        public List<QL_NhomNguoiDung> loadNhomNguoiDung()
        {
            var listNguoiDung = db.QL_NhomNguoiDungs.ToList();
            return listNguoiDung;

        }

        // thêm người dùng vào nhóm người dùng
        public bool themNguoiDungVaoNhom(int maNguoiDung, int maNhom, string ghiChu)
        {
            try
            {
                QL_NguoiDungNhomNguoiDung nd = new QL_NguoiDungNhomNguoiDung();
                nd.maNguoiDung = maNguoiDung;
                nd.maNhom = maNhom;
                nd.ghiChu = ghiChu;
                db.QL_NguoiDungNhomNguoiDungs.InsertOnSubmit(nd);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // lấy Nhóm người dùng có mã đầu tiền
        public int maNhomNguoiDungDauTien()
        {
            var maNhom = db.QL_NhomNguoiDungs.Take(1).OrderByDescending(m => m.maNhom).Single();
            return maNhom.maNhom;
        }

        // xóa người dùng ra khỏi nhóm
        public bool xoaNguoiDungRaKhoiNhom(int maNguoiDung, int maNhom)
        {
            try
            {
                var nguoiDung = db.QL_NguoiDungNhomNguoiDungs.SingleOrDefault(m => m.maNguoiDung == maNguoiDung && m.maNhom == maNhom);
                db.QL_NguoiDungNhomNguoiDungs.DeleteOnSubmit(nguoiDung);
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
