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

class Person
{
    private int age;

    public int GetAge()
    {
        return this.age;
    }

    public void SetAge(int age_)
    {
        if (age_ > 0 && age_ <= 120)
            this.age = age_;
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

        string s1 = "something";
        string s2 = s1;
        s2 = "different";
        Console.WriteLine(s1);

        Person p = new Person();
        // p.age = -1; //wrong! public property allows it
        p.SetAge(1);

        Console.ReadLine();
    }
}