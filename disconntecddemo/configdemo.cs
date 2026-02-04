using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace disconntecddemo
{
    internal class configdemo
    {
        DataSet ds = new DataSet();//untyped, no intelligence
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        DataSet1 dss1= new DataSet1();

        public void DisplayContacts()
        {
            string st = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
            SqlConnection conn = new SqlConnection(st);
            Console.WriteLine(st);
            //no need to open or close connection
            da = new SqlDataAdapter("select * from contacts", conn);
            //SqlDataAdapter da1 = new SqlDataAdapter("select * from employee", conn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            SqlCommandBuilder cm = new SqlCommandBuilder(da);

            da.Fill(dss1.contacts);//Run the Query, the output is stored in the dataset
                             //da1.Fill(ds, "emp");

            
            Console.WriteLine(dss1.contacts[0].contactid);
            for (int i = 0; i < dt.Rows.Count; i++)
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
    }
}
