using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MiraiAPI
{
    public class MiraiAPI
    {
        public class Message
        {
            /// <summary>
            /// 发送好友消息
            /// </summary>
            /// <param name="text">要发送的文本</param>
            /// <param name="key">你的Session</param>
            /// <param name="host">Http服务器地址</param>
            /// <param name="port">Http服务器端口</param>
            /// <param name="qq">好友QQ号</param>
            public string sendFriendMessage(string host, int port, uint qq, string key, string text)
            {
                var m = new Data.MessageChain()
                {
                    type = "Plain",
                    text = text
                };
                var msg = new List<Data.MessageChain>();
                msg.Add(m);
                var messgae = new Data.Msg()
                {
                    sessionKey = key,
                    target = qq,
                    messageChain = msg
                };
                string newmsg = JsonConvert.SerializeObject(messgae);
                return HttpPost("http://" + host + ":" + port + "/sendFriendMessage", newmsg);
            }
            /// <summary>
            /// 发送群聊消息
            /// </summary>
            /// <param name="text">要发送的文本</param>
            /// <param name="key">你的Session</param>
            /// <param name="host">Http服务器地址</param>
            /// <param name="port">Http服务器端口</param>
            /// <param name="qq">好友QQ号</param>
            public string sendGroupMessage(string host, int port, uint groupqq, string key, string text)
            {
                var m = new Data.MessageChain()
                {
                    type = "Plain",
                    text = text
                };
                var msg = new List<Data.MessageChain>();
                msg.Add(m);
                var messgae = new Data.Msg()
                {
                    sessionKey = key,
                    target = groupqq,
                    messageChain = msg
                };
                string newmsg = JsonConvert.SerializeObject(messgae);
                return HttpPost("http://" + host + ":" + port + "/sendGroupMessage", newmsg);
            }
            /// <summary>
            /// 发送临时消息
            /// </summary>
            /// <param name="text">要发送的文本</param>
            /// <param name="key">你的Session</param>
            /// <param name="host">Http服务器地址</param>
            /// <param name="port">Http服务器端口</param>
            /// <param name="qq">好友QQ号</param>
            public string sendTempMessage(string host, int port, uint qq, string key, string text)
            {
                var m = new Data.MessageChain()
                {
                    type = "Plain",
                    text = text
                };
                var msg = new List<Data.MessageChain>();
                msg.Add(m);
                var messgae = new Data.Msg()
                {
                    sessionKey = key,
                    target = qq,
                    messageChain = msg
                };
                string newmsg = JsonConvert.SerializeObject(messgae);
                return HttpPost("http://" + host + ":" + port + "/sendTempMessage", newmsg);
            }
            /// <summary>
            /// 撤回消息
            /// </summary>
            /// <param name="text">要发送的文本</param>
            /// <param name="key">你的Session</param>
            /// <param name="host">Http服务器地址</param>
            /// <param name="port">Http服务器端口</param>
            /// <param name="msgid">需要撤回的信息ID</param>
            public string recall(string host, int port, string key, int msgid)
            {
                var a = new Data.recall()
                {
                    sessionKey = key,
                    target = msgid
                };
                string newmsg = JsonConvert.SerializeObject(a);
                return HttpPost("http://" + host + ":" + port + "/recall", newmsg);
            }
            /// <summary>
            /// 禁言某人
            /// </summary>
            /// <param name="key">你的Session</param>
            /// <param name="host">Http服务器地址</param>
            /// <param name="port">Http服务器端口</param>
            /// <param name="time">禁言时长</param>
            /// <param name="qq">禁言对象的QQ号</param>
            /// <param name="groupqq">禁言对象所在的群号</param>
            public string mute(string host, int port, string key, uint qq, uint groupqq, int time)
            {
                var a = new Data.mute()
                {
                    memberId = qq,
                    sessionKey = key,
                    target = groupqq,
                    time = time
                };
                string msg = JsonConvert.SerializeObject(a);
                return HttpPost("http://" + host + ":" + port + "/mute", msg);
            }
        }
        public static string HttpPost(string url, string body)
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json";
            byte[] buffer = encoding.GetBytes(body);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
        public static void Main()
        {
            //连接机器人需要自行实现
            //我封装好了一些事件的API
            //剩下的就尽情发挥想象吧
            var bot = new Message();          
        }
    }
}
