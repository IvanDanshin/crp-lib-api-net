using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace crp_lib_api_net
{
    public class JsonUtil<T>
    {
        public static string convertObjectToJson(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T convertJsonToObject(T obj, string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
