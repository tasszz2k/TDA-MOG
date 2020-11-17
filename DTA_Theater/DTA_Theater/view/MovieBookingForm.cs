using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTA_Theater
{
    public partial class Client : Form
    {
        private String connString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();

        Socket client;
        IPEndPoint IP;

        List<Button> seatButtons;
        List<Seat> bookingSeats;
        List<Seat> seats;
        public Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            WindowState = FormWindowState.Maximized;
            connect();
        }

        private void resetBookingInfo()
        {
            String selectedAuditorium = ((DataRowView)listAuditoriums.SelectedItem).Row[0].ToString();
            String selectedSlot = ((DataRowView)listMovieSlots.SelectedItem).Row[2].ToString();
            String movieId = ((DataRowView)listAvailableMovies.SelectedItem).Row[0].ToString();

            txtAddress.Text = "";
            txtCustomerName.Text = "";
            txtTicketPrice.Text = "";
            txtTotalAmount.Text = "";
            txtDiscount.Text = "";
            txtDOB.Text = "";
            listDiscount.DataSource = null;
            bookingSeats = new List<Seat>();

            loadBookSeats(movieId, selectedSlot, selectedAuditorium);
        }


        private void loadSeatPrices()
        {
            String sql = "SELECT * FROM Row_classification";

            SqlConnection conn = new SqlConnection(connString);

            conn.Open();

            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                String type = (String)dataReader.GetValue(1);
                Double price = (Double)dataReader.GetValue(2);

                TextBox tbx = this.Controls.Find("txt" + type, false).FirstOrDefault() as TextBox;

                tbx.Text = "$" + price;
            }

            dataReader.Close();
            command.Dispose();
        }

        private void loadAvailableMovies()
        {
            DataSet ds = new DataSet();

            String sql = "SELECT Movie.Id, Movie.Title FROM Screening RIGHT JOIN Movie ON Movie.Id = Screening.Movie_id WHERE Screening.Screening_Date = CAST(GETDATE() AS DATE) GROUP BY Movie.Id, Movie.Title";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, connString);

            adapter.Fill(ds, "Movie");

            listAvailableMovies.DataSource = ds.Tables["Movie"];
            listAvailableMovies.DisplayMember = "Title";
            listAvailableMovies.ValueMember = "Id";
        }

        private void loadSeatByAuditorium(String auditorium)
        {
            seats.Clear();
            bookingSeats.Clear();

            String sql = "SELECT Seat.Id, Row_name, Number, Row_classification.Type FROM Seat JOIN Row_classification ON Row_classification.Id = Seat.Type_id WHERE Auditorium_id = " + auditorium;

            SqlConnection conn = new SqlConnection(connString);

            conn.Open();

            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                int id = (int)dataReader.GetValue(0);
                String rowName = (String)dataReader.GetValue(1);
                int Number = (int)dataReader.GetValue(2);
                String type = (String)dataReader.GetValue(3);

                Seat s = new Seat(id, rowName + Number, type);

                seats.Add(s);
            }

            dataReader.Close();
            command.Dispose();
        }

        private void loadBookSeats(String movieId, String slot, String auditorium)
        {
            foreach (Button btn in seatButtons)
            {
                btn.BackColor = Color.Gainsboro;
                btn.Enabled = true;
            }

            String sql = "SELECT Row_name, Number FROM Seat_reservation JOIN Screening ON Seat_reservation.Screening_id = Screening.Id JOIN Seat ON Seat.Id = Seat_reservation.Seat_id " +
                "WHERE Screening.Start = " + slot + " AND Movie_id = " + movieId + " AND Screening.Auditorium_id = " + auditorium + " AND Screening.Screening_Date = CAST(GETDATE() AS DATE)";

            SqlConnection conn = new SqlConnection(connString);

            conn.Open();

            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                String row = (String)dataReader.GetValue(0);
                int number = (int)dataReader.GetValue(1);

                Button matches = (Button)tableSeats.Controls.Find(row + number, false).FirstOrDefault();

                matches.BackColor = Color.IndianRed;
                matches.Enabled = false;
            }

            dataReader.Close();
            command.Dispose();
        }

        private void loadMovieDetails(String id)
        {
            String sql = "SELECT * FROM MOvie WHERE Id = " + id;

            SqlConnection conn = new SqlConnection(connString);

            conn.Open();

            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                String title = (String)dataReader.GetValue(1);
                String desc = (String)dataReader.GetValue(4);
                int duration = (int)dataReader.GetValue(5);
                String thumbnail = (String)dataReader.GetValue(6).ToString().Replace('\\', '/');

                txtTitle.Text = title;
                txtDesc.Text = desc;
                txtDuration.Text = duration + " minutes";

                movieThumbnail.Load("../../" + thumbnail);
            }
            dataReader.Close();
            command.Dispose();
        }

        private void ChatClient_Load(object sender, EventArgs e)
        {
            seatButtons = new List<Button>() {
                A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12,
                B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12,
                C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12,
                D1, D2, D3, D4, D5, D6, D7, D8, D9, D10, D11, D12,
                E1, E2, E3, E4, E5, E6, E7, E8, E9, E10, E11, E12,
                F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12,
                G1, G2, G3, G4, G5, G6, G7, G8, G9, G10, G11, G12,
                H1, H2, H3, H4, H5, H6, H7, H8, H9, H10, H11, H12,
                J1, J2, J3, J4, J5, J6, J7, J8, J9, J10, J11, J12
            };

            seats = new List<Seat>();

            bookingSeats = new List<Seat>();

            foreach (Button seat in seatButtons)
            {
                seat.Click += new System.EventHandler(handle_Seat_Booking);
            }

            // Set up for stimulation showtime's screen
            pbScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // Set side menu height
            this.pnMenu.Height = this.Height;

            listAvailableMovies.HorizontalScrollbar = true;
            pnPlaceOrder.Enabled = false;
            pnDiscount.Enabled = false;
            // Load all available movies
            loadAvailableMovies();
            loadSeatPrices();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            List<Point> shadePoints = new List<Point>();
            shadePoints.Add(new Point(0, 0));
            shadePoints.Add(new Point(pbScreen.Width, 0));
            shadePoints.Add(new Point(pbScreen.Width - 10, 60));
            shadePoints.Add(new Point(10, 60));
            e.Graphics.FillPolygon(Brushes.DarkSlateGray, shadePoints.ToArray());
        }


        private void handle_Seat_Booking(object sender, EventArgs e)
        {
            Button bookedSeat = (Button)sender;
            int indexSeat = seatButtons.IndexOf(bookedSeat);

            String selectedAuditorium = ((DataRowView)listAuditoriums.SelectedItem).Row[0].ToString();
            String selectedSlot = ((DataRowView)listMovieSlots.SelectedItem).Row[2].ToString();
            String selectedMovie = ((DataRowView)listAvailableMovies.SelectedItem).Row[0].ToString();

            if (bookedSeat.BackColor == Color.Gainsboro)
            {
                bookedSeat.BackColor = Color.PeachPuff;
                bookingSeats.Add(seats[indexSeat]);
                client.Send(serialize(bookedSeat.Text + ",Selected," + selectedMovie + "," + selectedSlot + "," + selectedAuditorium));
            }
            else
            {
                bookedSeat.BackColor = Color.Gainsboro;
                bookingSeats.Remove(seats[indexSeat]);
                client.Send(serialize(bookedSeat.Text + ",Cancelled," + selectedMovie + "," + selectedSlot + "," + selectedAuditorium));
            }

            if (bookingSeats.Count == 0)
            {
                pnDiscount.Enabled = false;
                pnPlaceOrder.Enabled = false;
            }
            else
            {
                pnDiscount.Enabled = true;
                pnPlaceOrder.Enabled = true;
            }

            double totalAmount = 0;

            foreach (Seat seat in bookingSeats)
            {
                TextBox temp = (TextBox)this.Controls.Find("txt" + seat.Type, false).FirstOrDefault();
                totalAmount += Convert.ToDouble(temp.Text.Split('$')[1]);
            }

            txtTicketPrice.Text = "$" + totalAmount;
            txtTotalAmount.Text = txtTicketPrice.Text;
        }

        private void close()
        {
            client.Close();
        }

        private void connect()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Can't connect to server !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Thread listener = new Thread(receive);
            listener.IsBackground = true;
            listener.Start();
        }

        private void receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string message = (String)deSerialize(data);

                    if (message != null)
                    {
                        String[] messageArr = message.Split(',');
                        Button pickedSeat = this.Controls.Find(messageArr[0], true).FirstOrDefault() as Button;

                        String selectedAuditorium = ((DataRowView)listAuditoriums.SelectedItem).Row[0].ToString();
                        String selectedSlot = ((DataRowView)listMovieSlots.SelectedItem).Row[2].ToString();
                        String selectedMovie = ((DataRowView)listAvailableMovies.SelectedItem).Row[0].ToString();

                        if (messageArr[1].Equals("Selected") && selectedMovie.Equals(messageArr[2]) && selectedSlot.Equals(messageArr[3]) && selectedAuditorium.Equals(messageArr[4]))
                        {
                            pickedSeat.Enabled = false;
                            pickedSeat.BackColor = Color.PeachPuff;
                        }
                        else if (messageArr[1].Equals("Cancelled") && selectedMovie.Equals(messageArr[2]) && selectedSlot.Equals(messageArr[3]) && selectedAuditorium.Equals(messageArr[4]))
                        {
                            pickedSeat.Enabled = true;
                            pickedSeat.BackColor = Color.Gainsboro;
                        }
                        else if (messageArr[1].Equals("Cancelled") && (!selectedMovie.Equals(messageArr[2]) || !selectedSlot.Equals(messageArr[3]) || !selectedAuditorium.Equals(messageArr[4])))
                        {
                            pickedSeat.Enabled = true;
                            pickedSeat.BackColor = Color.Gainsboro;
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Close");
                close();
            }

        }

        private byte[] serialize(Object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            return stream.ToArray();
        }

        private Object deSerialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel7.ClientRectangle, Color.DeepPink, ButtonBorderStyle.Solid);
        }

        private void listAvailableMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listAvailableMovies.SelectedIndex > -1)
            {
                String selectedMovieId = ((DataRowView)listAvailableMovies.SelectedItem).Row[0].ToString();

                DataSet ds = new DataSet();

                String sql = "SELECT Screening.Id, Movie.Duration_min, Start, Title FROM Screening RIGHT JOIN Movie ON Movie.Id = Screening.Movie_id" +
                    " WHERE Screening.Screening_Date = CAST(GETDATE() AS DATE) And Movie.Id = " + selectedMovieId;

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connString);

                adapter.Fill(ds, "Slot");

                foreach (DataRow dr in ds.Tables["Slot"].Rows)
                {
                    int duration = (int)dr[1];
                    int start = (int)dr[2];

                    int hour = (int)Math.Floor((double)duration / 60);
                    int surplus = duration - hour * 60;

                    dr[3] = start + ": 00 - " + (start + hour) + ": " + surplus;
                }


                listMovieSlots.DataSource = ds.Tables["Slot"];
                listMovieSlots.DisplayMember = "Title";
                listMovieSlots.ValueMember = "Start";

                loadMovieDetails(selectedMovieId);
            }

        }

        private void listMovieSlots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listMovieSlots.SelectedIndex > -1)
            {
                String selectedSlot = ((DataRowView)listMovieSlots.SelectedItem).Row[2].ToString();
                String selectedMovieId = ((DataRowView)listAvailableMovies.SelectedItem).Row[0].ToString();
                String movieId = ((DataRowView)listAvailableMovies.SelectedItem).Row[0].ToString();

                DataSet ds = new DataSet();

                String sql = "SELECT DISTINCT Auditorium.Id, Auditorium.Name FROM Screening JOIN Auditorium " +
                    "ON Auditorium.Id = Screening.Auditorium_id  WHERE Screening.Screening_Date = CAST(GETDATE() AS DATE) And Movie_id = " + selectedMovieId + " AND Start = " + selectedSlot;

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connString);

                adapter.Fill(ds, "Auditorium");

                listAuditoriums.DataSource = ds.Tables["Auditorium"];
                listAuditoriums.DisplayMember = "Name";
                listAuditoriums.ValueMember = "Id";
            }
        }

        private void listAuditoriums_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listAuditoriums.SelectedIndex > -1)
            {
                String selectedAuditorium = ((DataRowView)listAuditoriums.SelectedItem).Row[0].ToString();
                String selectedSlot = ((DataRowView)listMovieSlots.SelectedItem).Row[2].ToString();
                String movieId = ((DataRowView)listAvailableMovies.SelectedItem).Row[0].ToString();

                foreach (Seat seat in bookingSeats)
                {
                    client.Send(serialize(seat.Name + ",Cancelled," + movieId + "," + selectedSlot + "," + selectedAuditorium));
                }

                loadBookSeats(movieId, selectedSlot, selectedAuditorium);
                loadSeatByAuditorium(selectedAuditorium);

            }
        }

        private void pnPlaceOrder_MouseClick(object sender, MouseEventArgs e)
        {
            String customerName = txtCustomerName.Text;
            String address = txtAddress.Text;
            String dob = txtDOB.Text;
            String currentYear = DateTime.Now.Year.ToString();

            int age = Convert.ToInt32(currentYear) - Convert.ToInt32(dob);

            String note = "Customer's Name: " + customerName + "\n" + "Address: " + address + "\n" + "Age: " + age + "\n" + "Booking Seats: ";

            foreach (Seat seat in bookingSeats)
            {
                note += seat.Name + "(" + seat.Type + "),";
            }

            if (!txtDiscount.Text.Equals("")) note += "\nDiscount Amount: " + txtDiscount.Text;
            note += "\n" + "Total Amount: " + txtTotalAmount.Text;

            if (MessageBox.Show("Do you want to print payment ?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {           
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());

                        try
                        {
                            PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));

                            doc.Open();
                            Boolean succeed = doc.Add(new iTextSharp.text.Paragraph(note));

                            if (succeed)
                            {
                                MessageBox.Show("Export Payment successful !!");
                            }
                            else
                            {
                                MessageBox.Show("Export Payment Error !!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            doc.Close();
                        }
                    }
                }

            }

            String selectedSlot = ((DataRowView)listMovieSlots.SelectedItem).Row[0].ToString();
            String selectedMovieId = ((DataRowView)listAvailableMovies.SelectedItem).Row[0].ToString();
            String movieId = ((DataRowView)listAvailableMovies.SelectedItem).Row[0].ToString();

            SqlConnection conn = new SqlConnection(connString);

            conn.Open();

            SqlDataAdapter dataAdpater = new SqlDataAdapter();

            foreach (Seat seat in bookingSeats)
            {
                try
                {
                    String sql = "INSERT INTO [dbo].[Seat_reservation]" +
                       "([Seat_id]" +
                       ",[Screening_id]" +
                       ",[Employee_id]" +
                       ",[Note])" +
                 "VALUES" +
                       "(@Seat_id" +
                       ",@Screening_id" +
                       ",@Employee_id" +
                       ",@Note)";

                    dataAdpater.InsertCommand = conn.CreateCommand();
                    dataAdpater.InsertCommand.CommandText = sql;

                    dataAdpater.InsertCommand.Parameters.AddWithValue("Seat_id", seat.Id);
                    dataAdpater.InsertCommand.Parameters.AddWithValue("Screening_id", selectedSlot);
                    dataAdpater.InsertCommand.Parameters.AddWithValue("Employee_id", "1");
                    dataAdpater.InsertCommand.Parameters.AddWithValue("Note", note);

                    dataAdpater.InsertCommand.ExecuteNonQuery();
                } catch (Exception ex)
                {

                }
            }

            MessageBox.Show("Booking successful !!");
            resetBookingInfo();

        }

        private void panelDiscount_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                String dob = txtDOB.Text;
                String currentYear = DateTime.Now.Year.ToString();

                int age = Convert.ToInt32(currentYear) - Convert.ToInt32(dob);

                DataSet ds = new DataSet();

                String sql = "SELECT * FROM Discount WHERE Age_approved >= " + age;

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connString);

                adapter.Fill(ds, "Discount");

                listDiscount.DataSource = ds.Tables["Discount"];
                listDiscount.DisplayMember = "Code";
            }
            catch
            {
                MessageBox.Show("You must enter year DOB as Number");
            }
        }

        private void listDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listDiscount.SelectedIndex > -1 && !txtTicketPrice.Text.Equals(""))
            {
                int discountPercent = Convert.ToInt32(((DataRowView)listDiscount.SelectedItem).Row[1].ToString());

                double totalAmount = Convert.ToDouble(txtTicketPrice.Text.Split('$')[1]);

                double moneyAfterDiscount = totalAmount * discountPercent / 100;

                txtDiscount.Text = "$" + moneyAfterDiscount.ToString("0.##") + "";
                txtTotalAmount.Text = "$" + (totalAmount - moneyAfterDiscount).ToString("0.##") + "";
            }
        }
    }
}
