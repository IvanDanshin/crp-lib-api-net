using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace crp_lib_api_net.response
{
    class CrpResponse
    {
        public static string MAIN_URL = "https://crp.is:8182/";

        public bool             success;
        public string           result;

        private string          m_FullResponse;
        public string           getFullResponse() { return m_FullResponse; }

        public CrpResponse() { }

        public CrpResponse getResponse(string url, string data, string method, string cookie)
        {
            success = false;

            string response = "";

            WebRequest request = WebRequest.Create(MAIN_URL + url + data);
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64)");
            if (!cookie.Equals("")) request.Headers.Add("Cookie", cookie);

            request.Method = method;

            try
            {
                if (method.Equals("GET"))
                {
                    ((HttpWebRequest)request).AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                    using (HttpWebResponse wResponse = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = wResponse.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    { response = reader.ReadToEnd(); }
                }
                else
                {

                    byte[] byteArray = Encoding.UTF8.GetBytes(data);

                    request.ContentLength = byteArray.Length;
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();

                    WebResponse wResponse = request.GetResponse();

                    Console.WriteLine(((HttpWebResponse)wResponse).StatusDescription);

                    dataStream = wResponse.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    response = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                    wResponse.Close();
                }

                JObject obj = JObject.Parse(response);

                m_FullResponse = response;
                success = (bool)obj.GetValue("success");
                result = obj.GetValue("result").ToString();
            }
            catch (Exception e)
            { throw new CrpResponseException("Exception while receiving a response from the server: " + e.Message); }

            if (!success) throw new CrpResponseException("Response received, but success = false");
            return this;
        }

        override public string ToString()
        { return "[success = " + success + ", result = " + result + "]"; }
    }
}
