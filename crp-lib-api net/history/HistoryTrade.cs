using crp_lib_api_net.orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace crp_lib_api_net.history
{
    class HistoryTrade
    {
        public LinkedList<HistoryTradeItem> items;
        public PairStr                      pair;

        public HistoryTrade(
                LinkedList<HistoryTradeItem>    items,
                PairStr                         pair)
        {
            this.items  = items;
            this.pair   = pair;
        }

        override public string ToString()
        { return "Pojo [pair = " + pair + ", items = " + string.Join("]", items) + "]"; }
    }
}
