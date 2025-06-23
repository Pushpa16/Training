using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice8
{
    internal class Program
    {  //Generic method: If you don’t use a generic method, you have to write separate code every time you call a stored procedure. This leads to duplicate code and makes maintenance harder.
        static void Main(string[] args)
        {
            string ConString = "Server=WKSPUN05GTR1024;Database=EmployeeDB;Trusted_Connection=true";
            DataTable dt1 = ExecuteProcedure("spemployee", ConString);
            Console.WriteLine("First Stored Procedure Result:");
            PrintDataTable(dt1);

            Console.WriteLine();

            DataTable dt2 = ExecuteProcedure("spgetemployee", ConString, new SqlParameter("@Age", 25));
            Console.WriteLine("Second Stored Procedure Result:");
            PrintDataTable(dt2);
        }

        static DataTable ExecuteProcedure(string procedurename, string ConStringName, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConStringName))
            {
                using (SqlCommand cmd = new SqlCommand(procedurename, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

            }
            return dt;
        }
        static void PrintDataTable(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
               
                    Console.WriteLine(row["Name"] + " " + row["Email"] + " " + row["Mobile"] + " " + row["Department"]);
                
            }
        }
    }
}
