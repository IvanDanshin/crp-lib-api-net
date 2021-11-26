using System;
using System.Collections.Generic;
using System.Text;

namespace crp_lib_api_net.orders
{
    class Orders
    {
        public LinkedList<string>   allorders        = new LinkedList<string>();
        public Paginator            paginator;
        public LinkedList<string>   filters          = new LinkedList<string>();
        public int                  my_order_count;

        public Orders(
                LinkedList<string>  allorders,
                Paginator           paginator,
                LinkedList<string>  filters,
                int                 my_order_count)
        {
            this.allorders         = allorders;
            this.paginator         = paginator;
            this.filters           = filters;
            this.my_order_count    = my_order_count;
        }

        override public string ToString()
        { return "[allorders = " + allorders + ", paginator = " + paginator + ", filters = " + filters + ", my_order_count = " + my_order_count + "]"; }
    }
}
