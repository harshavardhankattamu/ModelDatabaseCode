using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Vehicle
    {
        public virtual void Drive(int a)
        {
            Console.WriteLine($"Base {a}");
        }
    }
    public class Car:Vehicle
    {
        public override void Drive(int a)
        {
            Console.WriteLine($"Car {a}");
        }
    }
    public class Bike : Vehicle
    {
        public override void Drive(int a)
        {
            Console.WriteLine($"Bike {a}");
        }
    }
}
