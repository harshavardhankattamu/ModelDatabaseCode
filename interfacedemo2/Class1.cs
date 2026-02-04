using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacedemo2
{
    interface IData
    {
        void Add(int a, int b);
        void Sub(int a, int b);
    }
    internal class testdata : IData
    {
        public void Add(int a, int b)
        {
            Console.WriteLine(a+b);
        }

        public void Sub(int a, int b)
        {
            Console.WriteLine(a-b);
        }
    }
}
