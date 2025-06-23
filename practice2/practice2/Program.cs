using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {   //example for Sqldataadapter
                string ConString = "Server=WKSPUN05GTR1024;Database=stu_db;Trusted_Connection=true";
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    //SqlDataAdapter da = new SqlDataAdapter("Select * from Users", conn);

                    //using datatable
                    //DataTable dt = new DataTable();
                    //the .Fill()
                    //1. Open the connection
                    //2. Execute Command
                    //3. Retrieve the Result
                    //4. Fill/Store the Retrieve Result in the Data table:student
                    //5. Close the connnection
                    // This method automatically handles the Opening and Closing of the database connections.
                    //da.Fill(dt);
                    //Console.WriteLine("Using Data Table");
                    //dt.Rows: Gets the collection of rows that belong to this table
                    //DataRow: Represents a row of data in a DataTable.
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //Console.WriteLine(row["user_id"] + "  " + row["user_fullname"]);
                    //}


                    //using dataset:collection of multiple tables
                    //DataTable dt = new DataTable(student1);
                    //DataSet ds = new DataSet();
                    //da.Fill(ds, "student1");
                    //Console.WriteLine("Using Data Set");
                    //foreach(DataRow row in ds.Tables["student1"].Rows)
                    //{
                    //    Console.WriteLine(row["user_id"] + "  " + row["user_fullname"]);

                    //}



                    //stored procedure
                    SqlDataAdapter da =new SqlDataAdapter("spGetStudents",conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine(row["user_fullname"]);
                    }
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
