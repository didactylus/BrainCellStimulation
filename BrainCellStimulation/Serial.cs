using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;

namespace BrainCellStimulation
{
    class Serial
    {
        public static SerialPort SP;
        public static void SerialValues()
        {
            SP = new SerialPort();
            SP.PortName = SetPortName(SP.PortName);
            SP.BaudRate = SetBaudRate(SP.BaudRate);
            SP.Parity = SetPortParity(SP.Parity);
            SP.DataBits = SetPortDataBits(SP.DataBits);
            SP.StopBits = SetPortStopBits(SP.StopBits);
            SP.Handshake = SetPortHandshake(SP.Handshake);
        }

        public static string SetPortName(string defaultPortName) => ChooseValue(defaultPortName, "COM Port", com => com);

        public static int SetBaudRate(int defaultBaudRate) => ChooseValue(defaultBaudRate, "Baud Rate", br => int.Parse(br));

        public static int SetPortDataBits(int defaultPortDataBits) => ChooseValue(defaultPortDataBits, "Data Bits", db => int.Parse(db));

        public static Parity SetPortParity(Parity defaultPortParity) => ChooseValue(defaultPortParity, "Parity", par => Enum.TryParse<Parity>(par, true), Enum.GetValues<Parity>());

        public static StopBits SetPortStopBits(StopBits defaultPortStopBits) => ChooseValue(defaultPortStopBits, "Stop Bits", sb => Enum.TryParse<StopBits>(sb, true), Enum.GetValues<StopBits>());

        public static Handshake SetPortHandshake(Handshake defaultPortHandshake) => ChooseValue(defaultPortHandshake, "HandShake", hs => Enum.TryParse<Handshake>(hs, true), Enum.GetValues<Handshake>());

        public static T ChooseValue<T>(T defaultValue, string title, Func<string, T> parser, IEnumerable<T> items = null)
        {
            if (items?.Any() ?? false)
            {
                Console.Write($"Available {title}:");
                foreach (var item in items)
                {
                    Console.Write($"  {item}");
                }
                Console.WriteLine();
            }
            Console.Write($"Default: {defaultValue}\n");
            Console.Write($"{title}: ");
            string value = Console.ReadLine();
            if (value == "")
            {
                value = defaultValue.ToString();
            }
            if (title == "COM Port")
            {
                bool result = int.TryParse(value, out int x);
                if (result == true)
                {
                    value = "COM" + value;
                }
            }
            Console.Clear();
            return parser(value);
        }
        public static void SerialOpen()
        {
            Console.Clear();
            try
            {
                if (!String.IsNullOrEmpty(Serial.SP.PortName) || Serial.SP.BaudRate != 0) // If Com Port or Baud is empty go back to Serial Values Menu or throws an error
                {
                    Serial.SP = new SerialPort(Serial.SP.PortName, Serial.SP.BaudRate); // Open Serial Port Connection and go to Serial Port Terminal
                    Serial.SP.DataReceived -= new SerialDataReceivedEventHandler(Port_DataReceived);
                    Serial.SP.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
                    Serial.SP.Open();
                    Console.WriteLine($"Serial Connection open on port: {Serial.SP.PortName} @ {Serial.SP.BaudRate}Hz");
                    UserTerminal.Terminal();
                    Serial.SP.Close();
                }
                else
                {
                    Console.WriteLine("COM Port or Baud Rate is unassigned or invalid");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("COM Port is either being used or is unavailable");
                Console.WriteLine(e);
                Console.ReadLine();
                Console.Clear();
            }
        }
        private static void Port_DataReceived(object sender, SerialDataReceivedEventArgs e) // Reads incoming messages 
        {
            string output = Serial.SP.ReadLine();
            string newoutput = output.Replace("\r", "");
            UserTerminal.Lastincomming = newoutput;
            Console.Write($"\n{newoutput}");
        }
    }
}
