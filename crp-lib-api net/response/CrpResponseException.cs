using System;
using System.Collections.Generic;
using System.Text;

namespace crp_lib_api_net.response
{
    class CrpResponseException : Exception
    {
        public CrpResponseException(string message) : base(message) { }
    }
}
