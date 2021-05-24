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
    }
}
