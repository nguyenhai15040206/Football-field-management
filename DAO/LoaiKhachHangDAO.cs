using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class LoaiKhachHangDAO
    {
        private static LoaiKhachHangDAO instance;
        public static LoaiKhachHangDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoaiKhachHangDAO();
                }
                return instance;
            }
        }
        QuanLySanBongDataContext db = new QuanLySanBongDataContext();
        ///load tất cả các khách hàng
        ///
        public List<LoaiKhachHang> loadLoaiKhachHang()
        {
            var listLoaiKH = db.LoaiKhachHangs.ToList();
            if (listLoaiKH.Count == 0)
            {
                return null;
            }
            return listLoaiKH;
        }

        // tìm loại khách hàng để xác định giảm giá bằng số điện thoại sđt khách hàng
        public LoaiKhachHang timLoaiKhachHang_SĐT(string sdt)
        {
            var khachHang = (from loai in db.LoaiKhachHangs
                             join kh in db.KhachHangs on loai.maLoaiKhachHang equals kh.maLoaiKhachHang
                             where kh.soDienThoai == sdt
                             select loai).SingleOrDefault();
            if(khachHang== null)
            {
                return null;
            }
            return khachHang;
        }
    }
}
