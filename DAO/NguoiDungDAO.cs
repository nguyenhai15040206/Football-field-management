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

        // load nhóm người dùng
        public List<QL_NhomNguoiDung> loadNhomNguoiDung()
        {
            var listNguoiDung = db.QL_NhomNguoiDungs.ToList();
            return listNguoiDung;

        }

        // load người dùng
        public List<NguoiDung> loadNguoiDung()
        {
            var listNguoiDung = db.NguoiDungs.ToList();
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

            return db.NguoiDungs.SingleOrDefault(m => m.tenDangNhap == tenDangNhap);
        }
    }
}
