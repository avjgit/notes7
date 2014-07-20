using System;

class GlazerCalc
{
    static void Main()
    {
        Console.Write("Enter width: ");
        string widthString = Console.ReadLine();
        double width = double.Parse(widthString);

        Console.Write("Enter height: ");
        string heightString = Console.ReadLine();
        double height = double.Parse(heightString);

        const double feetFromMeter = 3.25;
        const int verticalBars = 2;
        const int horizontalBars = 2;
        double woodLength = (width * horizontalBars + height * verticalBars) * feetFromMeter;

        const int glasses = 1;
        double glassArea = glasses * width * height;

        Console.WriteLine("The length of wood is " + woodLength + " feet.");
        Console.WriteLine("The area of glass is " + glassArea + " square meters.");
        Console.ReadLine();
    }
}