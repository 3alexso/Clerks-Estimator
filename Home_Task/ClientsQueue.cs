using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task
{
    public class ClientsQueue
    {
        private static Queue<Customer> queue;
        public ClientsQueue(int clientNum)//create queue with clients
        {
            queue = new Queue<Customer>();

            for (int i = 0; i < clientNum; i++)
            {
                queue.Enqueue(new Customer());
            }
        }
        public static Customer GetClientFromQueue()//remove client from queue
        {
            lock (queue)
            {
                if (queue.Count() > 0)
                {
                    return queue.Dequeue(); 
                }
                return null;
            }
        }
    }
}
