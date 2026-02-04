using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CRUDDemo c=new CRUDDemo();
            //c.ShowAllStudents();
            //c.ShowByIds();
            //c.AddStudent();
            //c.DeleteStudents();
            //c.UpdateStudents();
            empDemo e=new empDemo();
            //e.Showemp();
            //e.ShowAll();
            //e.ShowEmpbyid();
            e.getProcedure();
        }
    }
}
