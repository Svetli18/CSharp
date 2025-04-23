using System;
using System.Linq;
using System.Collections.Generic;

class Person
{

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        Products = new List<Product>();
    }

    public string Name { get; set; }
    public decimal Money { get; set; }
    public List<Product> Products { get; set; }

    public override string ToString()
    {
        return $"{Name} - ";
    }
}

class Product
{
    public Product(string name, decimal cost)
    {
        Name = name;
        Cost = cost;
    }

    public string Name { get; set; }
    public decimal Cost { get; set; }

    public override string ToString()
    {
        return Name;
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        List<Product> products = new List<Product>();

        string[] allPeople = Console.ReadLine()
            .Split(';', StringSplitOptions.RemoveEmptyEntries);

        string[] allProducts = Console.ReadLine()
            .Split(';', StringSplitOptions.RemoveEmptyEntries);

        AddPeople(people, allPeople);
        AddProducts(products, allProducts);

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] cmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string namePerson = cmd[0];
            string nameProduct = cmd[1];

            Person person = people.FirstOrDefault(p => p.Name == namePerson);
            Product product = products.FirstOrDefault(p => p.Name == nameProduct);

            if (person.Money < product.Cost)
            {
                Console.WriteLine($"{person.Name} can't afford {product.Name}");
                continue;
            }

            Console.WriteLine($"{person.Name} bought {product.Name}");
            person.Products.Add(product);
            person.Money -= product.Cost;
        }

        List<Person> peopleWithProducts = people.Where(p => p.Products.Count > 0).ToList();
        List<Person> peopleWithoutProducts = people.Where(p => p.Products.Count == 0).ToList();

        if (peopleWithProducts != null)
        {
            foreach (var person in peopleWithProducts)
            {
                Console.Write(person);
                Console.WriteLine(string.Join(", ", person.Products));
            }
        }

        if (0 < peopleWithoutProducts.Count)
        {
            foreach (var person in peopleWithoutProducts)
            {
                Console.WriteLine(person + "Nothing bought");
            }
        }
    }

    static void AddProducts(List<Product> products, string[] allProducts)
    {
        for (int i = 0; i < allProducts.Length; i++)
        {
            string[] currentProduct = allProducts[i]
                .Split('=', StringSplitOptions.RemoveEmptyEntries);
            string name = currentProduct[0];
            decimal cost = decimal.Parse(currentProduct[1]);

            Product product = new Product(name, cost);
            products.Add(product);
        }
    }

    static void AddPeople(List<Person> people, string[] allPeople)
    {
        for (int i = 0; i < allPeople.Length; i++)
        {
            string[] currentPerson = allPeople[i].Split('=');
            string name = currentPerson[0];
            decimal money = decimal.Parse(currentPerson[1]);

            Person person = new Person(name, money);
            people.Add(person);
        }
    }
}