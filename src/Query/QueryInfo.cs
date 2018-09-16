using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TianCheng.Model
{
    /// <summary>
    /// 查询条件基类
    /// </summary>
    public class QueryInfo
    {
        /// <summary>
        /// 排序规则
        /// </summary>
        [JsonProperty("sort")]
        public QuerySort Sort { get; set; } = new QuerySort();

        /// <summary>
        /// 分页信息
        /// </summary>
        [JsonProperty("pagination")]
        public QueryPagination Pagination { get; set; } = new QueryPagination();
    }

 
}
