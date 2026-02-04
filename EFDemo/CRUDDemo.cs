using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    internal class CRUDDemo
    {
        contactmgtdbEntities dc=new contactmgtdbEntities();
        public void ShowAllStudents()
        {
            var res = from t in dc.students
                      select t;
            foreach (var t in res)
            {
                Console.WriteLine( $"{t.studentid} {t.studentname} {t.totalmarks} {t.sclass}");
            }
        }
        public void ShowByIds()
        {
            Console.WriteLine("Enter the id");
            int id=int.Parse(Console.ReadLine());
            var res = (from t in dc.students
                      where t.studentid==id
                      select t).FirstOrDefault();
            
                Console.WriteLine($"{res.studentid} {res.studentname} {res.totalmarks} {res.sclass}");
            

        }
        public void AddStudent()
        {
            student s = new student()
            {
                studentid = int.Parse(Console.ReadLine()),
                studentname= Console.ReadLine(),
                totalmarks= int.Parse(Console.ReadLine()),
                sclass= int.Parse(Console.ReadLine())

            };
            dc.students.Add(s);
            int i=dc.SaveChanges();
            Console.WriteLine(i);

        }
        public void DeleteStudents()
        {
            Console.WriteLine("Enter the id");
            int id = int.Parse(Console.ReadLine());
            var res = (from t in dc.students
                       where t.studentid == id
                       select t).First();
            dc.students.Remove(res);
            dc.SaveChanges();

        }
        public void UpdateStudents()
        {
            Console.WriteLine("Enter the id");
            int id = int.Parse(Console.ReadLine());
            var res = (from t in dc.students
                       where t.studentid == id
                       select t).First();
            res.totalmarks = 80;
            dc.SaveChanges();


        }
    }
}
