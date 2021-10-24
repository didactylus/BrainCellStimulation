using System;

namespace BrainCellStimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Selection();
        }
        public static void Selection()
        {
            var line = "====     Cable Config ver 1.0     ====";
            Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
            Console.WriteLine(line);
            Console.WriteLine("Select your connection method");
            Console.WriteLine("1. Connect via Serial(Terminal is Experimental)");
            Console.WriteLine("2. Connect via SSH(Still In Development)");
            Console.Write("> ");
            var tmp = Console.ReadLine();
            int.TryParse(tmp, out int select);
            bool _continue = true;
            while (_continue)
            {
                switch (select)
                {
                    case 1:
                        try
                        {
                            Console.Clear();
                            Serial.SerialValues();
                            Serial.SerialOpen();
                        }
                        catch
                        {
                            Console.WriteLine("Comport is either being used or is unavailable");
                        }
                        break;
                    case 2:
                        try
                        {
                            Console.Clear();
                            Console.Write("Nothing here yet");
                            Console.ReadKey();
                            //SSHConnection.SSHOpen();
                        }
                        catch
                        {
                            Console.WriteLine("Sorry you suck");
                        }
                        break;
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Sorry you suck");
                            Console.ReadLine();
                            Console.Clear();
                            Selection();
                        }
                        break;
                }
            }
        }
    }
}