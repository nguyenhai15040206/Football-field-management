using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class LoaiSanDAO
    {
        QuanLySanBongDataContext db = new QuanLySanBongDataContext();
        private static LoaiSanDAO instance;

        public static LoaiSanDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new LoaiSanDAO();
                }
                return instance;
            }
        }

        public List<LoaiSan> loadTaCaLoaiSan()
        {
            var listLoaiSan = db.LoaiSans.ToList();
            if(listLoaiSan.Count==0)
            {
                return null;
            }
            return listLoaiSan;
        }
    }
}
