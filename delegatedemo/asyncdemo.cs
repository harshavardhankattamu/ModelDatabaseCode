using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace delegatedemo
{
    internal class asyncdemo
    {
        public void Method1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Method 1 is called" + i);
                Thread.Sleep(1000);
            }
            
        }
        public void Method2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Method 2 is called" + i);
                Thread.Sleep(1000);
            }
           
        }
        public async Task Method3()
        {
            //First task output will be the second task input
           await Task.Run(async () =>
            {
                Method1();

            }
           );
           await Task.Run(() =>
            {
                Method2();
            }

           );
        }
        public async Task Method4()
        {
            //First task output will be the second task input
            var t1=Task.Run(async () =>
            {
                int a = 5;
                int b= 5;
                int c = a + b;
                Console.WriteLine("the sum is"+c);

            }
            );
            await t1;
            
                Console.WriteLine("Task1 is completed");
            
        }
    }
}
