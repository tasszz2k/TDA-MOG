using DTA_Theater.dal;
using DTA_Theater.entity;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTA_Theater.view
{
    public partial class FoodOrderForm : Form
    {
        private BaseDAO db;
        List<OrderedFood> orderList;
        public FoodOrderForm()
        {
            InitializeComponent();
        }

        private void FoodOrderForm_Load(object sender, EventArgs e)
        {
            db = BaseDAO.getInstance();

            orderList = new List<OrderedFood>();
            LoadFoods();
        }

        private void RefreshOrderList()
        {

            DataTable foods = new DataTable();
            foods.Columns.Add(new DataColumn("ID"));
            foods.Columns.Add(new DataColumn("Name"));
            foods.Columns.Add(new DataColumn("Price"));
            foods.Columns.Add(new DataColumn("Quantity"));
            foods.Columns.Add(new DataColumn("Total"));

            double total = 0;

            foreach (OrderedFood food in orderList)
            {
                if (food.Quantity > 0)
                {
                    DataRow dr = foods.NewRow();
                    dr[0] = food.Id + "";
                    dr[1] = food.Name;
                    dr[2] = food.Price + "";
                    dr[3] = food.Quantity + "";
                    dr[4] = food.Quantity * food.Price + "";

                    total += food.Quantity * food.Price;

                    foods.Rows.Add(dr);
                }
            }

            gvPickeds.DataSource = foods;
            lbTotal.Text = "$" + total.ToString();
        }

        //private void RefreshDataAfterDelete()
        //{
        //    if (gvPickeds.Rows.Count <= 0)
        //    {
        //        return;
        //    }

        //    List<String> selectedNames = new List<string>();

        //    foreach (DataGridViewRow row in gvPickeds.Rows)
        //    {
        //        selectedNames.Add(row.Cells[1].Value.ToString());
        //    }

        //    foreach (OrderedFood food in orderList)
        //    {
        //        if (!selectedNames.Contains(food.Name))
        //        {
        //            food.Quantity = 0;
        //        }
        //    }
        //}

        private void LoadFoods()
        {
            DataTable foods = new DataTable();
            foods.Columns.Add(new DataColumn("ID"));
            foods.Columns.Add(new DataColumn("Name"));

            String sql = "select Id, Name, Price from Food";
            SqlConnection connection = new SqlConnection(BaseDAO.cnnString);
            connection.Open();

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DataRow dr = foods.NewRow();

                int id = reader.GetInt32(0);
                String name = reader.GetString(1);
                double price = reader.GetDouble(2);
                int quantity = 0;

                //Create for the order list
                OrderedFood orderedItem = new OrderedFood(id, name, price, quantity);
                //Create a row
                dr[0] = id + "";
                dr[1] = name + "";

                orderList.Add(orderedItem);
                foods.Rows.Add(dr);
            }

            gvFoods.DataSource = foods;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text) || nudQuantity.Value < 1)
            {
                MessageBox.Show("Please check if you have pick and food!!!(Name, Quantity)");
                return;
            }

            String txtinTextBox = txtName.Text.Trim();

            foreach (OrderedFood picked in orderList)
            {
                String compare = picked.Name;
                if (picked.Name.Equals(txtName.Text.Trim()))
                {
                    picked.Quantity += Convert.ToInt32(nudQuantity.Value.ToString());
                    break;
                }
            }

            RefreshOrderList();
        }

        private void gvFoods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gvFoods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gvFoods.Rows[e.RowIndex];
                txtName.Text = row.Cells[1].Value.ToString();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (var row in gvPickeds.SelectedRows)
            {
                DataGridViewRow pickedRow = (DataGridViewRow)row;

                foreach (OrderedFood food in orderList)
                {
                    if (food.Name.Equals(pickedRow.Cells[1].Value.ToString()))
                    {
                        food.Quantity = 0;
                        break;
                    }
                }

                gvPickeds.Rows.Remove(pickedRow);
            }

            RefreshOrderList();
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            String bill = "";
            foreach (OrderedFood food in orderList)
            {
                if (food.Quantity > 0)
                {
                    bill += food.ToString() + "\n";
                }
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());

                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));

                        doc.Open();
                        Boolean succeed = doc.Add(new iTextSharp.text.Paragraph(bill));

                        if (succeed)
                        {
                            MessageBox.Show("Export Bill successful !!");                          
                        }
                        else
                        {
                            MessageBox.Show("Export Bill Error !!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        gvPickeds.DataSource = null;
                        lbTotal.Text = "0$";
                        orderList = new List<OrderedFood>();

                        doc.Close();
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();

            EmployeeFunctionForm form = new EmployeeFunctionForm();

            form.ShowDialog();
        }
    }
}
