using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class NewPhieuNhap
    {

		private System.Nullable<System.DateTime> _NgayLap;
		private System.Nullable<decimal> _tongTien;
		private System.Nullable<int> _maPhieuNhap;
		private System.Nullable<bool> _tinhTrang;
		private string _tenNhaCungCap;
		private string _SoDienThoai;
		private string _tenNguoiDung;

        public DateTime? NgayLap { get => _NgayLap; set => _NgayLap = value; }
        public decimal? TongTien { get => _tongTien; set => _tongTien = value; }
        public bool? TinhTrang { get => _tinhTrang; set => _tinhTrang = value; }
        public string TenNhaCungCap { get => _tenNhaCungCap; set => _tenNhaCungCap = value; }
        public string SoDienThoai { get => _SoDienThoai; set => _SoDienThoai = value; }
        public string TenNguoiDung { get => _tenNguoiDung; set => _tenNguoiDung = value; }
        public int? MaPhieuNhap { get => _maPhieuNhap; set => _maPhieuNhap = value; }
    }
}
