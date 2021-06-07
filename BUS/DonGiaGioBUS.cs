using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DevExpress.XtraGrid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
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

        // load don giá có ngày cập nhật mới nhất
        public List<DonGiaGio> loadDonGiaGio_maLoaiSan(int maLoaiSan)
        {
            List<DonGiaGio> dg = new List<DonGiaGio>();
            dg = DonGiaGioDAO.Instance.loadDonGiaGio_NgayCNMoiNhat_MaLoaiSan(maLoaiSan);
            return dg;
        }



        // load đơn giá có ngày cập nhật mới nhất có tên loại sân
        public void loadDonGiaGio_NgayCNMoiNhat_Grid(GridControl dgv)
        {
            dgv.DataSource = DonGiaGioDAO.Instance.loadDonGiaGio_NgayCNMoiNhat_tenLoaiSan();
        }

        // load đơn giá có ngày cập nhật mới nhất có tên loại sân với mã
        public void loadDonGia_NgayCNMoiNhat_Grid_MaLoaiSan(GridControl dgv, int maLoaiSan)
        {
            dgv.DataSource = DonGiaGioDAO.Instance.loadDonGiaGio_NgayCNMoiNhat_TenLoaiMaLoaiSan(maLoaiSan);
        }

        //thêm đơn giá giờ
        public bool themDonGiaGio(int maLoai, double tuGK, double denKG, decimal donGia)
        {
            return DonGiaGioDAO.Instance.themDonGiaGio(maLoai, tuGK, denKG, donGia);
        }

        // xóa đơn giá giờ với mã sân
        public bool xoaDonGiaGioVoiMa(int maLoaiSan)
        {
            return DonGiaGioDAO.Instance.xoaDonGiaGioVoiMa(maLoaiSan);
        }
        
        // cập nhật lại đơn giá
        public bool capNhatDonGiaGio(int maLoai, double tuKhungGio, double denKhungGio, DateTime ngayCN, double donGia)
        {
            return DonGiaGioDAO.Instance.capNhatDonGiaGio(maLoai, tuKhungGio, denKhungGio, ngayCN, donGia);
        }

        // kkieemr tra trùng đơn giá giờ
        public bool kiemTraTrungDonGiaGio(int maLoai, double tuGK, double denKG, DateTime ngayCapNhat)
        {
            return DonGiaGioDAO.Instance.kiemTraTrungDonGiaGio(maLoai, tuGK, denKG, ngayCapNhat);
        }
    }
}
