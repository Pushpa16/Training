using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstApproach
{
    internal class rawsqlqueries
    {
        public static void Main(string[] args)
        {
            DBFirstApproachEntities1 db = new DBFirstApproachEntities1();

            //writing SQL for entities
            Console.WriteLine("enity");
            //IEnumerable<Area> areaList= db.Areas.SqlQuery("Select * from Area Where CityId=2");
            //foreach(Area a in areaList )
            //{
            //    Console.WriteLine(a.Name);
            //}
            //example using parameterised query
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@id";
            param.Value = 2;
            IEnumerable<Area> areaList = db.Areas.SqlQuery("Select * from Area Where CityId=@id", param);
            foreach (Area a in areaList)
            {
                Console.WriteLine(a.Name);
            }

            //writing SQL for non-entities
            Console.WriteLine("Non-enity");
            var myAreaList = db.Database.SqlQuery<Nonentity>("select Name,Pincode from Area");
            foreach (Nonentity n in myAreaList)
            {
                Console.WriteLine(n.Name, n.Pincode);
            }

            //send raw command to the database
            Console.WriteLine("Raw Command");
            int rowaffected = db.Database.ExecuteSqlCommand("Update Area set Pincode='581404' where AreaId=5");
            if (rowaffected == 1)
            {
                Console.WriteLine("Record Updated");
            }
            else
            {
                Console.WriteLine("Invalid Id");
            }
        }
    }
}
