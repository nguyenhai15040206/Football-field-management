using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySanBongMini
{
    public partial class frmGioiThieuSanBong : Form
    {
        public frmGioiThieuSanBong()
        {
            InitializeComponent();
            userControlGioiThieuSan1.Visible = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bunifuTransition2.HideSync(userControlBangGiaGio1);
            bunifuTransition1.ShowSync(userControlGioiThieuSan1);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            bunifuTransition2.HideSync(userControlGioiThieuSan1);
            bunifuTransition1.ShowSync(userControlBangGiaGio1);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
