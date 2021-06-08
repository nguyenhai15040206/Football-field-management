using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class NguoiDungDAO
    {
        private static NguoiDungDAO instance;

        public static NguoiDungDAO Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new NguoiDungDAO();
                }
                return instance;
            }
        }

        QuanLySanBongDataContext db = new QuanLySanBongDataContext();


        // load người dùng
        public List<NguoiDung> loadNguoiDung()
        {
            var listNguoiDung = db.NguoiDungs.ToList();
            return listNguoiDung;
        }

        // load người dùng theo tình trạng
        public List<NguoiDung> loadNguoiDung_TinhTrang(bool tinhTrang)
        {
            var listNguoiDung = db.NguoiDungs.Where(m=>m.hoatDong== tinhTrang).ToList();
            return listNguoiDung;
        }
        // load người dùng theo mã nhóm người dùng
        public List<NguoiDung> loadNguoiDungTheoNhom(int maNhom)
        {
            var listNguoiDung = (from nd in db.NguoiDungs
                                 join nhom in db.QL_NguoiDungNhomNguoiDungs on nd.maNguoiDung equals nhom.maNguoiDung
                                 where nhom.maNhom == maNhom
                                 select (nd)).ToList();
            return listNguoiDung;
        }


        // load người dùng chưa có trong nhóm
        public List<NguoiDung> loadNguoiDungChuaCoNhom()
        {
            var listNguoiDung = (from nd in db.NguoiDungs
                                 where
                                   !
                                     (from QL_NguoiDungNhomNguoiDung in db.QL_NguoiDungNhomNguoiDungs
                                      select new
                                      {
                                          MaNguoiDung = (int)QL_NguoiDungNhomNguoiDung.NguoiDung.maNguoiDung
                                      }).Contains(new { MaNguoiDung = nd.maNguoiDung })
                                 select nd).ToList();
            return listNguoiDung;
        }

        // check config
        public int checConfig()
        {
            return CheckConfig.Instance.checConfig();
        }


        public DataTable getDatabaseName(string server, string user, string pass)
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select name from sys.databases", "Data Source=" + server + ";Initial Catalog=master;User ID=" + user + ";Password=" + pass + "");
            adapter.Fill(table);
            return table;
        }

        public void saveConfig(string pServer, string pUser, string pPass, string pDatabaseName)
        {
            CheckConfig.Instance.saveConfig(pServer, pUser, pPass, pDatabaseName);
        }
        public NguoiDung dangNhapHeThong(string tenDangNhap, string matKhau)
        {
            var nguoiDung = db.NguoiDungs.SingleOrDefault(m => m.tenDangNhap == tenDangNhap && m.matKhau == matKhau);
            return nguoiDung;
        }

        //
        public NguoiDung ttNguoiDung(string tenDangNhap)
        {
            return db.NguoiDungs.AsEnumerable().FirstOrDefault(m => m.tenDangNhap == tenDangNhap);
        }

        // kiểm tra số điện thoại
        public NguoiDung ttNguoiDung_SoDienThoai(string soDienThoai)
        {
            return db.NguoiDungs.SingleOrDefault(m => m.soDienThoai == soDienThoai);
        }

        //đổi mật khẩu
        public bool doiMatKhau(string tenDN, string pass)
        {
            try
            {
                NguoiDung ng = db.NguoiDungs.SingleOrDefault(m => m.tenDangNhap == tenDN);
                ng.matKhau = pass;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        // thêm người dùng
        public bool themNguoiDung(string tenNguoiDung, string tenDangNhap, string matKhau, string diaChi, string soDienThoai,
            string email, DateTime ngayVaoLam, bool hoatDong)
        {
            try
            {
                NguoiDung nd = new NguoiDung();
                nd.tenNguoiDung = tenNguoiDung;
                nd.tenDangNhap = tenDangNhap;
                nd.matKhau = matKhau;
                nd.diaChi = diaChi;
                nd.soDienThoai = soDienThoai;
                nd.email = email;
                nd.ngayVaoLam = ngayVaoLam;
                nd.hoatDong = hoatDong;
                db.NguoiDungs.InsertOnSubmit(nd);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        // cập nhật nhân viên
        public bool capNhatNhanVien(int maNhanVien ,string tenNguoiDung, string diaChi, string soDienThoai,
            string email, bool hoatDong)
        {
            try
            {
                NguoiDung nd = db.NguoiDungs.SingleOrDefault(m => m.maNguoiDung == maNhanVien);
                if(nd == null)
                {
                    return false;
                }
                if (soDienThoai == nd.soDienThoai)
                {
                    nd.tenNguoiDung = tenNguoiDung;
                    nd.diaChi = diaChi;
                    nd.email = email;
                    nd.hoatDong = hoatDong;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    if (ttNguoiDung_SoDienThoai(soDienThoai) == null)
                    {
                        nd.tenNguoiDung = tenNguoiDung;
                        nd.diaChi = diaChi;
                        nd.email = email;
                        nd.soDienThoai = soDienThoai;
                        nd.hoatDong = hoatDong;
                        db.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }    
                }
            }
            catch
            {
                return false;
            }
        }




    }
}
