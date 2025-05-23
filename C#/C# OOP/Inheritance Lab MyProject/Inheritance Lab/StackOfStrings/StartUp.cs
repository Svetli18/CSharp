﻿namespace CustomStack
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var list = new RandomList<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");
            list.Add("5");
            list.RemoveRandomElement();
            list.RemoveRandomElement();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(list.GetRandomElement());
            }

            var myStack = new StackOfStrings<string>();
            Console.WriteLine(myStack.IsEmpty());
            myStack.AddRange(list);
            Console.WriteLine(myStack.IsEmpty());
        }
    }
}
