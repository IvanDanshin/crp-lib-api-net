using System;
using System.Collections.Generic;
using System.Text;

namespace crp_lib_api_net.market.panel
{
    class Panel
    {
        public LinkedList<OrderInfo>    book_sell;
        public LinkedList<OrderInfo>    book_buy;
        public Volumes                  volumes;
        public long                     time;
        public string                   cur;
        public string                   ecur;
        public string                   pair;

        public Panel(
            LinkedList<OrderInfo>   book_sell,
            LinkedList<OrderInfo>   book_buy,
            Volumes                 volumes,
            long                    time,
            string                  cur,
            string                  ecur,
            string                  pair)
        {
            this.book_sell  = book_sell;
            this.book_buy   = book_buy;
            this.volumes    = volumes;
            this.time       = time;
            this.cur        = cur;
            this.ecur       = ecur;
            this.pair       = pair;
        }

        override public string ToString()
        {
            return "[book_sell = " + book_sell + ", book_buy = " + book_buy + ", volumes = " + volumes + ", time = " + time +
                  ", cur = " + cur + ", ecur = " + ecur + ", pair = " + pair + "]";
        }
    }
}
