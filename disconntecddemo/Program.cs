using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disconntecddemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //disconnected d = new disconnected();
            //d.DisplayContacts();
            ////d.AddContacts();
            ////d.DeleteContact();
            ////d.UpdateContact();
            ////d.Search();
            ////d.datachanges();
            //d.WriteToXml();
            //d.ReadFromXml();
            //d.DisplayById();
            //disconnectedassignment d1 = new disconnectedassignment();
            //d1.PrintTwo();
            //d1.DataviewSort();
            //d1.TotalTables();
            //d1.DataTableEmp();
            //d1.Task6();
            //d1.Task7();
            //d1.Task8();
            //d1.Task9();
            //d1.Task10();
            //adoadvanced ado=new adoadvanced();
            // ado.DatatableDemo();
            //ado.RelationShipDemo();
            //ado.DataViewDemo();
            //configdemo cd=new configdemo();
            //cd.DisplayContacts();
            ConcurrencyDemo cd=new ConcurrencyDemo();
            cd.ConcurrencywithWhere();
            
        }
    }
}
