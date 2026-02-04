using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacedemo2
{
    
    interface Database
    {
        void Add(int a, int b);
        void Update();
        void Delete();
    }
    internal class sqlclass : Database
    {
        public void Add(int a, int b)
        {
            Console.WriteLine(a+b);
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
    internal class oracleclass : Database
    {
        public void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
    class datamanager
    {
        public static Database GetInstance(int x)
        {
            Database l = null;
            if (x == 1)
            {
                return new sqlclass();
            }
            else
            {
                return new oracleclass();
            }
        }
    }

}
