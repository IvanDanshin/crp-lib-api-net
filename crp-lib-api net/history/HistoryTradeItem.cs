using java.math;
using System;
using System.Collections.Generic;
using System.Text;

namespace crp_lib_api_net.history
{
    class HistoryTradeItem
    {
        public string       record_id;
        public string       record_type;
        public BigDecimal   price;
        public BigDecimal   amount;
        public BigDecimal   value;
        public long         created_at;

        public HistoryTradeItem(
                string   record_id,
                string   record_type,
                string   price,
                string   amount,
                string   value,
                long     created_at)
        {
            this.record_id      = record_id;
            this.record_type    = record_type;
            this.price          = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(price));
            this.amount         = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(amount));
            this.value          = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(value));
            this.created_at     = created_at;
        }

        override public string ToString()
        {
            return "[record_id = " + record_id + ", record_type = " + record_type + ", price = " + price +
                  ", amount = " + amount + ", value = " + value + "]";
        }
    }
}
