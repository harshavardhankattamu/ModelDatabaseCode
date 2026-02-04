using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacedemo2
{
    internal class Consumer
    {
        //which consumes Add method
        //u need to design such a way that add mthod can
        //it should be open to use any class
        //give me add method, i dont care which class its comes from
        IMathInter obj;
        public Consumer([FromKeyedServices("hi")] IMathInter m)//m is null
        {
            obj = m;

       }
       
        public void Show()
        {
            //Need to consume add method here
            obj.Add(10, 10);
        }
    }
}
