using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Windows.Forms;

namespace BUS
{
    public class PhanQuyenBUS
    {
        private static PhanQuyenBUS instance;

        public static PhanQuyenBUS Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new PhanQuyenBUS();
                }
                return instance;
            }
        }
        public void phanQuyen(MenuStrip menuStrip1, int maNguoiDung)
        {
            List<int> nhomND = NhomNguoiDungBUS.Instance.getMaNhomNguoiDung(maNguoiDung);

            foreach (int item in nhomND)
            {
                List<QL_PhanQuyen> dsQuyen = NhomNguoiDungDAO.Instance.getMaManHinh(item);
                for (int i = 0; i < dsQuyen.Count; i++)
                {
                    FindMenuPhanQuyen(menuStrip1.Items, dsQuyen[i].maManHinh.ToString(), (bool)dsQuyen[i].coQuyen);
                }

            }
        }

        private void FindMenuPhanQuyen(ToolStripItemCollection mnuItems, string pScreenName, bool pEnable)
        {
            foreach (ToolStripItem menu in mnuItems)
            {
                if (menu is ToolStripMenuItem && ((ToolStripMenuItem)(menu)).DropDownItems.Count > 0)
                {

                    FindMenuPhanQuyen(((ToolStripMenuItem)(menu)).DropDownItems, pScreenName, pEnable);
                    menu.Enabled = CheckAllMenuChildVisible(((ToolStripMenuItem)(menu)).DropDownItems);
                    menu.Enabled = menu.Enabled;
                }
                else if (string.Equals(pScreenName, menu.Tag))
                {
                    menu.Enabled = pEnable; menu.Enabled = pEnable;
                }
            }
        }

        private bool CheckAllMenuChildVisible(ToolStripItemCollection mnuItems)
        {
            foreach (ToolStripItem menuItem in mnuItems)
            {
                if (menuItem is ToolStripMenuItem && menuItem.Enabled)
                {
                    return true;
                }
                else if (menuItem is ToolStripSeparator)
                {
                    continue;
                }
            }
            return false;
        }
    }
}
