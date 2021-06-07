using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NewDonGiaGio
    {
        private int _maloaiSan;

        private string _tenLoaiSan;
        private double _tuKhungGio;
        private double _denKhungGio;
        private System.DateTime _ngayCapNhat;

        private System.Nullable<decimal> _donGia;

        public int MaloaiSan { get => _maloaiSan; set => _maloaiSan = value; }
        public string TenLoaiSan { get => _tenLoaiSan; set => _tenLoaiSan = value; }
        public DateTime NgayCapNhat { get => _ngayCapNhat; set => _ngayCapNhat = value; }
        public decimal? DonGia { get => _donGia; set => _donGia = value; }
        public double TuKhungGio { get => _tuKhungGio; set => _tuKhungGio = value; }
        public double DenKhungGio { get => _denKhungGio; set => _denKhungGio = value; }
    }
}
