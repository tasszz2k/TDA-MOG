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
        int menuSelection = 1;
        private DataSet dsEmployee;
        private DataSet dsMovie;
        private BindingSource bs;
        public AdminForm()
        {
            InitializeComponent();
        }

        private void DemoAdminFormDTA_Load(object sender, EventArgs e)
        {
            //style dadaGridView
            //dataGridView.RowTemplate.Height = 100;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //end style dadaGridView
            //this.FormBorderStyle = FormBorderStyle.None; // Assuming this code is in a method on your form
         
            ChangeMenu(1);
            SetFontAndColors();
        }

        private void LoadPictureBox()
        {

            //create a DataGridView Image Column
            DataGridViewImageColumn dgvImage = new DataGridViewImageColumn();
            //set a header test to DataGridView Image Column
            dgvImage.HeaderText = "Thumbnail";
            dgvImage.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView.Columns.Add(dgvImage);


            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                int id = Convert.ToInt32(row.Cells[0].Value.ToString());
                string imgPath = row.Cells["Thumnail_link"].Value.ToString();
                row.Cells[7].Value = Image.FromFile("../../images/" + imgPath);
            }

            //delete img path row[6]
            dataGridView.Columns[6].Visible = false;
        }


        public void ManageMovie()
        {
            dataGridView.RowTemplate.Height = 100;
            dsMovie = GetAllMovie();
            //binding source
            bs = new BindingSource();
            bs.DataSource = dsMovie.Tables[0].DefaultView;
            bindingNavigator.BindingSource = bs;

            dataGridView.DataSource = bs;

         
            LoadPictureBox();
        } 
        public void ManageEmpoyee()
        {
            dataGridView.RowTemplate.Height = 50;

            dsEmployee = GetAllEmployee();
            //binding source
            bs = new BindingSource();
            bs.DataSource = dsEmployee.Tables[0].DefaultView;
            bindingNavigator.BindingSource = bs;

            dataGridView.DataSource = bs;


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
            dataGridView.Columns.Clear();
            switch (menuSelection)
            {
                case 1:
                    this.menuSelection = 1;
                    pnlEmployee.BackColor = Color.FromArgb(0, 133, 137);//selected
                    pnlMovie.BackColor = Color.FromArgb(51, 52, 78);
                    pnlScreening.BackColor = Color.FromArgb(51, 52, 78);
                    ManageEmpoyee();
                    lblHeader.Text = "Employee Management";
                    break;
                case 2:
                    this.menuSelection = 2;
                    pnlMovie.BackColor = Color.FromArgb(0, 133, 137);
                    pnlEmployee.BackColor = Color.FromArgb(51, 52, 78);
                    pnlScreening.BackColor = Color.FromArgb(51, 52, 78);
                    ManageMovie();
                    lblHeader.Text = "Movie Management";
                    break;
                case 3:
                    lblHeader.Text = "Screening Management";
                    this.menuSelection = 3;
                    //this.Hide();
                    pnlEmployee.BackColor = Color.FromArgb(51, 52, 78);
                    pnlMovie.BackColor = Color.FromArgb(51, 52, 78);
                    pnlScreening.BackColor = Color.FromArgb(0, 133, 137);
                    //show other form
                    ScreeningForm cl = new ScreeningForm();

                    if (cl.ShowDialog() == DialogResult.Cancel)
                    {
                        ChangeMenu(1);
                    };
                   
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

        private void dataGridView_AllowUserToAddRowsChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            ChangeMenu(3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ChangeMenu(3);
        }

        private void pnlScreening_Click(object sender, EventArgs e)
        {
            ChangeMenu(3);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            switch (menuSelection)
            {
                case 1://employee
                    InsertOrUpdateEmployee(1);
                   
                    break;

                case 2://movie
                    InsertOrUpdateMovie(1);
                    break;
            }
        }

        private void InsertOrUpdateEmployee(int mode)
        {
            switch (mode)
            {
                case 1://insert
                    //show other form
                    using (InsertUpdateEmployeeForm form = new InsertUpdateEmployeeForm())
                    {
                        if (form.ShowDialog() == DialogResult.Cancel)
                        {
                            ChangeMenu(1);
                        };
                    }
                    break;
                case 2://update
                    if (dataGridView.SelectedRows.Count > 0)
                    {

                            int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value.ToString());
                            //show other form
                            using (InsertUpdateEmployeeForm form = new InsertUpdateEmployeeForm(id))
                            {
                                if (form.ShowDialog() == DialogResult.Cancel)
                                {
                                    ChangeMenu(1);
                                };
                            }

                    }
                  

                    break;
            }
        } 
        private void InsertOrUpdateMovie(int choice)
        {
            switch (choice)
            {
                case 1://insert
                    //show other form
                    using (InsertUpdateMovieForm form = new InsertUpdateMovieForm())
                    {
                        if (form.ShowDialog() == DialogResult.Cancel)
                        {
                            ChangeMenu(2);
                        };
                    }
                    break;
                case 2://update
                    if (dataGridView.SelectedRows.Count > 0)
                    {

                        int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value.ToString());
                        //show other form
                        using (InsertUpdateMovieForm form = new InsertUpdateMovieForm(id))
                        {
                            if (form.ShowDialog() == DialogResult.Cancel)
                            {
                                ChangeMenu(2);
                            };
                        }

                    }

                    break;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            switch (menuSelection)
            {
                case 1:
                    InsertOrUpdateEmployee(2);

                    break;
                case 2:
                    InsertOrUpdateMovie(2);
                    break;
            }

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
           
        }


        private void DeleteEmployeeById(int id)
        {
            using (var cnn = new SqlConnection(connString))
            {
                cnn.Open();
                //(1): SqlConnection
                //SqlConnection cnn  = new SqlConnection(connString);

                //(2): SqlCommand
                string sqlSelect = "DELETE dbo.Account WHERE id = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandText = sqlSelect;

                cmd.ExecuteNonQuery();

            }
        }

        private void DeleteMovieById(int id)
        {
            using (var cnn = new SqlConnection(connString))
            {
                cnn.Open();
                //(1): SqlConnection
                //SqlConnection cnn  = new SqlConnection(connString);

                //(2): SqlCommand
                string sqlSelect = "DELETE dbo.Movie WHERE id = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandText = sqlSelect;

                cmd.ExecuteNonQuery();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            

            if (dataGridView.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo) ==
                    DialogResult.Yes)
                {

                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value.ToString());
                    switch (menuSelection)
                    {
                        case 1:
                            DeleteEmployeeById(id);
                            MessageBox.Show("Delete Successfully!");
                            ChangeMenu(1);

                            break;
                        case 2:
                            DeleteMovieById(id);
                            MessageBox.Show("Delete Successfully!");
                            ChangeMenu(2);
                            break;
                    }
                  
                }
               
            }
        }
    }
}
