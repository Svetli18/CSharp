using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var activationKey = Console.ReadLine();

        var cmd = "";
        while((cmd = Console.ReadLine()) != "Generate") 
        {
            var cmdArgs = cmd.Split(">>>", StringSplitOptions.RemoveEmptyEntries);

            var commad = cmdArgs[0];

            if (commad == "Contains")
            {
                var substring = cmdArgs[1];

                if (activationKey.Contains(substring))
                {
                    Console.WriteLine($"{activationKey} contains {substring}");
                    continue;
                }

                Console.WriteLine("Substring not found!");

            }
            else if (commad == "Flip")
            {
                var type = cmdArgs[1];
                var startIndex = int.Parse(cmdArgs[2]);
                var endIndex = int.Parse(cmdArgs[3]);

                if (type == "Upper")
                {
                    var upperStr = activationKey.Substring(startIndex, endIndex - startIndex);
                    activationKey = activationKey.Replace(upperStr, "");
                    upperStr = upperStr.ToUpper();
                    activationKey = activationKey.Insert(startIndex, upperStr);
                }
                else if(type == "Lower")
                {
                    var lolerStr = activationKey.Substring(startIndex, endIndex - startIndex);
                    activationKey = activationKey.Replace(lolerStr, "");
                    lolerStr = lolerStr.ToLower();
                    activationKey = activationKey.Insert(startIndex, lolerStr);
                }

                Console.WriteLine(activationKey);

            }
            else if(commad == "Slice")
            {
                var startIndex = int.Parse(cmdArgs[1]);
                var endIndex = int.Parse(cmdArgs[2]);

                activationKey = activationKey.Remove(startIndex, endIndex - startIndex);

                Console.WriteLine(activationKey);
            }
        }

        Console.WriteLine($"Your activation key is: {activationKey}");

    }
}