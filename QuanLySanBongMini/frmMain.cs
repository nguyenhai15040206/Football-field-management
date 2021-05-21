using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace QuanLySanBongMini
{
    public partial class frmMain : Form
    {
        private int maND;
        public delegate void sendData(string value);
        public sendData thongTinNguoiDung;
        public sendData maNguoiDung;
        public frmMain()
        {
            InitializeComponent();
            thongTinNguoiDung = new sendData(getTTNguoiDung);
            maNguoiDung = new sendData(getMaNguoiDung);
        }

        public void getTTNguoiDung(string ttNguoiDung)
        {
             this.Text = "Phần mềm quản lý đặt sân bóng đá mini - Xin chào!   "+ ttNguoiDung;
        }
        public void getMaNguoiDung(string maNguoiDung)
        {
            maND = int.Parse(maNguoiDung.Trim());
        }
        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
