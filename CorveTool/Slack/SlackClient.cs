using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace CorveTool.Slack
{
    public class SlackClient
    {
        private readonly Uri _uri;
        private readonly Encoding _encoding = new UTF8Encoding();

        public SlackClient(string urlwithwebtoken)
        {
            _uri = new Uri(urlwithwebtoken);
        }

        public void postMessage(string text, string username = null, string channel = "#general")
        {
            Payload payload = new Payload()
            {

            };
        }
    }
}
