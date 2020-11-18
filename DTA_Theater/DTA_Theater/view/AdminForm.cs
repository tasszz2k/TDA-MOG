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
    public partial class AdminForm : Form
    {
        BaseDAO baseDao = BaseDAO.getInstance();
        private string connString = BaseDAO.CnnString;
        private int menuSelection = 1;
        private DataSet dsEmployee;
        private DataSet dsMovie;
        public AdminForm()
        {
            InitializeComponent();
        }

        private void DemoAdminFormDTA_Load(object sender, EventArgs e)
        {
            //style dadaGridView
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //end style dadaGridView
            //this.FormBorderStyle = FormBorderStyle.None; // Assuming this code is in a method on your form
         
            ManageEmpoyee();
            SetFontAndColors();
        }

        public void ManageMovie()
        {
            dsMovie = GetAllMovie();
            dataGridView.DataSource = dsMovie.Tables[0];
        } 
        public void ManageEmpoyee()
        {
            dsEmployee = GetAllEmployee();
            dataGridView.DataSource = dsEmployee.Tables[0];
        }


        private void SetFontAndColors()
        {
            this.dataGridView.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            this.dataGridView.DefaultCellStyle.ForeColor = Color.DimGray;
            this.dataGridView.DefaultCellStyle.BackColor = Color.Beige;
            this.dataGridView.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            this.dataGridView.DefaultCellStyle.SelectionBackColor = Color.DimGray;
        }

        private void PopulateDataGridViewCustomer()
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMinimize_Click_1(object sender, EventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Click(object sender, EventArgs e)
        {

        }

        private void pnMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private DataSet GetAllEmployee()
        {
            using (var cnn = new SqlConnection(connString))
            {

                //(1): SqlConnection
                //SqlConnection cnn  = new SqlConnection(connString);

                //(2): SqlCommand
                string sqlSelect = @"SELECT * FROM dbo.Account WHERE Role_id=1";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
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

        private DataSet GetAllMovie()
        {
            using (var cnn = new SqlConnection(connString))
            {

                //(1): SqlConnection
                //SqlConnection cnn  = new SqlConnection(connString);

                //(2): SqlCommand
                string sqlSelect = @"SELECT * FROM dbo.Movie";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
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

        private void pnlMovie_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlMovie_Click(object sender, EventArgs e)
        {
            ChangeMenu(2);
        }

        private void pnlEmployee_Click(object sender, EventArgs e)
        {
            ChangeMenu(1);
        }


        public void ChangeMenu(int menuSelection)
        {
            switch (menuSelection)
            {
                case 1:
                    pnlEmployee.BackColor = Color.FromArgb(0, 133, 137);
                    pnlMovie.BackColor = Color.FromArgb(51, 52, 78);
                    ManageEmpoyee();
                    break;
                case 2:
                    pnlMovie.BackColor = Color.FromArgb(0, 133, 137);
                    pnlEmployee.BackColor = Color.FromArgb(51, 52, 78);
                    ManageMovie();
                    break;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            ChangeMenu(1);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ChangeMenu(2);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ChangeMenu(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ChangeMenu(2);
        }
    }
}
