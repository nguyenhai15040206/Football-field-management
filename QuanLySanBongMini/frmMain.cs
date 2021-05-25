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
        public static int maND;
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

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private Form IstActive(Type type)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == type)
                {
                    return f;
                }
            }
            return null;
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void quảnLýĐặtSânToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = IstActive(typeof(frmDatSan));
            if (form == null)
            {
                frmDatSan frm = new frmDatSan();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void quảnLýNhânViênPhânQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = IstActive(typeof(frmQLNhanVienVaPhanQuyen));
            if (form == null)
            {
                frmQLNhanVienVaPhanQuyen frm = new frmQLNhanVienVaPhanQuyen();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void quảnLýĐặtSânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = IstActive(typeof(frmQLSanBong));
            if (form == null)
            {
                frmQLSanBong frm = new frmQLSanBong();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                form.Activate();
            }
        }
    }
}
