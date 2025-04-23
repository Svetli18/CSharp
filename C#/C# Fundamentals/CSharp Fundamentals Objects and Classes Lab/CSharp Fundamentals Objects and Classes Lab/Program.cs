using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] text = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Random random = new Random();

        for (int i = 0; i < text.Length; i++)
        {
            int randomIndex = random.Next(0, text.Length);

            Swap(text, i, randomIndex);
        }

        Console.WriteLine(string.Join(Environment.NewLine, text));

    }

    static void Swap(string[] list, int index, int swapElementIndex)
    {
        string temp = list[index];
        list[index] = list[swapElementIndex];
        list[swapElementIndex] = temp;
    }
}