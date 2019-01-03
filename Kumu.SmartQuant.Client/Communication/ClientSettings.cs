using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kumu.Trader.Client.Communication
{
    class ClientSettings
    {
        public static bool IsSsl { get; set; }
        public static int Port { get; set; }

        public static long Host { get; set; }
        public static int Size { get; set; }
        
    }
}
