using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTA_Theater.dal
{
    class MovieDAO
    {
        BaseDAO db;
        public MovieDAO()
        {
            db = BaseDAO.getInstance();
        }

        public List<int> GetMoviesId()
        {
            List<int> movieIds = new List<int>();
            SqlConnection cnn = null;
            try
            {
                String sql = "Select id from movie";
                cnn = new SqlConnection(BaseDAO.cnnString);
                cnn.Open();

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    movieIds.Add(reader.GetInt32(0));
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

            return movieIds;
        }
    }
}
