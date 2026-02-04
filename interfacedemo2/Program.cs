using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace interfacedemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //those methods manages lifetime of the object
            //add transient:create new object for every request
            //add scoped:each object is given for each client and the same is used for every communication
            //add singleton:creates single object for the entire application lifetime
            //where ever u use Imathinter interface create object of service class
            //var res = new ServiceCollection()
            //    .AddScoped<IMathInter,Service>().AddScoped<Consumer>()
            //    .BuildServiceProvider();
            //var obj=res.GetService<Consumer>();
            //obj.Show();
            Class5 c=new Class5();
            c.Demo3();
            //testdata t=new testdata();
            //t.Add(10, 10);
            //t.Sub(20, 10);

            //Imath1 m = new Class2();
            //m.Add(10,10);
            //Imath2 m1 = new Class2();
            //m1.Add(10, 10);


            //Database b=datamanager.GetInstance(1);
            //b.Add(10, 10);
            //Database b1 = datamanager.GetInstance(2);
            //b1.Add(10, 10);

            //IMathInter m = new Service();
            //Consumer c = new Consumer();//sending the object called as injecting
            //c.Show(m);
        }
    }
}
