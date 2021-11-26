using java.math;
using System;
using System.Collections.Generic;
using System.Text;

namespace crp_lib_api_net.history
{
    class HistoryItem
    {
        public string       record_type;
        public int          order_id;
        public string       order_user;
        public BigDecimal   price;
        public BigDecimal   amount;
        public BigDecimal   value;
        public string       cur;
        public string       ecur;
        public string       pair;
        public string       val;
        public BigDecimal   val_balance;
        public BigDecimal   fee;
        public long         created_at;

        public HistoryItem(
                string  record_type,
                int     order_id,
                string  order_user,
                string  price,
                string  amount,
                string  value,
                string  cur,
                string  ecur,
                string  pair,
                string  val,
                string  val_balance,
                string  fee,
                long    created_at)
        {
            this.record_type    = record_type;
            this.order_id       = order_id;
            this.order_user     = order_user;
            this.price          = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(price));
            this.amount         = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(amount));
            this.value          = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(value));
            this.cur            = cur;
            this.ecur           = ecur;
            this.pair           = pair;
            this.val            = val;
            this.val_balance    = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(val_balance));
            this.fee            = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(fee));
            this.created_at     = created_at;
        }

        override public string ToString()
        {
            return "[record_type = " + record_type + ", order_id = " + order_id + ", order_user = " + order_user +
                  ", price = " + price + ", amount = " + amount + ", value = " + value + ", cur = " + cur +
                  ", ecur = " + ecur + ", pair = " + pair + ", val = " + val + ", val_balance = " + val_balance +
                  ", fee = " + fee + ", created_at = " + created_at + "]";
        }
    }
}
