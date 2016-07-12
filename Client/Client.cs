using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Client
{
    public partial class Client : Form
    {
        
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            int port = 10;
            TcpClient server;
            try
            {
                server = new TcpClient("localhost", port);
            }
            catch
            {
                Console.WriteLine("Failed to connect to server at {0}:999", "localhost");
                return;
            }

            NetworkStream stream = server.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);

            Console.WriteLine("Connected");

            try {
                writer.WriteLine("hello"); //send function
                writer.Flush(); //send
                //do your functions here
                label1.Text = reader.ReadLine(); //get data from server
            }
            catch
            {
                stream.Close();
                
            }
        }
    }
}
