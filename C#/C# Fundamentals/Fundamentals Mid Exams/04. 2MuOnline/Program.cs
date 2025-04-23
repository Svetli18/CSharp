using System.Threading;

internal class Program
{
    private static void Main(string[] args)
    {
        var rooms = Console.ReadLine().Split('|',StringSplitOptions.RemoveEmptyEntries);

        int health = 100;
        int xrp = 0;
        int room = 0;
        bool winTheGame = true;

        for (int i = 0; i < rooms.Length; i++)
        {
            var currentRoom = rooms[i].Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string element = currentRoom[0];
            int value = int.Parse(currentRoom[1]);
            room= i + 1;

            if(element == "potion")
            {
                if (health + value <= 100)
                {
                    health += value;

                    Console.WriteLine($"You healed for {value} hp.");
                }
                else
                {
                    Console.WriteLine($"You healed for {100 - health} hp.");
                    health = 100;

                }

                Console.WriteLine($"Current health: {health} hp.");
            }
            else if (element == "chest")
            {
                xrp += value;
                Console.WriteLine($"You found {value} bitcoins.");
            }
            else
            {
                if (value < health)
                {
                    health -= value;
                    Console.WriteLine($"You slayed {element}.");
                }
                else
                {
                    Console.WriteLine($"You died! Killed by {element}.");
                    Console.WriteLine($"Best room: {room}");
                    winTheGame = false;
                    break;
                }
            }
        }

        if (winTheGame)
        {
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {xrp}");
            Console.WriteLine($"Health: {health}");
        }

    }
}