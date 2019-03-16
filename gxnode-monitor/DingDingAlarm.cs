using RestSharp;
using Newtonsoft.Json;
using System.Threading;

namespace gxnode_monitor
{
    public class Text
    {
        public string content { get; set; }
    }

    public class At
    {
        public bool isAtAll { get; set; }
    }


    public class DingdingMsg
    {
        public string msgtype { get; set; }
        public Text text { get; set; }
        public At at { get; set; }
    }


    public class DingDingAlarm : IAlarm
    {
        private RestClient client = null;

        public DingDingAlarm(string url)
        {
            client = new RestClient(url);
        }

        public void Alarm(AlarmLevel level, string msg)
        {

            DingdingMsg req = new DingdingMsg
            {
                msgtype = "text",
                text = new Text
                {
                    content = msg
                },
                at = new At
                {
                    isAtAll = level > 0
                }
            };

            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(req);

            try
            {
                client.Execute(request);
            }
            catch { }

            return;
        }
    }
}