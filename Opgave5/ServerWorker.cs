using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Opgave_1;

namespace Opgave5
{
    class ServerWorker
    {

        public void start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 4646);
            server.Start();
            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient tempsocket = socket;
                    DoClient(tempsocket);
                    socket.Close();
                });

            }



        }

        public void DoClient(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            string command1 = sr.ReadLine();
            string command2 = sr.ReadLine();
            string answer = "";

            if (command1 == "HentAlle")
            {
                answer = JsonConvert.SerializeObject(CykelList.CykelListe);
            }

            if (command1 == "Hent")
            {
                answer = JsonConvert.SerializeObject(CykelList.CykelListe[Int32.Parse(command2)]);
            }

            if (command1 == "Gem")
            {
                Cykel c = JsonConvert.DeserializeObject<Cykel>(command2);
                CykelList.Post(c);
                answer = "Det lykkedes";

            }
            Console.WriteLine(answer);
            sw.Flush();
        }
    }
}
