using BUS;
using DAO;
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
    public partial class frmThanhToanSan : Form
    {
        public frmThanhToanSan()
        {
            InitializeComponent();
        }

        private void frmThanhToanSan_Load(object sender, EventArgs e)
        {
            cbbThucUong.DataSource = ThucUongDAO.Instance.loadTaCaThucUong();
            cbbThucUong.DisplayMember = "tenThucUong";
            cbbThucUong.ValueMember = "maThucUong";
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
