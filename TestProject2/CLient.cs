using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    internal class Client
    {
        IMath math;
        public Client(IMath m)
        {

            math = m;
        }
        public int AddClient(int a, int b)
        {
            return math.Add(a, b);
        }
    }
}
