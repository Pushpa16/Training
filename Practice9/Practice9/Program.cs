using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice9
{
    internal class Program
    { //exampl of DataView
        static void Main(string[] args)
        {
            try
            {
                string ConString = "Server=WKSPUN05GTR1024;Database=EmployeeDB;Trusted_Connection=true";
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select * from Employee", conn);
                    DataTable dt=new DataTable();
                    da.Fill(dt);

                    //Creating DataView instance using DataView 
                    DataView dv =new DataView(dt);
                    Console.WriteLine("Accessing DataView using For Loop:");
                    for (int i = 0; i < dv.Count; i++)
                    {
                        Console.WriteLine(dv[i]["Id"]);
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
