
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
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

    }
}
