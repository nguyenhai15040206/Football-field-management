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

        public NguoiDung ttNguoiDung(string tenDangNhap)
        {

            return db.NguoiDungs.SingleOrDefault(m => m.tenDangNhap == tenDangNhap);
        }
    }
}
