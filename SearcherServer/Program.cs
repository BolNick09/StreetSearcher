using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

using TcpLib;
using System.Collections.Generic;

namespace SearcherServer
{
    internal class Program
    {
        private static void Main(string[] args) => new Program().Start();
        List<StreetIndex> streetIndices;
        private void Start()
        {
            Run().Wait();
        }

        private async Task Run()
        {
            streetIndices = new List<StreetIndex>();
            string filePath = "C:\\Users\\BolNi\\source\\repos\\StreetSearcher\\streets.txt";
            streetIndices = ParseFromFile(filePath);
            if (streetIndices.Count == 0)
            {
                Console.WriteLine("Не найдено улиц, сервер отключен.");
                return;
            }

            Console.WriteLine("Введите IP:");
            if (!IPAddress.TryParse(Console.ReadLine(), out var address))
            {
                Console.WriteLine("Невалидный IP, отключение сервера");
                return;
            }
            TcpListener listening = new TcpListener(address, 2024);
            Console.WriteLine("Сервер запущен");
            listening.Start();

            while (true)
            {
                TcpClient client = await listening.AcceptTcpClientAsync();

                ListenToClient(client);
                client.Close();

            }
        }
        private async void ListenToClient(TcpClient client)
        {
            while (true)
            {
                string indexStr = await client.ReceiveString();
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
                client.SendString(message);
                
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
