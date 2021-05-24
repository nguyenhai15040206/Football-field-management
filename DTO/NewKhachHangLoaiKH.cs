using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NewKhachHangLoaiKH
    {
        private int _maKhachHang;

        private string _tenKhachHang;

        private string _soDienThoai;

        private System.Nullable<double> _diemTichLuy;
        private string _tenLoai;

        public int MaKhachHang { get => _maKhachHang; set => _maKhachHang = value; }
        public string TenKhachHang { get => _tenKhachHang; set => _tenKhachHang = value; }
        public string SoDienThoai { get => _soDienThoai; set => _soDienThoai = value; }
        public double? DiemTichLuy { get => _diemTichLuy; set => _diemTichLuy = value; }
        public string TenLoai { get => _tenLoai; set => _tenLoai = value; }
    }
}
