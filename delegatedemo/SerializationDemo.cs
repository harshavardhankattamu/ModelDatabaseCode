using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace delegatedemo
{
    internal class SerializationDemo
    {
        public void serializedata()
        {
            string[] con = { "india", "Russia","singpore" };
            FileStream fs = new FileStream("c:\\1201\\con.xml",FileMode.OpenOrCreate,FileAccess.ReadWrite);
            XmlSerializer xs=new XmlSerializer(typeof(string[]));
            xs.Serialize(fs, con);
            fs.Close();
            Console.WriteLine("File Created Successfully");

        }
        public void deserializedata()
        {
            string[] empty = null;
            FileStream fs = new FileStream("c:\\1201\\con.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(string[]));
            empty=(string[]) xs.Deserialize(fs);
            foreach(string con in empty)
            {
                Console.WriteLine(con);
            }
            fs.Close();
            Console.WriteLine("File Created Successfully");

        }
    }
}
