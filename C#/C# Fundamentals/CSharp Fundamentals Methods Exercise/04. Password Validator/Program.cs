using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string password = Console.ReadLine();

        bool IsLength = GetPasswordIsLength(password);
        bool IsLettersAndDigits = GetPasswordIsLettersAndDigits(password);
        bool IsHaveTwoDigits = GetPasswordIsHaveTwoDigits(password);

        if (!IsLength)
        {
            Console.WriteLine("Password must be between 6 and 10 characters");
        }

        if (!IsLettersAndDigits)
        {
            Console.WriteLine("Password must consist only of letters and digits");
        }

        if (!IsHaveTwoDigits)
        {
            Console.WriteLine("Password must have at least 2 digits");
        }

        if (IsLength && IsLettersAndDigits && IsHaveTwoDigits)
        {
            Console.WriteLine("Password is valid");
        }

    }

    static bool GetPasswordIsHaveTwoDigits(string password)
    {
        int cnt = 0;

        for (int i = 0; i < password.Length; i++)
        {
            char character = password[i];

            if (char.IsDigit(character))
            {
                cnt++;
            }

        }

        return 2 <= cnt;
    }

    static bool GetPasswordIsLettersAndDigits(string password)
    {
        for (int i = 0; i < password.Length; i++)
        {
            char character = password[i];

            if (!char.IsLetterOrDigit(character))
            {
                return false;
            }

        }

        return true;
    }

    static bool GetPasswordIsLength(string password)
    {
        return 6 <= password.Length && password.Length <= 10 ? true : false;
    }
}