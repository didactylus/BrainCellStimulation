using BrainCellStimulation.Automation;
using System;
using System.Collections.Generic;

namespace BrainCellStimulation
{
    class Commands
    {
        public static Dictionary<string, string> SlashNotation = new()
        {
            { "/24", "255.255.255.0" },
            { "/25", "255.255.255.128" },
            { "/26", "255.255.255.192" },
            { "/27", "255.255.255.224" },
            { "/28", "255.255.255.240" },
            { "/29", "255.255.255.248" },
            { "/30", "255.255.255.252" },
            { "/31", "255.255.255.254" },
            { "/32", "255.255.255.255" },
        };
        public static Dictionary<string, string> Help = new()
        {
            { "/help auto", "Goes to the Automation Terminal" },
            { "/help back", "Goes goes back to the main selection page" },
            { "/help", "auto back close help quit" },
            { "/help help", "Displays information about local commands" },
            { "/help quit", "Exits out of Cable Config" }
        };
        public static Dictionary<string, Action> Execute = new()
        {
            { "/auto", () => AutoManager.Selection() },
            { "/back", () => { return; } },
            { "/clear", () => { Console.Clear(); } },
            { "/close", () => { Serial.SP.Close(); } },
            { "/quit", () => Environment.Exit(0) }
        }; 
        public static void SearchDic(string key)
        {
            if (Commands.Help.TryGetValue(key, out string value))
            {
                Console.Write(value);
                UserTerminal.Ran = true;
            }
            if (Commands.Execute.TryGetValue(key, out var execute))
            {
                execute();
                UserTerminal.Ran = true;
            }
        }
    }
}
