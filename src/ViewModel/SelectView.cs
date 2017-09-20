using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TianCheng.Model
{
    /// <summary>
    /// 用于给下拉列表显示数据的对象结构
    /// </summary>
    [BsonIgnoreExtraElements(Inherited = true)]
    public class SelectView
    {
        /// <summary>
        /// id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
