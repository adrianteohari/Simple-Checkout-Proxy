using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.Database db = new Database.Database();

            Console.WriteLine("TEST");
            Console.WriteLine(db.GetProduct("1234").Product);
            Console.ReadLine();
        }
    }
}
