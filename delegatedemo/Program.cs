using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace delegatedemo
{
    internal class Program
    {
        //public static bool MyLogic(int i)
        //{
        //    return i > 50;
        //}
        static void Main(string[] args)
        {


            simpledelegate s=new simpledelegate();
            
            
            //realtimeclass o = new realtimeclass();
            //int[] x = { 10, 20, 30, 40,60,70 };
            //realdel ob = null;
            ////ob=(y) => y > 50;
            //Console.WriteLine("=================");
            //o.Display(x, (y) => y > 50);
            //Console.WriteLine("=================");
            //o.Display(x, (y) => y > 50 && y<70);
            //Console.WriteLine("=================");
            //o.Display(x, (y) => y > 50 || y < 70);
            //simpledelegate s=new simpledelegate();
            //s.Show(20);
            //SerializationDemo s=new SerializationDemo();
            //s.deserializedata();
            //ReflectionDemo r=new ReflectionDemo();
            //r.Demo1();
            //asyncdemo d = new asyncdemo();


            // Task.Run(async () =>
            // {
            //     d.Method1();

            // }
            // );
            // Task.Run(() =>
            // {
            //     d.Method2();
            // }

            //);
            //d.Method4();
            //Console.Read();
            //using (gcdemo d = new gcdemo())
            //{

            //}
            

        }
    }
}
