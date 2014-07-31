using System;
using System.Collections.Generic;

// each class should have Single responsibility
///////////////////////////////////////////////////////////////////////////////
class FileLogger
{
    public void Handle(string error)
    {
        System.IO.File.WriteAllText(@"c:\Error.txt", error);
    }
}

partial class Customer : IDiscountable, IAddable
{
    private FileLogger logger = new FileLogger();

    public virtual void Add()
    {
        try
        {
            // some code goes here
        }
        catch (Exception ex)
        {
            // System.IO.File.WriteAllText(@"c:\Error.txt", ex.ToString());
            // here Customer class did what it is not supposed to do - logging.
            // It should be handled by some insance of Logging class
            logger.Handle(ex.ToString());
        }
    }
}

// class should be Open for extensions, Closed for modifications
///////////////////////////////////////////////////////////////////////////////
partial class Customer
{
    public int CustType {get; set;}

    // problem was: for each new type, new IF should be added -
    // .. means, class should be modified
    // public double getDiscount(double TotalSales)
    // {
        // if (_CustType == 1)
        // {
        //     return TotalSales - 100;
        // }
        // else
        // {
        //     return TotalSales - 50;
        // }
    // }
    public virtual double getDiscount(double TotalSales)
    {
        return TotalSales;
    }
}

// instead of modification, extensions (derived classes) should be created
class SilverCustomer : Customer
{
    public override double getDiscount(double TotalSales)
    {
        return base.getDiscount(TotalSales) - 50;
    }
}

class GoldCustomer : Customer
{
    public override double getDiscount(double TotalSales)
    {
        return base.getDiscount(TotalSales) - 100;
    }
}

// Liskov substitution principle: parent should be able to replace child object
///////////////////////////////////////////////////////////////////////////////

interface IDiscountable
{
    double getDiscount(double TotalSales);
}

interface IAddable
{
    void Add();
}


// to handle enquiries (like emails) - which are not customers yet
class Enquiry : IDiscountable
{
    public double getDiscount(double TotalSales)
    {
        return TotalSales - 5;
    }

    // this method was here when Enquity was inheriting from Customer
    // public override void Add()
    // {
    //     throw new Exception("Not allowed");
    // }
}




class Notes
{
    // reading http://www.codeproject.com/Articles/703634/SOLID-architecture-principles-using-simple-Csharp

    static void Main()
    {
        // S stands for SRP (Single responsibility principle)
        // O stands for OCP (Open closed principle)
        // L stands for LSP (Liskov substitution principle)
        // I stands for ISP (Interface segregation principle)
        // D stands for DIP (Dependency inversion principle)

        // illustration for Liskov
        List<Customer> customers = new List<Customer>();
        customers.Add(new SilverCustomer());
        customers.Add(new GoldCustomer());
        // customers.Add(new Enquiry()); // now we catch this error at compile time

        foreach (Customer c in customers)
        {
            // this will throw an error out of Enquiry
            // here parent could not replace child
            c.Add();
        }

        Console.ReadLine();
    }
}