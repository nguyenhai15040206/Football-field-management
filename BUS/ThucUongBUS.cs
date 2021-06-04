using DAO;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class ThucUongBUS
    {
        private static ThucUongBUS instance;
        public static ThucUongBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new ThucUongBUS();
                }
                return instance;
            }
        }



        QuanLySanBongDataContext db = new QuanLySanBongDataContext();
        // load danh sách thức uống vào treeLisst
        public void loadThucUong_TreeList(TreeList treeList)
        {
            treeList.BeginUnboundLoad();
            treeList.Nodes.Clear();
            List<ThucUong> listThucUong = ThucUongDAO.Instance.loadTaCaThucUong();
            for(int i=0;i < listThucUong.Count;i++)
            {
                TreeListNode nodes = treeList.AppendNode(null, null);
                nodes.SetValue("name", listThucUong[i].tenThucUong.ToString());
                nodes.Tag = (listThucUong[i].maThucUong.ToString()).ToString();
            }    
            treeList.EndUnboundLoad();
        }

        // load thức uống vào comBoBox 
        public void loadThucUong_cbo(DataGridViewComboBoxColumn cbo)
        {
            cbo.DataSource = ThucUongDAO.Instance.loadTaCaThucUong();
            cbo.DisplayMember = "tenThucUong";
            cbo.ValueMember = "maThucUong";
        }

        // DVT
        public string DVT(int maThucUong)
        {
            return ThucUongDAO.Instance.timThucUongVoi_Ma(maThucUong).DVT;
        }
        public double donGia(int maThucUong)
        {
            return (double)ThucUongDAO.Instance.timThucUongVoi_Ma(maThucUong).giaBan;
        }
    }


}
