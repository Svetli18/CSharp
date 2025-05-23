﻿namespace WildFarm
{
    using System;
    using WildFarm.Core;
    using WildFarm.Core.Contracts;
    using WildFarm.IO;
    using WildFarm.IO.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}