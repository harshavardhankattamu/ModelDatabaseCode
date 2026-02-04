using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disconntecddemo
{
    internal class ConcurrencyDemo
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        public void ConcurrencywithWhere()
        {
            //HOW applications should behave when 2 users trying madify
            //same record at same time
            try
            {
                SqlConnection conn = new SqlConnection("integrated security=true;server=WKSBAN36KELTR30\\SQLEXPRESS;database=contactmgtdb");
                //string str = "update contacts set phone=@ph where contactid=@conid and phone=@pho";
                string str = "update contacts set phone=@ph where ts=@time";
                //u need to give value for phone number
                //contactid will be taken automatically from database
                SqlParameter p1 = new SqlParameter("@ph", SqlDbType.VarChar, 12, "phone");
                //SqlParameter p2 = new SqlParameter("@conid", SqlDbType.VarChar, 12, "contactid");
                //p2.SourceVersion = DataRowVersion.Original;
                SqlParameter p2 = new SqlParameter("@time", SqlDbType.Timestamp, 20, "ts");
                p2.SourceVersion = DataRowVersion.Original;//value will take from db

                da = new SqlDataAdapter("select * from contacts", conn);

                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                SqlCommand cm = new SqlCommand(str, conn);
                cm.Parameters.Add(p1);
                cm.Parameters.Add(p2);
               
                da.Fill(ds, "c");
                da.UpdateCommand = cm;
                //new update command is applied
                dt = ds.Tables["c"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Console.Write(dt.Rows[i][j]);
                        Console.Write("\t");
                    }
                    Console.WriteLine();
                }
                //da.ContinueUpdateOnError = true;
                Console.WriteLine("Enter the phone");
                dt.Rows[0][4] = Console.ReadLine();
               
                int k = da.Update(dt);
                if (k > 0)
                    Console.WriteLine("Update Successfully");
                
            }
            catch (DBConcurrencyException ex)
            {
                Console.WriteLine("Some other user already modified");
            }
        }
    }
}
