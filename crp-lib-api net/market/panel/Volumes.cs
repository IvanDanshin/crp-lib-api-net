using java.math;

namespace crp_lib_api_net.market.panel
{
    class Volumes
    {
        public BigDecimal sell;
        public BigDecimal buy;

        public Volumes(
                string sell,
                string buy)
        {
            this.sell  = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(sell));
            this.buy   = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(buy));
        }

        override public string ToString()
        { return "[sell = " + sell + ", buy = " + buy + "]"; }
    }
}
