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
    public partial class InsertUpdateEmployeeForm : Form
    {
        BaseDAO baseDao = BaseDAO.getInstance();
        private string connString = BaseDAO.CnnString;
        private int id = -1;
        private int mode;

        public InsertUpdateEmployeeForm()
        {
            InitializeComponent();
            cbxIsActive.Checked = true;
            mode = 1;
        }

        public InsertUpdateEmployeeForm(int id)
        {
            InitializeComponent();
            this.id = id;
            mode = 2;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InsertUpdateEmployeeForm_Load(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void ResetValue()
        {
            switch (mode)
            {
                case 1:
                    tbxUsername.Clear();
                    tbxPassword.Clear();
                    tbxName.Clear();
                    tbxAddress.Clear();
                    tbxPhone.Clear();
                    tbxEmail.Clear();
                    cbxIsActive.Checked = true;
                    break;
                case 2:
                    DataSet dsEmployee = FindEmployeeById(id);
                    tbxId.Text = id.ToString();
                    tbxUsername.Text = dsEmployee.Tables[0].Rows[0]["Username"].ToString();
                    tbxPassword.Text = dsEmployee.Tables[0].Rows[0]["Password"].ToString();
                    tbxName.Text = dsEmployee.Tables[0].Rows[0]["Name"].ToString();
                    tbxAddress.Text = dsEmployee.Tables[0].Rows[0]["Address"].ToString();
                    tbxPhone.Text = dsEmployee.Tables[0].Rows[0]["Phone"].ToString();
                    tbxEmail.Text = dsEmployee.Tables[0].Rows[0]["Mail"].ToString();
                    cbxIsActive.Checked = Convert.ToBoolean(dsEmployee.Tables[0].Rows[0]["IsActive"].ToString());
                    dtpDOB.Value = (DateTime) dsEmployee.Tables[0].Rows[0]["Dob"];

                    break;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetValue();

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tbxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tbxPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text;
            string password = tbxPassword.Text;
            string name = tbxName.Text;
            DateTime dob = dtpDOB.Value;
            string address = tbxAddress.Text;
            string phone = tbxPhone.Text;
            string email = tbxEmail.Text;
            bool isActive = cbxIsActive.Checked;

            if (id != -1) //update
            {
                Update(id, username, password, name, dob, address, phone, email, isActive);
                MessageBox.Show("Update Successfully!");

            }
            else //insert
            {
                Insert(username, password, name, dob, address, phone, email, isActive);
                MessageBox.Show("Insert Successfully!");
            }

            this.Close();
           

        }

        private void Insert(string username, string password, string name, DateTime dob,
            string address, string phone, string email, bool isActive)
        {
            using (var cnn = new SqlConnection(connString))
            {
                cnn.Open();
                //(1): SqlConnection
                //SqlConnection cnn  = new SqlConnection(connString);

                //(2): SqlCommand
                string sqlSelect = @"INSERT INTO dbo.Account
                                    VALUES
                                    (   @username,        -- Username - varchar(100)
                                        @password,        -- Password - varchar(100)
                                        @name,       -- Name - nvarchar(100)
                                        @dob, -- Dob - date
                                        @address,        -- Address - varchar(100)
                                        @phone,        -- Phone - varchar(100)
                                        @email,        -- Mail - varchar(100)
                                        1,      -- IsActive - bit
                                        1          -- Role_id - int
                                        )";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                //setvalue
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);

                cmd.CommandText = sqlSelect;

                //execute
                cmd.ExecuteNonQuery();

            }
        }



        private void Update(int id, string username, string password, string name, DateTime dob,
          string address, string phone, string email, bool isActive)
        {
            using (var cnn = new SqlConnection(connString))
            {
                cnn.Open();
                //(1): SqlConnection
                //SqlConnection cnn  = new SqlConnection(connString);

                //(2): SqlCommand
                string sqlSelect = @"UPDATE dbo.Account SET
                                        Username = @username,
                                        Password=@password,
                                        name=@name,
                                        dob=@dob,
                                        Address=@address,
                                        Phone=@phone,
                                        Mail=@email,
                                        IsActive=@isActive
                                        WHERE Id = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                //setvalue
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@isActive", isActive);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.CommandText = sqlSelect;

                //execute
                cmd.ExecuteNonQuery();

            }
        }



        private DataSet FindEmployeeById(int id)
        {
            using (var cnn = new SqlConnection(connString))
            {

                //(1): SqlConnection
                //SqlConnection cnn  = new SqlConnection(connString);

                //(2): SqlCommand
                string sqlSelect = "SELECT * FROM dbo.Account WHERE id = @id";
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
    }
}
