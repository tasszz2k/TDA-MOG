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
using DTA_Theater.dal;

namespace DTA_Theater.view
{
    public partial class InsertUpdateMovieForm : Form
    {
        BaseDAO baseDao = BaseDAO.getInstance();
        private string connString = BaseDAO.CnnString;
        private int id = -1;
        private int mode;
        private DataSet dsMovie;


        public InsertUpdateMovieForm()
        {
            InitializeComponent();
            mode = 1;
        }
        public InsertUpdateMovieForm(int id)
        {
            InitializeComponent();
            this.id = id;
            mode = 2;
        }

        private void ResetValue()
        {
            switch (mode)
            {
                case 1:
                    tbxTitle.Clear();
                    tbxDirector.Clear();
                    tbxCast.Clear();
                    tbxDescription.Clear();
                    nudDuration.Value = 30;
                    pictureBoxThumbnail.Image = null;
                    break;
                case 2:
                    DataSet dsMovie = FindMovieById(id);
                    tbxId.Text = id.ToString();
                    tbxTitle.Text = dsMovie.Tables[0].Rows[0]["Title"].ToString();
                    tbxDirector.Text = dsMovie.Tables[0].Rows[0]["Director"].ToString();
                    tbxCast.Text = dsMovie.Tables[0].Rows[0]["Cast"].ToString();
                    tbxDescription.Text = dsMovie.Tables[0].Rows[0]["Description"].ToString();
                    nudDuration.Value = Convert.ToDecimal(dsMovie.Tables[0].Rows[0]["Duration_min"].ToString());
                    lblPath.Text = dsMovie.Tables[0].Rows[0]["Thumnail_link"].ToString();
                    pictureBoxThumbnail.Text = dsMovie.Tables[0].Rows[0]["Thumnail_link"].ToString();
                    pictureBoxThumbnail.Image = Image.FromFile("../../images/" + pictureBoxThumbnail.Text);
                    break;
            }
        }

        private DataSet FindMovieById(int id)
        {
            using (var cnn = new SqlConnection(connString))
            {

                //(1): SqlConnection
                //SqlConnection cnn  = new SqlConnection(connString);

                //(2): SqlCommand
                string sqlSelect = "SELECT * FROM dbo.Movie WHERE id = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandText = sqlSelect;

                //(3): SqlDataAdapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //(4): Init DataSet
                DataSet ds = new DataSet();
                try
                {
                    //Open connection
                    cnn.Open();
                    //fill data to ds
                    da.Fill(ds);
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    //close connection
                    cnn.Close();
                }

                return ds;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = tbxTitle.Text;
            string director = tbxDirector.Text;
            string cast = tbxCast.Text;
            string description = tbxDescription.Text;
            int duration = (int)nudDuration.Value;
            string thumbnailLink = pictureBoxThumbnail.Text;
            switch (mode)
            {
                case 1://insert
                    Insert(title,director,cast,description,duration,thumbnailLink);
                    MessageBox.Show("Insert Successfully!");
                    break;
                case 2://update
                    Update(id,title, director, cast, description, duration, thumbnailLink);
                    MessageBox.Show("Update Successfully!");

                    break;
            }

            this.Close();
        }


        private void Insert(string title, string director, string cast,
            string description, int duration, string thumbnailLink)
        {
            using (var cnn = new SqlConnection(connString))
            {
                cnn.Open();
                //(1): SqlConnection
                //SqlConnection cnn  = new SqlConnection(connString);

                //(2): SqlCommand
                string sqlSelect = @"INSERT INTO dbo.Movie
                                    VALUES
                                    (   @title, -- Title - varchar(100)
                                        @director, -- Director - varchar(100)
                                        @cast, -- Cast - varchar(1000)
                                        @description, -- Description - text
                                        @duration,  -- Duration_min - int
                                        @thumbnailLink  -- Thumnail_link - text
                                        )";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                //setvalue
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@director", director);
                cmd.Parameters.AddWithValue("@cast", cast);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@duration", duration);
                cmd.Parameters.AddWithValue("@thumbnailLink", thumbnailLink);


                cmd.CommandText = sqlSelect;

                //execute
                cmd.ExecuteNonQuery();

            }
        }



        private void Update(int id, string title, string director, string cast,
            string description, int duration, string thumbnailLink)
        {
            using (var cnn = new SqlConnection(connString))
            {
                cnn.Open();
                //(1): SqlConnection
                //SqlConnection cnn  = new SqlConnection(connString);

                //(2): SqlCommand
                string sqlSelect = @"SELECT * FROM dbo.Movie
                                    UPDATE dbo.Movie
                                    SET 
                                    Title = @title,
                                    Director=@director,
                                    Cast=@cast,
                                    Description=@description,
                                    Duration_min=@duration,
                                    Thumnail_link=@thumbnailLink
                                    WHERE Id = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                //setvalue
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@director", director);
                cmd.Parameters.AddWithValue("@cast", cast);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@duration", duration);
                cmd.Parameters.AddWithValue("@thumbnailLink", thumbnailLink);
                cmd.Parameters.AddWithValue("@id", id);


                cmd.CommandText = sqlSelect;

                //execute
                cmd.ExecuteNonQuery();

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tbxPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void InsertUpdateMovie_Load(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetValue();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChoosePictue_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBoxThumbnail.Image = new Bitmap(open.FileName);
                // image file path  
                pictureBoxThumbnail.Text = open.SafeFileName;
                lblPath.Text = pictureBoxThumbnail.Text;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
