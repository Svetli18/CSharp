﻿namespace CommandPattern.Core.Models.Comands
{
    using System;
    using CommandPattern.Core.Contracts;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Environment.Exit(0);

            return null;
        }
    }
}
