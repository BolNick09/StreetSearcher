using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Xml.Linq;

using TcpLib;

namespace FrmSearcherServer
{
    public partial class FrmSearcherClient : Form
    {
        public FrmSearcherClient()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            TcpClient server = new TcpClient();
            //Socket nameSocket = new Socket
            //(
            //    AddressFamily.InterNetwork,
            //    SocketType.Stream,
            //    ProtocolType.IP
            //);

            Console.WriteLine("Введите IP:");
            if (!IPAddress.TryParse(tbIp.Text, out var address))
            {
                Console.WriteLine("Невалидный IP, отключение сервера");
                return;
            }
            await server.ConnectAsync(address, 2024);
            Console.WriteLine("Соединение с сервером установлено");

            string message = tbIndex.Text.Trim();
            server.SendString(message);


            string receiveText = await server.ReceiveString();
            rtbStreets.Clear();
            rtbStreets.Text = receiveText;
        }
    }
}
