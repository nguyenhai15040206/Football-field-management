using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
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
        public void loadKhachhang_Cbo(ComboBox cbo)
        {
            var Khachhang = KhachHangDAO.Instance.loadTatCaKhachHang();
            cbo.DataSource = Khachhang;
            cbo.DisplayMember = "tenKhachHang";
            cbo.ValueMember ="maKhachHang";
        }
    }
}
