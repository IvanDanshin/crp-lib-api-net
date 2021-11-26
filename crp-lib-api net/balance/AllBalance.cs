using System;
using System.Collections.Generic;
using System.Text;

namespace crp_lib_api_net.balance
{
    class AllBalance
    {
        public LinkedList<Balance>  allbalance;
        public string               user_id;

        public AllBalance() { }

        override public string ToString()
        { return "[allbalance = " + string.Join("]", allbalance) + ", user_id = " + user_id + "]"; }

    }
}
