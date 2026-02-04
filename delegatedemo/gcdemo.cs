using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegatedemo
{
    //Instance
    //static
    internal class gcdemo:IDisposable
    {
        public gcdemo() {
            //database connection code goes here
            //con.open()
            //a best place to initialize global variables
            Console.WriteLine("gcdemo");
        }
        static gcdemo()
        {
            //static constuctor called only once
            //initilaize static variable
            Console.WriteLine("gcdemo static constructor called");
        }
        //use destructor for destroying unmanaged resources
        //what is unmanaged?
        //any code which is not handled by CLR
        //clr will handle only for managed resources
        //anything within the scope of .net env it is managed by clr
        //if u are using file handling
        //network connection
        ~gcdemo()
        {
            Console.WriteLine("gcdemo destructor called");
        }

        public void Dispose()
            
        {
            //use dispose to clear the
            Console.WriteLine("Dispose method is called");
            GC.SuppressFinalize(this);
        }
        //when the destructor called?
        //destructor will be called once the object is out of scope
    }
}
