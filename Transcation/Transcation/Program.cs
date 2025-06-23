using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//example of transcation with single database
namespace Transcation
{  //example of normal transcation
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Before Transcation");
    //        GetAccountDetails();

    //        operation();

    //        Console.WriteLine("After Transcation");
    //        GetAccountDetails();


    //    }
    //    static void GetAccountDetails()
    //    {
    //        try
    //        {
    //            string ConString = "Server=WKSPUN05GTR1024;Database=BankDB;Trusted_Connection=true";
    //            using (SqlConnection conn = new SqlConnection(ConString))
    //            {
    //                conn.Open();
    //                SqlCommand cmd = new SqlCommand("Select * from Accounts", conn);
    //                SqlDataReader rdr = cmd.ExecuteReader();
    //                while (rdr.Read())
    //                {
    //                    Console.WriteLine(rdr["AccountNumber"] + " " + rdr["CustomerName"] + " " + rdr["Balance"]);
    //                }
    //            }

    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }
    //    }
    //    static void operation()
    //    {
    //        try
    //        {
    //            string ConString = "Server=WKSPUN05GTR1024;Database=BankDB;Trusted_Connection=true";
    //            using (SqlConnection conn = new SqlConnection(ConString))
    //            {
    //                conn.Open();
    //                SqlTransaction trans= conn.BeginTransaction();
    //                try
    //                {
    //                    SqlCommand cmd = new SqlCommand("update accounts set Balance=Balance-500 where AccountNumber='Account1'", conn, trans);
    //                    cmd.ExecuteNonQuery();

    //                    SqlCommand cmd1 = new SqlCommand("update accounts set Balance=Balance+500 where AccountNumber='Account2'", conn, trans);
    //                    cmd1.ExecuteNonQuery();

    //                    trans.Commit();
    //                    Console.WriteLine("Successfully committed");
    //                }
    //                catch 
    //                    {
    //                        trans.Rollback();
    //                        Console.WriteLine("Rollback due to error");
    //                }
    //            }

    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }
    //    }
    //}


    //example of verifying the data consistency
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Before Transcation");
            GetAccountDetails();

            operation();

            Console.WriteLine("After Transcation");
            GetAccountDetails();


        }
        static void GetAccountDetails()
        {
            try
            {
                string ConString = "Server=WKSPUN05GTR1024;Database=BankDB;Trusted_Connection=true";
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Accounts", conn);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr["AccountNumber"] + " " + rdr["CustomerName"] + " " + rdr["Balance"]);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void operation()
        {
            try
            {
                string ConString = "Server=WKSPUN05GTR1024;Database=BankDB;Trusted_Connection=true";
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();
                    try
                    {
                        SqlCommand cmd = new SqlCommand("update accounts set Balance=Balance-500 where AccountNumber='Account1'", conn, trans);
                        cmd.ExecuteNonQuery();

                        SqlCommand cmd1 = new SqlCommand("update myaccounts set Balance=Balance+500 where AccountNumber='Account2'", conn, trans);
                        cmd1.ExecuteNonQuery();

                        trans.Commit();
                        Console.WriteLine("Successfully committed");
                    }
                    catch
                    {
                        trans.Rollback();
                        Console.WriteLine("Rollback due to error");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}