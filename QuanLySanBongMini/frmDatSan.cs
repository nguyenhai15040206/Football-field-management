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
    public partial class frmDatSan : Form
    {
        public frmDatSan()
        {
            InitializeComponent();
            dateTimePickerNgayDat.MinDate = DateTime.Now;
        }

        private void frmDatSan_Load(object sender, EventArgs e)
        {
            KhachHangBUS.Instance.loadKhachhang_Cbo(cboKhachHang);

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
    }
}
