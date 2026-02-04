using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace Linqdemo
{
    internal class Class3
    {
        List<Employee> employees = new List<Employee>()
{
    new Employee() {Id=1, Name="Raj", Department="IT", Salary=90000, Experience=8, ManagerId=4},
    new Employee() {Id=2, Name="Ravi", Department="IT", Salary=60000, Experience=4, ManagerId=1},
    new Employee() {Id=3, Name="Sneha", Department="HR", Salary=50000, Experience=1, ManagerId=1},
    new Employee() {Id=4, Name="Kiran", Department="Finance", Salary=100000, Experience=6, ManagerId=1},
    new Employee() {Id=5, Name="Meena", Department="IT", Salary=55000, Experience=3, ManagerId=2}
};

        List<Project> projects = new List<Project>()
{
    new Project() {ProjectId=101, ProjectName="Payroll", EmployeeId=2},
    new Project() {ProjectId=102, ProjectName="ERP", EmployeeId=1},
    new Project() {ProjectId=103, ProjectName="CRM", EmployeeId=2},
    new Project() {ProjectId=104, ProjectName="MobileApp", EmployeeId=2},
    new Project() {ProjectId=105, ProjectName="Audit", EmployeeId=4}
};



        List<Attendance> attendance = new List<Attendance>()
{
    new Attendance() {EmployeeId=1, Date=DateTime.Today.AddDays(-1), IsPresent=true},
    new Attendance() {EmployeeId=2, Date=DateTime.Today.AddDays(-1), IsPresent=false},
    new Attendance() {EmployeeId=3, Date=DateTime.Today.AddDays(-1), IsPresent=true},
    new Attendance() {EmployeeId=4, Date=DateTime.Today.AddDays(-1), IsPresent=true},
    new Attendance() {EmployeeId=5, Date=DateTime.Today.AddDays(-1), IsPresent=true}
};
            public void Module1()
        {
            //Find employees with same salary.
            //var res =from e in employees
            //        from e1 in employees
            //        where e.Salary==e1.Salary && e.Id!=e1.Id
            //        select e;
            //foreach (var e in res)
            //{
            //    Console.WriteLine($"{e.Name}{e.Department}");
            //}
            //Display employees earning above company average salary.
            //var avg =employees.Average(t=>t.Salary);
            //var res1 = employees.Where(t => t.Salary > avg);
            //Console.WriteLine(avg);
            //foreach(var e in res1)
            //{
            //    Console.WriteLine($"{e.Name}{e.Department}{e.Id}{e.Experience}");
            //}

            //more than manager
            //var res3 = from e in employees
            //           join e1 in employees
            //         on e.ManagerId equals e1.Id
            //           where e.Salary > e1.Salary
            //           select new
            //           {
            //               employee = e.Name,
            //               salary = e.Salary,
            //               manger = e1.Name,
            //               salmager=e1.Salary
            //           };
            //foreach (var e in res3)
            //{
            //    Console.Write($"{e.employee} {e.salary} {e.manger} {e.salmager}\n");
            //}
            //Top 2 department
            //var res4 = employees.GroupBy(t => t.Department).SelectMany(t => t.OrderByDescending(e => e.Salary).Take(2));
            //foreach (var e in res4)
            //{
            //    Console.Write($"{e.Id} {e.Name} {e.Department} {e.Salary}\n");
            //}

            var res5 = employees.Select(e => new
            {
                e.Name,
                e.Salary,
                SalaryLevel=e.Salary>=4 ? "Senior":e.Salary>2?"mid":"junior"
            });
            foreach (var e in res5)
            {
                Console.Write($"{e.Name} {e.Salary} {e.SalaryLevel}\n");
            }
        }

        public void Mquery1()
        {
            var res = from e in employees
                      join p in projects
                      on e.Id equals p.EmployeeId
                      select new
                      {
                          e.Name,
                          e.Salary,
                          e.Department,
                          p.ProjectId,
                          p.ProjectName
                      };
            foreach (var e in res)
            {
                Console.WriteLine($"{e.Name} {e.Salary} {e.Department} {e.ProjectId} {e.ProjectName}");
            }
        }
        public void Mquery2()
        {
            var res = from e in employees
                      join p in projects
                      on e.Id equals p.EmployeeId into dt
                      from p in dt.DefaultIfEmpty()
                      where p == null
                      select e;
            foreach (var e in res)
            {
                Console.WriteLine($"{e.Name} {e.Salary} {e.Department} {e.Id}");
            }

        }
        public void Mquery3()
        {
            var res = projects.GroupBy(t => t.EmployeeId).Select(t => new
            {
                Empo=t.Key,
                COunt=t.Count()
            });
            foreach (var e in res)
            {
                Console.WriteLine($"{e.Empo} {e.COunt}");
            }

        }
        public void Mquery4()
        {
            var res = projects.GroupBy(t => t.EmployeeId).Select(t => new
            {
                Empo = t.Key,
                COunt = t.Count()
            });
            var res1 = res.Where(t => t.COunt > 1).Select(t => new
            {
                EmpID = t.Empo
            });
            foreach (var e in res)
            {
                Console.WriteLine($"{e.Empo}");
            }

        }
        public void Mquery5()
        {
            var res = from e in employees
                      join p in projects
                      on e.Id equals p.EmployeeId
                      select new
                      {
                          e.Name,
                          e.Salary,
                          e.Department,
                          p.ProjectId,
                          p.ProjectName
                      };
            var res2 = res.GroupBy(t => t.Department).Select(t => new
            {
                depart = t.Key,
                Count = t.Count()
            });
            foreach (var e in res2)
            {
                Console.WriteLine($"{e.depart} {e.Count}");
            }


        }

       
    }
}
