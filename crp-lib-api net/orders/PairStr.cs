using System;
using System.Collections.Generic;
using System.Text;

namespace crp_lib_api_net.orders
{
    class PairStr
    {
        public string cur;
        public string ecur;

        public PairStr(
                string cur,
                string ecur)
        {
            this.cur       = cur;
            this.ecur      = ecur;
        }

        override public string ToString()
        { return "[cur = " + cur + ", ecur = " + ecur + "]"; }
    }
}
