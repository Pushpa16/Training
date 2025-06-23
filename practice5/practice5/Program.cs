using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice5
{
    internal class Program
    {  //storedprocedure
        static void Main(string[] args)
        {

            try
            {
                string connstr = "Server=WKSPUN05GTR1024;Database=stu_db;Trusted_Connection=true";
                using (SqlConnection conn = new SqlConnection(connstr)) 
                {
                    conn.Open ();
                    //without parameters
                    //SqlCommand cmd = new SqlCommand("spGetStudents",conn);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //SqlDataReader rdr=cmd.ExecuteReader();
                    //while (rdr.Read())
                    //{
                    //    Console.WriteLine(rdr["user_id"] + "  " + rdr["user_fullname"]);
                    //}


                    //with input parameters
                    //SqlCommand cmd = new SqlCommand("GetStudentDetails", conn);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //option1
                    //cmd.Parameters.AddWithValue("@user_id", 6);
                    //option2
                    //SqlParameter param = new SqlParameter("@user_id", SqlDbType.Int);
                    //param.Value = 6;
                    //param.Direction = ParameterDirection.Input; // Explicitly setting direction:If you're working with Output or Return parameters
                    //cmd.Parameters.Add(param);
                    //SqlDataReader rdr = cmd.ExecuteReader();
                    //while (rdr.Read())
                    //{
                    //    Console.WriteLine(rdr["user_id"] + "  " + rdr["user_fullname"]);
                    //}


                    //with both input and output
                    SqlCommand cmd = new SqlCommand("inoutStuDetails", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", 6);//input
                    SqlParameter param1 = new SqlParameter("@username", SqlDbType.VarChar, 50);//ouput
                    param1.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param1);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Name of user whose id is 6 is" + param1.Value.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
