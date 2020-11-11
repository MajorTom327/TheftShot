using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace TheftShot
{
    class TSServer
    {
        private readonly HttpClient client;
        public TSServer()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(TSConstants.ExternalHost);
        }

        public void SendEvent(string type)
        {
            var content = new StringContent(
                (new { type = type, date = DateTime.Now.ToString("s") }).ToString(),
                Encoding.UTF8,
                "application/json"
                ); ;
            client.PostAsync("/events", content);
        }
    }
}
