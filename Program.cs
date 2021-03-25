using System;
using System.Collections.Generic;

namespace vending_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount();
            
            account.Deposit(400);

            var vendingMachine = new VendingMachine();

            vendingMachine.Run();

            // Console.WriteLine(account.Balance());
        }
    }
}