using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace azurestoragequeue.Models
{
    public class Messages
    {
        [BsonElement("username")]
        public string username { get; set; }
        [BsonElement("email")]
        public string email { get; set; }
        [BsonElement("subject")]
        public string subject { get; set; }
        [BsonElement("message")]
        public string message { get; set; }
        [BsonElement("productname")]
        public string productname { get; set; }
    }
}
