using java.math;
using System;
using System.Collections.Generic;
using System.Text;

namespace crp_lib_api_net.balance
{
    class Balance
    {
        public int          id;
        public Currency     currency;
        public BigDecimal   reserve;
        public BigDecimal   balance;

        public Balance(
            int       id,
            Currency  currency,
            string    reserve,
            string    balance)
        {
            this.id            = id;
            this.currency      = currency;
            this.reserve       = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(reserve));
            this.balance       = BigDecimal.valueOf(0.00).setScale(8, BigDecimal.ROUND_DOWN).add(new BigDecimal(balance));
        }

        override public string ToString()
        { return "[id = " + id + ", currency = " + currency + ", reserve = " + reserve + ", balance = " + balance + "]"; }
    }
}
