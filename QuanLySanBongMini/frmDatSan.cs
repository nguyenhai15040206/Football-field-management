﻿using System;
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
        }
    }
}
