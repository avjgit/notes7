using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace cs_gotchas
{
    class Program
    {
        static Point point3;
        static Pen pen3;

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

    }
}
