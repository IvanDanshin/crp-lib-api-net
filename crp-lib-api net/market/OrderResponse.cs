using System;
using System.Collections.Generic;
using System.Text;

namespace crp_lib_api_net.market
{
    class OrderResponse
    {
        public bool success;
        public int  order_id;
        public int  daemon_id;

        public OrderResponse(
                bool    success,
                int     order_id,
                int     daemon_id)
        {
            this.success    = success;
            this.order_id   = order_id;
            this.daemon_id  = daemon_id;
        }

        override public string ToString()
        { return "[success = " + success + ", order_id = " + order_id + ", daemon_id = " + daemon_id + "]"; }
    }
}
