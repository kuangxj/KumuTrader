using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KumuTraderClient
{
    public class MsgArgs
    {
        public object Sender { get; private set; }

        public MsgArgs(object sender = null)
        {
            Sender = sender;
        }
    }
}
