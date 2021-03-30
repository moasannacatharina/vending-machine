using System;
using System.Collections.Generic;

namespace vending_machine
{
    public class VendingMachine
    {

        public List<VendingItem> VendingItems = new List<VendingItem>();
        public List<VendingItem> PurchasedVendingItems;
        public BankAccount Account;

        public VendingMachine(BankAccount account)
        {
            VendingItems.Add(new VendingItem("Snickers", 15));
            VendingItems.Add(new VendingItem("Eggs", 50));
            VendingItems.Add(new VendingItem("Ice Coffee", 25));
            VendingItems.Add(new VendingItem("Chips", 20));
            VendingItems.Add(new VendingItem("Olives", 30));
            VendingItems.Add(new VendingItem("Coca Cola", 25));
            VendingItems.Add(new VendingItem("Beer", 75));
            VendingItems.Add(new VendingItem("Birthday cake", 36)); 

            this.Account = account;
        }
       
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("Welcome to Moa's amazing Vending Machine!");
            Console.WriteLine();
            Console.ResetColor();
            
            var commands = new List<string>
            {
                "1",
                "2",
                "3",
                "Q",
            };

            while (true)
            {
                var command = GetCommand(commands);

                if (command == "1")
                {
                    var index = 1;
                    
                    if (VendingItems.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No items available :(");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("--Available items for purchase--");
                        Console.ResetColor();
                        foreach (var item in VendingItems)
                        {
                            Console.WriteLine($"{index++}] {item.ProductName}, ${item.Price}");
                        }
                    }
                    
                }

                if (command == "2")
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Which item would you like to purchase? "); 
                        Console.ResetColor();

                        var input = Console.ReadLine();
                        int.TryParse(input, out int number);

                        if (number > VendingItems.Count || number < 1)
                        {
                            Console.WriteLine("Item does not exist");
                        }
                        else
                        {
                            var selectedItem = VendingItems[number - 1];
                            Console.WriteLine($"You have selected {selectedItem.ProductName}");
                            Console.Write($"Do you wish to transfer ${selectedItem.Price} to the Vending Machine? y/n: ");

                            var answer = Console.ReadLine();

                            if (answer == "y")
                            {
                                if (Account.Balance() >= selectedItem.Price)
                                {
                                    Account.Withdraw(selectedItem.Price);
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine($"Successful transaction! Yay! You now have ${Account.Balance()} left. ");
                                    Console.WriteLine($"Enjoy your {selectedItem.ProductName.ToLower()}!");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    Console.Clear();
                                    
                                    PurchasedVendingItems.Add(VendingItems[number - 1]);
                                    VendingItems.Remove(VendingItems[number - 1]);
                                    break;
                                }

                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"You don't have enough money for this item, your balance is currently ${Account.Balance()}.");
                                Console.WriteLine("Please try again.");
                                Console.ResetColor();
                                Console.WriteLine();
                            }

                            if (answer == "n")
                            {
                                Console.WriteLine("Weird, but ok.");
                            }

                        }
                        
                    }

                }

                if (command == "3")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"You have ${Account.Balance()} on your account!");
                    Console.ResetColor();
                }

                if (command == "Q")
                {
                    Console.WriteLine("Sad to see you go :( Goodbye!");
                    break;
                }
            }
            
        }

        private string GetCommand(List<string> commands)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.ResetColor();
                
                Console.WriteLine("1] Display Vending Machine Items");
                Console.WriteLine("2] Purchase");
                Console.WriteLine("3] Check Bank Account");
                Console.WriteLine("Q] Quit");
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Which option would you like to select? ");
                Console.ResetColor();

                var input = Console.ReadLine();

                if (commands.Contains(input))
                {
                    Console.WriteLine();
                    Console.WriteLine("OK");
                    Console.WriteLine();

                    return input;
                }
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Option not found, please input a valid command.");
                Console.ResetColor();
            }
        }
    }
}