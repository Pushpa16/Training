using DBFirstApproach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstApproach
{
    internal class CRUD
    {
        static void Main(string[] args)
        {
            DBFirstApproachEntities1 db = new DBFirstApproachEntities1();
            Area myarea = new Area();

            int opt;
            do
            {
                Console.WriteLine("1.New Record\n 2.Update\n 3.Delete Record\n 4.Display");
                Console.WriteLine("Enter your option");
                opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        Console.WriteLine("enter area name,city id,pincode");
                        myarea.Name = Console.ReadLine();
                        myarea.CityId = Convert.ToInt32(Console.ReadLine());
                        myarea.Pincode = Console.ReadLine();
                        db.Areas.Add(myarea);
                        db.SaveChanges();
                        break;
                    case 2:
                        Console.WriteLine("Enter the Id to update");
                        int id = Convert.ToInt32(Console.ReadLine());
                        myarea = db.Areas.Find(id);
                        if (myarea == null)
                        {
                            Console.WriteLine("Invalid Id ");
                        }
                        else
                        {
                            Console.WriteLine("enter area name,city id,pincode");
                            myarea.Name = Console.ReadLine();
                            myarea.CityId = Convert.ToInt32(Console.ReadLine());
                            myarea.Pincode = Console.ReadLine();
                            db.SaveChanges();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter the Id to delete");
                        int id1 = Convert.ToInt32(Console.ReadLine());
                        myarea = db.Areas.Find(id1);
                        if (myarea == null)
                        {
                            Console.WriteLine("Invalid Id ");
                        }
                        else
                        {
                            db.Areas.Remove(myarea);
                            db.SaveChanges();
                        }
                        break;
                    case 4:
                        foreach (Area a in db.Areas)
                        {
                            Console.WriteLine("{0}\t{1}\t{2}\t{3}", a.AreaId, a.Name, a.Pincode, a.City.Name);
                        }
                        //if we are doing with the help of stored procedure
                        //foreach (Area a in db.SelectArea())
                        //{
                        //    Console.WriteLine("{0}\t{1}\t{2}\t{3}", a.AreaId, a.Name, a.Pincode, a.City.Name);
                        //}
                        break;
                    default:
                        Console.WriteLine("enter the valid option");
                        break;
                }

            } while (opt != 5);
        }
    }
      
 }
