using System;
using System.Collections.Generic;
using System.Text;

namespace crp_lib_api_net.user
{
    class UserSession
    {
        public User     user;
        public Session  session;

        public UserSession() { }

        override public string ToString()
        { return "[user = " + user + ", session = " + session + "]"; }
    }
}
