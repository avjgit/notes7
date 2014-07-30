using System;

//
// S stands for SRP (Single responsibility principle
//
class Customer
{
    public void Add()
    {
        try
        {
            // Database code goes here
        }
        catch (Exception ex)
        {
            System.IO.File.WriteAllText(@"c:\Error.txt", ex.ToString());
        }
    }
}

class Notes
{

    // reading http://www.codeproject.com/Articles/703634/SOLID-architecture-principles-using-simple-Csharp

    static void Main()
    {

        // S stands for SRP (Single responsibility principle
        // O stands for OCP (Open closed principle)
        // L stands for LSP (Liskov substitution principle)
        // I stands for ISP ( Interface segregation principle)
        // D stands for DIP ( Dependency inversion principle)
        Console.ReadLine();
    }

}