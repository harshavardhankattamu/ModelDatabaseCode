using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace delegatedemo
{
    internal class ReflectionDemo
    {
        //what is reflection??
        //is a technique which is used to 
        //access the content of assembly at runtime
        public void Demo1()
        {
            //show all methods of mathclass class
            var res = Assembly.LoadFrom("C:\\Users\\kattamudi.h\\source\\repos\\adodemo\\ClassLibrary1\\bin\\Debug\\ClassLibrary1.dll");
            var t=res.GetTypes();
            foreach(var x in t)
            {
                foreach(var y in x.GetMethods())
                {
                    Console.WriteLine(y.Name);
                }
            }

        }
    }
}
