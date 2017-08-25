using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace WhoNeedsflixWinForm.Utils
{
    class Ping
    {
        public bool PingHost(string url)
        {
            bool pingable = false;
            System.Net.NetworkInformation.Ping pinger = new System.Net.NetworkInformation.Ping();
            try
            {
                PingReply reply = pinger.Send(url);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            return pingable;
        }
    }
}
