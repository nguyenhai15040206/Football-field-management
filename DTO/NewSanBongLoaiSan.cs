using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NewSanBongLoaiSan
    {
        private int _maSan;

        private string _tenSan;

        //private System.Nullable<int> _maLoaiSan;

        //private System.Nullable<bool> _tinhTrang;

        private string _tenLoai;

        public int MaSan { get => _maSan; set => _maSan = value; }
        public string TenSan { get => _tenSan; set => _tenSan = value; }
        public string TenLoai { get => _tenLoai; set => _tenLoai = value; }
    }
}
