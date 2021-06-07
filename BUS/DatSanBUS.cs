using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DTO;

namespace BUS
{
    public class DatSanBUS
    {
        private static DatSanBUS instance;

        public static DatSanBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new DatSanBUS();
                }
                return instance;
            }
        }


        //load tất các các đặt sân lên GridControl
        public void loadDatSan(GridControl gv)
        {
            gv.DataSource = DatSanDAO.Instance.loadDatSan();
        }

        // laod tất cả các đặt sân với tình trạng là chưa thanh toán
        public void loadDatSanChuaThanhToan(LookUpEdit lookUpEdit)
        {
            lookUpEdit.Properties.DataSource = DatSanDAO.Instance.loadDatSan_ChuaThanhToan();
            lookUpEdit.Properties.DisplayMember = "TenKhachhang";
            //lookUpEdit.Properties.ValueMember = "_soDienThoai";

            lookUpEdit.CustomDisplayText += LookUpEdit_CustomDisplayText;
        }

        private void LookUpEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            LookUpEdit lookUpEdit = sender as LookUpEdit;
            NewDatSan ds = lookUpEdit.Properties.GetDataSourceRowByKeyValue(e.Value) as NewDatSan;
            if(ds !=null)
            {
                e.DisplayText = ds.TenKhachhang + " - " + ds.SoDienThoai;
                
            }    
        }


        // đặt sân
        public bool datSan(int maSan, int maKhachHang, int maNguoiDung, DateTime ngayDat, TimeSpan gioVao, TimeSpan gioRa, double tienSan,
            double tienCoc,  string ghiChu)
        {
            return DatSanDAO.Instance.datSan(maSan, maKhachHang, maNguoiDung, ngayDat, gioVao, gioRa, tienSan, tienCoc, ghiChu);
        }

        // hủy lịch
        public bool xoaDatSan(int maSan, int maKhachHang, DateTime ngayDat, TimeSpan gioVao, TimeSpan gioRa)
        {
            return DatSanDAO.Instance.xoaDatSan(maSan, maKhachHang, ngayDat, gioVao, gioRa);
        }

        // cập nhật tình trạng đã thanh toán khi Người dùng thanh toán
        public bool capNhatDatSan_DaThanhToan(int maSan, int maKhachHang, DateTime ngayDat, TimeSpan gioVao, TimeSpan gioRa, bool tinhTrang)
        {
            return DatSanDAO.Instance.capNhatDatSan(maSan, maKhachHang, ngayDat, gioVao, gioRa, tinhTrang);
        }

        // cập nhật tình trạng chưa thanh toán khi Người dùng hủy hóa đơn
        public bool capNhatDatSan_ChuaThanhToan(int maSan, int maKhachHang, DateTime ngayDat, TimeSpan gioVao, TimeSpan gioRa, bool tinhTrang)
        {
            return DatSanDAO.Instance.capNhatDatSan(maSan, maKhachHang, ngayDat, gioVao, gioRa, tinhTrang);
        }
    }
}
