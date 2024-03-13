using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_Utility_Unit_Test_Example.Ping
{
    public class NetworkService
    {
        public string SendPing()
        {
            // SearchDNS();
            // BuildPacket();
            return "Success: Ping Sent";
        }

        public int PingTimeout(int a, int b)
        {
            return a + b;
        }
    }
}
