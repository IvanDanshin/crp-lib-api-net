using System;
using System.Collections.Generic;
using System.Text;

namespace crp_lib_api_net.user
{
    class User
    {
        public string id;
        public string name;
        public string status;
        public string lang;

        public User() { }

        override public string ToString()
        { return "[id = " + id + ", name = " + name + ", status = " + status + ", lang = " + lang + "]"; }
    }
}
