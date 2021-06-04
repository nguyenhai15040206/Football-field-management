using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
   public class LoaiKhachHangBUS
    {
        private static LoaiKhachHangBUS instance;
        public static LoaiKhachHangBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoaiKhachHangBUS();
                }
                return instance;
            }

        }

        //load tất cả loại khách hàng lên combobox
        public void LoadLoaiKhachHang(ComboBox cbb)
        {
            var loaiKhachHang = LoaiKhachHangDAO.Instance.loadLoaiKhachHang();
            cbb.DataSource = loaiKhachHang;
            cbb.DisplayMember = "tenLoai";
            cbb.ValueMember = "maLoaiKhachHang";
        }

        // lấy ra được loại khách hàng số điện thoại khachsh hàng dể lấy được giảm giá
        public double giamGia (string sdt)
        {
            double giamGia = (double)LoaiKhachHangDAO.Instance.timLoaiKhachHang_SĐT(sdt).giamGia;
            return giamGia;
        }
    }
}
