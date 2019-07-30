using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace MuOnline.Core
{
    using System;

    using Contracts;

    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string[] inputArgs = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    var commandInterpreter = serviceProvider.GetService<ICommandInterpreter>();

                    var result = commandInterpreter.Read(inputArgs);

                    //TODO: Add IWriter
                    Console.WriteLine(result);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (ArgumentException ax)
                {
                    Console.WriteLine(ax.Message);
                }

                catch (InvalidProgramException iox)
                {
                    Console.WriteLine(iox.Message);
                }
            }
        }
    }
}