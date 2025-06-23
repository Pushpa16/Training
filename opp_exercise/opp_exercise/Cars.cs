using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_exercise
{
    public class Cars
    {
        private string brand;
        private int year;
        public Cars(string bName, int mYear)
        {
            brand = bName;
            year = mYear;
        }
        public void DisplayInfo()
        {
            Console.WriteLine(  brand +" "+ year );      
        }
    }
}
