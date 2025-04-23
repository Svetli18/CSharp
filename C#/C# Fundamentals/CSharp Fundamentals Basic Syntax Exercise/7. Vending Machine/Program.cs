namespace VendingMachine
{
    using System;
    using System.Xml;

    internal class Program
    {
        private static void Main(string[] args)
        {
            decimal myMoney = 0;

            string startCommand;
            while ((startCommand = Console.ReadLine()) != "Start")
            {

                decimal coin = decimal.Parse(startCommand);

                if (coin == 0.1m || coin == 0.2m || coin == 0.5m
                    || coin == 1m || coin == 2m)
                {
                    myMoney += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }

            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {

                if (command == "Nuts")
                {
                    if (2.0m <= myMoney)
                    {
                        myMoney -= 2.0m;
                        Console.WriteLine($"Purchased {command}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (command == "Crisps")
                {
                    if (1.5m <= myMoney)
                    {
                        myMoney -= 1.5m;
                        Console.WriteLine($"Purchased {command}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (command == "Coke")
                {
                    if (1.0m <= myMoney)
                    {
                        myMoney -= 1.0m;
                        Console.WriteLine($"Purchased {command}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (command == "Soda")
                {
                    if (0.8m <= myMoney)
                    {
                        myMoney -= 0.8m;
                        Console.WriteLine($"Purchased {command}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (command == "Water")
                {
                    if (0.7m <= myMoney)
                    {
                        myMoney -= 0.7m;
                        Console.WriteLine($"Purchased {command}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                
            }

            Console.WriteLine($"Change: {myMoney:f2}");

        }
    }
}