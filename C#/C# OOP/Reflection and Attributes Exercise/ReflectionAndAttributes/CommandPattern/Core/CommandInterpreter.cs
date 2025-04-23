namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using CommandPattern.Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] argsArray = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            string commandName = argsArray[0] + "Command";

            string[] commandArgs = argsArray.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type commandType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower());

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand command = Activator.CreateInstance(commandType) as ICommand;

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
