using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    public interface Icar
    {
        void displayCar();
    }
    public class car
    {

        string name = "abc";
        string color = "blue";
        public void displayCar()
        {
            Console.WriteLine(name + " " + color);
        }
    }
}
