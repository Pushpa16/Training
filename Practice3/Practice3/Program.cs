using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3
{
    internal class Program
    {  //example of datatable
        static void Main(string[] args)
        {
            try
            {
                DataTable dt = new DataTable("Student");

                //DataColumn Id = new DataColumn("ID");
                //Id.DataType = typeof(int);
                //Id.Unique = true;
                //Id.AllowDBNull = false;
                //dt.Columns.Add(Id);


                //if we want to do autoincrement
                DataColumn Id = new DataColumn("ID");
                Id.DataType = typeof(int);
                Id.Unique = true;
                Id.AllowDBNull = false;
                Id.AutoIncrement = true;
                Id.AutoIncrementSeed = 200;
                Id.AutoIncrementStep = 1;
                dt.Columns.Add(Id);



                DataColumn Name = new DataColumn("Name");
                Name.MaxLength = 50;
                Name.AllowDBNull = false;
                dt.Columns.Add(Name);

                DataColumn Email = new DataColumn("Email");
                dt.Columns.Add(Email);

                dt.PrimaryKey = new DataColumn[] { Id };

                dt.Rows.Add(null, "Mohanty", "Mohanty@dotnettutorials.net");
                dt.Rows.Add(null, "Pushpa", "pushpa@dotnettutorials.net");
                dt.Rows.Add(null, "Divya", "divya@dotnettutorials.net");

                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(row[Id] + " " + row[Name]);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }

            Console.ReadKey();
        }
    }
}
