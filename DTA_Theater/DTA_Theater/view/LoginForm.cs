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

namespace DTA_Theater.view
{
    public partial class LoginForm : Form
    {
        private int role_id = -1;
        BaseDAO db;
        public LoginForm()
        {
            InitializeComponent();
            db = BaseDAO.getInstance();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateField())
            {
                return;
            }

            String username = txtUsername.Text;
            String pass = txtPassword.Text;

            Login(username, pass);            
        }

        private Boolean ValidateField()
        {
            Boolean hasReport = false;
            
            if (String.IsNullOrEmpty(txtUsername.Text) )
            {
                MessageBox.Show("Username can not be empty!!!");
                txtUsername.Focus();
                hasReport = true;
            }
            if (String.IsNullOrEmpty(txtPassword.Text) && !hasReport)
            {                
                MessageBox.Show("Password can not be empty!!!");
                txtPassword.Focus();
                hasReport = true;
            }

            return hasReport;
        }

        private void Login(String username, String password)
        {
            SqlConnection cnn = null;
            try
            {
                String sql = "SELECT Role_id FROM Account WHERE Username = @username AND Password = @password";
                cnn = new SqlConnection(BaseDAO.cnnString);
                cnn.Open();

                SqlCommand command = new SqlCommand(sql, cnn);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    role_id = reader.GetInt32(0);
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

            //Check login fail or not
            if (role_id == 1)
            {
                this.Hide();

                //Replace this to perform task

                this.Close();
            }
            else if (role_id == 2)
            {
                this.Hide();

                //Replace this to perform task
                DemoAdminFormDTA form = new DemoAdminFormDTA();
                form.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed!!! Try Again");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ValidateField())
                {
                    return;
                }

                String username = txtUsername.Text;
                String pass = txtPassword.Text;

                Login(username, pass);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ValidateField())
                {
                    return;
                }

                String username = txtUsername.Text;
                String pass = txtPassword.Text;

                Login(username, pass);
            }
        }
    }
}
