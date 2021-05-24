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
        int maSan;
        public frmDatSan()
        {
            InitializeComponent();
            //dateTimePickerNgayDat.MinDate = DateTime.Now;

        }


        public void loadSanBongConTrong(TimeSpan gioVao, TimeSpan gioRa, DateTime ngayDat, FlowLayoutPanel panel)
        {
            panel.Controls.Clear();
            List<sanBong> listSanBong = SanBongDAO.Instance.loadTatCaSanBongConTrong(gioVao, gioRa, ngayDat);
            if (listSanBong.Count == 0)
            {
                return;
            }
            sanBong = new UserControlSanBong[listSanBong.Count];
            for (int i = 0; i < listSanBong.Count; i++)
            {
                sanBong[i] = new UserControlSanBong();
                sanBong[i].Top = 30 *i;

                sanBong[i].lblTenSan.Text = listSanBong[i].tenSan;
                sanBong[i].Tag = listSanBong[i].maSan.ToString();
                sanBong[i].panel1.Click += Panel1_Click;
                panel.Controls.Add(sanBong[i]);
            }
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
            numericUpDownGioThue.Value = 1;
            cboKhachHang.SelectedIndex = 0;
            dateTimePickerGioVao.Value = DateTime.Now;
            dateTimePickerGioRa.Value = DateTime.Now;
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
            if(DatSanBUS.Instance.datSan(1,1,1,dateTimePickerNgayDat.Value.Date,dateTimePickerGioVao.Value.TimeOfDay, dateTimePickerGioRa.Value.TimeOfDay,100000,50000,true,""))
            {
                MessageBox.Show("Thêm thành công!");
            }    
            else
            {
                MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại thông tin");
            }    
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
           // SanBongBUS.Instance.load(dateTimePickerGioVao.Value.TimeOfDay, dateTimePickerGioRa.Value.TimeOfDay, dateTimePickerNgayDat.Value.Date, gridControl1);
        }

        private void dockPanel2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void btnTimSan_Click(object sender, EventArgs e)
        {
            loadSanBongConTrong(dateTimePickerGioVao.Value.TimeOfDay, dateTimePickerGioRa.Value.TimeOfDay, dateTimePickerNgayDat.Value.Date, flowLayoutPanel1);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
