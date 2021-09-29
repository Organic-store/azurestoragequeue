using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace azurestoragequeue.Models
{
    public class complaints
    {
        [BsonId]
        public object _id { get; set; }

        [BsonElement("productname")]
        public string productname { get; set; }

        [BsonElement("count")]
        public int count { get; set; }

    }
}
