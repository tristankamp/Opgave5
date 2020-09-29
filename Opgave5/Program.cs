using System;

namespace Opgave5
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerWorker server = new ServerWorker();
            server.start();
            Console.ReadLine();
        }
    }
}
