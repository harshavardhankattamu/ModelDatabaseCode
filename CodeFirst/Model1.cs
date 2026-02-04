using System;
using System.Data.Entity;
using System.Linq;

namespace CodeFirst
{
    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CodeFirst.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public Model1()
            : base("name=Model1")
        {
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Student>().ToTable("tbl_Student");
        //    modelBuilder.Entity<Student>().HasKey(s => s.StudentID);
        //    modelBuilder.Entity<Student>().Property(s => s.StudentName)
        //        .HasColumnName("")
        //        .HasMaxLength(25)
        //        .IsRequired().HasColumnType("varchar");
        //    modelBuilder.Entity<Student>().Property(s => s.Dob)
        //        .IsRequired().HasColumnType("Date");

        //    modelBuilder.Entity<Student>().Property(s => s.Phone)
        //        .HasMaxLength(8)
        //        .IsRequired().HasColumnType("varchar");

        //    modelBuilder.Entity<Student>().Property(s => s.SAddress)
        //        .HasMaxLength(50)
        //        .IsRequired().HasColumnType("varchar");

        //}

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Student> students { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}