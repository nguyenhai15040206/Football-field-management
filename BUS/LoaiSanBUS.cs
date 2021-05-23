using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
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

        // load tất cả các loại sân lên Panel bằng checkBox
        //public void loadLoaiSan_ckb(Panel panel)
        //{
        //    List<LoaiSan> listLoaiSan = LoaiSanDAO.Instance.loadTaCaLoaiSan();
        //    if (listLoaiSan.Count == 0)
        //    {
        //        return;
        //    }
            
        //    int top = 10;
        //    int left = 10;
        //    for (int i=0; i < listLoaiSan.Count; i++)
        //    {
        //        CheckBox ckb = new CheckBox();
        //        ckb.Text = listLoaiSan[i].tenLoai;
        //        ckb.Name = listLoaiSan[i].maLoaiSan.ToString();
        //        ckb.Top = top;
        //        top +
        //        ckb.Left = 30;
        //        panel.Controls.Add(ckb);
        //    }

        //    int a= panel.Controls.Count;

        //} 
       
    }
}
