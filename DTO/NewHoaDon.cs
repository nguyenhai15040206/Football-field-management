using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NewHoaDon
    {
        private int _maHoaDon;
        private DateTime _ngayLap;
        private double _tienSan;
        private double giamGia;
        private double _tienNuoc;
        private double _datCoc;
        private double _tongTien;
        private string _tenSan;
        private string _tenKhachHang;
        private string _soDienThoai;
        private DateTime _ngayDat;
        private TimeSpan _gioVao;
        private TimeSpan _gioRa;
        private int maNguoiDung;
        private bool _tinhTrang;

        public int MaHoaDon { get => _maHoaDon; set => _maHoaDon = value; }
        public DateTime NgayLap { get => _ngayLap; set => _ngayLap = value; }
        public double TienSan { get => _tienSan; set => _tienSan = value; }
        public double GiamGia { get => giamGia; set => giamGia = value; }
        public double TienNuoc { get => _tienNuoc; set => _tienNuoc = value; }
        public double DatCoc { get => _datCoc; set => _datCoc = value; }
        public double TongTien { get => _tongTien; set => _tongTien = value; }
        public string TenSan { get => _tenSan; set => _tenSan = value; }
        public string TenKhachHang { get => _tenKhachHang; set => _tenKhachHang = value; }
        public string SoDienThoai { get => _soDienThoai; set => _soDienThoai = value; }
        public DateTime NgayDat { get => _ngayDat; set => _ngayDat = value; }
        public TimeSpan GioVao { get => _gioVao; set => _gioVao = value; }
        public TimeSpan GioRa { get => _gioRa; set => _gioRa = value; }
        public int MaNguoiDung { get => maNguoiDung; set => maNguoiDung = value; }
        public bool TinhTrang { get => _tinhTrang; set => _tinhTrang = value; }
    }
}
