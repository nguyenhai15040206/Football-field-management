using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DevExpress.XtraGrid;
using DTO;

namespace BUS
{
    public class SanBongBUS : EventArgs
    {
        private static SanBongBUS instance;
        public static SanBongBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new SanBongBUS();
                }
                return instance;
            }
        }

        //
        public void loadTaCaSanBong(GridControl gv)
        {
            gv.DataSource = SanBongDAO.Instance.loadTatCaSanBong();
        }
        //thêm sân bóng
        public bool themSan(string ten, bool tinhTrang, int ma)
        {
            return SanBongDAO.Instance.ThemSanBong(ten, tinhTrang, ma);
        }

        //Kiểm tra trùng tên sân
        public bool KtraTrungTenSan(string input)
        {
            return SanBongDAO.Instance.TrungTenSan(input);
        }


        //load tất cả sân đã bảo trì thành công
        public void LoadSanDaBaoTri(GridControl grid)
        {
            var san = SanBongDAO.Instance.loadTatCaSanBongDaBaoTri();
            grid.DataSource = san;
        }
        //load tất cả sân đã bảo trì thành công
        public void LoadSanBaoTri(GridControl grid)
        {
            var san = SanBongDAO.Instance.loadTatCaSanBongBaoTri();
            grid.DataSource = san;
        }

        // lấy ra maSan với ten san bóng
        public int maSan_voiTenSan(string tenSan)
        {
            int maSan = 0;
            maSan = SanBongDAO.Instance.maSan_voiTenSan(tenSan.Trim());
            return maSan;
        }

    }
}
