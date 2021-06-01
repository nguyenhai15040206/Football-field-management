using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NewQL_PhanQuyen
    {
        int maManHinh;
        string tenManHinh;
        bool? coQuyen;

        public int MaManHinh { get => maManHinh; set => maManHinh = value; }
        public string TenManHinh { get => tenManHinh; set => tenManHinh = value; }
        public bool? CoQuyen { get => coQuyen; set => coQuyen = value; }
    }
}
