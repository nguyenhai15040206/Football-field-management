using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ReportDAO
    {
        private static ReportDAO instance;

        public static ReportDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new ReportDAO();
                }
                return instance;
            }
        }

        QuanLySanBongDataContext db = new QuanLySanBongDataContext();
        // tạo report phiếu thanh toán
        public DataTable phieuThanhToan(int maPhieu)
        {
            DataTable table = new DataTable();
            var query = (from hd in db.HoaDons
                        join cthd in db.ChiTietHDs on hd.maHoaDon equals cthd.maHoaDon
                        join tu in db.ThucUongs on cthd.maThucUong equals tu.maThucUong
                        join kh in db.KhachHangs on hd.maKhachHang equals kh.maKhachHang
                        join sb in db.sanBongs on hd.maSan equals sb.maSan
                        where hd.maHoaDon == maPhieu
                        select new
                        {
                            hd.maHoaDon,
                            hd.ngayLap,
                            hd.tienNuoc,
                            hd.tienSan,
                            hd.giamGia,
                            hd.tongTien,
                            hd.ngayDat,
                            hd.gioVao,
                            hd.gioRa,
                            kh.tenKhachHang,
                            sb.tenSan,
                            tu.tenThucUong,
                            cthd.soLuong,
                            cthd.giaBan,
                            cthd.thanhTien
                        }).ToList();
            table = ToDataTable(query);   
            return table;
        }

        // tạo phiếu nhập hàng
        public DataTable phieuNhapHang(int maPhieu)
        {
            DataTable table = new DataTable();
            var query = (from pn in db.PhieuNhaps
                         join ctpn in db.ChiTietPNs on pn.maPhieuNhap equals ctpn.maPhieuNhap
                         join tu in db.ThucUongs on ctpn.maThucUong equals tu.maThucUong
                         join ncc in db.NhaCungCaps on pn.maNhaCungCap equals ncc.maNhaCungCap
                         join nd in db.NguoiDungs on pn.maNguoiDung equals nd.maNguoiDung
                         where pn.maPhieuNhap == maPhieu
                         select new
                         {
                             pn.maPhieuNhap,
                             pn.NgayLap,
                             nd.tenNguoiDung,
                             ncc.tenNhaCungCap,
                             ncc.SoDienThoai,
                             ncc.diaChi,
                             tu.tenThucUong,
                             tu.DVT,
                             tu.giaNhap,
                             ctpn.thanhTien,
                             ctpn.soLuong,
                             pn.tongTien,
                         }).ToList();
            table = ToDataTable(query);
            return table;
        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {//inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
