using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ModelFirst
{
    internal class custcrud
    {
        Model1Container dc=new Model1Container();
        public void addcustomer()
        {
            try
            {
                Customer1 c = new Customer1();
                c.Custid = 101;
                c.Custname = "Ajay";
                c.address = Caddress.banglore;
                c.location = System.Data.Entity.Spatial.DbGeography.FromText("POINT(12.9716 77.5946)");
                dc.Customer1.Add(c);
                dc.SaveChanges();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
