using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    interface IMath
    {
        int Add(int x, int y);
    }
    //Real service,uses database, real logic
    internal class Service : IMath
    {
        public int Add(int x, int y)
        {
            {
                int res = x + y;
                return res;
            }
        }
    }
}
