using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
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


        public List<DonGiaGio> loadDonGiaGio_maLoaiSan(int maLoaiSan)
        {
            List<DonGiaGio> dg = new List<DonGiaGio>();
            dg = DonGiaGioDAO.Instance.loadDonGiaGio_NgayCNMoiNhat_MaLoaiSan(maLoaiSan);
            return dg;
        }




        public void loadDonGiaGio_NgayCNMoiNhat_ListView(ListView lv)
        {
            ListViewItem[] kq = new ListViewItem[DonGiaGioDAO.Instance.loadDonGiaGio_NgayCNMoiNhat_tenLoaiSan().Count];
            ListViewItem[] kq1 = new ListViewItem[DonGiaGioDAO.Instance.loadDonGiaGio_NgayCNMoiNhat_tenLoaiSan().Count];
            ListViewItem[] kq2 = new ListViewItem[DonGiaGioDAO.Instance.loadDonGiaGio_NgayCNMoiNhat_tenLoaiSan().Count];
            for (int i =0; i < DonGiaGioDAO.Instance.loadDonGiaGio_NgayCNMoiNhat_tenLoaiSan().Count; i++)
            {
                    ListViewItem lvItem = new ListViewItem(new[] { DonGiaGioDAO.Instance.loadDonGiaGio_NgayCNMoiNhat_tenLoaiSan()[i].TenLoaiSan, "Từ: "+DonGiaGioDAO.Instance.loadDonGiaGio_NgayCNMoiNhat_tenLoaiSan()[i].TuKhungGio +" đến: "+
                    DonGiaGioDAO.Instance.loadDonGiaGio_NgayCNMoiNhat_tenLoaiSan()[i].DenKhungGio, DonGiaGioDAO.Instance.loadDonGiaGio_NgayCNMoiNhat_tenLoaiSan()[i].NgayCapNhat.ToString("dd-MM-yyy"),
                string.Format("{0:0,0} vnđ",DonGiaGioDAO.Instance.loadDonGiaGio_NgayCNMoiNhat_tenLoaiSan()[i].DonGia)});
                    lvItem.Name = DonGiaGioDAO.Instance.loadDonGiaGio_NgayCNMoiNhat_tenLoaiSan()[i].MaloaiSan.ToString();
                    kq[i] = lvItem;
            }
            lv.Items.Clear();
            lv.Items.AddRange(kq);
        }
    }
}
