using System;
using System.Threading;
using MuOnline.Core.Commands.Contracts;

namespace MuOnline.Core.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] inputArgs)
        {
            for (int i = 5; i >= 1; i--)
            {
                Console.WriteLine($"Exit after: {i}s");
                Thread.Sleep(1000);
            }

            Environment.Exit(0);
            return null;
        }
    }
}