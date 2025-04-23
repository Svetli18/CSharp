internal class Program
{
    using s

    private static void Main(string[] args)
    {
        int hours = int.Parse(Console.ReadLine());

        int minutes = int.Parse(Console.ReadLine());

        if (minutes + 30 <= 59)
        {
            minutes += 30;
        }
        else
        {
            hours++;

            minutes = (minutes + 30) - 60;

            if (23 < hours)
            {
                hours = 0;
            }
        }

        Console.WriteLine($"{hours}:{minutes:d2}");
    }
}