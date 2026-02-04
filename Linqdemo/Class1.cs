using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using adodemo;
namespace Linqdemo
{
    internal class Class1
    {
        List<Contacts> li = new List<Contacts>() {
            new Contacts() {contacttid=100,customername="Raj",age=20,address="banglore"},
            new Contacts() {contacttid=101,customername="Vijay",age=24,address="banglore"},
            new Contacts() {contacttid=102,customername="Raj",age=27,address="chennai"},
            new Contacts() {contacttid=103,customername="Raj",age=29,address="pune"}
            };
        public void Demo1()
        {
            string[] data = { "Harsga", "india", "canada", "swiz" };
            var res = from t in data
                      where t.StartsWith("s")
                      select t;
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
        public void Demo2()
        {
            int[] data = { 10, 11, 12, 13, 14, 15, 16, 17 };
            var i = from t in data
                    where t.IsEven()
                    select t;
            foreach(var j in i)
            {
                Console.WriteLine(j);
            }
        }
        public void Demo3()
        {
            //store 
           
            var res=from t in li
                    where t.address=="banglore"
                    select t;
            foreach (var item in res)
            {
                Console.WriteLine($"{item.contacttid} {item.customername} {item.age}{item.address}");
            }
            var res1=from t in li
                     where t.customername.StartsWith("R") && t.age>20
                     select t;
            foreach (var item in res1)
            {
                Console.WriteLine(item.contacttid);
            }
            var res2 = from t in li
                       where t.contacttid>100 
                       select t;
            foreach (var item in res2)
            {
                Console.WriteLine(item.contacttid);
            }
            var res3 = from t in li
                       where (t.contacttid>200 && t.contacttid < 400)// t is * in SQL
                       select t;
            foreach (var item in res3)
            {
                Console.WriteLine(item.contacttid);
            }
        }
        public void Demo4()
        {
            //how to filter the columns + how tomuse alias for columns
            var res = from t in li
                      select new { contactid = t.contacttid, contactname = t.customername };
            foreach(var item in res)
            {
                Console.WriteLine(item.contactid);
            }

        }
        public void Demo5()
        {
            int[] num1 = {1,2,3,4,5};
            int[] num2 = { 2, 3, 6, 8 };
            var res=from t in num2
                    where num1.Contains(t)
                    select t;

        }

        public void Demo7()
        {
            //two ways to write Linq query
            //1.Query expression method
            //2.lambda expression method
            //var res = li.Where(t => t.address == "banglore");
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item.contacttid);
            //}
            //take(top)

            var res1 = li.Take(1);//print 1st row
            var res2 = li.Skip(1);
            var res3 = li.TakeWhile(t => t.age != 19);//print untill 19
            var res4=li.SkipWhile(t => t.age != 20);
            foreach (var item in res3)
            {
                Console.WriteLine(item.contacttid);
            }
            //intersect,distinct,union,except
        }
        public void Demo8()
        {
            //all,any
            var rs = li.TakeWhile(t => t.age > 30).Take(3).Skip(1).Take(1);
            //1.print the second highest age
            //2.print all the age.20 and order in descending order
            //3.
            var res3=li.OrderByDescending(t=>t.age).Skip(1).Take(1);
            foreach (var item in res3)
            {
                Console.WriteLine(item.contacttid);
            }
            var res=li.Where(t => t.age > 20).OrderByDescending(t => t.age);
            foreach (var item in res)
            {
                Console.WriteLine(item.contacttid);
            }
            var res4=li.Where(t=>t.address=="banglore").Count();
            Console.WriteLine(res4);
            var res6 = li.Where(t => t.customername.EndsWith("y")).Select(t => new { t.contacttid, t.customername });
            foreach (var item in res6)
            {
                Console.WriteLine($"{item.contacttid} {item.customername}");
            }
        }
    }               
}
