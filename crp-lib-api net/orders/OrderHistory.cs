using System;
using System.Collections.Generic;
using System.Text;

namespace crp_lib_api_net.orders
{
    class OrderHistory
    {
        public Order                order;
        public LinkedList<string>   history;
        public PairStr              pair;

        public OrderHistory(
                Order               order,
                LinkedList<string>  history,
                PairStr             pair)
        {
            this.order     = order;
            this.history   = history;
            this.pair      = pair;
        }

        override public string ToString()
        { return "[order = " + order + ", history = " + history + ", pair = " + pair + "]"; }
    }
}
