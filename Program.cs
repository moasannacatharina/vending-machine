using System;
using System.Collections.Generic;

namespace vending_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount();
            account.Deposit(100);
            var vendingMachine = new VendingMachine(account);

            vendingMachine.Run();

            // Console.WriteLine(account.Balance());
        }
    }
}