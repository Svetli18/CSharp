namespace CommandPattern.Core
{
    using System;

    using CommandPattern.Core.Contracts;
    using CommandPattern.IO;
    using CommandPattern.IO.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        private IReader reader;

        private IWriter writer;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
            this.reader = new Reader();
            this.writer = new Writer();
        }

        public void Run()
        {
            while (true)
            {
                string args = this.reader.ReadLine();

                try
                {
                    string result = this.commandInterpreter.Read(args);

                    this.writer.WriteLine(result);
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }

            }
        }
    }
}
