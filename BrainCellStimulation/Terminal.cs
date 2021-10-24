using System;
using System.Collections.Concurrent;
using System.IO.Ports;

namespace BrainCellStimulation
{
    class UserTerminal
    {
        public static bool Ran { get; set; }
        public static string Lastincomming { get; set; }
        public static void Terminal() // Deals with user input
        {
            while (true)
            {
                try
                {
                    string word = "";
                    while (Ran is false)
                    {
                        var uinput = Console.ReadKey(true);
                        if (uinput.Key is ConsoleKey.Backspace)
                        {
                            if (!string.IsNullOrEmpty(word))
                            {
                                ClearCurrentConsoleLine();
                                Console.Write(Lastincomming);
                                string backword = word.Remove(word.Length - 1, 1);
                                word = backword;
                                Console.Write(word);
                                continue;
                            }
                            ClearCurrentConsoleLine();
                            Console.Write(Lastincomming);
                            Console.Write(word);
                            continue;
                        }
                        else if (uinput.Key is ConsoleKey.Enter)
                        {
                            if (string.IsNullOrEmpty(word))
                            {
                                SendCommand("\r");
                                continue;
                            }
                            else
                            {
                                if (word.Contains("/"))
                                {
                                    Commands.SearchDic(word);
                                }
                                else
                                {
                                    SendCommand($"{word}\r");
                                    word = "";
                                    continue;
                                }
                            }
                        }
                        if (uinput.KeyChar.ToString() is not "\r" or "\b")
                        {
                            word += uinput.KeyChar.ToString();
                            ClearCurrentConsoleLine();
                            Console.Write(Lastincomming);
                            Console.Write(word);
                            continue;
                        }
                    }
                }
                catch (Exception e)
                {
                    Serial.SP.Close();
                    Console.WriteLine(e);
                    Console.ReadKey();
                }
            }
        }
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        public static void SendCommand(string cmd) // sends input to serial device
        {
            Serial.SP.Write(cmd);
        }
    }
}