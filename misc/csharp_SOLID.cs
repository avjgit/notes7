using System;
using System.Collections.Generic;

// each class should have Single responsibility
///////////////////////////////////////////////////////////////////////////////
class FileLogger : ILogger
{
    public void Handle(string error)
    {
        System.IO.File.WriteAllText(@"c:\Error.txt", error);
    }
}

partial class Customer : IDiscountable, IDatabase
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

interface IDatabase
{
    void Add();
    // void Read(); // bad
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

// Interface segragation
///////////////////////////////////////////////////////////////////////////////
interface IDatabaseReadable : IDatabase
{
    void Read();
}

class CustomerWithReadRights : IDatabaseReadable
{
    public void Add()
    {
        Customer c = new Customer();
        c.Add();
    }

    public void Read()
    {
        // some logic here
    }
}

// Dependency inversion
///////////////////////////////////////////////////////////////////////////////
interface ILogger
{
    void Handle(string error);
}

class EventViewerLogger : ILogger
{
    public void Handle(string error)
    {
        // log error to event viewer
    }
}

class EmailLogger : ILogger
{
    public void Handle(string error)
    {
        // send error via email
    }
}

partial class Customer
{
    private ILogger l;

    public Customer()
    {

    }

    // now it's responsibility of client, which consumes Customer, ...
    // ... to decide which logger to use
    public Customer(ILogger logger_to_use)
    {
        l = logger_to_use;
    }

    public virtual void Add(int excHandle)
    {
        try
        {

        }
        catch(Exception ex)
        {
            if (excHandle == 1)
            {
                l = new EventViewerLogger();
            }
            else
            {
                l = new EmailLogger();
            }
            l.Handle(ex.ToString());
        }
    }
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

        // DI: client will inject the Logger object
        Customer myCustomer = new Customer(new EmailLogger());

        Console.ReadLine();
    }
}