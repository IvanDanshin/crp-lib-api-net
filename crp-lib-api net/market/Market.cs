
using crp_lib_api_net.balance;
using crp_lib_api_net.market.pair;
using crp_lib_api_net.market.panel;
using crp_lib_api_net.response;
using java.math;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace crp_lib_api_net.market
{
    class Market
    {
        private Client m_Client;

        public Market(Client client)
        {
            m_Client = client;
        }

        override public string ToString()
        { return "[m_Client = " + m_Client + "]"; }


        /**  Get trading pairs list */
        public LinkedList<Pairs> getPairs()
        {
            CrpResponse response = new CrpResponse().getResponse("market/pairs",
                    "", "GET", "auth_token="+ m_Client.auth_token);

            JObject obj = JObject.Parse(response.result);

            return JsonUtil<LinkedList<Pairs>>.convertJsonToObject(new LinkedList<Pairs>(), obj.GetValue("pairs").ToString());
        }

        /**  Buy currency
         *   pair   - required
         *   amount - required
         *   price  - required
         */
        public OrderResponse buy(Pair pair, BigDecimal amount, BigDecimal price)
        {
            CrpResponse response = new CrpResponse().getResponse("market/buy?",
                    "pair=" +pair.pair+"&amount="+amount.toString()+"&price="+price.toString(),
                        "POST", "auth_token="+ m_Client.auth_token);

            return JsonUtil<OrderResponse>.convertJsonToObject(new OrderResponse(false, 0, 0), response.result);
        }

        /**  Sell currency
         *   pair   - required
         *   amount - required
         *   price  - required
         */
        public OrderResponse sell(Pair pair, BigDecimal amount, BigDecimal price)
        {
            CrpResponse response = new CrpResponse().getResponse("market/sell?",
                    "pair=" + pair.pair + "&amount=" + amount.toString() + "&price=" + price.toString(),
                    "POST", "auth_token=" + m_Client.auth_token);

            return JsonUtil<OrderResponse>.convertJsonToObject(new OrderResponse(false, 0, 0), response.result);
        }

        /**  Hold or Unhold order
         *   orderId - required
         */
        public OrderResponse hold(int orderId)
        {
            CrpResponse response = new CrpResponse().getResponse("market/hold?",
                    "order_id=" + orderId, "POST", "auth_token=" + m_Client.auth_token);

            return JsonUtil<OrderResponse>.convertJsonToObject(new OrderResponse(false, orderId, 0), response.result);
        }

        /**  Cancel the specified order
         *   orderId - required
         */
        public OrderResponse cancel(int orderId)
        {
            CrpResponse response = new CrpResponse().getResponse("market/cancel?",
                    "order_id=" + orderId, "POST", "auth_token=" + m_Client.auth_token);

            return JsonUtil<OrderResponse>.convertJsonToObject(new OrderResponse(false, orderId, 0), response.result);
        }

        /**  Get order book by trade pair
         *   pair - required
         */
        public Panel getPanel(Pair pair)
        {
            CrpResponse response = new CrpResponse().getResponse("market/panel?",
                    "pair=" + pair.pair, "POST", "auth_token=" + m_Client.auth_token);

            return JsonUtil<Panel>.convertJsonToObject(new Panel(null, null, null, 0L, null, null, null), response.result);
        }

        /**  Get currencies list */
        public Dictionary<string, Currency> getCurList()
        {
            CrpResponse response = new CrpResponse().getResponse("market/curlist",
                    "", "GET", "auth_token=" + m_Client.auth_token);

            return JsonUtil<Dictionary<string, Currency>>.convertJsonToObject(new Dictionary<string, Currency>(), response.result);
        }
    }
}
