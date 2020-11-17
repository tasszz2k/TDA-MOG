using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTA_Theater.dal;

namespace DTA_Theater.dal
{
    class SeatDAO
    {
        BaseDAO db;
        public SeatDAO()
        {   
            db = BaseDAO.getInstance();
        }

        public void ProvideSeats()
        {

            String[] normals = { "A", "B", "C" };
            String[] vips = { "D", "E", "F" };
            String[] deluxes = { "G", "H" };
            String[] sweets = { "J" };

            List<String[]> types = new List<string[]>();
            types.Add(normals);
            types.Add(vips);
            types.Add(deluxes);
            types.Add(sweets);

            String sql = "INSERT INTO Seat(Row_name, Number, Auditorium_id, Type_id) " +
                "VALUES (@row_name, @number, @auditorium_id, @type_id)";
            SqlConnection cnn = new SqlConnection(BaseDAO.cnnString);
            cnn.Open();

            SqlCommand command = new SqlCommand(sql, cnn);

            try
            {
                for (int auditorium_id = 1; auditorium_id <= 6; auditorium_id++)
                {
                    foreach (String[] type in types)
                    {
                        foreach (String rowName in type)
                        {
                            for (int i = 1; i <= 12; i++)
                            {
                                command.Parameters.AddWithValue("@row_name", rowName);
                                command.Parameters.AddWithValue("@number", i);
                                command.Parameters.AddWithValue("@auditorium_id", auditorium_id);

                                if (Array.IndexOf(normals, rowName) != -1)
                                {
                                    command.Parameters.AddWithValue("@type_id", 1);                                    
                                }
                                else if (Array.IndexOf(vips, rowName) != -1)
                                {
                                    command.Parameters.AddWithValue("@type_id", 2);                                    
                                }
                                else if (Array.IndexOf(deluxes, rowName) != -1)
                                {
                                    command.Parameters.AddWithValue("@type_id", 3);                                    
                                }
                                else
                                {
                                    command.Parameters.AddWithValue("@type_id", 4);                                    
                                }

                                command.ExecuteNonQuery();
                                command.Parameters.Clear();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n" + sql);
            }
            finally
            {
                cnn.Close();
            }     
        }


    }
}
