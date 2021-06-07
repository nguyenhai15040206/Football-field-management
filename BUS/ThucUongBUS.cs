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
using System.Data;
using System.Linq;
using System.Reflection;
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
            List<ThucUong> listThucUong = ThucUongDAO.Instance.loadTaCaThucUong_ConHang();
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
            cbo.DataSource = ThucUongDAO.Instance.loadTaCaThucUong_ConHang();
            cbo.DisplayMember = "tenThucUong";
            cbo.ValueMember = "maThucUong";
        }

        // load thức uống vào lookUpEdit
        public void loadThucUong_looUpEdit(RepositoryItemLookUpEdit lookUpEdit)
        {
            lookUpEdit.DataSource = ThucUongDAO.Instance.loadTaCaThucUong_ConHang();
            lookUpEdit.ValueMember = "maThucUong";
            lookUpEdit.DisplayMember = "tenThucUong";
        }


        // load dánh thức uống vào GridConbtrol 
        public void loadThucUong_GridControl(GridControl gv, bool tinhTrang)
        {
            if (tinhTrang)
            {
                gv.DataSource = ThucUongDAO.Instance.loadTaCaThucUong_ConHang();
            }
            else
            {
                gv.DataSource = ThucUongDAO.Instance.loadTaCaThucUong_HetHang();
            }    
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

        public double donGiaNhap(int maThucUong)
        {
            return (double)ThucUongDAO.Instance.timThucUongVoi_Ma(maThucUong).giaNhap;
        }

        public string tenThucUong (int maThucUong)
        {
            return ThucUongDAO.Instance.timThucUongVoi_Ma(maThucUong).tenThucUong;
        }


        // danh sách các chức năng nghiệp vụ
        // xóa thức uống
        public bool xoaThucUong(int maThucUong)
        {
            return ThucUongDAO.Instance.xoaThucUong(maThucUong);
        }

        // thêm thức uống
        public bool themThucUong(string tenThucUong, string DVT, double giaBan, double giaNhap, int soLuong, bool tinhTrang)
        {
            return ThucUongDAO.Instance.themThucUong(tenThucUong, DVT, giaBan, giaNhap, soLuong, tinhTrang);
        }

        // cập nhật thức uống
        public bool capNhatThucUong(int maTU, string tenThucUong, string DVT, double giaBan, double giaNhap, int soLuong, bool tinhTrang)
        {
            return ThucUongDAO.Instance.capNhatThucUong(maTU, tenThucUong, DVT, giaBan, giaNhap, soLuong, tinhTrang);
        }



        //////////////
        /// cập nhật số lượng khi sản phẩm dược mua hoặc hóa đơn đó không kkhar dụng
        // nhập nhật số lượng khi mua
        public bool capNhatSoLuongKhiMua(int maThucUong, int soLuongMua)
        {
            return ThucUongDAO.Instance.capNhatSoLuongKhiMua(maThucUong, soLuongMua);

        }

        public bool capNhatSoLuongKhiHuy(int maThucUong, int soLuongHuy)
        {
            return ThucUongDAO.Instance.capNhatSoLuongKhiHuy(maThucUong, soLuongHuy);

        }

    }


}
