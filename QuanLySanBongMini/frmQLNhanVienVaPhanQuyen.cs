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
using DevExpress.XtraEditors;

namespace QuanLySanBongMini
{
    public partial class frmQLNhanVienVaPhanQuyen : Form
    {
        int row = -1, rowMaNDNhom = -1;
        int maNhom = 0;
        public frmQLNhanVienVaPhanQuyen()
        {
            InitializeComponent();
            maNhom = NhomNguoiDungBUS.Instance.layMaNHomNguoiDungDauTien();
        }


        private void frmQLNhanVienVaPhanQuyen_Load(object sender, EventArgs e)
        {
            // load nhóm người dùng
            NhomNguoiDungBUS.Instance.loadNhomNguoiDung(treeListNguoiDUng);
            // load nhóm người dùng lên comBoBox
            NhomNguoiDungBUS.Instance.loadDSNhomNguoiDungComboBox(cboNhomNguoiDung);
            // load tất cả người dùng
            NguoiDungBUS.Instance.loadNguoiDung(gridContrrolNguoiDung);

            // laod ds người dùng chưa có nhóm
            NguoiDungBUS.Instance.loadNguoiDungChuaCoNhom(gridControlNguoiDungChuaCoNhom);

            // load người dùng có mã nhóm đầu tiên
            NhomNguoiDungBUS.Instance.loadDSNhomNguoiDungTheoMaNhom(maNhom, gridControlNDCoNhom);

            NhomNguoiDungBUS.Instance.loadDSNhomNguoiDung_GridControl(gridControlQLNhomND);

            //DanhMucManHinhBUS.Instance.loadDanhMucManHinh(treeList2);
        }

        public void loadLaiForm()
        {
            NguoiDungBUS.Instance.loadNguoiDungChuaCoNhom(gridControlNguoiDungChuaCoNhom);
            NhomNguoiDungBUS.Instance.loadDSNhomNguoiDungTheoMaNhom(int.Parse(cboNhomNguoiDung.SelectedValue.ToString()), gridControlNDCoNhom);
            NhomNguoiDungBUS.Instance.loadNhomNguoiDung(treeListNguoiDUng);
            rowMaNDNhom = -1;
            row = -1;
        }

        private void gridView6_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            // load danh sách quyền chức năng
            try
            {
                int maNhom = int.Parse(gridViewDSNDPhanQuyen.GetRowCellValue(gridViewDSNDPhanQuyen.FocusedRowHandle, gridColumn29).ToString());
                DanhMucManHinhBUS.Instance.loadDanhSachQuyenChucNang(gridControlQuyénDmanHinh, maNhom);
            }
            catch
            {
                return;
            }
        }

        private void menutItemThem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonLamMoi_Click(object sender, EventArgs e)
        {
            txtMatKhau.ReadOnly = false;
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            if (row == -1)
            {
                XtraMessageBox.Show("Vui lòng chọn nhân viên thêm vào nhóm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (NhomNguoiDungBUS.Instance.themNguoiDungVaoNhom(row, int.Parse(cboNhomNguoiDung.SelectedValue.ToString()), ""))
                {
                    XtraMessageBox.Show("Thêm người dùng vào nhóm thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    loadLaiForm();
                }
            }
        }

        private void gridViewnguoiDungChuaCoNhom_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            row = int.Parse(gridViewnguoiDungChuaCoNhom.GetRowCellValue(gridViewnguoiDungChuaCoNhom.FocusedRowHandle, gridColumn3).ToString());
            btnRemove.Enabled = false;
            btnADD.Enabled = true;
        }

        private void cboNhomNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                NhomNguoiDungBUS.Instance.loadDSNhomNguoiDungTheoMaNhom(int.Parse(cboNhomNguoiDung.SelectedValue.ToString()), gridControlNDCoNhom);
                row = -1;
                rowMaNDNhom = -1;
            }
            catch
            {
                NhomNguoiDungBUS.Instance.loadDSNhomNguoiDungTheoMaNhom(maNhom, gridControlNDCoNhom);
            }
        }

        private void gridViewNguoiDungDaCoNhom_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            rowMaNDNhom = int.Parse(gridViewNguoiDungDaCoNhom.GetRowCellValue(gridViewNguoiDungDaCoNhom.FocusedRowHandle, gridColumn10).ToString());
            btnADD.Enabled = false;
            btnRemove.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (rowMaNDNhom == -1)
            {
                XtraMessageBox.Show("Vui lòng chọn người dùng loại khỏi nhóm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (NhomNguoiDungBUS.Instance.xoaNguoiDungRaKhoiNhom(rowMaNDNhom, int.Parse(cboNhomNguoiDung.SelectedValue.ToString())))
                {
                    XtraMessageBox.Show("Loại người dùng ra khỏi nhóm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadLaiForm();
                }

            }
        }
    }
}
