using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTA_Theater.dal
{
    class AuditoriumDAO
    {
        BaseDAO db;
        public AuditoriumDAO()
        {
            db = BaseDAO.getInstance();
        }

        public List<int> GetAutoriumIds()
        {
            List<int> idList = new List<int>();
            SqlConnection cnn = null;
            try
            {
                String sql = "Select id from [dbo].[Auditorium]";
                cnn = new SqlConnection(BaseDAO.cnnString);
                cnn.Open();

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    idList.Add(reader.GetInt32(0));
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                cnn.Close();
            }

            return idList;
        }
    }
}
