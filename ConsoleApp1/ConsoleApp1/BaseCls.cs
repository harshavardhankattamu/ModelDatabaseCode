using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class BaseCls
    {
        public BaseCls(int a) {
            Console.WriteLine($"Base {a}");
        }
    }
    class DerivedCls:BaseCls
    {
        public DerivedCls(int a):base(a)
        {
            Console.WriteLine($"Derived {a}");
        }
    }
}
