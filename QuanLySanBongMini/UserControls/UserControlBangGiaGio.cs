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
    public partial class UserControlBangGiaGio : UserControl
    {
        public UserControlBangGiaGio()
        {
            InitializeComponent();
        }

        private void UserControlBangGiaGio_Load(object sender, EventArgs e)
        {
            try
            {
                DonGiaGioBUS.Instance.loadDonGiaGio_NgayCNMoiNhat_Grid(gridControl3) ;
            }
            catch
            {
                return;
            }
        }
    }
}
