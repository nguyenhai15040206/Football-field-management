using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLySanBongMini
{
    static class Program
    {
        public static frmDangNhap frm = null;
        public static frmMain mainForm = null;
        public static frmConfigDatabase frmConfigDatabase = null;
        public static frmDoiMatKhau frmDoiMatKhau = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        { 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //frm = new frmDangNhap();
            //Application.Run(frm);
            Application.Run(new frmQuanLyCauThu());
        }




    }
}
