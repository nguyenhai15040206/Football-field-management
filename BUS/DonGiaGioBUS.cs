using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public void loadDonGiaGio_TreeList(TreeList treeList)
        {
            treeList.BeginUnboundLoad();
            treeList.Nodes.Clear();
            List<DonGiaGio> listThucUong = DonGiaGioDAO.Instance.loadDonGiaGio_NgayCNMoiNhat();
            for (int i = 0; i < listThucUong.Count; i++)
            {
                TreeListNode nodes = treeList.AppendNode(null, null);
                nodes.SetValue("name","Từ: "+ listThucUong[i].tuKhungGio.ToString()+ "h đến " + listThucUong[i].denKhungGio.ToString() +"h: "+ string.Format("{0:0.0} vnđ", listThucUong[i].donGia));
            }
            treeList.EndUnboundLoad();
        }
    }
}
