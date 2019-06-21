using Newtonsoft.Json;

namespace TianCheng.Model
{
    /// <summary>
    /// 排序信息
    /// </summary>
    public class QuerySort
    {
        /// <summary>
        /// 排序属性
        /// </summary>
        [JsonProperty("prop")]
        public string Property { get; set; }

        /// <summary>
        /// 排序方向
        /// </summary>
        [JsonProperty("asc")]
        public bool IsAsc { get; set; }
    }
}
