using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.ComTypes;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string input = Console.ReadLine();

            Console.WriteLine(this.commandInterpreter.Read(input));
        }
    }
}