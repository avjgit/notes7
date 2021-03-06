﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using my_extensions;
using System.IO;

namespace cs_gotchas
{
    class Program
    {
        //source: http://www.toptal.com/c-sharp/top-10-mistakes-that-c-sharp-programmers-make
        static Point point3;

        #pragma warning disable 649
        static Pen pen3;
        #pragma warning restore 649


        static void Main(string[] args)
        {
            
            ////////////////////////////////////////////////////////////////// ref vs values
            Point point1 = new Point(10, 20);
            Point point2 = point1;
            point2.X = 30; //ok, still 10
            Console.WriteLine(point1.X);

            Pen pen1 = new Pen(Color.Black);
            Pen pen2 = pen1;
            pen2.Color = Color.Red;
            Console.WriteLine(pen1.Color); //red!

            //point1 and point2 each contain their own copy of a Point object, 
            //whereas pen1 and pen2 contain references to the same Pen object.
            //The answer is to look at the definitions of the object types
            //public struct Point { … }     // defines a “value” type
            //public class Pen { … }        // defines a “reference” type   

            change_pen(pen1);
            Console.WriteLine(pen1.Color);

            change_point(point1);
            Console.WriteLine(point1.X);

            ////////////////////////////////////////////////////////////////// defaults
            Console.WriteLine(pen3 == null);    // ok, true
            Console.WriteLine(point3 == null);  // false! 'cause (0;0)
            Console.WriteLine(point3.IsEmpty);  //true
            point3.X = 12;
            Console.WriteLine(point3.IsEmpty);  //false; ok
            point3.X = 0;
            Console.WriteLine(point3.IsEmpty);  //hm. ok, (0,0) is empty
            //When you’re checking to see if a variable has been initialized or not, 
            //make sure you know what value an uninitialized variable of that type will have by default 
            //and don’t rely on it being null..   


            ////////////////////////////////////////////////////////////////// wrong string comparison
            // don't use ==, use public bool Equals(string value, StringComparison comparisonType);
            string s = "strasse";

            // outputs False:
            Console.WriteLine("comparisons:");
            Console.WriteLine(s == "straße");
            Console.WriteLine(s.Equals("straße"));
            Console.WriteLine(s.Equals("straße", StringComparison.Ordinal));
            Console.WriteLine(s.Equals("Straße", StringComparison.CurrentCulture));
            Console.WriteLine(s.Equals("straße", StringComparison.OrdinalIgnoreCase));

            // outputs True:
            Console.WriteLine(s.Equals("straße", StringComparison.CurrentCulture));
            Console.WriteLine(s.Equals("Straße", StringComparison.CurrentCultureIgnoreCase));

            // compare texts coming from user via CurrentCulture
            // compare texts coming code via OrdinalCulture

            ////////////////////////////////////////////////////////////////// foreach vs LinQ
            decimal total = 0;
            
            List<Account> myAccounts = new List<Account>();

            foreach (Account account in myAccounts)
            {
                if (account.Status == "Active")
                {
                    total += account.Balance;
                }
            }

            total = (from account in myAccounts
                    where account.Status == "active"
                    select account.Balance).Sum();

            ////////////////////////////////////////////////////////////////// extension methods
            string s1 = "hi there extension methods";
            Console.WriteLine(s1.WordCount());
            ////////////////////////////////////////////////////////////////// freeing up memory
            //using (FileStream f = File.OpenRead("foo.txt")) // "using" will call Dispose() at end of block
            //{
            //    f.Read(buffer, 0, 100);
            //}
            ////////////////////////////////////////////////////////////////// exception handling
            // METHOD 1:
            // Throws an exception if account can't be cast to SavingsAccount
            //SavingsAccount savingsAccount = (SavingsAccount)account;

            // METHOD 2:
            // Does NOT throw an exception if account can't be cast to
            // SavingsAccount; will just set savingsAccount to null instead
            //SavingsAccount savingsAccount = account as SavingsAccount;

            //int.Parse();     // throws exception if argument can’t be parsed
            //int.TryParse();  // returns a bool to denote whether parse succeeded

            //IEnumerable.First();           // throws exception if sequence is empty
            //IEnumerable.FirstOrDefault();  // returns null/default value if sequence is empty
            ////////////////////////////////////////////////////////////////// stick to 0 errors, 0 warnings
            //there may be times when your code will look a bit fishy to the compiler, 
            //even though it is exactly how you intended it to be. In those very rare cases, 
            //use #pragma warning disable [warning id] around only the code that triggers the warning
            ////////////////////////////////////////////////////////////////// 

            Console.ReadLine();
        }

        public static void change_pen(Pen p)
        {
            p.Color = Color.Green;
        }
        public static void change_point(Point p)
        {
            p.X = 40;
        }


        public static byte[] buffer { get; set; }
    }
}
