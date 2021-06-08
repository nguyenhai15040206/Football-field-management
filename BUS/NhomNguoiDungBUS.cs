using DAO;
using DevExpress.XtraGrid;
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
    public class NhomNguoiDungBUS
    {
        private static NhomNguoiDungBUS instance;

        public static NhomNguoiDungBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new NhomNguoiDungBUS();
                }
                return instance;
            }
        }

        QuanLySanBongDataContext db = new QuanLySanBongDataContext();
        public void loadNhomNguoiDung(TreeList tv)
        {
            tv.BeginUnboundLoad();

            tv.Nodes.Clear();
            List<QL_NhomNguoiDung> nd = NhomNguoiDungDAO.Instance.loadNhomNguoiDung();
            for (int i = 0; i < nd.Count; i++)
            {
                TreeListNode nodes = tv.AppendNode(null, null);
                nodes.SetValue("name", nd[i].tenNhom.ToString());
                nodes.Tag = (nd[i].maNhom.ToString()).ToString();
                string maNhom = (string)nodes.Tag;
                List<NguoiDung> ndNhomND = NguoiDungDAO.Instance.loadNguoiDungTheoNhom(int.Parse(maNhom.ToString()));
                for (int j = 0; j < ndNhomND.Count; j++)
                {
                    TreeListNode childNodes = null;
                    childNodes = tv.AppendNode(null, nodes);
                    childNodes.SetValue("name", "Tài khoản: " + ndNhomND[j].tenDangNhap);
                }


            }
            tv.EndUnboundLoad();
        }

        //load danh sách Nhóm người dùng
        public void loadDSNhomNguoiDungComboBox(ComboBox cbo)
        {
            cbo.DataSource = NhomNguoiDungDAO.Instance.loadNhomNguoiDung();
            cbo.DisplayMember = "tenNhom";
            cbo.ValueMember = "maNhom";
        }
        public void loadDSNhomNguoiDung_GridControl(GridControl dgv)
        {
            dgv.DataSource = NhomNguoiDungDAO.Instance.loadNhomNguoiDung();
        }

        // thêm người dùng vào nhóm
        public bool themNguoiDungVaoNhom(int maNguoiDung, int maNhom, string ghiChu)
        {
            return NhomNguoiDungDAO.Instance.themNguoiDungVaoNhom(maNguoiDung, maNhom, ghiChu);
        }

        // xóa người dùng ra khỏi nhóm
        public bool xoaNguoiDungRaKhoiNhom(int maNguoiDung, int maNhom)
        {
            return NhomNguoiDungDAO.Instance.xoaNguoiDungRaKhoiNhom(maNguoiDung, maNhom);
        }

        // load danh sách nhóm người dùng
        public void loadDSNhomNguoiDungTheoMaNhom(int maNhom, GridControl gv)
        {
            gv.DataSource = null;
            gv.DataSource = NguoiDungDAO.Instance.loadNguoiDungTheoNhom(maNhom);
        }

        // lấy mã nhóm người dùng đầu tiên
        public int layMaNHomNguoiDungDauTien()
        {
            return NhomNguoiDungDAO.Instance.maNhomNguoiDungDauTien();
        }

        // get mã nhóm người dùng
        public List<int> getMaNhomNguoiDung(int maNguoiDung)
        {
            return NhomNguoiDungDAO.Instance.getMaNhomNguoiDung(maNguoiDung);
        }

        // get ma ManHinh từ mã nhóm
        public List<QL_PhanQuyen> getMaManHinh(int maNhom)
        {
            return NhomNguoiDungDAO.Instance.getMaManHinh(maNhom);
        }

        // phân quyền
        public bool phanQuyen(int maNhom, int maaManHinh, bool coQuyen)
        {
            return NhomNguoiDungDAO.Instance.phanQuyen(maNhom, maaManHinh, coQuyen);
        }
    }
}
