using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task
{
    public class Customer
    {
        public int GetTreatTime()
        {
            Random rnd = new Random();
            return rnd.Next(30, 40);
        }
    }
}
