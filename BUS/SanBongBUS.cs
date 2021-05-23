using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomUserControl;
using DAO;
using DevExpress.XtraGrid;
using DTO;

namespace BUS
{
    public class SanBongBUS : EventArgs
    {
        private static SanBongBUS instance;
        public UserControlSanBong []sanBong;
        public static SanBongBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new SanBongBUS();
                }
                return instance;
            }
        }
        

        // load tất cả sân bóng còn giờ
        public void load(TimeSpan gioVao,TimeSpan gioRa, DateTime ngayDat, FlowLayoutPanel panel)
        {
            panel.Controls.Clear();
            List<sanBong> listSanBong = SanBongDAO.Instance.loadTatCaSanBongConTrong(gioVao, gioRa, ngayDat);
            if(listSanBong.Count==0)
            {
                return;
            }
            sanBong = new UserControlSanBong[listSanBong.Count]; 
            for(int i =0; i < listSanBong.Count; i++)
            {
                sanBong[i] = new UserControlSanBong();
                sanBong[i].lblTenSan.Text = listSanBong[i].tenSan;
                sanBong[i].Tag = listSanBong[i].maSan;
                panel.Controls.Add(sanBong[i]);
            }    
        }
    }
}
