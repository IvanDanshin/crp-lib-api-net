using crp_lib_api_net.balance;
using crp_lib_api_net.market.pair;
using crp_lib_api_net.market.panel;
using crp_lib_api_net.orders;
using System;
using System.Collections.Generic;

namespace crp_lib_api_net
{
    class Example
    {
        static void Main(string[] args)
        {
            Client client = Client.login("52EAECEA83437ADDA5800E2C9EEB6D456753B0B2CD11D37B90DFABA1592ED955",
            "qwerty12345", "");

            Console.WriteLine("Client:");
            Console.WriteLine(client);

            Console.WriteLine("\n getAllBalance()");
            AllBalance allBalance = client.getAllBalance();
            Console.WriteLine(allBalance);

            Console.WriteLine("\n getPairs()");
            LinkedList<Pairs> pairs = client.getMarket().getPairs();
            Console.WriteLine(string.Join("]", pairs));


            Console.WriteLine("\n getPanel()");
            Panel panel = client.getMarket().getPanel(pairs.First.Value.pair);
            Console.WriteLine(panel);

            Console.WriteLine("\n getCurList()");
            Dictionary<string, Currency> curList = client.getMarket().getCurList();
            Console.WriteLine(curList.Values);

            client.logout();
        }
    }
}
