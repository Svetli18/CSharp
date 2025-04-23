using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var greenLight = int.Parse(Console.ReadLine());
        var freeWindow = int.Parse(Console.ReadLine());

        var cars = new Queue<string>();
        var cnt = 0;

        var crashHappened = false;

        var command = "";
        while ((command = Console.ReadLine()) != "END")
        {
            var currGreenLight = greenLight;
            var currFreeWindow = freeWindow;

            if (command == "green" && cars.Any())
            {
                while (cars.Any() && 0 < currGreenLight)
                {
                    var currCar = cars.Dequeue();

                    if (currCar.Length <= currGreenLight)
                    {
                        currGreenLight -= currCar.Length;
                        cnt++;
                    }
                    else if (currCar.Length <= currGreenLight + currFreeWindow)
                    {
                        for (int i = 0; i < currCar.Length; i++)
                        {
                            if (0 < currGreenLight)
                            {
                                currGreenLight--;
                            }
                            else
                            {
                                currFreeWindow--;
                            }
                        }
                        cnt++;
                    }
                    else
                    {
                        var part = currCar.Substring(currGreenLight + freeWindow, 1);
                        crashHappened = true;
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currCar} was hit at {part}.");
                        break;
                    }
                }
            }
            else
            {
                cars.Enqueue(command);
            }

            if (crashHappened)
            {
                break;
            }

        }

        if (!crashHappened)
        {
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{cnt} total cars passed the crossroads.");
        }
    }
}