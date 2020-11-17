using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTA_Theater.view
{
    public partial class EmployeeFunctionForm : Form
    {
        public EmployeeFunctionForm()
        {
            InitializeComponent();
        }

        private void btnMovie_Click(object sender, EventArgs e)
        {
            this.Hide();

            //Replace this to perform task
            Client cl = new Client();

            cl.ShowDialog();

            this.Close();
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            this.Hide();

            //Replace this to perform task
            FoodOrderForm cl = new FoodOrderForm();

            cl.ShowDialog();

            this.Close();
        }
    }
}
