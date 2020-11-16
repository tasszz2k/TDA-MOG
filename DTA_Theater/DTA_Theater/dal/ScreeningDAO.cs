using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTA_Theater.dal
{
    class ScreeningDAO
    {
        BaseDAO db;
        public ScreeningDAO()
        {
            db = BaseDAO.getInstance();
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public void SchedulingScreenings(List<int> movieIdList)
        {
            MovieDAO movieDAO = new MovieDAO();
            AuditoriumDAO auditoriumDAO = new AuditoriumDAO();

            //List<int> movieIdList = movieDAO.GetMoviesId();
            List<int> auditoriumList = auditoriumDAO.GetAutoriumIds();

            
            int presetDays = 6; //Number of days to provide screening
            DateTime today = DateTime.Today; //First day in the presetDay
            int[] hoursStart = { 8, 11, 14, 19, 22 }; //Every screening starts hour is int these time slot

            int movieEndProvidedIndex = 0; //Index of the movie that will ve signed a screening in a time slot                                 

            String sql = "insert into Screening " +
                            "values " +
                            "(@movie_id, @auditorium_id, @date, @startHour)";

            SqlConnection cnn = new SqlConnection(BaseDAO.cnnString);
            cnn.Open();

            SqlCommand command = new SqlCommand(sql, cnn);

            try
            {
                //First loop is to create Screening for a day (day of Screening)
                for (int d = 1; d <= presetDays; d++)
                {
                    //Second loop is to create Screening for a timeslot(time slot of the screening)
                    for (int t = 0; t < hoursStart.Length; t++)
                    {
                        //Third loop is to create Screening for a auditorium (auditorium of the screening)
                        foreach (int auditorium_id in auditoriumList)
                        {
                            command.Parameters.AddWithValue("@movie_id", movieIdList[movieEndProvidedIndex]);

                            command.Parameters.AddWithValue("@auditorium_id", auditorium_id);
                            command.Parameters.AddWithValue("@date", today);
                            command.Parameters.AddWithValue("@startHour", hoursStart[t]);

                            command.ExecuteNonQuery();
                            command.Parameters.Clear();

                            movieEndProvidedIndex++;
                            if (movieEndProvidedIndex > movieIdList.Count - 1)
                            {
                                movieEndProvidedIndex = 0;
                            }
                        }
                    }

                    today = today.AddDays(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnn.Close();
            }

        }
    }

}
