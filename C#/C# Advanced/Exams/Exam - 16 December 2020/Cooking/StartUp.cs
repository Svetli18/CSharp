namespace Cooking
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> ingredients = new Stack<int>(
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            SortedDictionary<string, int> bakingData = new SortedDictionary<string, int>();

            bakingData["Bread"] = 0;
            bakingData["Cake"] = 0;
            bakingData["Pastry"] = 0;
            bakingData["Fruit Pie"] = 0;

            while (liquids.Any() && ingredients.Any())
            {
                int currValue = liquids.Peek() + ingredients.Peek();

                if (currValue == 25)
                {
                    bakingData["Bread"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (currValue == 50)
                {
                    bakingData["Cake"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (currValue == 75)
                {
                    bakingData["Pastry"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (currValue == 100)
                {
                    bakingData["Fruit Pie"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Push(ingredients.Pop() + 3);
                }

            }

            if (0 < bakingData["Bread"] &&
                0 < bakingData["Cake"] &&
                0 < bakingData["Pastry"] &&
                0 < bakingData["Fruit Pie"])
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            string resultLiquids = liquids.Any() ? string.Join(", ", liquids) : "none";
            Console.WriteLine($"Liquids left: {resultLiquids}");

            string resultIngredients = ingredients.Any() ? string.Join(", ", ingredients) : "none";
            Console.WriteLine($"Ingredients left: {resultIngredients}");

            foreach (var kvp in bakingData)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

        }
    }
}
