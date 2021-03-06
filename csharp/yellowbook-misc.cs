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

    public int Age
    {
        set
        {
            if (value > 0 && value <= 120)
                this.age = value;
        }

        get
        {
            return this.age;
        }
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
        // p.SetAge(1);
        p.Age = 1; // calling property, not a field

        // NB: If there is a situation where a property assignment can fail it is better to use a method, not a property
        // since method can return bool for success:
        // public bool SetAge( int inAge )
        // {
        // if ( (inAge > 0) && (inAge < 120) )
        // {
        // this.age = inAge;
        // return true;
        // }
        // return false;
        // }

        Console.ReadLine();
    }
}