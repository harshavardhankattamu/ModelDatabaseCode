using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace interfacedemo2
{
    internal class Class5
    {
        public void Demo1()
        {
            var res = new ServiceCollection()
                .AddScoped<IMathInter, Service>()
                .BuildServiceProvider();
            var obj1 = res.GetService<IMathInter>();
            obj1.Add(10, 20);

        }
        public void Demo2()
        {
            var res = new ServiceCollection()
                .AddScoped<IMathInter, Service>()
                .AddScoped<Consumer>()
                .BuildServiceProvider();

            var obj2 = res.GetService<Consumer>();
            obj2.Show();


        }
        public void Demo3()
        {
            var res = new ServiceCollection()
                .AddKeyedScoped<IMathInter,Service>("hi")//name is given to uniquely identify 
                .AddKeyedScoped<IMathInter, NewService>("hello")
                .AddScoped<Consumer>()
                .BuildServiceProvider();

            //var obj2 = res.GetService<Consumer>();
            //obj2.Show();
            var a = res.GetKeyedService < IMathInter > ("hi");
            a.Add(10, 10);
            var b = res.GetKeyedService<IMathInter>("hello");
            b.Add(10, 10);

        }
    }
}