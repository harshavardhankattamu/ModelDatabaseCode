using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace disconntecddemo
{
    //relationship(pk, forenkey)
    //transaction scope
    //datatable raeder

    internal class adoadvanced
    {
        //datatable:sql server
        //dt=ds.Table["key"] table
        //data can come from xml file
        //dt.Rows.Add
        public void DatatableDemo() {
            //Row state: using row state we can track the chnages happeend in datatable
            DataTable dt = new DataTable();
            dt.Columns.Add("custid", typeof(int));
            dt.Columns.Add("custname", typeof(string));
            dt.Columns.Add("age", typeof(int));
            dt.Columns.Add("address", typeof(string));
            dt.PrimaryKey=new DataColumn[] {dt.Columns["custid"]};
            DataRow dr= dt.NewRow();
            dr[0] = 100;
            dr[1] = "Arjun";
            dr[2] = 50;
            dr[3] = "Banglore";
            dt.Rows.Add(dr);
            DataRow dr1 = dt.NewRow();
            dr1[0] = 200;
            dr1[1] = "Arjun";
            dr1[2] = 50;
            dr1[3] = "Banglore";
            dt.Rows.Add(dr1);
            //unchanged, dettached, added, modified, deleted
            //Console.WriteLine(dr.RowState);
            //dt.AcceptChanges();//it will commit all newly added recordsd
            //dt.Rows[0][1] = "Vijay";
            //Console.WriteLine(dr.RowState);
            //Console.WriteLine(dr["custname",DataRowVersion.Original]);
            //Console.WriteLine(dr["custname", DataRowVersion.Current]);
            //dr.Delete();
            //Console.WriteLine(dr.RowState);
            foreach (DataRow item in dt.Rows)
            {
                Console.WriteLine(item[0]);
                Console.WriteLine(item[1]);
                Console.WriteLine(item[2]);
                Console.WriteLine(item[3]);

            }



        } 
        public void RelationShipDemo()
        {
            DataSet ds=new DataSet();
            DataTable parentdt = new DataTable();
            parentdt.Columns.Add("custid", typeof(int));
            parentdt.Columns.Add("custname", typeof(string));
            parentdt.Columns.Add("age", typeof(int));
            parentdt.Columns.Add("address", typeof(string));

            DataTable childdt = new DataTable();
            childdt.Columns.Add("orderid", typeof(int));
            childdt.Columns.Add("custid", typeof(int));
           
            childdt.Columns.Add("products", typeof(string));
            childdt.Columns.Add("price", typeof(int));
            ds.Tables.Add(parentdt);
            ds.Tables.Add(childdt);
            DataRelation d = new DataRelation("hi", parentdt.Columns[0], childdt.Columns[1]);
            ForeignKeyConstraint fkcon = new ForeignKeyConstraint(
                 "FK_parentChild",
                 parentdt.Columns["custid"],
                 childdt.Columns["custid"]
                 );
            fkcon.UpdateRule = Rule.Cascade;
            fkcon.DeleteRule = Rule.SetNull;
            childdt.Constraints.Add(fkcon);
            ds.Relations.Add(d);
            parentdt.Rows.Add(101,"harsga",21,"jsjsdjh");
            parentdt.Rows.Add(102, "jay", 31, "jkasjkadjh");

            childdt.Rows.Add(1, 101, "books", 200);
            childdt.Rows.Add(2,102, "cd", 100);
            

           
            DataRow dr3 = parentdt.Rows[0];
            dr3[0] = 1000;
            foreach (DataRow item in parentdt.Rows)
            {
                Console.WriteLine(item[0]);
                Console.WriteLine(item[1]);
                Console.WriteLine(item[2]);
                Console.WriteLine(item[3]);

            }
            foreach (DataRow item in childdt.Rows)
            {
                Console.WriteLine(item[0]);
                Console.WriteLine(item[1]);
                Console.WriteLine(item[2]);
                Console.WriteLine(item[3]);

            }


        }
        public void DataViewDemo()
        {
            //rowfilter, rowstate, crud operation in dataview
            DataTable parentdt = new DataTable();
            parentdt.Columns.Add("custid", typeof(int));
            parentdt.Columns.Add("custname", typeof(string));
            parentdt.Columns.Add("age", typeof(int));
            parentdt.Columns.Add("address", typeof(string));
            parentdt.Rows.Add(101, "harsga", 21, "jsjsdjh");
            parentdt.Rows.Add(102, "jay", 31, "jkasjkadjh");
            parentdt.Rows.Add(103, "harsga", 21, "jsjsdjh");
            parentdt.Rows.Add(104, "jay", 31, "jkasjkadjh");
            parentdt.AcceptChanges();
            DataView dv=new DataView(parentdt);
            //dv.RowFilter = "age>20 ";
            //parentdt.Rows[0][2] = 50;
            //DataRow dr1=parentdt.Rows[0];
            //dr1.Delete();
            //dv.RowStateFilter = DataViewRowState.OriginalRows;
            //dv.RowStateFilter = DataViewRowState.ModifiedCurrent;
            //dv.RowStateFilter = DataViewRowState.Added;
            //dv.RowStateFilter=DataViewRowState.Deleted;
            DataRowView ddv=dv.AddNew();
            ddv[0] = 500;
            ddv[1] = "hari";
            ddv[2] = 45;
            ddv[3] = "mumbai";
            ddv.EndEdit();// data will be updated to datatable
                          //dv[0][2] = 55;
            
            dv.Delete(1);
            parentdt.RejectChanges();
            foreach (DataRow item in parentdt.Rows)
            {
                Console.Write(item[0]); Console.Write("\t");
                Console.Write(item[1]); Console.Write("\t");
                Console.Write(item[2]); Console.Write("\t");
                Console.Write(item[3]); Console.Write("\t\n");
               
            }
            foreach (DataRowView item in dv)
            {
                Console.Write(item[0]); Console.Write("\t");
                Console.Write(item[1]); Console.Write("\t");
                Console.Write(item[2]); Console.Write("\t");
                Console.Write(item[3]); Console.Write("\t\n");
               
            }
            // readonly+forward only direction
            DataTableReader dtr = new DataTableReader(parentdt);
            while (dtr.Read())
            {
                Console.WriteLine($"{dtr[0]} {dtr[1]} {dtr[2]} {dtr[3]}");
            }

        }
    }
}
