using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Home_Task
{
    public class Clerck
    {
        private Thread takeCustomer;
        public int daily;
        private static int _total;
        public int Total
        {
            get { return _total; }
        }
        public static Clerck[] CreateClercks(int numOfClerrcks, int totalDay)
        {
            _total = totalDay;
            Clerck[] clercks = new Clerck[numOfClerrcks];
            for (int i = 0; i < numOfClerrcks; i++)
            {
                clercks[i] = new Clerck();
            }
            return clercks;
        }

        public Clerck()
        {
            this.daily = 540;
            takeCustomer = new Thread(clerckJob);
            takeCustomer.Start();
        }

        public void clerckJob()
        {
            Customer client = ClientsQueue.GetClientFromQueue();
            while ((this.daily > 0) && (client != null)) //checks if day not finished and if left any clients in queue
            {
                int clientTime = client.GetTreatTime();
                this.daily -= clientTime; //subtract time of a single queue from one clerk
                _total -= clientTime; //substract time of a single queue from all clerks
                Console.WriteLine(this.daily);
                Thread.Sleep(100);
                client = ClientsQueue.GetClientFromQueue();

            }
            takeCustomer.Join();
        }
    }
}
