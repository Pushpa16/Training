using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{    public interface Ibike
    {   
        void displayBike();
    }
    public class bike
    {
        string name = "xyz";
        string color = "black";
        public void displayBike()
        {
            Console.WriteLine(name + " " + color);
        }
    }
}
