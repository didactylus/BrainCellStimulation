using static BrainCellStimulation.Automation.Commands;

namespace BrainCellStimulation.Automation
{
    class Scripts
    {
        public static void NME() // Setup NME
        {
            ConfigT();
            SerialConnection.SendCommand("int g2/0\n");
            SerialConnection.SendCommand("ip add 1.1.1.1 255.255.255.0\n");
            SerialConnection.SendCommand("no shut\n");
            SerialConnection.SendCommand("line 131\n");
            SerialConnection.SendCommand("transport input all\n");
            End();
        }
        public static void Vlans()
        {

        }

    }
}
