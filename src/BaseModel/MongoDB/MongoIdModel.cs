using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace TianCheng.Model
{
    /// <summary>
    /// Id为MongoId类型的实体基类
    /// </summary>
    [BsonIgnoreExtraElements(Inherited = true)]
    public class MongoIdModel : IIdModel<ObjectId>
    {
        /// <summary>
        /// ID
        /// </summary>
        [BsonElement("_id")]
        [JsonConverter(typeof(MongoObjectIdConverter))]
        [JsonProperty("id")]
        public ObjectId Id { get; set; }

        /// <summary>
        /// 获取ID的字符串格式
        /// </summary>
        public string IdString
        {
            get
            {
                return Check(Id) ? Id.ToString() : string.Empty;
            }
        }

        /// <summary>
        /// 判断对象是否为空对象
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return !Check(Id);
            }
        }

        /// <summary>
        /// 设置对象ID为空
        /// </summary>
        public void SetEmpty()
        {
            Id = ObjectId.Empty;
        }

        /// <summary>
        /// 检查当前对象ID是否正确
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true正确ID   false不可用ID</returns>
        public bool CheckId(ObjectId id)
        {
            return Check(id);
        }

        /// <summary>
        /// 检查id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool Check(ObjectId id)
        {
            return !(id == null || id == ObjectId.Empty || string.IsNullOrEmpty(id.ToString()) || id.Timestamp == 0 || id.Machine == 0 || id.Increment == 0);
        }

        ///// <summary>
        ///// 将字符串转成ID
        ///// </summary>
        ///// <param name="strId"></param>
        ///// <returns></returns>
        //public ObjectId GetId(string strId)
        //{
        //    if (ObjectId.TryParse(strId, out ObjectId id))
        //    {
        //        return id;
        //    }
        //    return ObjectId.Empty;
        //}

        /// <summary>
        /// 设置对象ID，如果传入的ID无效，返回false
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public bool SetId(string strId)
        {
            // 检查ID是否有效
            if (!ObjectId.TryParse(strId, out ObjectId id))
            {
                return false;
            }
            if (!Check(id))
            {
                return false;
            }

            this.Id = id;
            return true;
        }
    }
}
