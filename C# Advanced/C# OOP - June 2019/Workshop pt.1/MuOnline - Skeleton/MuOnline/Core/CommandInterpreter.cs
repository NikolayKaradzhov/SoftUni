using System.Linq;
using System.Reflection;
using MuOnline.Core.Commands.Contracts;
using MuOnline.Core.Contracts;

namespace MuOnline.Core
{
    using System;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "command";
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Read(string[] args)
        {
            //Every time we have different commands(different commands are interested in different repositories(Heroes,Items,Monsters))
            //For example AddItemCommand loads itemRepository and itemFactory

            //AddItem itemName
            string commandName = args[0].ToLower() + Suffix;
            string[] inputArgs = args.Skip(1).ToArray();

            var type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName);

            if (type == null)
            {
                throw new ArgumentNullException("Invalid command!");
            }

            var constructor = type
                .GetConstructors()
                .FirstOrDefault();

            var constructorParams = constructor
                .GetParameters()
                .Select(p => p.ParameterType)
                .ToArray();

            var services = constructorParams
                .Select(this.serviceProvider.GetService)
                .ToArray();

            var typeInstance = (ICommand)Activator.CreateInstance(type, services);

            var result = typeInstance.Execute(inputArgs);

            //read params
            //instanciate
            //invoke method
            //return result

            return result;
        }
    }
}
