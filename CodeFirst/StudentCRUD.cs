using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    internal class StudentCRUD
    {
        Model1 m=new Model1();
        public void ShowALL()
        {
            var res = from t in m.students
                      select t;
            foreach (var t in res)
            {
                Console.WriteLine($"{t.StudentID} {t.StudentName} {t.Dob} {t.SAddress} {t.Phone}");
            }
            
        }
        public void Testing()
        {
            try
            {
                Student s = new Student();
                s.StudentID = 100;
                s.StudentName = "Raj";
                s.Dob = DateTime.Parse("1-1-2000");
                s.SAddress = "Bangalore";
                s.Phone = "9686868A";
                var validator=new StudentValidator();
                var result=validator.Validate(s);
                m.students.Add(s);
                int i = m.SaveChanges();
                Console.WriteLine(i);
                if(!result.IsValid)
                {
                    throw new Exception(result.Errors.First().ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void AddStudent()
        {
            try
            {
                Student s = new Student();
                s.StudentID = 100;
                s.StudentName = "Raj";
                s.Dob = DateTime.Parse("1-1-2000");
                s.SAddress = "Bangalore";
                s.Phone = "9686868A";
                m.students.Add(s);
                int i = m.SaveChanges();
                Console.WriteLine(i); ;
            }
            catch (Exception ex)
            {
                var res = m.GetValidationErrors();
                foreach(var t in res)
                {
                    if(t.ValidationErrors.Count > 0)
                    {
                        foreach(var err in t.ValidationErrors)
                        {
                            Console.WriteLine(err.ErrorMessage);
                        }
                    }
                }
            }
            
        }
    }
}
