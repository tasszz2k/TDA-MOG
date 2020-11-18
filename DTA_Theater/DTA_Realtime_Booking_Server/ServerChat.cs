using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace Server
{
    public partial class ServerChat : Form
    {
        List<Socket> clients;
        IPEndPoint IP;
        Socket server;

        List<String> bookings;

        public ServerChat()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            connect();
            MessageBox.Show("Server is opened");
        }

        private void ServerChat_Load(object sender, EventArgs e)
        {

        }

        private void connect()
        {
            clients = new List<Socket>();
            bookings = new List<String>();

            IP = new IPEndPoint(IPAddress.Loopback, 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            server.Bind(IP);

            Thread listener = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        server.Listen(100);

                        Socket client = server.Accept();
                        clients.Add(client);

                        Thread test = new Thread(receive);
                        test.IsBackground = true;
                        test.Start(client);
                    }
                    catch
                    {
                        IP = new IPEndPoint(IPAddress.Loopback, 9999);
                        server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                    }
                }
            });

            listener.IsBackground = true;
            listener.Start();
        }

        private void receive(Object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string message = (String)deSerialize(data);

                    String[] messageArr = message.Split(',');

                    Boolean fetchMessage = true;

                    if (messageArr[0].Equals("Fetch") && bookings.Count != 0)
                    {
                        List<String> bookedSeats = new List<string>();

                        String selectedAuditorium = messageArr[3];
                        String selectedSlot = messageArr[2];
                        String movieId = messageArr[1];

                        for (int i = 0; i < bookings.Count; i++)
                        {
                            String[] bookingMessageArr = bookings[i].Split(',');

                            if (movieId.Equals(bookingMessageArr[2]) && selectedSlot.Equals(bookingMessageArr[3]) && selectedAuditorium.Equals(bookingMessageArr[4]))
                            {
                                bookedSeats.Add(bookingMessageArr[0]);
                            }
                        }

                        if (bookedSeats.Count > 0)
                        {
                            String bookedMessage = "Fetch,";

                            for (int i = 0; i < bookedSeats.Count; i++)
                            {
                                if (i == bookedSeats.Count - 1)
                                {
                                    bookedMessage += bookedSeats[i];
                                    break;
                                }

                                bookedMessage += bookedSeats[i] + ",";
                            }

                            client.Send(serialize(bookedMessage));
                        }
                    }

                    if (messageArr[1].Equals("Selected") && bookings.IndexOf(message) < 0)
                    {
                        bookings.Add(message);
                        fetchMessage = false;
                    }
                    else if (messageArr[1].Equals("Cancelled") && bookings.IndexOf(message.Replace("Cancelled", "Selected")) >= 0)
                    {
                        bookings.Remove(message.Replace("Cancelled", "Selected"));
                        fetchMessage  = false;
                    } else if (messageArr[1].Equals("Booked"))
                    {
                        fetchMessage = false; 

                        for (int i = 1; i < messageArr.Length; i++)
                        {
                            bookings.Remove(message.Replace("Booked", "Selected"));
                        }
                    }

                    if (!fetchMessage)
                    {
                        foreach (Socket s in clients)
                        {
                            if (s != null && s != client)
                            {
                                s.Send(serialize(message));
                            }
                        }
                    }

                    listLogs.Items.Add(message);
                }
            }
            catch
            {
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

        private void btnStart_Click(object sender, EventArgs e)
        {

        }
    }
}
