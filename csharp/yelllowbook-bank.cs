using System;

enum AccountState
{
    New,
    Active,
    UnderAudit,
    Frozen,
    Closed
}

struct Account
{
    public AccountState state;
    public string name;
    public string address;
    public int accountNumber;
    private decimal balance;
    public int overdraft;

    public bool Withdraw(decimal amount)
    {
        if (balance < amount)
            return false;

        balance -= amount;
        return true;
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
            balance = 0,
            overdraft = -100
        };

        Console.WriteLine("Just created account for {0}.", RobsAccount.name);




        Console.ReadLine();
    }
}