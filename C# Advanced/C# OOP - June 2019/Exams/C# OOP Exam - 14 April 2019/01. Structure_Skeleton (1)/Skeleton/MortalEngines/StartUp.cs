using System;
using MortalEngines.Core;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            MachinesManager mm = new MachinesManager();

            mm.HirePilot("Pesho");
            mm.ManufactureFighter("F1", 100, 200);
            mm.ManufactureTank("T1", 300, 400);
            mm.EngageMachine("Pesho", "F1");
            mm.EngageMachine("Pesho", "T1");

            Console.WriteLine(mm.PilotReport("Pesho"));

        }
    }
}