using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    internal class empDemo
    {
        contactmgtdbEntities dc=new contactmgtdbEntities();
        public void Showemp()
        {
            
            var res = dc.Employees.ToList();
            foreach (var item in res)
            {
                Console.WriteLine($"{item.department_id} {item.employee_id}");
            }
        }
            public void ShowEmpbyid()
        {
            
            int id=int.Parse(Console.ReadLine());
            var item = dc.Employees.Find(id);
            
                Console.WriteLine($"{item.department_id} {item.employee_id} {item.employee_name}");

            

        }
        public void ShowAll()
        {
            // u need to create object of only pk table

            var res=dc.Departments.ToList();
            dc.Configuration.LazyLoadingEnabled = false;
            foreach (var item in res)
            {
                Console.WriteLine(item.department_id+":"+item.department_name);
                foreach (var item2 in item.Employees)
                {
                    Console.WriteLine(item2.employee_id);
                }
            }

            

        }
        public void getProcedure()
        {
            int id = int.Parse(Console.ReadLine());
            var res = dc.getEmpDept(id).First();
            
            
                Console.WriteLine($"{res.employee_id}");
            

        }

        public void TransactionDemo()
        {
            using(var t =dc.Database.BeginTransaction())
            {
                try
                {
                    //logic to insert goes here
                    Employee emp = new Employee()
                    {
                        employee_id=int.Parse(Console.ReadLine()),
                        employee_name=Console.ReadLine(),
                        job_title=Console.ReadLine(),
                        salary= int.Parse(Console.ReadLine()),
                        date_of_join=DateTime.Parse(Console.ReadLine()),
                        department_id=int.Parse(Console.ReadLine())
                    };
                    Department dep = new Department()
                    {
                        department_id = int.Parse(Console.ReadLine()),
                        department_name = Console.ReadLine()
                    };
                    t.Commit();
                }
                catch(Exception ex) {
                t.Rollback();
                Console.WriteLine("Could not inserted record..");
                }
            }
        }

    }
}
