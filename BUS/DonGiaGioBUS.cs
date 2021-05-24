using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
  public  class DonGiaGioBUS
    {
        private static DonGiaGioBUS instance;

        public static DonGiaGioBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new DonGiaGioBUS();
                }
                return instance;
            }
        }


        public List<DonGiaGio> loadDonGiaGio_maLoaiSan(int maLoaiSan)
        {
            List<DonGiaGio> dg = new List<DonGiaGio>();
            dg = DonGiaGioDAO.Instance.loadDonGiaGio_NgayCNMoiNhat_MaLoaiSan(maLoaiSan);
            return dg;
        }
    }
}
