using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practice10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Creating Customer Data Table
                DataTable Cust = new DataTable("Customer");

                // Adding Data Columns to the Customer Data Table
                DataColumn CustomerId = new DataColumn("ID", typeof(Int32));
                Cust.Columns.Add(CustomerId);
                DataColumn CustomerName = new DataColumn("Name", typeof(string));
                Cust.Columns.Add(CustomerName);
                DataColumn CustomerMobile = new DataColumn("Mobile", typeof(string));
                Cust.Columns.Add(CustomerMobile);

                //Adding Data Rows into Customer Data Table
                Cust.Rows.Add(101, "Anurag", "2233445566");
                Cust.Rows.Add(202, "Manoj", "1234567890");


                // Creating Orders Data Table
                DataTable Ord = new DataTable("Orders");

                // Adding Data Columns to the Orders Data Table
                DataColumn OrderId = new DataColumn("ID", typeof(System.Int32));
                Ord.Columns.Add(OrderId);
                DataColumn CustId = new DataColumn("CustomerId", typeof(Int32));
                Ord.Columns.Add(CustId);
                DataColumn OrderAmount = new DataColumn("Amount", typeof(int));
                Ord.Columns.Add(OrderAmount);

                //Adding Data Rows into Orders Data Table
                Ord.Rows.Add(10001, 101, 20000);
                Ord.Rows.Add(10002, 102, 30000);


                //Creating DataSet Object
                DataSet ds = new DataSet();

                //Adding DataTables into DataSet
                ds.Tables.Add(Cust);
                ds.Tables.Add(Ord);

                Console.WriteLine("Details of Customer Table");
                foreach (DataRow row in ds.Tables["Customer"].Rows )
                {
                    Console.WriteLine(row["ID"] + " "+ row["Name"]);
                }

                Console.WriteLine("Details of Order Table");
                foreach (DataRow row1 in ds.Tables["Orders"].Rows)
                {
                    Console.WriteLine(row1["ID"] + " " + row1["CustomerId"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
        }
    
    }
}
