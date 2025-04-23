﻿namespace InheritanceDemos
{
    using System;

    public class ConsoleIEngine : IReader, IWriter
    {
        public string Read()
        {
            return Console.ReadLine();
        }

        public void Write(string str)
        {
            Console.WriteLine(str);
        }
    }
}
