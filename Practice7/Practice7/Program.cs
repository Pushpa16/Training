using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    internal class Program
    { //example of  how to call a stored procedure and store the result in a DataSet using C#
       
        static void Main(string[] args)
        {
            try
            {
                string ConString = "Server=WKSPUN05GTR1024;Database=EmployeeDB;Trusted_Connection=true";
                using (SqlConnection conn = new SqlConnection(ConString))
                {   //use sqlcommand when dealing with stored procedure
                    SqlCommand cmd = new SqlCommand("spgetemployee",conn);
                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Age", 25);
                    

                    //now dataset
                    SqlDataAdapter da= new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    //retrieving the data
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Console.WriteLine(row["Name"] + " " + row["Email"] + " " + row["Mobile"] + " " + row["Department"]);
                    }
                }
            }
            catch(Exception ex) 
                {
                    Console.WriteLine(ex.ToString());
                }
        }
    }
}
