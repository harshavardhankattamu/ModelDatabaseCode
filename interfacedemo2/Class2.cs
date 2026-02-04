using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacedemo2
{
    interface Imath1
    {
        void Add(int a, int b);
        void Sub(int a, int b);
    }
    interface Imath2
    {
        void Add(int a, int b);
        void Mul(int a, int b);
    }
    internal class Class2 : Imath1, Imath2
    {
        void Imath1.Add(int a, int b)
        {
            Console.WriteLine(a+b);
            
        }

        void Imath2.Add(int a, int b)
        {
            Console.WriteLine(a-b);
        }

        void Imath1.Sub(int a, int b)
        {
            Console.WriteLine(a+b);
        }

        void Imath2.Mul(int a, int b)
        {
            Console.WriteLine(a*b);
        }
    }
   
}
