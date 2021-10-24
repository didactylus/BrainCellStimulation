using System;

namespace BrainCellStimulation.Automation
{
    class Assignment
    {
        
        public static void Ass()
        {

            bool _continue = true;
            while(_continue == true)
            {
                Console.WriteLine("Enter Vlan Name");
                string NameInput = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("IP");
                string IpInput = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("SubNet(Can be slash notation)");
                string SubInput = Console.ReadLine();
                if(SubInput.Contains("/"))
                {
                    MainProp.SearchDic(SubInput);
                }

                Console.Clear();
                Vlan vlan = new Vlan { VlanName = NameInput, VlanIP = IpInput, SubNet = SubInput, EigrpIp = eigrpout };
                Addition(vlan);
            }
        }
        public static string eigrpout { get; set; }
        public static void EigrpCalc(string Ip)
        {
            string tmp = Ip.Split(".")[3];
            int.TryParse(tmp, out int octet);
            int tmp2 = octet - 1;
            eigrpout = Ip[0] + Ip[1] + Ip[2] + tmp2.ToString();
        }
        public static void Addition(Vlan x)
        {
            PropList.vlans.Add(x);
        }
    }
}