using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class ThucUongBUS
    {
        private static ThucUongBUS instance;
        public static ThucUongBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new ThucUongBUS();
                }
                return instance;
            }
        }

        // load thức uống lên ComboboxEdit
        public void loadThucUong_Cbo(ComboBox cbo)
        {
            cbo.DataSource = ThucUongDAO.Instance.loadTaCaThucUong();
            cbo.DisplayMember = "tenThucUong";
            cbo.ValueMember = "maThucUong";
        }    
    }
}
