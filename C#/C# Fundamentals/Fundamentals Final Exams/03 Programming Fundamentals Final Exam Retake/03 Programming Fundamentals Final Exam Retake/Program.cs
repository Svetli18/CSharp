using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var massage = Console.ReadLine();

        string cmd;
        while ((cmd = Console.ReadLine()) != "Reveal")
        {
            var cmdArgs = cmd.Split(":|:", StringSplitOptions.RemoveEmptyEntries);

            var command = cmdArgs[0];

            if (command == "InsertSpace")
            {
                var index = int.Parse(cmdArgs[1]);

                massage = massage.Insert(index, " ");
                Console.WriteLine(massage);
            }
            else if (command == "Reverse")
            {
                var str = cmdArgs[1];

                if (massage.Contains(str))
                {
                    var index = massage.IndexOf(str);
                    massage = massage.Remove(index, str.Length);
                    var reverse = GetReverse(str);
                    massage = string.Concat(massage, reverse);
                    Console.WriteLine(massage);
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (command == "ChangeAll")
            {
                var oldStr = cmdArgs[1];
                var newStr = cmdArgs[2];
                while (massage.Contains(oldStr))
                {
                    massage = massage.Replace(oldStr, newStr);
                }
                Console.WriteLine(massage);
            }
        }

        Console.WriteLine($"You have a new text message: {massage}");
    }

    static string GetReverse(string str)
    {
        string s = "";

        for (int i = str.Length - 1; i >= 0; i--)
        {
            s += str[i];
        }

        return s;
    }
}