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
        int maNhomPhanQuyen = 0; 
        int maManHinh = 0;
        bool hoatDong = true;
        bool coQuyen = true;
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
            // load tất cả người dùng còn hoạt động
            NguoiDungBUS.Instance.loadNguoiDung_TinhTrang(gridContrrolNguoiDung, hoatDong);

            // laod ds người dùng chưa có nhóm
            NguoiDungBUS.Instance.loadNguoiDungChuaCoNhom(gridControlNguoiDungChuaCoNhom);

            // load người dùng có mã nhóm đầu tiên
            NhomNguoiDungBUS.Instance.loadDSNhomNguoiDungTheoMaNhom(maNhom, gridControlNDCoNhom);

            NhomNguoiDungBUS.Instance.loadDSNhomNguoiDung_GridControl(gridControlQLNhomND);

            DanhMucManHinhBUS.Instance.loadDanhMucManHinh(treeList2);
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
                maNhomPhanQuyen = int.Parse(gridViewDSNDPhanQuyen.GetRowCellValue(gridViewDSNDPhanQuyen.FocusedRowHandle, gridColumn29).ToString());
                DanhMucManHinhBUS.Instance.loadDanhSachQuyenChucNang(gridControlQuyenDmanHinh, maNhomPhanQuyen);
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
            txtTenDangNhap.ReadOnly = false;
            toolStripButtonLuuND.Enabled = true;
            toolStripButtonCapNhat.Enabled = false;
            foreach(Control item in panel8.Controls)
            {
                if(item.GetType() == typeof(TextBox))
                {
                    item.Text = string.Empty;
                }    
            }
            txtTenNguoiDung.Focus();
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

        private void bunifuckbHoatHong_OnChange(object sender, EventArgs e)
        {
            if(bunifuckbHoatHong.Checked== true)
            {
                hoatDong = true;
                NguoiDungBUS.Instance.loadNguoiDung_TinhTrang(gridContrrolNguoiDung, hoatDong);
                lbTinhTrang.Text = "Hoạt động";
            }    
            else
            {
                hoatDong = false;
                NguoiDungBUS.Instance.loadNguoiDung_TinhTrang(gridContrrolNguoiDung, hoatDong);
                lbTinhTrang.Text = "Không hoạt động";
            }    
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtMaNguoiDung.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnMaNguoiDung).ToString();
                txtTenDangNhap.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnTenDN).ToString();
                txtTenNguoiDung.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnTenNguoiDung).ToString();
                txtSoDienThoai.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnSoDienThoai).ToString();
                txtDiaChi.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnDiaChi).ToString();
                txtEmail.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnEmail).ToString();
                txtMatKhau.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnMatKhau).ToString();
                dateTimePickerNgayVL.Text = gridView2.GetRowCellValue(e.RowHandle, gridColumnNgayVL).ToString();
                toolStripButtonLuuND.Enabled = false;
                txtMatKhau.ReadOnly = true;
                txtTenDangNhap.ReadOnly = true;
                if (bunifuckbHoatHong.Checked==true)
                {
                    toolStripButtonCapNhat.Enabled = true;
                }    
                else
                {
                    toolStripButtonCapNhat.Enabled = false;
                }    
            }
            catch
            {
                return;
            }
        }

        private void toolStripButtonLuuND_Click(object sender, EventArgs e)
        {
            if (txtTenNguoiDung.Text.Trim().Length > 0 && txtTenDangNhap.Text.Trim().Length > 0 && txtMatKhau.Text.Trim().Length > 0 && txtDiaChi.Text.Trim().Length > 0 &&
                txtSoDienThoai.Text.Trim().Length > 0 && txtEmail.Text.Trim().Length > 0)
            {
                if (KiemTraDuLieu.kiemTraKhoanTrang(txtTenDangNhap.Text.Trim()) && KiemTraDuLieu.kiemTraKhoanTrang(txtMatKhau.Text.Trim()))
                {
                    if (KiemTraDuLieu.KtraSoDienThoai(txtSoDienThoai.Text))
                    {
                        if (KiemTraDuLieu.KtraEmail(txtEmail.Text.Trim()))
                        {
                            if (NguoiDungBUS.Instance.KiemTraTenDangNhap(txtTenDangNhap.Text.Trim())==false)
                            {
                                if (NguoiDungBUS.Instance.kiemTraSoDienThoai(txtSoDienThoai.Text.Trim()))
                                {
                                    if (NguoiDungBUS.Instance.themNguoiDung(txtTenNguoiDung.Text.Trim(), txtTenDangNhap.Text.Trim(), txtMatKhau.Text,
                                    txtDiaChi.Text, txtSoDienThoai.Text, txtEmail.Text, dateTimePickerNgayVL.Value, hoatDong))
                                    {
                                        XtraMessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        NguoiDungBUS.Instance.loadNguoiDung_TinhTrang(gridContrrolNguoiDung, hoatDong);
                                        toolStripButtonLuuND.Enabled = false;
                                    }
                                }
                                else
                                {
                                    XtraMessageBox.Show("Số điện thoại đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtSoDienThoai.Focus();
                                }    
                            }
                            else
                            {
                                XtraMessageBox.Show("Tên đăng nhập đã tồn tại vui lòng nhập tên khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtTenDangNhap.Focus();
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Nhập sai định dạng email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtEmail.Focus();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Nhập sai định dạng số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSoDienThoai.Focus();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Tên đăng nhập hoặc mật khẩu không chứa khoản trắng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDangNhap.Focus();
                }    
            }
            else
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNguoiDung.Focus();
            }
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "gridColumnXoa")
            {
                if (bunifuckbHoatHong.Checked == true)
                {
                    if (XtraMessageBox.Show("Bạn có chắc muốn xóa nhân viên này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (NguoiDungBUS.Instance.xoaNhanVien(int.Parse(gridView2.GetRowCellValue(e.RowHandle, gridColumnMaNguoiDung).ToString()), false))
                        {
                            XtraMessageBox.Show("Nhân viên không còn hoạt động!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            NguoiDungBUS.Instance.loadNguoiDung_TinhTrang(gridContrrolNguoiDung, hoatDong);
                        }    
                }
                }
            }
        }

        private void toolStripButtonCapNhat_Click(object sender, EventArgs e)
        {
            if (txtTenNguoiDung.Text.Trim().Length > 0  && txtDiaChi.Text.Trim().Length > 0 &&
                txtSoDienThoai.Text.Trim().Length > 0 && txtEmail.Text.Trim().Length > 0)
            {
                if (KiemTraDuLieu.KtraSoDienThoai(txtSoDienThoai.Text))
                {
                    if (KiemTraDuLieu.KtraEmail(txtEmail.Text.Trim()))
                    {
                        if (NguoiDungBUS.Instance.capNhatNhanVien(int.Parse(txtMaNguoiDung.Text.Trim()),txtTenNguoiDung.Text.Trim(), 
                            txtDiaChi.Text.Trim(),txtSoDienThoai.Text.Trim(),txtEmail.Text.Trim(),hoatDong))
                        {
                            XtraMessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NguoiDungBUS.Instance.loadNguoiDung_TinhTrang(gridContrrolNguoiDung, hoatDong);
                        }
                        else
                        {
                            XtraMessageBox.Show("Số điện thoại đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtSoDienThoai.Focus();
                        }    
                    }
                    else
                    {
                        XtraMessageBox.Show("Nhập sai định dạng email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmail.Focus();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Nhập sai định dạng số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoDienThoai.Focus();

                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNguoiDung.Focus();
            }
        }

        private void gridView7_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            maManHinh = int.Parse(gridView7.GetRowCellValue(e.RowHandle, gridColumnMaMnHinh).ToString());
            coQuyen = (bool.Parse(gridView7.GetRowCellValue(e.RowHandle, gridColumnCoQuyen).ToString()));
        }

        private void gridView7_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if(e.Column.Name== "gridColumnCoQuyen")
            {
                if(coQuyen==true)
                {
                    NhomNguoiDungBUS.Instance.phanQuyen(maNhomPhanQuyen, maManHinh, false);
                    DanhMucManHinhBUS.Instance.loadDanhSachQuyenChucNang(gridControlQuyenDmanHinh, maNhomPhanQuyen);
                }    
                else
                {
                    NhomNguoiDungBUS.Instance.phanQuyen(maNhomPhanQuyen, maManHinh, true);
                    DanhMucManHinhBUS.Instance.loadDanhSachQuyenChucNang(gridControlQuyenDmanHinh, maNhomPhanQuyen);
                }    

                
            }    
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
