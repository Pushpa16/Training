using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_exercise
{
    public class Student
    {
        private string name;
        private int roll_no;
        private int grade;
        public Student(string Sname, int Sroll_no, int Sgrade)
        {
            name = Sname;
            roll_no = Sroll_no;
            grade = Sgrade;
        }
        public void DisplayInfo()
        {
            Console.WriteLine(name+"  "+roll_no+"  "+grade);
        }
    }
}
