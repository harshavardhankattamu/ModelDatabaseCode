using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adodemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Class1 c = new Class1())
            {

                //DateTime d1 = DateTime.Parse(Console.ReadLine());
                //DateTime d2 = DateTime.Parse(Console.ReadLine());

                //c.GetTransaction(d1, d2);

                //c.GetCommonRecords(5);
                //c.InsertAndFetch();
                //c.AddTwo();
                c.transcopedemo();
            }
            
            
        }
        
    }
    public static class mycls
    {
        public static bool IsEven(this int x)
        {
            return (x % 2 == 0);
        }
    }
}
