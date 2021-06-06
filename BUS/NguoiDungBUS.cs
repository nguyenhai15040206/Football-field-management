
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraGrid;

namespace BUS
{
    public class NguoiDungBUS
    {
        private static NguoiDungBUS instance;

        public static NguoiDungBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new NguoiDungBUS();
                }
                return instance;
            }
        }
        public int maND = 0;

        public int checkConfig()
        {
            return NguoiDungDAO.Instance.checConfig();
        }
        // getSername
        public void getServerName(ComboBox cbo)
        {
            cbo.Items.Clear();
            cbo.Items.Add(@".\SQLEXPRESS");
            cbo.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
        }

        public void getDatabaseName(string server, string user, string pass, ComboBox cbo)
        {
            try
            {
                cbo.DataSource = NguoiDungDAO.Instance.getDatabaseName(server, user, pass);
                cbo.DisplayMember = "name";
            }
            catch
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }
        }

        public void saveConfig(string pServer, string pUser, string pPass, string pDatabaseName)
        {
            NguoiDungDAO.Instance.saveConfig(pServer, pUser, pPass, pDatabaseName);
        }

        // đăng nhập hệ thống
        public int dangNhapHeThong(string tenDangNhap, string matKhau)
        {
            var nguoiDung = NguoiDungDAO.Instance.dangNhapHeThong(tenDangNhap, KiemTraDuLieu.MD5Hash(matKhau));
            try
            {
                if (nguoiDung == null)
                {
                    return 100;
                }
                if (nguoiDung.hoatDong == false)
                {
                    return 200;
                }
                else
                {
                    return 300;
                }
            }
            catch
            {
                return 300;
            }
        }

        // láy ra mã người dùng khi đăng nhập
        public int maNguoiDung(string tenDangNhap)
        {
            return NguoiDungDAO.Instance.ttNguoiDung(tenDangNhap).maNguoiDung;
        }

        // lấy ra Tên người dùng và số điện thoại người dùng khi đăng nhập
        public string thongTinNguoiDung(string tenDangNhap)
        {

            var nd = NguoiDungDAO.Instance.ttNguoiDung(tenDangNhap);
            return nd.tenNguoiDung + " - " +
                nd.soDienThoai;
        }

        public void loadNhomNguoiDung(TreeList tv)
        {
            tv.BeginUnboundLoad();

            tv.Nodes.Clear();
            List<QL_NhomNguoiDung> nd = NguoiDungDAO.Instance.loadNhomNguoiDung();
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

        // load tất cả người dùng
        public void loadNguoiDung(GridControl gv)
        {
            gv.DataSource = NguoiDungDAO.Instance.loadNguoiDung();
        }

        public void loadNhomNguoiDung_GridCOntrol(GridControl gv)
        {
            gv.DataSource = NguoiDungDAO.Instance.loadNhomNguoiDung();
        }

        public void loadNguoiDungChuaCoNhom(GridControl dgv)
        {
            dgv.DataSource = null;
            dgv.DataSource = NguoiDungDAO.Instance.loadNguoiDungChuaCoNhom();
        }



    }
}
