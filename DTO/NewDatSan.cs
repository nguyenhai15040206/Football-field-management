using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NewDatSan
    {
		private string _tenSan;

		private System.String _tenKhachhang;

		private System.String _tenNguoiDung;

		private System.DateTime _NgayDat;

		private System.String _GioVao;

		private System.String _GioRa;

		private System.Nullable<decimal> _tienSan;

		private System.Nullable<decimal> _tienCoc;

		private System.Nullable<bool> _tinhTrang;

		private string _ghiChu;

        public DateTime NgayDat { get => _NgayDat; set => _NgayDat = value; }
        public decimal? TienSan { get => _tienSan; set => _tienSan = value; }
        public decimal? TienCoc { get => _tienCoc; set => _tienCoc = value; }
        public bool? TinhTrang { get => _tinhTrang; set => _tinhTrang = value; }
        public string TenSan { get => _tenSan; set => _tenSan = value; }
        public string TenKhachhang { get => _tenKhachhang; set => _tenKhachhang = value; }
        public string TenNguoiDung { get => _tenNguoiDung; set => _tenNguoiDung = value; }
        public string GhiChu { get => _ghiChu; set => _ghiChu = value; }
        public String GioVao { get => _GioVao; set => _GioVao = value; }
        public String GioRa { get => _GioRa; set => _GioRa = value; }
    }
}
