using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandItems = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = commandItems[0] + "Command";

            string[] items = commandItems.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type[] allTypes = assembly.GetTypes();

            Type typeCommand = allTypes.FirstOrDefault(t => t.Name == commandName);

            object instance = Activator.CreateInstance(typeCommand);

            ICommand command = (ICommand) instance;

            return command.Execute(items);
        }
    }
}