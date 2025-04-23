using System;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string pass = Console.ReadLine();

        string cmd;
        while ((cmd = Console.ReadLine()) != "Done")
        {
            string[] cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = cmdArgs[0];

            if (command == "TakeOdd")
            {
                pass = TakeOdds(pass);
                Console.WriteLine(pass);
            }
            else if (command == "Cut")
            {
                int index = int.Parse(cmdArgs[1]);
                int length = int.Parse(cmdArgs[2]);

                pass = pass.Remove(index, length);
                Console.WriteLine(pass);

            }
            else if (command == "Substitute")
            {
                string oldStr = cmdArgs[1];
                string newStr = cmdArgs[2];

                if (pass.Contains(oldStr))
                {
                    pass = pass.Replace(oldStr, newStr);
                    Console.WriteLine(pass);
                }
                else
                {
                    Console.WriteLine($"Nothing to replace!");
                }
            }
        }

        Console.WriteLine($"Your password is: {pass}");

    }

    static string TakeOdds(string pass)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < pass.Length; i++)
        {
            if (i % 2 != 0)
            {
                sb.Append(pass[i]);
            }
        }

        return sb.ToString().Trim();
    }
}