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
            //    Application.Run(mainForm);
            //}
             Application.Run(new frmDatSan());
        }




    }
}
