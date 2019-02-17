using Newtonsoft.Json;

namespace FcmConsoleDemo
{
    public class FCMMessage
    {
        [JsonProperty("to")]
        public string ReceiverDeviceKey { get; set; }

        //[JsonProperty("to")]
        public string ReceiverDeviceGroupKey { get; set; }

        [JsonProperty("topic")]
        public string TopicName { get; set; }

        [JsonProperty("notification")]
        public MessageBody Message{ get; set; }

        public class MessageBody
        {
            [JsonProperty("body")]
            public string Body { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("sound")]
            public string Sound { get; set; }

            [JsonProperty("click_action")]
            public string ClickAction { get; set; }
        }
    }
}