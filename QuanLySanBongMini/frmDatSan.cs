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
using DAO;
using DTO;

namespace QuanLySanBongMini
{
    public partial class frmDatSan : Form
    {
        public UserControlSanBong[] sanBong;
        public static string ptenSan = string.Empty;
        public static string pMaSan = string.Empty;
        int maSan=0;
        int maKhachHang = 0;
        int maLoaiSan = 0;
        double tienSan = 0;
        // 
        double ptuKhungGio;
        double pdenKhungGio;
        double tien = 0;
        double gioDu = 0;
        public frmDatSan()
        {
            InitializeComponent();
            //dateTimePickerNgayDat.MinDate = DateTime.Now;

        }



        private void Panel1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(pMaSan))
            {
                maSan = int.Parse(pMaSan);
            }
            if(!string.IsNullOrEmpty(ptenSan))
            {
                lblChonSanBong.Text = "SÂN ĐANG CHỌN: " + ptenSan.ToUpper();
            }    
        }

        private void frmDatSan_Load(object sender, EventArgs e)
        {
            KhachHangBUS.Instance.loadKhachhang_Cbo(cboKhachHang);
            //this.userControlSanBong1.lblTenSan.Text = "Sân C1";

            //
            DatSanBUS.Instance.loadDatSan(gridContrrolDatSan);

        }

        private void toolStripButtonLamMoi_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            numericUpDownGioThue.Value = 1;
            cboKhachHang.SelectedIndex = 0;
            dateTimePickerGioVao.Value = DateTime.Now;
            dateTimePickerGioRa.Value = DateTime.Now;
            lblChonSanBong.Text = "CHƯA CHỌN SÂN BÓNG";
            foreach (Control item in groupBox1.Controls)
            {
                if(item.GetType() == typeof(TextBox))
                {
                    item.Text = string.Empty;
                }    
            }
        }

        private void toolStripButtonLuuDatSan_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text.Trim().Length > 0 && txtSoDT.Text.Trim().Length > 0 && txtTienSan.Text.Trim().Length > 0)
            {
                if (dateTimePickerGioVao.Value.AddHours(0.9).TimeOfDay > dateTimePickerGioRa.Value.TimeOfDay || dateTimePickerGioVao.Value.TimeOfDay >= dateTimePickerGioRa.Value.TimeOfDay)
                {
                    MessageBox.Show("Vui lòng chọn số lượng giờ đá");
                }
                else
                {
                    if (maKhachHang != 0)
                    {
                        if (maSan != 0)
                        {
                            if (DatSanBUS.Instance.datSan(maSan, maKhachHang, 1, dateTimePickerNgayDat.Value.Date, dateTimePickerGioVao.Value.TimeOfDay, dateTimePickerGioRa.Value.TimeOfDay, tienSan, double.Parse(txtDatCoc.Text.Trim()),  txtGhiChu.Text.Trim()))
                            {
                                MessageBox.Show("Thêm thành công!");
                                loadLaiSanBongConTrong();
                                DatSanBUS.Instance.loadDatSan(gridContrrolDatSan);
                                maKhachHang = 0;
                                maSan = 0;
                                tienSan = 0;
                            }
                            else
                            {
                                MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại thông tin");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng tìm và chọn sân bóng cần đặt!");
                        }    
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn khách hàng!");
                    }    
                }    
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin!");
            }    
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if (maLoaiSan != 0)
            {
                dateTimePickerGioRa.Value = dateTimePickerGioVao.Value.AddHours(double.Parse(numericUpDownGioThue.Value.ToString()));
                // Tham lam
                double gioVao = (double)dateTimePickerGioVao.Value.Hour + (double)((double)dateTimePickerGioVao.Value.Minute / 60);
                double soGio = (double)numericUpDownGioThue.Value;
                double gioRa = gioVao + soGio;
                List<DonGiaGio> dgg = DonGiaGioBUS.Instance.loadDonGiaGio_maLoaiSan(maLoaiSan);
                if(dgg.Count ==0)
                {
                    MessageBox.Show("Chưa cập nhập đơn giá cho loại sân này");
                    return;
                }    
                for (int i = 0; i < dgg.Count - 1; i++)
                {
                    if (gioVao >= dgg[i].tuKhungGio && gioVao < dgg[i].denKhungGio)
                    {
                        ptuKhungGio = dgg[i].tuKhungGio;
                        pdenKhungGio = dgg[i].denKhungGio;
                        if (pdenKhungGio - gioVao != soGio)
                        {
                            gioDu = soGio - (pdenKhungGio - gioVao);
                            tien += (pdenKhungGio - gioVao) * (double)dgg[i].donGia;
                            if (gioDu != 0)
                            {
                                double m = gioDu;
                                for (int j = i + 1; j < dgg.Count; j++)
                                {
                                    if (dgg[j].denKhungGio - (dgg[j - 1].denKhungGio + m) >= 0)
                                    {
                                        tien += m * (double)dgg[j].donGia;
                                        break;
                                    }
                                    else
                                    {
                                        m = (dgg[j - 1].denKhungGio + m) - dgg[j].denKhungGio;
                                        tien += (dgg[j].denKhungGio - dgg[j].tuKhungGio) * (double)dgg[j].donGia;
                                        if (m != 0)
                                        {
                                            continue;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            tien = soGio * (double)dgg[i].donGia;
                            break;
                        }
                        break;
                    }
                    continue;
                }
                if (tien == 0)
                {
                    MessageBox.Show("Giờ này chưa cập nhập đon giá! Vui lòng chọn giờ khác");
                    return;
                }
                else
                {
                    txtTienSan.Text = string.Format("{0:0,0} vnđ", Math.Round(tien, 0));
                    tienSan = tien;
                    tien = 0;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sân bóng");
            }    

        }

        private void dockPanel2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void btnTimSan_Click(object sender, EventArgs e)
        {
            
            loadLaiSanBongConTrong();
        }

        public void loadLaiSanBongConTrong()
        {
            flowLayoutPanel1.Controls.Clear();
            List<sanBong> listSanBong = SanBongDAO.Instance.loadTatCaSanBongConTrong(dateTimePickerGioVao.Value.TimeOfDay, dateTimePickerGioRa.Value.TimeOfDay, dateTimePickerNgayDat.Value.Date, maLoaiSan);
            if (listSanBong == null)
            {
                MessageBox.Show("Không có sân trống với loại sân này!");
            }
            else
            {
                sanBong = new UserControlSanBong[listSanBong.Count];
                for (int i = 0; i < listSanBong.Count; i++)
                {
                    sanBong[i] = new UserControlSanBong();
                    sanBong[i].Top = 30 * i;

                    sanBong[i].lblTenSan.Text = listSanBong[i].tenSan;
                    sanBong[i].Tag = listSanBong[i].maSan.ToString();
                    sanBong[i].panel1.Click += Panel1_Click;
                    flowLayoutPanel1.Controls.Add(sanBong[i]);
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                maKhachHang = int.Parse(cboKhachHang.SelectedValue.ToString());
                txtTenKH.Text = KhachHangBUS.Instance.hotenKhachHang(maKhachHang);
                txtSoDT.Text = KhachHangBUS.Instance.soDienThoai(maKhachHang);
            }
            catch
            {
                return;
            }
        }

        private void txtTienSan_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtDatCoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                
            }    
        }

        private void txtDatCoc_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDatCoc_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtDatCoc, "Vui lòng nhập số tiền");
        }

        private void txtDatCoc_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtDatCoc, "Vui lòng nhập số tiền");
        }



        private void ckb5Nguoi_CheckedChanged(object sender, EventArgs e)
        {
            if(ckb5Nguoi.Checked== true)
            {
                maLoaiSan = 1;
            }    
            if(ckb7Nguoi.Checked==true)
            {
                ckb7Nguoi.Checked = false;
            }  
            if(ckb11Nguoi.Checked == true)
            {
                ckb11Nguoi.Checked = false;
            }    
        }

        private void ckb7Nguoi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb7Nguoi.Checked == true)
            {
                maLoaiSan = 2;
            }
            if (ckb5Nguoi.Checked == true)
            {
                ckb5Nguoi.Checked = false;
            }
            if (ckb11Nguoi.Checked == true)
            {
                ckb11Nguoi.Checked = false;
            }
            
        }

        private void ckb11Nguoi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb11Nguoi.Checked == true)
            {
                maLoaiSan = 3;
            }
            if (ckb5Nguoi.Checked == true)
            {
                ckb5Nguoi.Checked = false;
            }
            if (ckb7Nguoi.Checked == true)
            {
                ckb7Nguoi.Checked = false;
            }
        }
    }
}
