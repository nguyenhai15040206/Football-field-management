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

        // load tất cả các thức uống
        public List<ThucUong> loadTaCaThucUong()
        {
            var lisThucUong = db.ThucUongs.ToList();
            return lisThucUong;
        }
    }
}
