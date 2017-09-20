using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace TianCheng.Model
{
    /// <summary>
    /// MongoId 基础类型
    /// </summary>
    [BsonIgnoreExtraElements(Inherited = true)]
    public class MongoIdModel
    {
        /// <summary>
        /// ID
        /// </summary>
        [BsonElement("_id")]
        [JsonConverter(typeof(MongoObjectIdConverter))]
        [JsonProperty("id")]
        public ObjectId Id { get; set; }

        /// <summary>
        /// 判断对象是否为空对象
        /// </summary>
        public bool IsEmpty()
        {
            if (Id == null || String.IsNullOrEmpty(Id.ToString()) ||
                Id.Timestamp == 0 || Id.Machine == 0 || Id.Increment == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 设置对象ID为空
        /// </summary>
        public void SetEmptyId()
        {
            Id = MongoDB.Bson.ObjectId.Empty;
        }
    }
}
