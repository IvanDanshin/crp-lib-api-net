
namespace crp_lib_api_net.market.pair
{
    class Pairs
    {
        public DataMarket data_market;
        public Pair pair;

        public Pairs(
                DataMarket  data_market,
                Pair        pair)
        {
            this.data_market    = data_market;
            this.pair           = pair;
        }

        override public string ToString()
        { return "[pair = " + pair + ", data_market = " + data_market + "]"; }
    }
}
