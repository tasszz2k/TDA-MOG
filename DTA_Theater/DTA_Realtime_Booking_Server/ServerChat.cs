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

                    foreach (Socket s in clients)
                    {
                        if (s != null && s != client)
                        {
                            s.Send(serialize(message));
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
