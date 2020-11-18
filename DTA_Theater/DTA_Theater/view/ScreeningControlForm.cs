using DTA_Theater.dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTA_Theater
{
    public partial class ScreeningForm : Form
    {
        public ScreeningForm()
        {
            BaseDAO bd = BaseDAO.getInstance();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SeatDAO seatDAO = new SeatDAO();
            //seatDAO.ProvideSeats();

            //ScreeningDAO screeningDAO = new ScreeningDAO();
            //screeningDAO.SchedulingScreenings();
            gvScreening.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadMoviesList();
            LoadMoviesScreening();
        }
        private void LoadMoviesList()
        {
            try
            {
                String sql = "select id, title from movie";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, BaseDAO.cnnString);

                DataSet data = new DataSet();

                adapter.Fill(data, "movies");

                lbMovie.ValueMember = "id";
                lbMovie.DisplayMember = "title";
                lbMovie.DataSource = data.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadMoviesScreening()
        {
            try
            {
                String sql = "select movie.id, title , COUNT(Screening.Id) AS ScreeningNumbers " +
                        "from movie join Screening on Movie.Id = Screening.Movie_id " +
                        "GROUP BY movie.id, title";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, BaseDAO.cnnString);

                DataSet data = new DataSet();

                adapter.Fill(data, "movies");

                gvScreening.DataSource = data.Tables[0];                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnArrange_Click(object sender, EventArgs e)
        {
            CleanScreening();

            List<int> listMovieId = new List<int>();
            String test = "";

            foreach (DataRowView objDataRowView in lbMovie.SelectedItems)
            {
                listMovieId.Add(Convert.ToInt32(objDataRowView["id"]));
                test += objDataRowView["id"].ToString();
            }

            ScreeningDAO dao = new ScreeningDAO();
            dao.SchedulingScreenings(listMovieId);

            LoadMoviesScreening();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BaseDAO dao = BaseDAO.getInstance();

            String sql = "delete from Screening " +
                    "where Screening_Date< @date";
            SqlConnection cnn = null;
            DateTime today = DateTime.Today;

            try
            {
                cnn = new SqlConnection(BaseDAO.cnnString);
                cnn.Open();
                SqlCommand command = new SqlCommand(sql, cnn);
                command.Parameters.AddWithValue("@date", today);
                command.ExecuteNonQuery();

                LoadMoviesScreening();
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

        private void CleanScreening()
        {
            BaseDAO dao = BaseDAO.getInstance();

            String sql = "delete from Screening ";
            SqlConnection cnn = null;
            DateTime today = DateTime.Today;

            try
            {
                cnn = new SqlConnection(BaseDAO.cnnString);
                cnn.Open();
                SqlCommand command = new SqlCommand(sql, cnn);
                command.ExecuteNonQuery();

                LoadMoviesScreening();
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

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
   

            List<int> listMovieId = new List<int>();
            String test = "";

            foreach (DataRowView objDataRowView in lbMovie.SelectedItems)
            {
                listMovieId.Add(Convert.ToInt32(objDataRowView["id"]));
                test += objDataRowView["id"].ToString();
            }

            ScreeningDAO dao = new ScreeningDAO();
            DataSet dsScreen = dao.ViewScreenings(listMovieId);

            gvScreening.DataSource = dsScreen.Tables[0];
        }

     
            
        
    }
    
}
