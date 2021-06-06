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
    public partial class frmQLSanPhanVaKhoHang : Form
    {
        private bool tinhTrang = true;
        public frmQLSanPhanVaKhoHang()
        {
            InitializeComponent();
        }

        public void lamMoiDuLieu()
        {
            numericUpDownSL.Value = 0;
            ckbTinhTrang.Checked = false;
            toolStripButtonLuu.Enabled = true;
            toolStripButtonCapNhat.Enabled = false;
            foreach (Control item in groupBox1.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    item.Text = string.Empty;
                }
            }
        }

        private void frmQLSanPhanVaKhoHang_Load(object sender, EventArgs e)
        {
            ckbTinhTrang.Checked = true;
            ThucUongBUS.Instance.loadThucUong_GridControl(gridContrrolThucUong, tinhTrang);
        }

        private void ckbTinhTrang_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTinhTrang.Checked == true)
            {
                tinhTrang = true;
                ckbTinhTrang.Text = "Còn hàng";
            }
            else
            {
                tinhTrang = false;
                ckbTinhTrang.Text = "Hết hàng";
            }
            ThucUongBUS.Instance.loadThucUong_GridControl(gridContrrolThucUong, tinhTrang);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtTenThucUong.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn4).ToString();
            cboDonViTinh.Text = (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn5).ToString());
            numericUpDownSL.Value = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn6).ToString());
            txtDonGia.Text = string.Format("{0:0,0} vnđ", double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn7).ToString()));
            ckbTinhTrang.Checked = bool.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn8).ToString());
            toolStripButtonCapNhat.Enabled = true;
            toolStripButtonLuu.Enabled = false;
        }

        private void toolStripButtonLamMoi_Click(object sender, EventArgs e)
        {
            lamMoiDuLieu();
        }


        private void btnThemPhieuNhap_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaThucUong_Click(object sender, EventArgs e)
        {
            int maThucUong = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn3).ToString());
            if(MessageBox.Show("Bạn có chắc muốn xóa thức uống này không?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                if(ThucUongBUS.Instance.xoaThucUong(maThucUong))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThucUongBUS.Instance.loadThucUong_GridControl(gridContrrolThucUong, tinhTrang);
                }    
            }    
        }
    }
}
