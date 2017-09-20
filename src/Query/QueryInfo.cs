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
        /// 排序条件
        /// </summary>
        [JsonProperty("order")] 
        public string OrderBy { get; set; }


        private QueryPagination _Pagination = new QueryPagination();
        /// <summary>
        /// 分页信息
        /// </summary>
        [JsonProperty("pagination")]
        public QueryPagination Pagination { get { return _Pagination; } set { _Pagination = value; } }
    }
}
