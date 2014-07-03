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
            //public struct Point { … }     // defines a “value” type
            //public class Pen { … }        // defines a “reference” type   

            change_pen(pen1);
            Console.WriteLine(pen1.Color);

            change_point(point1);
            Console.WriteLine(point1.X);

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
