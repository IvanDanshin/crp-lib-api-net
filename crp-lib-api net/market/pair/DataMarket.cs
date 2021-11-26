using java.math;

namespace crp_lib_api_net.market.pair
{
    class DataMarket
    {
        public BigDecimal   open;
        public BigDecimal   close;
        public BigDecimal   high;
        public BigDecimal   low;
        public BigDecimal   volume;
        public BigDecimal   value;
        public BigDecimal   volume_usd;
        public BigDecimal   rate;
        public long         date_now;

        public DataMarket(
            string open,
            string close,
            string high,
            string low,
            string volume,
            string value,
            string volume_usd,
            string rate,
            long date_now)
        {
            this.open       = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(open));
            this.close      = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(close));
            this.high       = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(high));
            this.low        = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(low));
            this.volume     = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(volume));
            this.value      = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(value));
            this.volume_usd = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(volume_usd));
            this.rate       = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(rate));
            this.date_now   = date_now;
        }

        override public string ToString()
        {
            return "[open = " + open + ", close = " + close + ", high = " + high + ", low = " + low + ", volume = " + volume +
                  ", value = " + value + ", volume_usd = " + volume_usd + ", rate = " + rate + ", date_now = " + date_now + "]";
        }
    }
}
