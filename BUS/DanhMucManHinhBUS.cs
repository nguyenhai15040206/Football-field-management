using DevExpress.XtraTreeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraGrid;

namespace BUS
{
    public class DanhMucManHinhBUS
    {
        private static DanhMucManHinhBUS instance;

        public static DanhMucManHinhBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DanhMucManHinhBUS();
                }
                return instance;
            }

        }

        // load danh mục màn hình lên GridControl
        public void loadDanhMucManHinh(TreeList tv)
        {
            tv.BeginUnboundLoad();

            tv.Nodes.Clear();
            List<DanhMucManHinh> nd = DanhMucManHinhVaPhanQuyenDAO.Instance.loadTatCaDanhMucManHinh();
            for (int i = 0; i < nd.Count; i++)
            {
                TreeListNode nodes = tv.AppendNode(null, null);
                nodes.SetValue("name", nd[i].tenManHinh.ToString());
                nodes.Tag = (nd[i].maManHinh.ToString()).ToString();
            }
            tv.EndUnboundLoad();
        }

        // load danh sách quyền chức năng
        public void loadDanhSachQuyenChucNang(GridControl gv, int maNhom)
        {
            gv.DataSource = DanhMucManHinhVaPhanQuyenDAO.Instance.danhSachQuyenChucNang(maNhom);
        }

    }
}
