using System.Collections.Generic;

namespace BrainCellStimulation.Automation
{
    class PropList
    {
        public static List<Vlan> vlans = new List<Vlan>(); // List of Vlans user has inputed
    }
    class Vlan
    {
        public string VlanIP { get; set; } // VLAN IPs
        public string VlanName { get; set; } // VLAN Names
        public string SubNet { get; set; } // SubNet
        public string EigrpIp { get; set; } // Vlan EIGRP IP
    }
}
