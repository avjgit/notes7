using System;

class GlazerCalc
{
    static void Main()
    {
        // Console.Write("Enter width: ");
        string widthString = "1"; //Console.ReadLine();
        double width = double.Parse(widthString);

        // Console.Write("Enter height: ");
        string heightString = "2"; //Console.ReadLine();
        double height = double.Parse(heightString);

        const double feetFromMeter = 3.25;
        const int verticalBars = 2;
        const int horizontalBars = 2;
        double woodLength = (width * horizontalBars + height * verticalBars) * feetFromMeter;

        const int glasses = 1;
        double glassArea = glasses * width * height;

        Console.WriteLine("The length of wood is " + woodLength + " feet.");
        Console.WriteLine("The area of glass is " + glassArea + " square meters.");

        string x;
        // x = "\x0041BCDE\a";
        x = "\x0041BCDE\a";
        Console.WriteLine(x);
        x = @"\x0041BCDE\a - is good for specially formatted strings";
        Console.WriteLine(x);
        x = @"also
        for strings
        with layout";
        Console.WriteLine(x);

        // float myFloat;
        // myFloat = (float)3.4; // hey, 3.4 double; casting required
        // myFloat = 4.5f; // or with "f" in the end

        int j = 3, i = 2;

        float ints_fraction = j / i;
        Console.WriteLine ("ints fraction is {0}", ints_fraction); //1

        float float_fraction = (float)j / (float)i;
        Console.WriteLine ("float fraction is {0}", float_fraction); //1.5

        // precision, number of digits output
        int some_int = 150;
        double some_double = 12345.345678;
        Console.WriteLine("i: {0:0000.00}, f: {1:0.0000}", some_int, some_double);
        Console.WriteLine("i: {0:#,##0} f: {1:##,##0.00}", some_int, some_double ); // # is "put a digit if you have one"

        // layouts
        Console.WriteLine ( "i: {0,10:0} f: {1,15:0.00}", some_int, some_double) ;
        Console.WriteLine ( "i: {0,10:0} f: {1,15:0.00}", 0, 0 ) ;
        // left justified
        Console.WriteLine ( "i: {0,-10:0} f: {1,-15:0.00}", some_int, some_double) ;
        Console.WriteLine ( "i: {0,-10:0} f: {1,-15:0.00}", 0, 0 ) ;












        Console.ReadLine();
    }
}