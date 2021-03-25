using System;
using System.Collections.Generic;

namespace vending_machine
{
    public class VendingMachine
    {

        public List<VendingItem> VendingItems = new List<VendingItem>();
        private List<string> ItemIds = new List<string>();
        public BankAccount Account;

        public VendingMachine()
        {
            VendingItems.Add(new VendingItem("A1","Snickers", 15));
            VendingItems.Add(new VendingItem("A2","Eggs", 50));
            VendingItems.Add(new VendingItem("B1","Lion", 25));
            VendingItems.Add(new VendingItem("B2","Chips", 20));
            VendingItems.Add(new VendingItem("C1","Olives", 30));
            VendingItems.Add(new VendingItem("C2","Coca Cola", 25));
            VendingItems.Add(new VendingItem("D1","Beer", 75));
            VendingItems.Add(new VendingItem("D2","Birthday cake", 36));
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
                "Q",
            };

            while (true)
            {
                var command = GetCommand(commands);

                if (command == "1")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("--Available items for purchase--");
                    Console.ResetColor();

                    foreach (var item in VendingItems)
                    {
                        Console.WriteLine($"{item.Id}] {item.ProductName}, ${item.Price}");
                    }
                }

                if (command == "2")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Which item would you like to purchase? "); 
                    Console.ResetColor();
                    var input = Console.ReadLine();
                    if (input != "") 
                    {
                        foreach (var item in VendingItems)
                        {
                            if (input == item.Id)
                            {
                                Console.WriteLine($"You have selected {item.ProductName}! Please insert ${item.Price}");
                                
                            }
                        }
                        Console.WriteLine("Item not found");
                        continue;
                        
                    }
                }

                if (command == "Q")
                {
                    Console.WriteLine("Sad to see you go :( Goodbye!");
                    break;
                }
            }
            
        }

        public string GetCommand(List<string> commands)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.ResetColor();
                Console.WriteLine("1] Display Vending Machine Items");
                Console.WriteLine("2] Purchase");
                Console.WriteLine("Q] Quit");
                
                Console.Write("What option do you want to select? ");

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