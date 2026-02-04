using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DayOne d = new DayOne();
            //d.Employee();
            //d.Sumof10Nums();
            //d.Swapnums(10, 20);
            //d.SwapNums(10, 20);
            //int[] TeamA = { 45, 78, 45, 34, 65, 89 };
            //int[] TeamB = { 78, 4, 8, 9, 65, 3, 7, 34 };
            //d.Common(TeamA, TeamB);
            //Object[] myObjects = new Object[5];
            //myObjects[0] = "hello";
            //myObjects[1] = 123;
            //myObjects[2] = 123.4;
            //myObjects[3] = null;
            //myObjects[4] ="Mphasis";
            //d.ObjectsFind(myObjects);
            /*StudentsDet s=new StudentsDet();
            var s1 = new StudentsDet
            {
                Studentid = 101,
                StudentName = "Harsha",
                Marks = 520
            };
            s1.GetDetails();*/
            //DerivedCls c = new DerivedCls(54);
            Vehicle obj = new Car();
            obj.Drive(34);
            Vehicle obj1 = new Bike();
            obj1.Drive(34);

        }
    }
}
