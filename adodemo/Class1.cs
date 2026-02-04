using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
namespace adodemo
{
    internal class Class1:IDisposable
    {
        private SqlConnection conn;
        private string conne = "integrated security=true;server=WKSBAN36KELTR30\\SQLEXPRESS;database=contactmgtdb;multipleactiveresultsets=true";
        public Class1(){
            conn = new SqlConnection(conne);
            conn.Open();
        }
        ~Class1(){
            conn.Close();
        }
      
        
        public void showallcontact()
        {
            SqlCommand cmd = new SqlCommand("getcontacts", conn);

            SqlParameter p1 = new SqlParameter("@a", "ffgf");
            cmd.Parameters.Add(p1);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.Write($"{dr[i]} ");
                }
                Console.WriteLine();

            }

        }
        public void GetTransaction(DateTime d1,DateTime d2)
        {
            SqlCommand cmd = new SqlCommand("gettransactions", conn);
            SqlParameter p1 = new SqlParameter("@a", $"{d1}");
            SqlParameter p2 = new SqlParameter("@b", $"{d2}");
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.Write($"{dr[i]} ");
                }
                Console.WriteLine();

            }
           dr.Close();

        }

        public void GetCommonRecords(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand($"select * from employee e join department d on e.department_id=d.department_id where e.employee_id={id}", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Console.Write($"{dr[i]} ");
                    }
                    Console.WriteLine();

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            

        }
        public void InsertAndFetch()
        {
            string name=Console.ReadLine();
            string title = Console.ReadLine();
            int salary=int.Parse(Console.ReadLine());
            DateTime date = DateTime.Parse(Console.ReadLine());
            int dep=int.Parse(Console.ReadLine());
            SqlCommand comm=new SqlCommand("insertandfetch",conn);
            SqlParameter p1 = new SqlParameter("@name", $"{name}");
            SqlParameter p2 = new SqlParameter("@title", $"{title}");
            SqlParameter p3 = new SqlParameter("@salary", $"{salary}");
            SqlParameter p4 = new SqlParameter("@doj", $"{date}");
            SqlParameter p5 = new SqlParameter("@deptId", $"{dep}");
            comm.Parameters.Add(p1);
            comm.Parameters.Add(p2);
            comm.Parameters.Add(p3);
            comm.Parameters.Add(p4);
            comm.Parameters.Add(p5);
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {

                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.Write($"{dr[i]} ");
                }
                Console.WriteLine();

            }
            dr.Close();

        }
        public void AddTwo()
        {
            SqlCommand cmd = new SqlCommand("select * from Employee;select * from department", conn);
            SqlDataReader dr=cmd.ExecuteReader();
            while (dr.Read())
            {

                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.Write($"{dr[i]} ");
                }
                Console.WriteLine();

            }
            dr.NextResult();
            while (dr.Read())
            {

                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.Write($"{dr[i]} ");
                }
                Console.WriteLine();

            }
        }
        public void Addcontacts()
        {
           
            int contactid=int.Parse(Console.ReadLine());
            string name=Console.ReadLine();
            DateTime date = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString("yyyy-MM-dd"));
            string mail=Console.ReadLine();
            string no=Console.ReadLine();
            SqlCommand cmd = new SqlCommand($"insert into contacts values('{contactid}','{name}','{date}','{mail}','{no}')", conn);
            int i=cmd.ExecuteNonQuery();
            if (i>0)
            {
                Console.WriteLine("Inserted successfully");
            }
            else
            {
                Console.WriteLine("Unsuccessfull");
            }
            
            
        }
        public void deletecontacts()
        {
            int id = int.Parse(Console.ReadLine());
            try
            {
                SqlCommand cmd = new SqlCommand($"delete from contacts where contactid={id}", conn);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Console.WriteLine("Deleted successfully");
                }
                else
                {
                    Console.WriteLine("Unsuccessfull");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            
            
           
           
        }

        public void GetEmployeeDetails()
        {
            try
            {
                Console.Write("Enter Employee ID: ");
                int empId = int.Parse(Console.ReadLine());
                if (conn.State != ConnectionState.Open)
                {
                    Console.WriteLine("Connection is NOT opened!");
                    return;
                }
                SqlCommand cmd = new SqlCommand("sp_GetEmployeeDet", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Empid", SqlDbType.Int).Value = empId;

               
                SqlParameter dojParam = new SqlParameter("@DateofJoin", SqlDbType.Date)
                {
                    Direction = ParameterDirection.Output
                };
                SqlParameter deptParam = new SqlParameter("@Department", SqlDbType.NVarChar, 50)
                {
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(dojParam);
                cmd.Parameters.Add(deptParam);

                cmd.ExecuteNonQuery();

                var doj = cmd.Parameters["@DateofJoin"].Value;
                var dept = cmd.Parameters["@Department"].Value;

                if (doj == DBNull.Value)
                {
                    Console.WriteLine("No employee found with this ID.");
                    return;
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }
        }

        public void transactions()
        {
            SqlTransaction tr = conn.BeginTransaction();

            try
            {
                SqlCommand cmd1 = new SqlCommand("insert into A values(4,'jay')", conn);
                cmd1.Transaction = tr;
                SqlCommand cmd2 = new SqlCommand("insert into B values(5,'jay')", conn);
                cmd2.Transaction = tr;
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                tr.Commit();
                Console.WriteLine("Record inserted successfully");
            }
            catch (Exception ex)
            {
                tr.Rollback();
                Console.WriteLine("could insert it is rollbacked!");
            }



        }

        public void transcopedemo()
        {
            string str = "integrated security=true;server=WKSBAN36KELTR30\\SQLEXPRESS;database=contactmgtdb";
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    SqlCommand cmd1 = new SqlCommand("insert into A values(5,'jay')", conn);
                    SqlCommand cmd2 = new SqlCommand("insert into B values(5,'jay')", conn);
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();

                }
                scope.Complete();
                Console.WriteLine("Transaction Successfull");
            }

        }
       
        public void Dispose()
        {
            conn.Close();
        }
    }
}
