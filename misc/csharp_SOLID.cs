using System;

//
// S stands for SRP (Single responsibility principle
//
class FileLogger
{
    public void Handle(string error)
    {
        System.IO.File.WriteAllText(@"c:\Error.txt", error);
    }
}
class Customer
{
    private FileLogger logger = new FileLogger();

    public virtual void Add()
    {

        try
        {
            // Database code goes here
        }
        catch (Exception ex)
        {
            // here Customer class does what it is not supposed to do - logging.
            // It should be handled by some insance of Logging class
            // System.IO.File.WriteAllText(@"c:\Error.txt", ex.ToString());
            logger.Handle(ex.ToString());
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