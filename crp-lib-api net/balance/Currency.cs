using java.math;
using System;
using System.Collections.Generic;
using System.Text;

namespace crp_lib_api_net.balance
{
    class Currency
    {
        public int          id;
        public string       name;
        public string       fullname;
        public string       appname;
        public string       icon;
        public int          round;
        public BigDecimal   deposit_fee;
        public BigDecimal   deposit_min;
        public BigDecimal   withdraw_fee;
        public BigDecimal   withdraw_fee_pro;
        public BigDecimal   withdraw_min;
        public int          address_size;
        public BigDecimal   min_fee;
        public bool         enable;
        public bool         show;

        public Currency(
                int         id,
                string      name,
                string      fullname,
                string      appname,
                string      icon,
                int         round,
                string      deposit_fee,
                string      deposit_min,
                string      withdraw_fee,
                string      withdraw_fee_pro,
                string      withdraw_min,
                int         address_size,
                string      min_fee,
                bool        enable,
                bool        show)
        {
            this.id                 = id;
            this.name               = name;
            this.fullname           = fullname;
            this.appname            = appname;
            this.icon               = icon;
            this.round              = round;
            this.deposit_fee        = BigDecimal.valueOf(0.00).setScale(round, BigDecimal.ROUND_DOWN).add(new BigDecimal(deposit_fee));
            this.deposit_min        = BigDecimal.valueOf(0.00).setScale(round, BigDecimal.ROUND_DOWN).add(new BigDecimal(deposit_min));
            this.withdraw_fee       = BigDecimal.valueOf(0.00).setScale(round, BigDecimal.ROUND_DOWN).add(new BigDecimal(withdraw_fee));
            this.withdraw_fee_pro   = BigDecimal.valueOf(0.00).setScale(round, BigDecimal.ROUND_DOWN).add(new BigDecimal(withdraw_fee_pro));
            this.withdraw_min       = BigDecimal.valueOf(0.00).setScale(round, BigDecimal.ROUND_DOWN).add(new BigDecimal(withdraw_min));
            this.address_size       = address_size;
            this.min_fee            = BigDecimal.valueOf(0.00).setScale(round, BigDecimal.ROUND_DOWN).add(new BigDecimal(min_fee));
            this.enable             = enable;
            this.show               = show;
        }

        override public string ToString()
        {
            return "[id = " + id + ", name = " + name + ", fullname = " + fullname + ", appname = " + appname +
                  ", icon = " + icon + ", round = " + round + ", deposit_fee = " + deposit_fee + ", deposit_min = " + deposit_min +
                  ", withdraw_fee = " + withdraw_fee + ", withdraw_fee_pro = " + withdraw_fee_pro + ", withdraw_min = " + withdraw_min +
                  ", deposit_min = " + deposit_min + ", address_size = " + address_size + ", min_fee = " + min_fee + ", enable = " + enable +
                  ", show = " + show + "]";
        }
    }
}
