using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TianCheng.Model
{
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
