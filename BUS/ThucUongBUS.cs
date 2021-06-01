using DAO;
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

        // load thức uống lên ComboboxEdit
        public void loadThucUong_Cbo(ComboBox cbo)
        {
            cbo.DataSource = ThucUongDAO.Instance.loadTaCaThucUong();
            cbo.DisplayMember = "tenThucUong";
            cbo.ValueMember = "maThucUong";
        }  
        
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
    }


}
