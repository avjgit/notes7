using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_tutorialspoint
{
    class Program
    {
        static void Main(string[] args)
        {
            // what? dynamic types?
            dynamic x = 20;
            x = "a";

            // public, private
            // protected - available for children only
            // internal - available to other in same assembly
            Console.ReadLine();

            //The Null Coalescing Operator (??)
            double? num1 = null;
            double num3 = num1 ?? 1;
        }
    }
}
