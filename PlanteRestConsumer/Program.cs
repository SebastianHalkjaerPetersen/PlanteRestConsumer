using System;
using System.Security.Cryptography.X509Certificates;

namespace PlanteRestConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker restWorker = new Worker();
            restWorker.Start();
            Console.ReadLine();
        }
    }
}
