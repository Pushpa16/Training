using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//example of transcation using distributed database
//In order to create and use distributed transactions, first of all, we need to create an instance of the TransactionScope class. It is also
//possible to open multiple database connections within the same transaction scope. The transaction scope will decide whether to create a local transaction or
//a distributed transaction The transaction scope automatically converts a local transaction to a distributed transaction if required.

namespace Transcation1
{
    internal class Program
    {
        static void Main(string[] args)
        {


        }
    }
}
