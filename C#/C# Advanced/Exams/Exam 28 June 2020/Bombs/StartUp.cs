namespace Bombs
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Queue<int> bombEfect = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> bombCasings = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            SortedDictionary<string, int> bombsData = new SortedDictionary<string, int>();

            bombsData["Datura Bombs"] = 0;
            bombsData["Cherry Bombs"] = 0;
            bombsData["Smoke Decoy Bombs"] = 0;

            bool isBombPouchSuccess = false;

            while (bombEfect.Any() && bombCasings.Any())
            {
                int currentSum = bombEfect.Peek() + bombCasings.Peek();

                if (currentSum % 40 == 0 || currentSum % 60 == 0 || currentSum % 120 == 0)
                {
                    bombEfect.Dequeue();
                    bombCasings.Pop();

                    if (currentSum == 40)
                    {
                        bombsData["Datura Bombs"]++;
                    }
                    else if (currentSum == 60)
                    {
                        bombsData["Cherry Bombs"]++;
                    }
                    else if (currentSum == 120)
                    {
                        bombsData["Smoke Decoy Bombs"]++;
                    }
                    if (3 <= bombsData["Datura Bombs"] &&
                        3 <= bombsData["Cherry Bombs"] &&
                        3 <= bombsData["Smoke Decoy Bombs"])
                    {
                        isBombPouchSuccess = true;
                        break;
                    }
                    continue;
                }

                bombCasings.Push(bombCasings.Pop() - 5);

            }

            if (isBombPouchSuccess)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            Console.Write("Bomb Effects: ");
            Console.WriteLine(bombEfect.Any() ? string.Join(", ", bombEfect) : "empty");
            Console.Write("Bomb Casings: ");
            Console.WriteLine(bombCasings.Any() ? string.Join(", ", bombCasings) : "empty");

            foreach (var kvp in bombsData)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
