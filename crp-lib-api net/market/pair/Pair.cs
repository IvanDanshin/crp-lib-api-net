using java.math;

namespace crp_lib_api_net.market.pair
{
    class Pair
    {
        public int          pair_id;
        public string       pair;
        public string       pair_show;
        public string       group;
        public bool         visible;
        public bool         enable;
        public int          round_deal_amount;
        public int          round_deal_price;
        public BigDecimal   min_amount;
        public BigDecimal   min_price;
        public BigDecimal   max_price;

        public Pair(
            int     pair_id,
            string  pair,
            string  pair_show,
            string  group,
            bool    visible,
            bool    enable,
            int     round_deal_amount,
            int     round_deal_price,
            string  min_amount,
            string  min_price,
            string  max_price)
        {
            this.pair_id            = pair_id;
            this.pair               = pair;
            this.pair_show          = pair_show;
            this.group              = group;
            this.visible            = visible;
            this.enable             = enable;
            this.round_deal_amount  = round_deal_amount;
            this.round_deal_price   = round_deal_price;
            this.min_amount         = BigDecimal.valueOf(0.00).setScale(round_deal_amount, BigDecimal.ROUND_DOWN).add(new BigDecimal(min_amount));
            this.min_price          = BigDecimal.valueOf(0.00).setScale(round_deal_price, BigDecimal.ROUND_DOWN).add(new BigDecimal(min_price));
            this.max_price          = BigDecimal.valueOf(0.00).setScale(round_deal_price, BigDecimal.ROUND_DOWN).add(new BigDecimal(max_price));
        }

        override public string ToString()
        {
            return "[pair_id = " + pair_id + ", pair = " + pair + ", pair_show = " + pair_show + ", group = " + group +
                  ", visible = " + visible + ", enable = " + enable + ", round_deal_amount = " + round_deal_amount + ", round_deal_price = " + round_deal_price +
                  ", min_amount = " + min_amount + ", min_price = " + min_price + ", max_price = " + max_price + "]";
        }
    }
}
