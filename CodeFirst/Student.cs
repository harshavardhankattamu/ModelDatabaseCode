using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
namespace CodeFirst
{
    /*1.need different tablename
     * 2.i need different column name
     * 3.i need datatype with proper name
     * 4.i need validation
     */
    [Table("Studentstbl")]
    public class Student
    {

        public int StudentID { get; set; }

        public String StudentName { get; set; }

        public DateTime Dob { get; set; }

        public string Phone { get; set; }

        public string SAddress { get; set; }
    }
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            
            RuleFor(s => s.Dob)
                .LessThan(DateTime.Today)
                .WithMessage("Date of birth must be in the past");
            RuleFor(s => s.Phone)
                .NotEmpty()
                .WithMessage("Phone number is requried")
                .Matches("^[0-9]+$")
                .WithMessage("Invalid phone number")
                .Length(5, 8)
                .WithMessage("Invalid Length");
        }
    }
}
