using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class StudentsDet
    {
        public int Studentid { get; set; }
        public string StudentName { get; set; }
        public int Marks { get; set; }
        public void GetDetails()
        {
            double percentage = (Marks/800)* 100.0;
            if(Marks<0 && Marks > 800)
            {
                Console.WriteLine("Invalid Marks");
            }
            if (percentage > 60)
            {
                Console.WriteLine("First");
            }
            else if (percentage < 60 && percentage>50)
            {
                Console.WriteLine("Second");
            }
            else
            {
                Console.WriteLine("Fail");
            }

        }
    }
}
