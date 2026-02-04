using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace delegatedemo
{
    public delegate string mydel(string x);
    internal class simpledelegate
    {
        
        //public void Even(int x)
        //{
        //    Console.WriteLine(x + "even called");
        //}
        //public void Odd(int x)
        //{
        //    Console.WriteLine(x+"odd called");
        //}
        //public void Show(int x)
        //{
        //    mydel ob = null;
        //    if (x % 2 == 0)
        //    {
        //        //ob=new mydel(Even);
        //        //ob = Even;
        //        //ob = delegate (int y)//Anonymous function
        //        //{
        //        //    Console.WriteLine(y + "even called");
        //        //};
        //        ob=(int y)=> Console.WriteLine(y + "even called");

        //    }
        //    else
        //    {
        //        ob= new mydel(Odd);
        //    }
        //    ob.Invoke(x);//invocation
        //}

      
        public string Game(string x)
        {

            return $"Hello:{x}";


        }

    }
}
