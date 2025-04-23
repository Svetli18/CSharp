using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        string text = Console.ReadLine();

        Stack<char> stack = new Stack<char>(text);

        foreach (char ch in stack)
        {
            Console.Write(ch);
        }
    }
}