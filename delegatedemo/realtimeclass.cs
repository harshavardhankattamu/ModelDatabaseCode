using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegatedemo
{
    public delegate bool realdel(int x);
    internal class realtimeclass
    {
       
        public void Display(int[] data,realdel d)
        {
            foreach (var item in data)
            {
                if (d.Invoke(item))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
