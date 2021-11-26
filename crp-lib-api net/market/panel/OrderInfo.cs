using java.math;

namespace crp_lib_api_net.market.panel
{
    class OrderInfo
    {
        public BigDecimal price;
        public BigDecimal amount;
        public BigDecimal value;

        public OrderInfo(
                string price,
                string amount,
                string value)
        {
            this.price   = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(price));
            this.amount  = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(amount));
            this.value   = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(value));
        }

        override public string ToString()
        { return "[price = " + price + ", amount = " + amount + ", value = " + value + "]"; }
    }
}
