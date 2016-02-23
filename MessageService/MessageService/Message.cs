using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MessageService
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Text { get; set; }
    }
}