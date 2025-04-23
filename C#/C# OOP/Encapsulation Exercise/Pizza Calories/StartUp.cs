namespace PizzaCalories
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                string[] pizzaArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string pizzaName = pizzaArgs[1];
                Pizza pizza = new Pizza(pizzaName);

                string[] doughArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string flourType = doughArgs[1];
                string bakingTechnique = doughArgs[2];
                int doughGrams = int.Parse(doughArgs[3]);
                Dough dough = new Dough(flourType, bakingTechnique, doughGrams);
                pizza.Dough = dough;

                double totalCalories = 0;
                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] args = command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    //string product = args[0];

                    //if (product == "Pizza")
                    //{
                        
                    //}
                    //else if (product == "Dough")
                    //{

                    //}
                    //else if (product == "Topping")
                    //{
                        
                    //}

                    string type = args[1];
                    int grams = int.Parse(args[2]);
                    Topping topping = new Topping(type, grams);

                    pizza.AddTopping(topping);

                }

                Console.WriteLine($"{pizza.Name} - {pizza.PizzaTotalCalories():F2} Calories.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}