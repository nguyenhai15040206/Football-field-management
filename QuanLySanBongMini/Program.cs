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
        public static int maNguoiDUng = 0;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        { 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //frmDangNhap frm = new frmDangNhap();
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    frmMain mainForm = new frmMain();
            //    mainForm.thongTinNguoiDung(frm.thongTinND);
            //    mainForm.maNguoiDung(Convert.ToString(frm.maNguoiDung));
            //    frm.Close();
            //    if (mainForm.ShowDialog() == DialogResult.OK)
            //    {
            //        frmDangNhap frmDangNhap = new frmDangNhap();
            //        mainForm.Close();
            //        Application.Run(frmDangNhap);
            //    }
            //}
             Application.Run(new frmQLNhanVienVaPhanQuyen());
        }




    }
}
