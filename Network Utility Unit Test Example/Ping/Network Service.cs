using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }

        public PingOptions GetPingOptions()
        {
            // This is a random object found in a lib somewhere, not actually being used, just for example.
            return new PingOptions()
            {
                DontFragment = true,
                Ttl = 1,
            };
        }

        public IEnumerable<PingOptions> MostRecentPings()
        {
            // Generic IEnumerable (basically a list of objects)
            IEnumerable<PingOptions> pingOptions = new[]
            {
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },

                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },

                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },

                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
            };

            return pingOptions;
        }
    }
}
