using java.math;
using System;
using System.Collections.Generic;
using System.Text;

namespace crp_lib_api_net.orders
{
    class Order
    {
        public int          order_id;
        public BigDecimal   amount;
        public BigDecimal   price;
        public BigDecimal   value;
        public BigDecimal   orig_value;
        public long         date_reg;
        public string       task;
        public string       status;
        public BigDecimal   orig_amount;
        public string       cur;
        public string       ecur;
        public BigDecimal   price_executed;
        public BigDecimal   value_executed;

        public Order(
                int order_id,
                string amount,
                string price,
                string value,
                string orig_value,
                long date_reg,
                string task,
                string status,
                string orig_amount,
                string cur,
                string ecur,
                string price_executed,
                string value_executed)
        {
            this.order_id       = order_id;
            this.amount         = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(amount));
            this.price          = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(price));
            this.value          = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(value));
            this.orig_value     = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(orig_value));
            this.date_reg       = date_reg;
            this.task           = task;
            this.status         = status;
            this.orig_amount    = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(orig_amount));
            this.cur            = cur;
            this.ecur           = ecur;
            this.price_executed = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(price_executed));
            this.value_executed = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(value_executed));
        }

        override public string ToString()
        {
            return "[order_id = " + order_id + ", amount = " + amount + ", price = " + price + ", value = " + value +
                  ", orig_value = " + orig_value + ", date_reg = " + date_reg + ", task = " + task + ", status = " + status +
                  ", orig_amount = " + orig_amount + ", cur = " + cur + ", ecur = " + ecur + ", price_executed = "
                  + price_executed + ", value_executed = " + value_executed + "]";
        }
    }
}
