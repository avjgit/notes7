using System;

enum AccountState
{
    New,
    Active,
    UnderAudit,
    Frozen,
    Closed
}

public interface IAccount
{
    void PayInFunds ( decimal amount );
    bool WithdrawFunds ( decimal amount );
    decimal GetBalance ();
}

class Account
{
    public AccountState state;
    public string name;
    public string address;
    public int accountNumber;
    private decimal balance;
    public int overdraft;

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

    public bool Withdraw(decimal amount)
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
};

class Bank
{
    static void Main()
    {
        int MAX_CUSTOMERS = 50;
        Account [] bank = new Account[MAX_CUSTOMERS];

        Account RobsAccount = new Account{
            state = AccountState.Active,
            name = "Rob Miles",
            address = "The House",
            accountNumber = 1234,
            // balance = 0,
            overdraft = -100
        };

        Console.WriteLine("Just created account for {0}.", RobsAccount.name);




        Console.ReadLine();
    }
}