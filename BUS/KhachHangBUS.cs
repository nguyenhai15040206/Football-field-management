using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DTO;

namespace BUS
{
  public  class KhachHangBUS
    {
        private static KhachHangBUS instance;

        public static KhachHangBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new KhachHangBUS();
                }
                return instance;
            }
        }

        // load tất cả các khách hàng lên ComboBox
        public void loadKhachhang_Cbo(System.Windows.Forms.ComboBox cbo)
        {
            var Khachhang = KhachHangDAO.Instance.loadTatCaKhachHang();
            cbo.DataSource = Khachhang;
            cbo.DisplayMember = "tenKhachHang";
            cbo.ValueMember ="maKhachHang";
        }

        // load khách hàng lên Grid
        public void loadKhachHang_Grid(GridControl grid)
        {
            var KhachHang = KhachHangDAO.Instance.loadTatCaKhachHang();
            grid.DataSource = KhachHang;
        }


        // lấy thông tin khách hàng với mã
            //+ lấy họ tên 
        public string hotenKhachHang(int maKhachHang)
        {
            return KhachHangDAO.Instance.thongTinKhachHang_maKH(maKhachHang).tenKhachHang;
        }

        //+ lấy thông tin số điện thoại
        public string soDienThoai(int maKhachhang)
        {
            return KhachHangDAO.Instance.thongTinKhachHang_maKH(maKhachhang).soDienThoai;
        }


        // lấy thông tin khách hàng từ số điện thoại
        public int maKhachHang_soDienThoai(string soDienThoai)
        {
            return KhachHangDAO.Instance.thongTinKhachHang_soDienThoai(soDienThoai).maKhachHang;
        }


        //kiêm tra trùng số điện thoại
        public bool KtraTrungSDTKhachHang(string input)
        {
            return KhachHangDAO.Instance.KtraTrungSoDienThoai(input);
        }

        //Thêm khách hàng mới
        public bool ThemKhachHang(string ten, string sdt)
        {
            return KhachHangDAO.Instance.themKhachHang(ten, sdt);
        }


        //Cập nhậy thông tin khách hàng'
        public bool CapNhatThongTin(int makh, string ten, string sdt, double diem, int maLoai)
        {
            return KhachHangDAO.Instance.CapNhatThongtinKH(makh, ten, sdt, diem, maLoai);
        }

        // xóa thông tin Khách hàng
        public bool xoaKhachHang(int maKhachHang)
        {
            return KhachHangDAO.Instance.xoaKhachHang(maKhachHang);
        }

        // cập nhật điểm tích lũy
        public bool capNhatDienTichLuy_khiDat(int maKhachHang)
        {
            return KhachHangDAO.Instance.capNhatDienTichLuy_khiDat(maKhachHang);
        }

        public bool capNhatDienTichLuy_khiHuy(int maKhachHang)
        {
            return KhachHangDAO.Instance.capNhatDienTichLuy_khiHuy(maKhachHang);
        }
    }
}
