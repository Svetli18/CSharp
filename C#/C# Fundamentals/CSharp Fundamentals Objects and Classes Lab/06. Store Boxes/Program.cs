using System;
using System.Linq;
using System.Collections.Generic;

class Item
{
    public Item(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; set; }
    public decimal Price { get; set; }
}

class Box
{
    public Box(string serialNumber, Item item, int itemQuantity)
    {
        SerialNumber = serialNumber;
        Item = item;
        ItemQuantity = itemQuantity;
    }

    public string SerialNumber { get; set; }
    public Item Item { get; set; }
    public int ItemQuantity  { get; set; }
    public decimal PriceForABox => Item.Price * ItemQuantity;

}

internal class Program
{
    private static void Main(string[] args)
    {
        List<Box> boxes = new List<Box>();

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] commandArguments = command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string currentBoxSerialNumber = commandArguments[0];
            string currentItemName = commandArguments[1];
            int currentBoxItemQuantity = int.Parse(commandArguments[2]);
            decimal currentItemPrice = decimal.Parse(commandArguments[3]);

            Item item = new Item(currentItemName, currentItemPrice);
            Box box = new Box(currentBoxSerialNumber, item, currentBoxItemQuantity);

            boxes.Add(box);
        }

        boxes = boxes.OrderByDescending(b => b.PriceForABox).ToList();

        foreach (var box in boxes)
        {
            Console.WriteLine(box.SerialNumber);
            Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.ItemQuantity}");
            Console.WriteLine($"-- ${box.PriceForABox:F2}");
        }
    }
}