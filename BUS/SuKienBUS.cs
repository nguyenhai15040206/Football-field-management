using DAO;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class SuKienBUS
    {
        private static SuKienBUS instance;
        public static SuKienBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new SuKienBUS();
                }
                return instance;
            }
        }

        public bool themSuKien(string tenSuKien, DateTime ngayBatDau, int soDoiThamGia, int soBangDau,
            int soDoiVongKnockOut, int soLuongNguoiMoiDoi, int maND, double lePhiThamGia,bool tinhTrang)
        {
            return SuKienDAO.Instance.themSuKien(tenSuKien, ngayBatDau, soDoiThamGia, soBangDau,
                soDoiVongKnockOut, soLuongNguoiMoiDoi, maND, lePhiThamGia,tinhTrang);
        }

        public int soLuongCauThu_suKien(int maSuKien)
        {
            return (int)SuKienDAO.Instance.thongTinSuKien(maSuKien).soLuongNguoiMoiDoi;
        }

        public int soDoiThamGia_suKien(int maSuKien)
        {
            return (int)SuKienDAO.Instance.thongTinSuKien(maSuKien).soDoiThamGia;
        }
        public int soBangDau_suKien(int maSuKien)
        {
            return (int)SuKienDAO.Instance.thongTinSuKien(maSuKien).soBangDau;
        }
        public int soDoiTGiaKnockout_suKien(int maSuKien)
        {
            return (int)SuKienDAO.Instance.thongTinSuKien(maSuKien).soDoiVongKnockout;
        }

        public bool huySuKien(int maSuKien)
        {
            return SuKienDAO.Instance.xoaSuKien(maSuKien);
        }

        public void loadSuKien(GridControl gv)
        {
            gv.DataSource = SuKienDAO.Instance.loadTatCaSuKien();
        }


        // đội bóng
        public void loadDoiBong(GridControl gv, int maSuKien)
        {
            gv.DataSource = SuKienDAO.Instance.loadDoiBongBoiSuKien(maSuKien);
        }

        public string tenDoiBong(int maDoiBong)
        {
            return SuKienDAO.Instance.thongTinDoiBOng(maDoiBong).tenDoiBong;
        }

        public string tenNguoiDaiDien(int maDoiBong)
        {
            return SuKienDAO.Instance.thongTinDoiBOng(maDoiBong).tenNguoiDaiDien;
        }

        public string soDienThoaiNguoiDaiDien(int maDoiBong)
        {
            return SuKienDAO.Instance.thongTinDoiBOng(maDoiBong).SDTDoiDaiDien;
        }

        public void loadDoiBongBoiSuKien_Look(GridLookUpEdit lookUpEdit, int maSuKien)
        {
            lookUpEdit.Properties.DataSource = SuKienDAO.Instance.loadDoiBongBoiSuKien(maSuKien);
            lookUpEdit.Properties.ValueMember = "maDoiBong";
            lookUpEdit.Properties.DisplayMember = "tenDoiBong";
        }

        public void loadDoiBongCBB(System.Windows.Forms.ComboBox cbb, int maSuKien)
        {
            cbb.DataSource = SuKienDAO.Instance.loadDoiBongBoiSuKien(maSuKien);
            cbb.DisplayMember = "tenDoiBong";
            cbb.ValueMember = "maDoiBong";
        }

        public bool themDoiBong(int maDoiBong, int maSuKien, string tenDoiBong, string tenNguoiDD, string sdt,
            string email, string hinhDoiBong, bool tinhTrang)
        {
            return SuKienDAO.Instance.themDoiBong(maDoiBong, maSuKien, tenDoiBong, tenNguoiDD, sdt, email, hinhDoiBong, tinhTrang);
        }

        public bool capNhatDoiBong(string tenDoiBong, string tenNguoiDD, string sdt,
            string email, string hinhDoiBong, bool tinhTrang, int maDoiBong)
        {
            return SuKienDAO.Instance.capNhatDoiBong(tenDoiBong, tenNguoiDD, sdt, email, hinhDoiBong, tinhTrang, maDoiBong);
        }

        public bool xoaDoiBong(int maDoiBong)
        {
            return SuKienDAO.Instance.xoaDoiBong(maDoiBong);
        }

        public int soLuongHienTaiCuaSK(int maSuKien)
        {
            return SuKienDAO.Instance.soLuongDoiBongCuaSK(maSuKien);
        }

        // cầu thủ
        public void loadCauThu(GridControl gv,int maDoiBong, bool tinhTrang)
        {
            gv.DataSource = SuKienDAO.Instance.loadDanhSachCauThuTheoDoiBong(maDoiBong, tinhTrang);
        }

        public bool themCauThu(string hoten, string sdt, DateTime ngaySinh, string hinhMinhHoa, string cmnd, int maDoiBong)
        {
            return SuKienDAO.Instance.themCauThu(hoten,sdt,ngaySinh, hinhMinhHoa, cmnd, maDoiBong);
        }


        public bool capNhatCauThu(int maCauThu, string hoten, string sdt, DateTime ngaySinh, string hinhMinhHoa, string cmnd)
        {
            return SuKienDAO.Instance.capNhatCauThu(maCauThu, hoten, sdt, ngaySinh, hinhMinhHoa, cmnd);
        }

        public bool xoaCauThu(int maCauThu)
        {
            return SuKienDAO.Instance.xoaCauThu(maCauThu);
        }



        // bảng thi đấu
        public bool themBangThiDau(string tenBangDau, int maSuKien, bool tinhTrang)
        {
            return SuKienDAO.Instance.themBangThiDau(tenBangDau, maSuKien, tinhTrang);
        }

        public bool themChiTietBangDau(int maDoiBong, string ghiChu)
        {
            return SuKienDAO.Instance.themChiTietBangDau(maDoiBong, ghiChu);
        }



        // trọng tài
        public bool themTrongTai(string tenTrongTai, string soDienThoai, bool tinhTrang)
        {
            return SuKienBUS.Instance.themTrongTai(tenTrongTai, soDienThoai, tinhTrang);
        }

        public bool capNhatTrongTai(int maTrongTai, string tenTrongTai, string soDienThoai, bool tinhTrang)
        {
            return SuKienBUS.Instance.capNhatTrongTai(maTrongTai, tenTrongTai, soDienThoai, tinhTrang);
        }

        public bool xoaTrongTai(int maTrongTai, bool tinhTrang)
        {
            return SuKienBUS.Instance.xoaTrongTai(maTrongTai, tinhTrang);
        }


        // tại lịch đấu
        public bool themTranDau(int maSan, int maTrongTai, DateTime ngayThiDau, TimeSpan gioThiDau,
            int maDoiBong1, int maDoiBong2, int banThangDoi1, int bangThangDoi2)
        {
            return SuKienBUS.Instance.themTranDau(maSan, maTrongTai, ngayThiDau, gioThiDau, maDoiBong1, maDoiBong2, banThangDoi1, bangThangDoi2);
        }

        public bool xoaTranDau(int maTranDau)
        {
            return SuKienBUS.Instance.xoaTranDau(maTranDau);
        }

    }
}
