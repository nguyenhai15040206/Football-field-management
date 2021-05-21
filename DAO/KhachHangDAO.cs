using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
  public  class KhachHangDAO
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
        public List<KhachHang> loadTatCaKhachHang()
        {
            var listKH = db.KhachHangs.ToList();
            return listKH;
        }
    }
}
