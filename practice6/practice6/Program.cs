using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice6
{
    internal class Program
    {   //example of DataTable Methods in C# using SQL Server:
        static void Main(string[] args)
        {

            try
            {
                string ConString = "Server=WKSPUN05GTR1024;Database=stu_db;Trusted_Connection=true";
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from Users", conn);
                    DataTable dt = new DataTable("Student");
                    da.Fill(dt);
                    Console.WriteLine("Before any changes");
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine(row["user_email"] + " " + row["user_fullname"]);
                    }


                    //copy: copy the DataTable data and its schema. 
                    //Console.WriteLine("Copied DataTable");
                    //DataTable copiedDt = dt.Copy();
                    //if (copiedDt != null)
                    //{
                    //    foreach (DataRow row in copiedDt.Rows)
                    //    {
                    //        Console.WriteLine(row["user_fullname"]);
                    //    }
                    //}

                    //clone:copy the data table schema without data
                    //Console.WriteLine("Cloned DataTable");
                    //DataTable cloneDt= dt.Clone();
                    //if (cloneDt.Rows.Count > 0)
                    //{
                    //    foreach (DataRow row in cloneDt.Rows)
                    //    {
                    //        Console.WriteLine(row["user_fullname"]);
                    //    }
                    //}
                    //else
                    //{
                    //    cloneDt.Rows.Add(12, "Sandhya", "sand@gmail.com", "student");
                    //    foreach (DataRow row in cloneDt.Rows)
                    //    {
                    //        Console.WriteLine(row["user_email"] + " " + row["user_fullname"]);
                    //    }
                    //}


                    //delete:delete method marks the datarow for removal. the actual removal will occur when you call the acceptchanges method. if you want to roll back, then you need to use the rejectchanges method, which will roll back to the previous state.
                    Console.WriteLine("deletion");
                    foreach (DataRow row1 in dt.Rows)
                    {
                        if (Convert.ToInt32(row1["user_id"]) == 9)
                        {
                            row1.Delete();
                        }
                    }
                    dt.RejectChanges();
                    //dt.AcceptChanges();
                    //int a=Convert.ToInt32(da.Update());
                    foreach (DataRow row1 in dt.Rows)
                    {
                        Console.WriteLine(row1["user_fullname"]);
                    }

                    //remove:The Remove method will remove the row from the collection
                    //foreach (DataRow row in dt.Select())
                    //{
                    //    if (Convert.ToInt32(row["user_id"]) == 9)
                    //    {
                    //        dt.Rows.Remove(row);
                    //    }
                    //}
                    //foreach (DataRow row1 in dt.Rows)
                    //{
                    //    Console.WriteLine(row1["user_fullname"]);
                    //}

                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    Console.WriteLine(row["user_email"] + " " + row["user_fullname"]);
                    //}

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
        }
    }
}
