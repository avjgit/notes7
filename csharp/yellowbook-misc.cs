using System;

class Point
{
    public int x;
    public int y;

    public override bool Equals(object obj)
    {
        Point comparable = (Point) obj;
        return comparable.x == x && comparable.y == y;
    }
}

class YellowBook
{
    public static void Main()
    {
        Point shipPosition = new Point();
        shipPosition.x = 1;
        shipPosition.y = 2;

        Point misslePosition = new Point();
        misslePosition.x = 1;
        misslePosition.y = 2;

        if (misslePosition.Equals(shipPosition))
            Console.WriteLine("Bang!");

        Console.ReadLine();
    }
}