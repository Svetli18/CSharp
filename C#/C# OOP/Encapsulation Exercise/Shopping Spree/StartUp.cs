namespace ShoppingSpree
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static void Main(string[] args)
        {
            string[] inputPeopleArgs = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            string[] inputProductArgs = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            HashSet<Person> people = new HashSet<Person>();
            AddPeople(inputPeopleArgs, people);

            HashSet<Product> products = new HashSet<Product>();
            AddProducts(inputProductArgs, products);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string personName = commandArgs[0];
                string productName = commandArgs[1];

                try
                {
                    Person person = people.FirstOrDefault(p => p.Name == personName);
                    Product product = products.FirstOrDefault(p => p.Name == productName);

                    if (person.Money < product.Cost)
                    {
                        throw new Exception($"{person.Name} can't afford {product.Name}");
                    }

                    person.AddProduct(product);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (Person person in people)
            {
                string bag = person.BagOfProducts.Any() ? $"{string.Join(", ", person.BagOfProducts)}" : "Nothing bought";

                Console.WriteLine($"{person.Name} - {bag}");
            }

        }

        private static void AddPeople(string[] inputPeopleArgs, HashSet<Person> people)
        {
            foreach (string currentArgs in inputPeopleArgs)
            {
                string[] personArgs = currentArgs
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);

                string name = personArgs[0];
                decimal money = decimal.Parse(personArgs[1]);

                Person person = new Person(name, money);
                people.Add(person);
            }
        }

        private static void AddProducts(string[] inputProductArgs, HashSet<Product> products)
        {
            foreach (var currentArgs in inputProductArgs)
            {
                string[] productArgs = currentArgs
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);

                string name = productArgs[0];
                decimal cost = decimal.Parse(productArgs[1]);

                Product product = new Product(name, cost);
                products.Add(product);
            }
        }
    }
}