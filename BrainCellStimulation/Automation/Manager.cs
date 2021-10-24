using System;
using BrainCellStimulation;
namespace BrainCellStimulation.Automation
{
    class AutoManager
    {
        public static void Selection()
        {
            Console.WriteLine("Welcome to The Automation Manager");
            Console.WriteLine("Type \"help\" for help");
            Console.Write(">");
            var cmd = Console.ReadLine();
        }
    }
}