using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Config
    {
        /// <summary>
        /// websocket地址
        /// </summary>
        public string WebsocketHost { get; set; }
        /// <summary>
        /// websocket端口
        /// </summary>
        public int WebsocketPort { get; set; }
        /// <summary>
        /// 要登录的QQ号
        /// </summary>
        public uint QQ { get; set; }
        /// <summary>
        /// Mirai-Http-API的key
        /// </summary>
        public string authKey { get; set; }
        /// <summary>
        /// 消息转发的群号
        /// </summary>
        public List<int> Group { get; set; }
    }
    public class auth
    {
        public int code { get; set; }
        public string session { get; set; }
    }
    public class receive
    {
        public int code { get; set; }
        public string msg { get; set; }
        public string messageId { get; set; }
    }
    public class verify
    {
        public string sessionKey { get; set; }
        public uint qq { get; set; }
    }
    public class MessageChain
    {
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string text { get; set; }
    }

    public class Msg
    {
        /// <summary>
        /// 激活的sessionkey
        /// </summary>
        public string sessionKey { get; set; }
        /// <summary>
        /// 目标好友QQ号
        /// </summary>
        public uint target { get; set; }
        /// <summary>
        /// 引用一条消息的messageId进行回复
        /// </summary>
        public List<MessageChain> messageChain { get; set; }
    }
    public class recall
    {
        /// <summary>
        /// 已经激活的Session
        /// </summary>
        public string sessionKey { get; set; }
        /// <summary>
        /// 需要撤回的消息的messageId
        /// </summary>
        public int target { get; set; }
    }
    public class mute
    {
        /// <summary>
        /// 你的session key
        /// </summary>
        public string sessionKey { get; set; }
        /// <summary>
        /// 指定群的群号
        /// </summary>
        public uint target { get; set; }
        /// <summary>
        /// 指定群员QQ号
        /// </summary>
        public uint memberId { get; set; }
        /// <summary>
        /// 禁言时长，单位为秒，最多30天，默认为0
        /// </summary>
        public int time { get; set; }
    }

}
