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
        // load ra tất cả các sân còn trống trong khung giờ vào và khung giờ ra
        public List<sanBong> loadTatCaSanBongConTrong(TimeSpan gioVao , TimeSpan gioRa, DateTime ngayDat)
        {
            var listSanBong = new  List<sanBong>();
            listSanBong = (from SanBong in db.sanBongs
                           where
                             SanBong.LoaiSan.maLoaiSan == 1 && !
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



    }
}
