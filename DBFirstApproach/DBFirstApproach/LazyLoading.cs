using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstApproach
{
    internal class LazyLoading
    {
        public static void Main(string[] args)
        {
            DBFirstApproachEntities1 db=new DBFirstApproachEntities1 ();
            foreach(City c in db.Cities)
            {
                Console.WriteLine("{0}\t{1}", c.CityId, c.Name);
                foreach(Area a in c.Areas)
                {
                    Console.WriteLine("{0}", a.Name);
                }
            }
        }

    }
}
