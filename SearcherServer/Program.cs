using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace SearcherServer
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            List<StreetIndex> streetIndices = new List<StreetIndex>();
            streetIndices = ParseFromFile("streets.txt");
            if (streetIndices.Count == 0)
            {
                Console.WriteLine("No street indices found. Server stopped.");
                return;
            }

           
            Socket listening = new Socket
            (
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.IP
            );

            Console.WriteLine("Введите свой IP-адрес: ");
            string ip = Console.ReadLine();
            if (!IPAddress.TryParse(ip, out IPAddress address))
            {
                Console.WriteLine("IP Адрес не валиден");
                return;
            }

            IPEndPoint endPiont = new IPEndPoint(address, 2048);
            listening.Bind(endPiont);
            
            listening.Listen(10);
            Console.WriteLine($"Сервер ожидает подключения по адресу {endPiont}");


            while (true)
            {
                using Socket client = listening.Accept();

                byte[] buffer = new byte[2048];
                int received = client.Receive(buffer);


                string indexStr = Encoding.UTF8.GetString(buffer, 0, received);
                int index = int.Parse(indexStr);
                List<string> streets = new List<string>();
                foreach (StreetIndex streetIndex in streetIndices)
                {
                    if (streetIndex.Index == index)
                    {
                        streets = streetIndex.GetStreets(index);
                        break;
                    }
                }
                string message = "";
                if (streets.Count != 0)                
                    message = string.Join("\n", streets); 
                else
                    message = "По данному индексу не найдено улиц";
                
                buffer = Encoding.UTF8.GetBytes(message);
                client.Send(buffer);
                client.Shutdown(SocketShutdown.Both);
            }
        }       



    private static List<StreetIndex> ParseFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File {filePath} not found.");
                return null;
            }
            List<StreetIndex> streetIndices = new List<StreetIndex>();
            string[] lines = File.ReadAllLines(filePath);

            StreetIndex currentStreetIndex = null;

            foreach (string line in lines)
            {
                if (line.StartsWith(" "))  
                    currentStreetIndex.AddStreet(line.Trim());
                
                else
                {                   
                    int index = int.Parse(line);
                    currentStreetIndex = new StreetIndex(index);
                    streetIndices.Add(currentStreetIndex);
                }
            }
            return streetIndices;
        }
    }
}
