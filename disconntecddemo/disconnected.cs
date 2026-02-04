using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace disconntecddemo
{
    internal class disconnected
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        public void DisplayContacts()
        {
            SqlConnection conn = new SqlConnection();
            //no need to open or close connection
            da = new SqlDataAdapter("select * from contacts", conn);
            //SqlDataAdapter da1 = new SqlDataAdapter("select * from employee", conn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            SqlCommandBuilder cm= new SqlCommandBuilder(da);
           
            da.Fill(ds, "c");//Run the Query, the output is stored in the dataset
            //da1.Fill(ds, "emp");
           
            dt = ds.Tables["c"];
            for(int i = 0; i <dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j]);
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine(dt.Rows.Count);

            //1st row firstcolumn
        }
        public void DisplayById()
        {
            Console.WriteLine("Enter the Id");
            int id =int.Parse(Console.ReadLine());
            DataRow dr = dt.Rows.Find(id);

            if (dr != null)
            {
                for (int j = 0; j < dr.Table.Columns.Count; j++)
                {
                    Console.Write(dr[j]);
                    Console.Write("\t");
                }

            }
            else
            {
                Console.WriteLine("Not Found");
            }

        }
        public void AddContacts()
        {
            int id=int.Parse(Console.ReadLine());   
            string name=Console.ReadLine();
            DateTime date = DateTime.Parse(Console.ReadLine());
            string mail=Console.ReadLine();
            string dep=Console.ReadLine();
            dt.Rows.Add(id, name, date, mail, dep);
            int ra=da.Update(dt);
            Console.WriteLine(ra);

        }
        public void DeleteContact()
        {
            Console.WriteLine("Enter the Id");
            int id = int.Parse(Console.ReadLine());
            DataRow dr = dt.Rows.Find(id);
            dr.Delete();
            int ra = da.Update(dt);
            Console.WriteLine("Total rows deleted is "+ra);

        }
         public void UpdateContact()
        {
            Console.WriteLine("enter the id");
            int id=int.Parse(Console.ReadLine());
            DataRow dr=dt.Rows.Find(id);
            dr[4] = "7672832782";
            int ra = da.Update(dt);
            Console.WriteLine("The total rows Updated is "+ra);
        }

        public void Search()
        {
            DataView dv=new DataView(dt);
     
            //dv.RowFilter = $"contactid>{id}";
            dv.RowFilter = "contactid>300 and dob>#2000-12-31#";
            dv.Sort = "contactid DESC" ;
            if (dv != null)
            {
                foreach(DataRowView d in dv)
                {
                    Console.WriteLine(d[0]);
                    Console.WriteLine(d[1]);
                    Console.WriteLine(d[2]);
                    Console.WriteLine(d[3]);
                    Console.WriteLine(d[4]);
                    Console.WriteLine();
                }
            }
            else{
                Console.WriteLine("Not Found");
            }
        }
        public void datachanges()
        {
            dt.Rows.Add(900, "romio", "2004-01-02", "hsjhsjh@gmail.com", 23238237);
            if (ds.HasChanges())
            {
                DataTable d = dt.GetChanges();
                for (int i = 0; i < d.Rows.Count; i++)
                {
                    for (int j = 0; j < d.Columns.Count; j++)
                    {
                        Console.Write(d.Rows[i][j]);
                        Console.Write("\t");
                    }
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine("No changes happened");
            }
        }

        public void WriteToXml()
        {
            dt.Rows.Add(9400, "romio", "2004-01-02", "hsjhsjh@gmail.com", 23238237);

            if (ds.HasChanges())
            {
                DataTable d = dt.GetChanges();
                d.WriteXml("C:\\1201\\contacts.xml",XmlWriteMode.WriteSchema);

            }
           
        }
        public void ReadFromXml()
        {
            var ds1=new DataSet();
            ds1.ReadXml("C:\\1201\\contacts.xml");
            ds.Merge(ds1);
            DataTable dt1=new DataTable();
            dt1=ds.Tables[0];
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                for (int j = 0; j < dt1.Columns.Count; j++)
                {
                    Console.Write(dt1.Rows[i][j]);
                    Console.Write("\t");
                }
                Console.WriteLine();
            }

        }
    }
}
