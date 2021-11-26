using crp_lib_api_net.balance;
using crp_lib_api_net.history;
using crp_lib_api_net.market;
using crp_lib_api_net.market.pair;
using crp_lib_api_net.market.panel;
using crp_lib_api_net.orders;
using crp_lib_api_net.response;
using crp_lib_api_net.user;
using java.math;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace crp_lib_api_net
{
    class Client
    {
        public User         getUser()       { return user_session.user; }
        public UserSession  user_session;
        public string       auth_token;

        public Client(UserSession user_session, string auth_token)
        {
            this.user_session = user_session;
            this.auth_token   = auth_token;
            this.m_Market     = new Market(this);
        }

        /**  Sign in to system
         *   publicKey   - required
         *   password    - required
         *   twoFa_pin   - optional
         */
        public static Client login(string publicKey, string password, string twoFa_pin)
        {
            CrpResponse response = new CrpResponse().getResponse("user/login?",
                    "PublicKey=" + publicKey + "&password=" + password + "&2fa_pin=" + twoFa_pin, "POST", "");

            return JsonUtil<Client>.convertJsonToObject(new Client(null, null), response.result);
        }

        /**  Sign out from system */
        public void logout()
        {
            CrpResponse response = new CrpResponse().getResponse("user/logout",
                "", "POST", "auth_token="+ auth_token);

            Console.WriteLine(response.result);
        }

        override public string ToString()
        { return "[user_session = " + user_session + ", auth_token = " + auth_token + "]"; }


        /**  BALANCE START ************************************************************************************************/
        /***/

        /**  Get all user balances */
        public AllBalance getAllBalance()
        {
            CrpResponse response = new CrpResponse().getResponse("user/balance",
                "", "GET", "auth_token="+auth_token);

            return JsonUtil<AllBalance>.convertJsonToObject(new AllBalance(), response.result);
        }
        /**  BALANCE END **************************************************************************************************/

        /**  MARKET START *************************************************************************************************/
        /***/

        private Market m_Market;
        public Market getMarket() { return m_Market; }

        public LinkedList<Pairs> getPairs()
        { return getMarket().getPairs(); }

        /**  Get order book by trade pair
         *   pair - required
         */
        public Panel getPanel(Pair pair)
        { return getMarket().getPanel(pair); }

        /**  Get currencies list */
        public Dictionary<string, Currency> getCurList()
        { return getMarket().getCurList(); }

        /**  Buy currency
         *   pair   - required
         *   amount - required
         *   price  - required
         */
        public OrderResponse buy(Pair pair, BigDecimal amount, BigDecimal price)
        { return getMarket().buy(pair, amount, price); }

        /**  Sell currency
         *   pair   - required
         *   amount - required
         *   price  - required
         */
        public OrderResponse sell(Pair pair, BigDecimal amount, BigDecimal price)
        { return getMarket().sell(pair, amount, price); }

        /**  Hold or Unhold order
         *   orderId - required
         */
        public OrderResponse hold(int orderId)
        { return getMarket().hold(orderId); }

        /**  Cancel the specified order
         *   orderId - required
         */
        public OrderResponse cancel(int orderId)
        { return getMarket().cancel(orderId); }
        /**  MARKET END ***************************************************************************************************/


        /**  ORDERS START *************************************************************************************************/
        /***/

        /**  Get orders list
         *   status   - optional Values: open/close/cancel/hold
         *   task     - optional Values: buy/sell
         */
        public enum OrderStatus { open, close, cancel, hold }
        public enum OrderTask { buy, sell }

        public Orders getOrders(OrderStatus status, OrderTask task)
        {
            CrpResponse response = new CrpResponse().getResponse("orders?",
                    "status=" + nameof(status) + "&task=" + nameof(task), "GET", "auth_token=" + auth_token);
            return JsonUtil<Orders>.convertJsonToObject(new Orders(null, null, null, 0), response.result);
        }

        public Orders getOrders(OrderStatus status)
        {
            CrpResponse response = new CrpResponse().getResponse("orders?",
                    "status=" + nameof(status), "GET", "auth_token=" + auth_token);

            return JsonUtil<Orders>.convertJsonToObject(new Orders(null, null, null, 0), response.result);
        }

        public Orders getOrders(OrderTask task)
        {
            CrpResponse response = new CrpResponse().getResponse("orders?",
                    "task=" + nameof(task) + "", "GET", "auth_token=" + auth_token);
            return JsonUtil<Orders>.convertJsonToObject(new Orders(null, null, null, 0), response.result);
        }

        public Orders getOrders()
        {
            CrpResponse response = new CrpResponse().getResponse("orders",
                    "", "GET", "auth_token=" + auth_token);
            return JsonUtil<Orders>.convertJsonToObject(new Orders(null, null, null, 0), response.result);
        }

        /**  Get orders history
         *   orderId  - required
         */
        public OrderHistory getOrdersHistory(int orderId)
        {
            CrpResponse response = new CrpResponse().getResponse("orders/history?",
                    "order_id=" + orderId, "POST", "auth_token=" + auth_token);
            return JsonUtil<OrderHistory>.convertJsonToObject(new OrderHistory(null, null, null), response.result);
        }
        /**  ORDERS END ***************************************************************************************************/


        /**  HISTORY START ************************************************************************************************/
        /***/

        /**  Get trading history by pairs
         *   pair     - required
         */
        public HistoryTrade getHistoryTrade(Pair pair)
        {
            CrpResponse response = new CrpResponse().getResponse("history/trade?",
                    "pair=" + pair.pair, "GET", "auth_token=" + auth_token);
            return JsonUtil<HistoryTrade>.convertJsonToObject(new HistoryTrade(null, null), response.result);
        }

        /**  Get operations history
         *   type           - required      Values: profile/trade/billing
         *   from_id        - optional      (uuid)	Pagination offset
         *   record_type    - optional      Billing operation type (only for billing)	payment/comission/withdraw or combined
         *   currency       - optional      Currency (only for billing type)
         */
        public enum HistoryType { profile, trade, billing }
        public enum BillingOperation { payment, comission, withdraw, combined }
        public LinkedList<HistoryItem> getHistory(HistoryType type, string fromId, BillingOperation recordType, Currency currency)
        {
            CrpResponse response = new CrpResponse().getResponse("history?",
                    "type=" + nameof(type) + "&from_id=" + fromId + "&record_type=" + nameof(recordType) + "&currency=" + currency.name
                    , "POST", "auth_token=" + auth_token);
            JObject obj = JObject.Parse(response.result);
            return JsonUtil<LinkedList<HistoryItem>>.convertJsonToObject(new LinkedList<HistoryItem>(), obj.GetValue("items").ToString());
        }

        public LinkedList<HistoryItem> getHistory(HistoryType type, string fromId)
        {
            CrpResponse response = new CrpResponse().getResponse("history?",
                    "type=" + nameof(type) + "&from_id=" + fromId, "POST", "auth_token=" + auth_token);
            JObject obj = JObject.Parse(response.result);
            return JsonUtil<LinkedList<HistoryItem>>.convertJsonToObject(new LinkedList<HistoryItem>(), obj.GetValue("items").ToString());
        }

        public LinkedList<HistoryItem> getHistory(HistoryType type)
        {
            CrpResponse response = new CrpResponse().getResponse("history?",
                    "type=" + nameof(type), "POST", "auth_token=" + auth_token);
            JObject obj = JObject.Parse(response.result);
            return JsonUtil<LinkedList<HistoryItem>>.convertJsonToObject(new LinkedList<HistoryItem>(), obj.GetValue("items").ToString());
        }
        /**  HISTORY END **************************************************************************************************/
    }
}
