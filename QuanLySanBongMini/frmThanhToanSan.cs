using BUS;
using DAO;
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
    public partial class frmThanhToanSan : Form
    {
        public frmThanhToanSan()
        {
            InitializeComponent();
        }

        private void frmThanhToanSan_Load(object sender, EventArgs e)
        {


            // load danh sách thức uống lên treeList
            ThucUongBUS.Instance.loadThucUong_TreeList(treeListThucUong);

            cbbThucUong.DataSource = ThucUongDAO.Instance.loadTaCaThucUong();
            cbbThucUong.DisplayMember = "TenThucUong";
            cbbThucUong.ValueMember = "maThucUong";

            // load đơn giá giờ lên treeList
            //DonGiaGioBUS.Instance.loadDonGiaGio_TreeList(treeListDGG);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Columns[e.RowIndex].Name == "btnXoaThucUong")
            {
                if(MessageBox.Show("Bạn có chắc muốn xóa thức uống này không?","Thông báo xóa!",MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                {

                }    
            }    
        }
    }
}
