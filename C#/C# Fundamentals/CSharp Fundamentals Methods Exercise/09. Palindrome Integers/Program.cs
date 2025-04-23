using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = "";
        while ((input = Console.ReadLine()) != "END")
        {
            string isPalindrome = PalindromeNumberTest(input);

            if (isPalindrome == "false")
            {
                Console.WriteLine(isPalindrome);
                continue;
            }

            Console.WriteLine(isPalindrome);
        }
    }

    static string PalindromeNumberTest(string input)
    {
        for (int i = 0; i < input.Length / 2; i++)
        {
            if (!input[i].Equals(input[input.Length - 1 - i]))
            {
                return false.ToString().ToLower();
            }

        }

        return true.ToString().ToLower();
    }
}