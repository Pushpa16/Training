using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice11
{ //DataSet using SQL Server in C#
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string ConString = "Server=WKSPUN05GTR1024;Database=ShoppingCartDB;Trusted_Connection=true";
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    //single select statement 
                    //SqlDataAdapter da=new SqlDataAdapter("select * from customers", conn);
                    //DataSet ds=new DataSet();

                    //below: this will open the connection, execute the command,retrieve the result
                    //       and will store the data in the dataset.we have not specified the data table
                    //       name and the data table will be created at index position 0 and close the connection.
                    //da.Fill(ds);

                    //foreach (DataRow row in ds.Tables[0].Rows)
                    //{
                    //    Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Mobile"]);
                    // }


                    //multiple select statement
                    SqlDataAdapter da = new SqlDataAdapter("select * from customers; select * from orders", conn); 
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    Console.WriteLine("Customer table");
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Mobile"]);
                    }

                    Console.WriteLine("Order table");
                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        Console.WriteLine(row["Id"] + ",  " + row["CustomerID"]);
                    }


                    //Copy(): Copies both the structure and data of the DataSet.
                    //Clone(): Copies the structure of the DataSet, including all schemas, relations, and constraints.no data
                    //Clear(): Clears the DataSet of any data by removing all rows in all tables.


                    // Remove a DataTable from a Dataset:
                    Console.WriteLine();
                    //Now, we want to delete the Orders data table from the DataSet
                    if (ds.Tables.Contains("Orders") && ds.Tables.CanRemove(ds.Tables["Orders"]))
                    {
                        Console.WriteLine("Deleting Orders Data Table..");
                        ds.Tables.Remove(ds.Tables["Orders"]);
                        //dataSet.Tables.Remove(dataSet.Tables[1]);
                    }
                    //Now check whether the DataTable exists or not
                    if (ds.Tables.Contains("Orders"))
                    {
                        Console.WriteLine("Orders Data Table Exits");
                    }
                    else
                    {
                        Console.WriteLine("Orders Data Table Not Exits Anymore");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }

        }
    }
}
