using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace disconntecddemo
{
    internal class disconnectedassignment:Contacts
    {
        DataSet ds=new DataSet();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();

        SqlDataAdapter da1;
     
        public void PrintTwo()
        {
            SqlConnection conn = new SqlConnection("integrated security=true;server=WKSBAN36KELTR30\\SQLEXPRESS;database=contactmgtdb");
            da1 = new SqlDataAdapter("select * from employee", conn);
            SqlDataAdapter da2 = new SqlDataAdapter("select * from department", conn);
            da1.Fill(ds, "e");
            da2.Fill(ds, "d");
            dt1=ds.Tables[0];
            dt2= ds.Tables[1];
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                for (int j = 0; j < dt1.Columns.Count; j++)

                {
                    Console.Write(dt1.Rows[i][j]);
                    Console.Write("\t");
                }
                Console.WriteLine();

            }
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                for (int j = 0; j < dt2.Columns.Count; j++)

                {
                    Console.Write(dt2.Rows[i][j]);
                    Console.Write("\t");
                }
                Console.WriteLine();

            }
        }
        public void DataviewSort()
        {
            DataView dv=new DataView(dt1);
            dv.RowFilter = "salary>47000 and department_id=1 and employee_name like 'A%'";
            dv.Sort = "employee_id DESC";
            if (dv.Count!=0)
            {
                foreach (DataRowView d in dv)
                {
                    Console.WriteLine(d[0]);
                    Console.WriteLine(d[1]);
                    Console.WriteLine(d[2]);
                    Console.WriteLine(d[3]);
                    Console.WriteLine(d[4]);
                    Console.WriteLine(d[5]);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }

        }

        public void TotalTables()
        {
            Console.WriteLine(ds.Tables.Count);
        }

        public void DataTableEmp()
        {
            DataTable dt3=new DataTable("students");
            dt3.Columns.Add("StudentId", typeof(int));
            dt3.Columns.Add("Name", typeof(string));
            dt3.Columns.Add("Age", typeof(int));

            dt3.Rows.Add(1, "Harsha", 20);
            dt3.Rows.Add(2, "Karthikeya", 20);
            dt3.Rows.Add(3, "pavan", 20);
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                for (int j = 0; j < dt3.Columns.Count; j++)

                {
                    Console.Write(dt3.Rows[i][j]);
                    Console.Write("\t");
                }
                Console.WriteLine();

            }
        }

        public void Task6()
        {
            SqlConnection conn = new SqlConnection("integrated security=true;server=WKSBAN36KELTR30\\SQLEXPRESS;database=contactmgtdb");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from department",conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt4 = new DataTable();
            dt4.Load(dr);
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                for (int j = 0; j < dt4.Columns.Count; j++)

                {
                    Console.Write(dt4.Rows[i][j]);
                    Console.Write("\t");
                }
                Console.WriteLine();

            }
            conn.Close();
        }
        public void Task7()
        {
            SqlConnection conn = new SqlConnection("integrated security=true;server=WKSBAN36KELTR30\\SQLEXPRESS;database=customer");
            SqlDataAdapter da1=new SqlDataAdapter("select * from customer",conn);
            SqlDataAdapter da2 = new SqlDataAdapter("select * from orders", conn);

            DataSet ds1=new DataSet();
            DataSet ds2=new DataSet();

            da1.Fill(ds1,"c");
            da2.Fill(ds2,"o");
            ds1.Merge(ds2);
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            dt3 = ds1.Tables["c"];
            dt4 = ds1.Tables["o"];
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                for (int j = 0; j < dt3.Columns.Count; j++)

                {
                    Console.Write(dt3.Rows[i][j]);
                    Console.Write("\t");
                }
                Console.WriteLine();

            }
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                for (int j = 0; j < dt4.Columns.Count; j++)

                {
                    Console.Write(dt4.Rows[i][j]);
                    Console.Write("\t");
                }
                Console.WriteLine();

            }

        }
        public void Task8()
        {
            SqlConnection conn = new SqlConnection("integrated security=true;server=WKSBAN36KELTR30\\SQLEXPRESS;database=customer");
            SqlDataAdapter da= new SqlDataAdapter("select * from orders", conn);
            da.Fill(ds,"o");
            DataTable dt4=new DataTable();
            dt4=ds.Tables["o"];

            DataView dv = new DataView(dt4);
            dv.RowFilter = "orderdate >#2024-01-21# and orderdate < #2025-12-31#";

            if (dv.Count!=0)
            {
                foreach (DataRowView d in dv)
                {
                    Console.WriteLine(d[0]);
                    Console.WriteLine(d[1]);
                    Console.WriteLine(d[2]);
                    Console.WriteLine(d[3]);
                    Console.WriteLine(d[4]);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }

        }
        public void Task9()
        {
            var ds1=new DataSet();
            ds1.ReadXml("C:\\1201\\CUSTOMER.xml");
            DataTable dt=new DataTable();
            dt = ds1.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)

                {
                    Console.Write(dt.Rows[i][j]);
                    Console.Write("\t");
                }
                Console.WriteLine();

            }
        }

        public void Task10()
        {
            SqlConnection conn = new SqlConnection("integrated security=true;server=WKSBAN36KELTR30\\SQLEXPRESS;database=contactmgtdb");
            SqlDataAdapter  da1 = new SqlDataAdapter("select * from contacts", conn);
          
            DataSet ds3=new DataSet();
            da1.Fill(ds3, "c");
            DataTable dt3= new DataTable();
            dt3 = ds3.Tables["c"];
            List<Contacts> li = new List<Contacts>();
            for (int i = 0;i < dt3.Rows.Count;i++)
            {
                
                Contacts c = new Contacts();

                c.contacttid = int.Parse(dt3.Rows[i][0].ToString());
                c.customername = dt3.Rows[i][1].ToString();
                c.dob = DateTime.Parse(dt3.Rows[i][2].ToString());
                c.email = (dt3.Rows[i][3].ToString());
                c.phone =dt3.Rows[i][4].ToString();

                
    
                li.Add(c);
            }
            foreach (var c1 in li)
            {
                Console.WriteLine($"{c1.contacttid} {c1.customername} {c1.dob} {c1.email} {c1.phone}");
            }
            


        }
    }
}
