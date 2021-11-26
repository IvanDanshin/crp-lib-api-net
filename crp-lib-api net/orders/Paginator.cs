using System;
using System.Collections.Generic;
using System.Text;

namespace crp_lib_api_net.orders
{
    class Paginator
    {
        public int count;
        public int page;
        public int limit;

        public Paginator(
                int count,
                int page,
                int limit)
        {
            this.count      = count;
            this.page       = page;
            this.limit      = limit;
        }

        override public string ToString()
        { return "[count = " + count + ", page = " + page + ", limit = " + limit + "]"; }
    }
}
