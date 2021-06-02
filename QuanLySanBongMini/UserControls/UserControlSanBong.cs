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
    public partial class UserControlSanBong : UserControl
    {


        public UserControlSanBong()
        {
            InitializeComponent();
        }


        

        private void panel1_Click(object sender, EventArgs e)
        {
            int row = int.Parse(this.Tag.ToString());
            frmDatSan.ptenSan = this.lblTenSan.Text;
            frmDatSan.pMaSan = this.Tag.ToString();
            
        }
    }
}
