using System;

namespace BrainCellStimulation.Automation
{
    class Commands
    {
        public static void ConfigT()
        {
            SerialConnection.SendCommand("\nenable\n");
            SerialConnection.SendCommand("conf t\n");
        }
        public static void NME()
        {
            SerialConnection.SendCommand("\nenable\n");
            SerialConnection.SendCommand("service-module g2/0 session\n");
            SerialConnection.SendCommand("no\n");
        }
        public static void End()
        {
            SerialConnection.SendCommand("exit\nexit\n");
            SerialConnection.SendCommand("write mem\n");
            SerialConnection.SendCommand("exit\n");
        }
        public static void Back()
        {
            SerialConnection.SendCommand("end\nexit\n\n");
            SerialConnection.SendCommand(Convert.ToChar(30) + "xdisconnect\n\n");
            SerialConnection.SendCommand("write mem\n");
        }
    }
}
