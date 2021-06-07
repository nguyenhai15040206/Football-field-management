using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DevExpress.XtraEditors;
using DTO;

namespace BUS
{
    public class LoaiSanBUS
    {
        private static LoaiSanBUS instance;

        public static LoaiSanBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new LoaiSanBUS();
                }
                return instance;
            }
        }

        public void loadLoaiSam_LookUpEdit(LookUpEdit lookUpEdit)
        {
            var loaiSan = LoaiSanDAO.Instance.loadTaCaLoaiSan();
            lookUpEdit.Properties.DataSource = loaiSan;
            lookUpEdit.Properties.DisplayMember = "tenLoai";
            lookUpEdit.Properties.ValueMember = "maLoaiSan";
        }

    }
}
