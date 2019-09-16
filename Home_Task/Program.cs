using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Home_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter num of Clients");
            int ClientNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter Max num of Clerks you can effort");
            int maxClercks = int.Parse(Console.ReadLine());
            for (int i = 1; i <= maxClercks; i++)  //checks 1 to Max clerks
            {
                Console.WriteLine("Checking for {0} Clerks", i);
                Thread.Sleep(1000);
                ClientsQueue clientqueue = new ClientsQueue(ClientNum);
                Clerck[] clercks = Clerck.CreateClercks(i, i * 540);
                Thread.Sleep(2000);
                if (clercks[0].Total > 0)
                {
                    Console.WriteLine("Calculation Finished");
                    Console.WriteLine("Number of Needed Clerks for {0} Clients is: {1}", ClientNum, i);
                    break;
                }
                if ((clercks[0].Total < 0) && (i == maxClercks))
                {
                    Console.WriteLine("Calculation Finished");
                    Console.WriteLine("You can't have enough clerks to serve all customers");
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
