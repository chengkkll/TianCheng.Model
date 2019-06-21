using MongoDB.Bson;
using Newtonsoft.Json;
using System;

namespace TianCheng.Model
{
    /// <summary>
    /// 设置Newtonsoft.Json 的JSon转换信息， 将MongoDB 的ObjectId与字符串相互转换
    /// </summary>
    class MongoObjectIdConverter : JsonConverter
    {
        /// <summary>
        /// 转成string
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }
        /// <summary>
        /// 转成ObjectId类型
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (ObjectId.TryParse(reader.Value.ToString(), out ObjectId id))
            {
                return id;
            }
            return ObjectId.Empty;
        }
        /// <summary>
        /// 判断是否可以转换
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(ObjectId).IsAssignableFrom(objectType);
        }
    }
}
