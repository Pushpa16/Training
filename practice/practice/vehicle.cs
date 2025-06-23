using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace practice
{   
   
    public class vehicle: Ibike,Icar
    {

        public void displayBike()
        {
            Console.WriteLine("hi");
            
        }

        public void displayCar()
        {
            Console.WriteLine("hello");
        }
    }
}
