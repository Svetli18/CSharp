using System;
using System.Linq;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var code = Console.ReadLine();
        var command = "";
        while ((command = Console.ReadLine()) != "Decode")
        {
            var commandArds = command.Split('|', StringSplitOptions.RemoveEmptyEntries);

            if (commandArds[0] == "Move" && char.IsDigit(commandArds[1][0]))
            {
                var n = int.Parse(commandArds[1]) % code.Length;
                code = MoveCommand(code, n);
            }
            else if (commandArds[0] == "Insert" && char.IsDigit(commandArds[1][0]))
            {
                var index = int.Parse(commandArds[1]);
                var value = commandArds[2];

                if (0 <= index && index <= code.Length)
                {
                    code = code.Insert(index, value);
                }
            }
            else if (commandArds[0] == "ChangeAll")
            {
                code = ChangeElements(code, commandArds);
            }
        }

        Console.WriteLine($"The decrypted message is: {string.Concat(code)}");

    }

    static string ChangeElements(string code, string[] commandArds)
    {
        var oldElement = commandArds[1];
        var newElement = commandArds[2];
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < code.Length; i++)
        {
            if (code[i].ToString() == oldElement)
            {
                sb.Append(newElement);
            }
            else
            {
                sb.Append(code[i]);
            }
        }

        return sb.ToString().Trim();
    }

    static string MoveCommand(string code, int n)
    {
        for (int i = 0; i < n; i++)
        {
            var ch = code[0];
            var newStr = string.Concat(code.Skip(1));
            code = newStr + ch.ToString();
        }

        return code;
    }
}