using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CheckConfig
    {
        //Data transfer object là các class đóng gói data để chuyển giữa client - server hoặc giữa các service trong microservice.
        //Mục đích tạo ra DTO là để giảm bớt lượng info không cần thiết phải chuyển đi, và cũng tăng cường độ bảo mật.
        public static CheckConfig instance;

        public static CheckConfig Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new CheckConfig();
                }
                return instance;
            }
        }
        public int checConfig()
        {
            if (Properties.Settings.Default.Conn == string.Empty)
            {
                return 1;// Chuỗi cấu hình không tòn tại;
            }
            SqlConnection sqlConnection = new SqlConnection(DTO.Properties.Settings.Default.Conn);
            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();
                return 0;// chuỗi kết nối hợp lệ;
            }
            catch
            {
                return 2;//Chuổi cấu hình không phù hợp;
            }
        }

        public void saveConfig(string pServer, string pUser, string pPass, string pDatabaseName)
        {
            DTO.Properties.Settings.Default.Conn = "Data Source=" + pServer + ";Initial Catalog=" + pDatabaseName + ";User ID=" + pUser + ";Password=" + pPass + "";
            DTO.Properties.Settings.Default.Save();
        }

    }
}
