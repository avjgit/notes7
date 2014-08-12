// http://www.robmiles.com/c-yellow-book/

using System;

public enum AccountState
{
    New,
    Active,
    UnderAudit,
    Frozen,
    Closed
}

public interface IAccount
{
    void Pay ( decimal amount );
    bool Withdraw ( decimal amount );
    decimal Balance ();
    string RudeLetterString();
    string GetName();
}

public interface IPrintable
{
    void Print();
}

public sealed class BabyAccount : CustomerAccount, IAccount
{
    public override bool Withdraw(decimal amount)
    {
        if (amount > 10)
        {
            return false;
        }

        return base.Withdraw(amount);
    }
}

public class CustomerAccount : Account, IPrintable
{
    // changed private to protected so child classes could access it
    protected decimal balance = 0;

    public CustomerAccount() :
        base ()
    {

    }

    public CustomerAccount(string name, string address) :
        base (name, address)
    {

    }

    public void Print()
    {
        Console.WriteLine("printing");
    }

    public override string RudeLetterString()
    {
        return "you are overdrawn";
    }

    // The keyword virtual means “I might want to make another version of this method in
    // a child class”. You don’t have to override the method, but if you don’t have the word
    // present, you definitely can’t.
    // public virtual bool Withdraw(decimal amount)
    // {
    //     if (balance < amount)
    //         return false;

    //     balance -= amount;
    //     return true;
    // }


    public decimal RipoffFee(decimal balance)
    {
        if (balance < 0)
            return 100;
        else
            return 1;
    }
}

public abstract class Account
{
    public AccountState state;
    public string name;
    public string address;
    public int accountNumber;
    private decimal balance;
    public int overdraft;

    public string GetName()
    {
        return name;
    }

    public Account()
    {
        Console.WriteLine("shiny new account created");
    }

    public Account(string inName, string inAddress, decimal inBalance)
    {
        name = inName;
        address = inAddress;
        balance = inBalance;
    }

    public Account(string inName, string inAddress) :
        this (inName, inAddress, 0)
    {
    }

    public Account(string inName) :
        this (inName, "unknown", 0)
    {
    }

    // public Account (string inName, string inAddress)
    // {
    //     if ( SetName ( inName ) == false ) {
    //        throw new Exception ( "Bad name " + inName) ;
    //     }
    //     if ( SetAddress ( inAddress) == false ) {
    //         throw new Exception ( "Bad address" + inAddress) ;
    //     }
    // }

    // static does not mean "can not be changed"
    // static means - member of a class, not of an instance
    public static int InterestRate;

    private static decimal minIncome;
    private static decimal minAge;

    public static bool AccountAllowed (decimal income, int age)
    {
        return age >= minAge && income >= minIncome;
    }

    public virtual bool Withdraw(decimal amount)
    {
        if (balance < amount)
            return false;

        balance -= amount;
        return true;
    }

    public void Pay(decimal amount)
    {
        balance += amount;
    }

    public decimal Balance()
    {
        return balance;
    }

    // method body is not provided in the class.
    // we're requiring child classes to do so.
    // one abstract method makes whole class abstract
    // ('cause you can't now create instance of this class
    // ('cause - instance would not know what to do if this method would called))
    public abstract string RudeLetterString();

    // abstract classes differ from interfaces in that way,
    // that they may have some methods with full body

    // Interfaces let me describe what each component can do.
    // Class hierarchies let me re-use code inside those components.

    public override string ToString()
    {
        return "Name: " + name + " balance: " + balance;
    }
};

/////////////////////////
// Delegates
public delegate decimal CalculateFee(decimal balance);

public interface IBank
{
    IAccount FindAccount (string name);
    bool StoreAccount(IAccount account);
}

class ArrayBank : IBank
{
    private IAccount [] accounts;

    public ArrayBank(int size)
    {
        accounts = new IAccount [size];
    }

    public IAccount FindAccount(string name)
    {
        for (int i = 0; i < accounts.Length; i++)
        {
            if (accounts[i] == null)
                continue;

            if (accounts[i].GetName() == name)
                return accounts[i];
        }
        return null;
    }

    public bool StoreAccount(IAccount account)
    {
        for(int i = 0; i < accounts.Length; i++)
        {
            if (accounts[i] == null)
            {
                // if there is no accounts stored yet
                accounts[i] = account; // save the referece to account
                return true;
            }
        }
        return false;
    }
}

class Bank
{

    static void Main()
    {
        int MAX_CUSTOMERS = 50;
        Account [] bank = new Account[MAX_CUSTOMERS];

        Account RobsAccount = new CustomerAccount{
            state = AccountState.Active,
            name = "Rob Miles",
            address = "The House",
            accountNumber = 1234,
            // balance = 0,
            overdraft = -100
        };

        Console.WriteLine("Just created account for {0}.", RobsAccount.name);

        Account a2 = new CustomerAccount("Joe", "house");

        Console.WriteLine(RobsAccount.ToString());

        /////////////////////////
        // Delegates
        // public delegate decimal CalculateFee(decimal balance);
        CustomerAccount c = new CustomerAccount();
        Console.WriteLine(c.RipoffFee(1));

        CalculateFee calc = new CalculateFee(c.RipoffFee);
        decimal fees = calc(99);
        Console.WriteLine(fees);

        // Def:
        // A delegate is a type-safe referece to a method in a class
        // calc = new CalculateFee(c.FriendlyFee); // as well

        IBank abank = new ArrayBank(50);

        Console.ReadLine();
    }
}