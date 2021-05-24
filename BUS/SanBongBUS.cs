using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DevExpress.XtraGrid;
using DTO;

namespace BUS
{
    public class SanBongBUS : EventArgs
    {
        private static SanBongBUS instance;
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

    }
}
