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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Socket nameSocket = new Socket
            (
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.IP
            );

            Console.WriteLine("Введите свой IP-адрес: ");
            
            if (!IPAddress.TryParse(tbIp.Text, out IPAddress address))
            {
                Console.WriteLine("IP Адрес не валиден");
                return;
            }
            IPEndPoint endPiont = new IPEndPoint(address, 2048);
            nameSocket.Connect(endPiont);

            string message = tbIndex.Text.Trim();
            byte[] sendBytes = Encoding.UTF8.GetBytes(message);
            nameSocket.Send(sendBytes);

            byte[] receiveBytes = new byte[2048];
            nameSocket.Receive(receiveBytes);

            string receiveText = Encoding.UTF8.GetString(receiveBytes).Trim();
            rtbStreets.Clear();
            rtbStreets.Text = receiveText;
        }
    }
}
