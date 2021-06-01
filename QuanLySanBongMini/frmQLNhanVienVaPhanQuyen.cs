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
    public partial class frmQLNhanVienVaPhanQuyen : Form
    {
        public frmQLNhanVienVaPhanQuyen()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void buttonDesign1_Click(object sender, EventArgs e)
        {

        }

        private void frmQLNhanVienVaPhanQuyen_Load(object sender, EventArgs e)
        {
            NguoiDungBUS.Instance.loadNhomNguoiDung(treeList1);

            NguoiDungBUS.Instance.loadNguoiDung(gridContrrolNguoiDung);

            NguoiDungBUS.Instance.loadNhomNguoiDung_GridCOntrol(gridControlQLNhomND);

            NguoiDungBUS.Instance.loadNguoiDungChuaCoNhom(gridControl2);

            DanhMucManHinhBUS.Instance.loadDanhMucManHinh(treeList2);
        }

        private void gridView6_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            // load danh sách quyền chức năng
            try
            {
                int maNhom = int.Parse(gridView6.GetRowCellValue(gridView6.FocusedRowHandle, gridColumn29).ToString());
                DanhMucManHinhBUS.Instance.loadDanhSachQuyenChucNang(gridControl6, maNhom);
            }
            catch
            {
                return;
            }
        }
    }
}
