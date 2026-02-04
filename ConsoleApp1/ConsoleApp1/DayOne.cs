using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class DayOne
    {
        public void Employee()
        {
            Console.WriteLine("Enter Employee Name");
            string empname = Console.ReadLine();
            Console.WriteLine("Enter Basic pay");
            int basic = int.Parse(Console.ReadLine());
            double hra = 0.15 * basic;
            double da = 0.1 * basic;
            double tax = 0.08 * basic;
            double gross = basic + hra + tax;
            Console.WriteLine("HRA " + hra);
            Console.WriteLine("DA " + da);
            Console.WriteLine("TAX " +tax);
            Console.WriteLine("Gross " + gross);
        }
       public void Sumof10Nums()
        {
            int sum = 0;
            for(int i = 0; i < 10; i++)
            {
                int b = int.Parse(Console.ReadLine());
                if (b >= 0)
                {
                    sum += b;
                    if (i == 9)
                    {
                        Console.WriteLine(sum);
                    }

                }
                else
                {
                    Console.WriteLine("User Entered Negative Number");
                    break;

                }
            }
            
        }
        public void Swapnums(int a,int b)
        {
            int t = a;
            a = b;
            b = t;
            Console.WriteLine($"{a},{b}");
        }
        public void SwapNums(int a,int b)
        {
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
            Console.WriteLine($"{a},{b}");
        }
        public void Common(int[] TeamA,int[] TeamB)
        {
            Array.Sort(TeamA);
            Array.Sort(TeamB);
            for (int i = 0; i < TeamA.Length; i++)
            {
                for (int j = 0; j < TeamB.Length; j++)
                {
                    if (TeamA[i] == TeamB[j])
                    {
                        Console.WriteLine(TeamB[j]);
                    }
                }
            }
        }
        public void ObjectsFind(Object[] myObj)
        {
            foreach(var obj in myObj)
            {
                if(obj is String s)
                Console.WriteLine(s);
            }
        }
        }
    
}
