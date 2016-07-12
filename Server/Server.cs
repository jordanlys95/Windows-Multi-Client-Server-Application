using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Server
{

    public partial class Server : Form
    {
        static int port = 10;

        static TcpListener listener = new TcpListener(port);

        public Server()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            listener.Start();
            int maxClients = 10;
            for (int i = 0; i < maxClients; i++)
            {
                Thread newThread = new Thread(new ThreadStart(Listeners));
                newThread.Start();
            }
        }

        static void Listeners()
        {
            Socket client = listener.AcceptSocket();
            if (client.Connected)
            {
                Console.WriteLine("Client: " + client.RemoteEndPoint + "connected.");
                NetworkStream stream = new NetworkStream(client);
                StreamWriter writer = new StreamWriter(stream);
                StreamReader reader = new StreamReader(stream);

                while (true)
                {
                    string request = reader.ReadLine();
                    //here the requests being sent to the server
                    switch (request)
                    {
                        
                        case "hello": //if the request sent as hello, 
                            writer.WriteLine("HELLO CLIENT"); //send back writeline
                            writer.Flush(); //send data to client
                            break;
                    }
                    //reader.Close();
                    //writer.Close();
                    //stream.Close();
                }
            }
            client.Close();
        }
    }
}
