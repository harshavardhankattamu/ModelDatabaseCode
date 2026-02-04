using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace interfacedemo2
{
    interface IMathInter
    {
        void Add(int x, int y);
    }
    //it doesn,t support object lifetime
    //a class which contains logic/program
    // a class which needs to be called through out the application
    internal class Service:IMathInter
    {
        public void Add(int x, int y)
        {
            Console.WriteLine($"service{x + y}");
        }
    }
    internal class NewService : IMathInter
    {
        public void Add(int x, int y)
        {
            Console.WriteLine(x + y);
        }
    }
}
