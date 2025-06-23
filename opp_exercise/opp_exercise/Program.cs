using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_exercise
{
    public abstract class DBZ
    {
        public string Name { get; set; }
        public string Species { get; set; }

        public DBZ(string name, string race)
        {

            Name = name;
            Species = race;
        }
        public abstract void Character();

       

        static void Main(string[] args)
        {

            string a;
            Console.WriteLine("Enter value of a");
            Console.ReadLine();




        }  }
    
}
