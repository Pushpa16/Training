using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstApproach
{
    internal class ChangeTracking
    {
        public static void Main(string[] args)

        {
            DBFirstApproachEntities1 db = new DBFirstApproachEntities1();

            Area myarea = new Area()
            {
                Name = "marukeri",
                CityId = 1,
                Pincode = "581320"
            };
            db.Areas.Add(myarea);
            Console.WriteLine("After adding");
            foreach (var tracker in db.ChangeTracker.Entries<Area>())
            {
                Console.WriteLine(tracker.State);
            }


            Area modified = db.Areas.Find(4);
            if (modified != null)
            {
                modified.Pincode = "581402";
                Console.WriteLine("After modification");
                foreach (var tracker in db.ChangeTracker.Entries<Area>())
                {
                    Console.WriteLine(tracker.State);
                }
            }



            Area deleted = db.Areas.Find(5);
            if (deleted != null)
            {
                db.Areas.Remove(deleted);
                Console.WriteLine("After deletion");
                foreach (var tracker in db.ChangeTracker.Entries<Area>())
                {
                    Console.WriteLine(tracker.State);
                }
            }

        }
    }
}
