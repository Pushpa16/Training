using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //string ConString = "Server=WKSPUN05GTR1024;Database=stu_db;Trusted_Connection=true";
                string ConString = "Server=WKSPUN05GTR1024;Database=ShoppingCartDB;Trusted_Connection=true";
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();


                    //ExecuteReader()
                    //SqlCommand cmd = new SqlCommand("Select * from Users", conn);
                    //SqlDataReader rdr = cmd.ExecuteReader();
                    //while (rdr.Read())
                    //{
                      //Console.WriteLine(rdr["user_id"] + " " + rdr["user_fullname"]);
                      //2nd method
                      //Console.WriteLine(rdr[0] + " " + rdr[1]);
                    //}


                    //ExecuteScaler(): return type of ExecuteScaler is object, so we need to typecast it into int type.
                    //SqlCommand cmd = new SqlCommand("Select count(user_id) from Users", conn);
                    //int totalstudent= (int)cmd.ExecuteScalar();
                    //Console.WriteLine( "Total number of students"+ totalstudent );


                    //ExecuteNonQuery()
                    //SqlCommand cmd= new SqlCommand("insert into Users(user_fullname, user_email, user_role) values('sandhya','sand@gmail.com', 'Teacher')",conn);
                    //int roweffected=cmd.ExecuteNonQuery();
                    //Console.WriteLine("No of inserted rows  "+ roweffected);


                    //storedprocedure
                    //SqlCommand cmd = new SqlCommand("GetStudentDetails", conn);
                    //cmd.CommandType=CommandType.StoredProcedure; //specifies its a stored procedure
                    //cmd.Parameters.AddWithValue("@user_id", 6);
                    //SqlDataReader rdr = cmd.ExecuteReader();
                    //while (rdr.Read())
                    //{
                    //  Console.WriteLine(rdr["user_id"] + " " + rdr["user_fullname"]);
                    //}


                    //multiple result set: where a single SQL query returns more than one table of data. This happens when you execute multiple SELECT statements in one go.
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Customers; SELECT * FROM Orders", conn);
                    SqlDataReader reader =cmd.ExecuteReader();
                    //Looping through First Result Set
                    Console.WriteLine("First Result Set:");
                    while (reader.Read())
                       {
                         Console.WriteLine(reader["ID"] + " " + reader["Name"]+ " "+ reader["Mobile"]);
                       }
                    //Looping through Second Result Set using NextResultMethod
                    Console.WriteLine("Second Result Set:");
                    while (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader["ID"] + " " + reader["CustomerId"] + " " + reader["Amount"]);
                            }
                        }
                }
            }
            catch (Exception e )
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            Console.ReadKey();
        }
    }
}
