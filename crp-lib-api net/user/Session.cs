using System;
using System.Collections.Generic;
using System.Text;

namespace crp_lib_api_net.user
{
    class Session
    {
        public string id;

        public Session() { }

        override public string ToString()
        {  return "[id = " + id + "]"; }
    }
}
