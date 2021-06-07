using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NewChiTietHD
    {
        private int _maThucUong;
        private string _DVT;
        private int _soLuong;

        private double _donGia;

        private double _thanhTien;
        public int MaThucUong { get => _maThucUong; set => _maThucUong = value; }
        public string DVT { get => _DVT; set => _DVT = value; }
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
        public double DonGia { get => _donGia; set => _donGia = value; }
        public double ThanhTien { get => _thanhTien; set => _thanhTien = value; }
    }
}
